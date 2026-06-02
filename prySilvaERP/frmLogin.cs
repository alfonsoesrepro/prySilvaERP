using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using prySilvaERP.Conexion;
using System;

namespace prySilvaERP
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        int intentos = 0;

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña.", "Datos incompletos",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                intentos++;
                if (intentos == 3)
                {
                    Close();
                }
                txtUsuario.Focus();

                return;
            }

            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                "|DataDirectory|\\Conexion\\Silva.accdb;Persist Security Info=True";

            var conexion = new CConexion();
            if (!conexion.Conectar(connStr))
            {
                string err = conexion.ObtenerError();
                MessageBox.Show("Error al conectar a la base de datos: " + (string.IsNullOrWhiteSpace(err) ? "desconocido" : err), "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 1) Obtener el Id del usuario si las credenciales son correctas
                string sqlGetUserId = "SELECT Id_usuario FROM Usuario WHERE Mail = ? AND Contraseña = ?";
                int idUsuario = 0;
                using (OleDbCommand cmd = new OleDbCommand(sqlGetUserId, conexion.CNN))
                {
                    cmd.Parameters.AddWithValue("@p1", usuario);
                    cmd.Parameters.AddWithValue("@p2", contrasena);

                    object result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value || !int.TryParse(result.ToString(), out idUsuario))
                    {
                        // Credenciales incorrectas -> registrar intento (Fallido)
                        int filas = conexion.GrabarIntento(usuario, "Fallido", "-");
                        if (filas <= 0)
                        {
                            MessageBox.Show("No se pudo registrar intento en auditoría: " + conexion.ObtenerError(), "Error logging", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        intentos++;
                        if (intentos == 3)
                        {
                            conexion.Desconectar();
                            Close();
                        }
                        txtUsuario.Focus();
                        txtUsuario.Clear();
                        txtContrasena.Clear();
                        return;
                    }
                }

                // 2) Verificar que se haya seleccionado un perfil
                if (cmbPerfil.DataSource == null || cmbPerfil.SelectedValue == null)
                {
                    // Registrar intento fallido por perfil inválido/ausente
                    conexion.GrabarIntento(usuario, "Fallido", "-");

                    MessageBox.Show("Seleccione un perfil válido.", "Perfil no seleccionado",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPerfil = 0;
                if (!int.TryParse(cmbPerfil.SelectedValue.ToString(), out idPerfil))
                {
                    conexion.GrabarIntento(usuario, "Fallido", "-");

                    MessageBox.Show("Perfil seleccionado no válido.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3) Comprobar en la tabla de relación que el usuario tiene asignado ese perfil
                // NOTE: Ajuste el nombre de la tabla si en la BD se llama distinto. Aquí se usa "Relacion-usuario-perfil".
                string sqlCheckRelation = "SELECT COUNT(*) FROM [Relacion-usuario-perfil] WHERE Id_usuario = ? AND Id_perfil = ?";
                using (OleDbCommand cmdRel = new OleDbCommand(sqlCheckRelation, conexion.CNN))
                {
                    cmdRel.Parameters.AddWithValue("@p1", idUsuario);
                    cmdRel.Parameters.AddWithValue("@p2", idPerfil);

                    object relResult = cmdRel.ExecuteScalar();
                    int relCount = 0;
                    if (relResult != null && int.TryParse(relResult.ToString(), out relCount) && relCount > 0)
                    {
                        // Todo OK: registrar intento exitoso y abrir formulario correspondiente
                        int filasLog = conexion.GrabarIntento(usuario, "Exitoso", cmbPerfil.Text);
                        if (filasLog <= 0)
                        {
                            // no bloqueamos el acceso por fallo de logging, pero informamos en desarrollo
                            // MessageBox.Show("No se pudo registrar intento exitoso: " + conexion.ObtenerError(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        intentos = 0;

                        // Si el perfil elegido es "RR.HH." abrimos frmRRHH, en caso contrario frmMain
                        if (string.Equals(cmbPerfil.Text, "RR.HH.", StringComparison.OrdinalIgnoreCase))
                        {
                            this.Hide();
                            var rrhh = new frmRRHH();
                            rrhh.ShowDialog();
                            this.Show();
                            return;
                        }
                        else
                        {
                            this.Hide();
                            var main = new frmMain();
                            main.usuario = usuario;
                            main.perfil = cmbPerfil.Text; // nombre del perfil mostrado
                            main.ShowDialog();
                            this.Show();
                            return;
                        }
                    }
                    else
                    {
                        // Perfil no asignado -> registrar intento fallido
                        conexion.GrabarIntento(usuario, "Fallido", "-");

                        MessageBox.Show("El perfil seleccionado no está asignado a este usuario.", "Acceso denegado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        intentos++;
                        if (intentos == 3)
                        {
                            conexion.Desconectar();
                            Close();
                        }
                        txtUsuario.Focus();
                        txtUsuario.Clear();
                        txtContrasena.Clear();
                        return;
                    }
                }
            }
            catch (OleDbException ex)
            {
                // Si falla por nombre de tabla/columnas, informar el error para facilitar corrección
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Cargar perfiles desde la tabla Perfil y asignar DisplayMember / ValueMember
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                "|DataDirectory|\\Conexion\\Silva.accdb;Persist Security Info=True";

            var conexion = new CConexion();
            if (!conexion.Conectar(connStr))
            {
                string err = conexion.ObtenerError();
                MessageBox.Show("Error al conectar a la base de datos para cargar perfiles: " + (string.IsNullOrWhiteSpace(err) ? "desconocido" : err),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sql = "SELECT Id_perfil, Nombre FROM Perfil ORDER BY Nombre";
                using (OleDbCommand cmd = new OleDbCommand(sql, conexion.CNN))
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        cmbPerfil.DisplayMember = "Nombre";
                        cmbPerfil.ValueMember = "Id_perfil";
                        cmbPerfil.DataSource = dt;
                    }
                    else
                    {
                        cmbPerfil.DataSource = null;
                        cmbPerfil.Items.Clear();
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error al obtener perfiles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar perfiles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Desconectar();
            }
        }
    }
}