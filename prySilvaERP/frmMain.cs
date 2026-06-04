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
        private Timer _timerFechaHora;

        public frmMain()
        {
            InitializeComponent();
            this.Load += frmMain_Load;
        }

        public string usuario;
        public string perfil;

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Intentar leer la cadena de conexión desde <connectionStrings> en App.config
            string connStr = null;
            try
            {
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                "|DataDirectory|\\Conexion\\Silva.accdb;Persist Security Info=True";
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

        private void frmMain_Load_1(object sender, EventArgs e)
        {
            lblUsuario.Text = "Usuario: " + usuario;
            lblPerfil.Text = "Perfil: " + perfil;

            // Inicializar timer para actualizar fecha y hora
            _timerFechaHora = new Timer();
            _timerFechaHora.Interval = 1000; // 1 segundo
            _timerFechaHora.Tick += TimerFechaHora_Tick;

            // Primera actualización inmediata
            ActualizarFechaHora();

            _timerFechaHora.Start();

            // Auditoría ahora se muestra en el formulario frmAuditoria
        }

        private void TimerFechaHora_Tick(object sender, EventArgs e)
        {
            ActualizarFechaHora();
        }

        private void ActualizarFechaHora()
        {
            // Formato de fecha y hora en formato español
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_timerFechaHora != null)
            {
                _timerFechaHora.Stop();
                _timerFechaHora.Tick -= TimerFechaHora_Tick;
                _timerFechaHora.Dispose();
                _timerFechaHora = null;
            }

            base.OnFormClosing(e);
        }

        private void consultarAuditoriaAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuditoria x = new frmAuditoria();
            x.ShowDialog();
        }

        private void rRHHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRRHH x = new frmRRHH();
            x.ShowDialog();
        }

        private void cmdCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}