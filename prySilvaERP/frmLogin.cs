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
                string sqlGetUserId = "SELECT Id_usuario FROM Usuario WHERE Mail = ? AND Contrasena = ?";
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

                // 2) Obtener los perfiles asignados al usuario desde la tabla de relación
                string sqlGetPerfiles = "SELECT p.Id_perfil, p.Nombre FROM Perfil p INNER JOIN [Relacion-usuario-perfil] r ON p.Id_perfil = r.Id_perfil WHERE r.Id_usuario = ? ORDER BY p.Nombre";
                DataTable dtPerfiles = new DataTable();
                using (OleDbCommand cmdPerf = new OleDbCommand(sqlGetPerfiles, conexion.CNN))
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmdPerf))
                {
                    cmdPerf.Parameters.AddWithValue("@p1", idUsuario);
                    da.Fill(dtPerfiles);
                }

                // Si no hay perfiles, no bloqueamos el acceso; mostramos 'Sin perfil'
                string perfilDisplay;
                if (dtPerfiles.Rows.Count == 0)
                {
                    perfilDisplay = "Sin perfil";
                }
                else
                {
                    var nombres = new List<string>();
                    foreach (DataRow row in dtPerfiles.Rows)
                    {
                        nombres.Add(row["Nombre"].ToString());
                    }

                    perfilDisplay = string.Join(", ", nombres);
                }

                // Registrar intento exitoso usando los perfiles encontrados (o 'Sin perfil')
                int filasLog = conexion.GrabarIntento(usuario, "Exitoso", perfilDisplay);
                if (filasLog <= 0)
                {
                    // No bloquear el acceso por fallo de logging
                }

                intentos = 0;

                // Siempre abrir frmMain independientemente del perfil
                this.Hide();
                var main = new frmMain();
                main.usuario = usuario;
                main.perfil = perfilDisplay; // nombre(s) de perfiles o 'Sin perfil'
                main.ShowDialog();
                this.Show();
                return;
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
            CheckDbStatus();

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
                        /*cmbPerfil.DisplayMember = "Nombre";
                        cmbPerfil.ValueMember = "Id_perfil";
                        cmbPerfil.DataSource = dt;*/
                    }
                    else
                    {
                        /*cmbPerfil.DataSource = null;
                        cmbPerfil.Items.Clear();*/
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

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrar.Checked)
            {
                txtContrasena.UseSystemPasswordChar = false;
                txtContrasena.Focus();
            }
            else
            {
                txtContrasena.UseSystemPasswordChar = true;
                txtContrasena.Focus();
            }
        }

        private void CheckDbStatus()
        {
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                             "|DataDirectory|\\Conexion\\Silva.accdb;Persist Security Info=True";

            var conexion = new CConexion();
            bool conectado = conexion.Conectar(connStr);

            if (conectado)
            {
                lblEstado.ForeColor = Color.Green;
                lblEstado.Text = "Conexión establecida correctamente.";
            }
            else
            {
                lblEstado.ForeColor = Color.Red;
                string err = conexion.ObtenerError();
                lblEstado.Text = "Error de conexión: " + (string.IsNullOrWhiteSpace(err) ? "desconocido." : err);
            }

            conexion.Desconectar();
        }
    }
}