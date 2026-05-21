using System;
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

namespace prySilvaERP
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña.", "Datos incompletos", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Silva.accdb";

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
                // Consulta parametrizada. Ajustar nombre de tabla/columnas si su BD usa otros nombres.
                string sql = "SELECT COUNT(*) FROM Usuario WHERE Mail = ? AND Contraseña = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, conexion.CNN))
                {
                    cmd.Parameters.AddWithValue("@p1", usuario);
                    cmd.Parameters.AddWithValue("@p2", contrasena);

                    object result = cmd.ExecuteScalar();
                    int count = 0;
                    if (result != null && int.TryParse(result.ToString(), out count) && count > 0)
                    {
                        // Credenciales correctas -> abrir formulario principal
                        var main = new frmMain();
                        main.Show();
                        this.Hide();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
