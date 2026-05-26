using prySilvaERP.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySilvaERP
{
    public partial class frmRRHH : Form
    {
        public frmRRHH()
        {
            InitializeComponent();
        }

        private void frmRRHH_Load(object sender, EventArgs e)
        {
            cmbRedes.SelectedIndex = 0;

            // Cargar localidades desde la tabla Localidades_cordoba2 y asignar DisplayMember / ValueMember
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                "|DataDirectory|\\Conexion\\Silva.accdb;Persist Security Info=True";

            var conexion = new CConexion();
            if (!conexion.Conectar(connStr))
            {
                string err = conexion.ObtenerError();
                MessageBox.Show("Error al conectar a la base de datos para cargar localidades: " + (string.IsNullOrWhiteSpace(err) ? "desconocido" : err),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sql = "SELECT Id, Localidad FROM Localidades_cordoba2 ORDER BY Localidad";
                using (OleDbCommand cmd = new OleDbCommand(sql, conexion.CNN))
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        cmbLocalidad.DisplayMember = "Localidad";
                        cmbLocalidad.ValueMember = "Id";
                        cmbLocalidad.DataSource = dt;
                    }
                    else
                    {
                        cmbLocalidad.DataSource = null;
                        cmbLocalidad.Items.Clear();
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error al obtener localidades: " + ex.Message, "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar localidades: " + ex.Message, "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Desconectar();
            }


            // Cargar provincias desde la tabla Provincias2 y asignar DisplayMember / ValueMember
            
            if (!conexion.Conectar(connStr))
            {
                string err = conexion.ObtenerError();
                MessageBox.Show("Error al conectar a la base de datos para cargar provincias: " + (string.IsNullOrWhiteSpace(err) ? "desconocido" : err),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sql = "SELECT Id, Provincia FROM Provincias2 ORDER BY Provincia";
                using (OleDbCommand cmd = new OleDbCommand(sql, conexion.CNN))
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        cmbProvincia.DisplayMember = "Provincia";
                        cmbProvincia.ValueMember = "Id";
                        cmbProvincia.DataSource = dt;
                    }
                    else
                    {
                        cmbProvincia.DataSource = null;
                        cmbProvincia.Items.Clear();
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error al obtener provincias: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar provincias: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Desconectar();
            }
        }
    }
}