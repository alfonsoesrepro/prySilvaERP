using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prySilvaERP.Conexion;
using System.Data.OleDb;

namespace prySilvaERP
{
    public partial class frmAuditoria : Form
    {
        public frmAuditoria()
        {
            InitializeComponent();
            this.Load += frmAuditoria_Load;
            this.cmdAtras.Click += cmdAtras_Click;
        }

        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            CargarAuditoria();
        }

        private void cmdAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarAuditoria()
        {
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                             "|DataDirectory|\\Conexion\\Silva.accdb;Persist Security Info=True";

            var conexion = new CConexion();
            if (!conexion.Conectar(connStr))
            {
                MessageBox.Show("Error al cargar auditoría: " + conexion.ObtenerError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sql = "SELECT Id, Usuario, Fecha_Hora, [Estado del Login], [Opcion del sistema] FROM [Auditoria-sesion] ORDER BY Fecha_Hora DESC";
                using (OleDbCommand cmd = new OleDbCommand(sql, conexion.CNN))
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAuditoria.DataSource = dt;

                    if (dgvAuditoria.Columns.Contains("Fecha_Hora"))
                    {
                        dgvAuditoria.Columns["Fecha_Hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener auditoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        private void cmdAtras_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
