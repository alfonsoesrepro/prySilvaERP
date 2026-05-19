using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using prySilvaERP.Conexion;

namespace prySilvaERP
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.Load += frmMain_Load;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Intentar leer la cadena de conexión desde <connectionStrings> en App.config
            string connStr = null;
            try
            {
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                + Application.StartupPath + "\\Silva.accdb";
            }
            catch
            {
                connStr = null;
            }

            if (string.IsNullOrWhiteSpace(connStr))
            {
                // No hay cadena configurada => mostrar en rojo
                lblEstado.ForeColor = Color.Red;
                lblEstado.Text = "Cadena de conexión no configurada.";
                return;
            }

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

            // Cerrar si quedó abierta
            conexion.Desconectar();
        }
    }
}
