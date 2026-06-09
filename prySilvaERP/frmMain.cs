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
        private bool _isRRHHUser = false;

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

            // Determinar si el usuario tiene perfil RR.HH. o Administrador.
            _isRRHHUser = false;
            bool isAdmin = false;
            if (!string.IsNullOrWhiteSpace(perfil))
            {
                // perfil puede ser una lista separada por comas
                var tokens = perfil.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(t => t.Trim()).ToList();
                foreach (var t in tokens)
                {
                    var normalized = t.Replace(".", string.Empty).Replace(" ", string.Empty);
                    if (string.Equals(normalized, "RRHH", StringComparison.OrdinalIgnoreCase))
                    {
                        _isRRHHUser = true;
                    }
                    if (string.Equals(t, "Administrador", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(t, "Admin", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(normalized, "ADMIN", StringComparison.OrdinalIgnoreCase))
                    {
                        isAdmin = true;
                    }
                }
            }

            // Si es administrador permitir todo; si es RR.HH solo permitir Sistema + RR.HH; si no, permitir solo Sistema
            if (isAdmin)
            {
                sistemaToolStripMenuItem.Enabled = true;
                consultarAuditoriaAdminToolStripMenuItem.Enabled = true;
                rRHHToolStripMenuItem.Enabled = true;
                finanzasToolStripMenuItem.Enabled = true;
                usuarioToolStripMenuItem.Enabled = true;
            }
            else if (_isRRHHUser)
            {
                sistemaToolStripMenuItem.Enabled = true;
                consultarAuditoriaAdminToolStripMenuItem.Enabled = false;
                rRHHToolStripMenuItem.Enabled = true;
                finanzasToolStripMenuItem.Enabled = false;
                usuarioToolStripMenuItem.Enabled = false;
            }
            else
            {
                // Usuario normal: solo Sistema (y elementos que contenga Sistema)
                sistemaToolStripMenuItem.Enabled = true;
                consultarAuditoriaAdminToolStripMenuItem.Enabled = false;
                rRHHToolStripMenuItem.Enabled = false;
                finanzasToolStripMenuItem.Enabled = false;
                usuarioToolStripMenuItem.Enabled = false;
            }

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
            // Permitir acceso solo si el usuario tiene perfil RR.HH. o es administrador.
            if (!(_isRRHHUser || (perfil ?? string.Empty).IndexOf("Administrador", StringComparison.OrdinalIgnoreCase) >= 0 ||
                  (perfil ?? string.Empty).IndexOf("Admin", StringComparison.OrdinalIgnoreCase) >= 0))
            {
                MessageBox.Show("Acceso denegado. Esta opción solo está disponible para usuarios con perfil RR.HH.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmRRHH x = new frmRRHH();
            x.ShowDialog();
        }

        private void cmdCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}