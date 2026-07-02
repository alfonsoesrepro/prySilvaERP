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
        
        // Guarda el estado original de cada control: posición, tamaño y tamaño de fuente
        private Dictionary<Control, Rectangle> tamañosOriginales = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> fuentesOriginales = new Dictionary<Control, float>();
        private float anchoFormularioOriginal;
        private float altoFormularioOriginal;
        private bool cargado = false; // <-- bandera de control

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


            // Acá el formulario todavía tiene el tamaño de diseño (chico)
            anchoFormularioOriginal = this.ClientSize.Width;
            altoFormularioOriginal = this.ClientSize.Height;

            tamañosOriginales.Clear();
            fuentesOriginales.Clear();

            foreach (Control control in this.Controls)
            {
                tamañosOriginales[control] = control.Bounds;
                fuentesOriginales[control] = control.Font.Size;
            }

            cargado = true;

            // Recién ahora maximizamos, lo cual va a disparar el Resize con los factores correctos
            this.WindowState = FormWindowState.Maximized;
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

            // Si es administrador permitir todo; si es RR.HH mostrar todas las opciones pero controlar acceso al hacer click
            // si no, permitir solo Sistema
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
                // Para usuarios de RR.HH permitimos que hagan click en los items (para mostrar el mensaje de acceso denegado)
                sistemaToolStripMenuItem.Enabled = true;
                consultarAuditoriaAdminToolStripMenuItem.Enabled = true;
                rRHHToolStripMenuItem.Enabled = true;
                finanzasToolStripMenuItem.Enabled = true;
                usuarioToolStripMenuItem.Enabled = true;
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
            // Sólo administradores pueden acceder a esta opción.
            if (_isRRHHUser || (perfil ?? string.Empty).IndexOf("Administrador", System.StringComparison.OrdinalIgnoreCase) < 0 &&
                (perfil ?? string.Empty).IndexOf("Admin", System.StringComparison.OrdinalIgnoreCase) < 0)
            {
                MessageBox.Show("Acceso denegado. Esta opción solo está disponible para usuarios Administradores.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

        private void finanzasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // En el diseño actual sólo administradores tienen acceso a Finanzas.
            if (_isRRHHUser || (perfil ?? string.Empty).IndexOf("Administrador", StringComparison.OrdinalIgnoreCase) < 0 &&
                (perfil ?? string.Empty).IndexOf("Admin", StringComparison.OrdinalIgnoreCase) < 0)
            {
                MessageBox.Show("Acceso denegado. No tiene permisos para acceder a Finanzas.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: abrir formulario de Finanzas cuando esté disponible
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // En el diseño actual sólo administradores tienen acceso a Usuario.
            if (_isRRHHUser || (perfil ?? string.Empty).IndexOf("Administrador", StringComparison.OrdinalIgnoreCase) < 0 &&
                (perfil ?? string.Empty).IndexOf("Admin", StringComparison.OrdinalIgnoreCase) < 0)
            {
                MessageBox.Show("Acceso denegado. No tiene permisos para acceder a Usuario.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: abrir formulario de Usuario cuando esté disponible
        }

        private void cmdCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatosDesarrollador x = new frmDatosDesarrollador();
            x.ShowDialog();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (!cargado) return; // evita que se ejecute antes de tiempo
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0) return;

            float factorX = this.ClientSize.Width / anchoFormularioOriginal;
            float factorY = this.ClientSize.Height / altoFormularioOriginal;

            foreach (Control control in this.Controls)
            {
                if (!tamañosOriginales.TryGetValue(control, out Rectangle original))
                    continue; // si por algún motivo no está, lo salteamos en vez de explotar

                control.Left = (int)(original.Left * factorX);
                control.Top = (int)(original.Top * factorY);
                control.Width = (int)(original.Width * factorX);
                control.Height = (int)(original.Height * factorY);

                float nuevaFuente = fuentesOriginales[control] * Math.Min(factorX, factorY);
                if (nuevaFuente > 1)
                    control.Font = new Font(control.Font.FontFamily, nuevaFuente, control.Font.Style);
            }
        }

        private void cmdAuditoria_Click(object sender, EventArgs e)
        {
            // Sólo administradores pueden acceder a esta opción.
            if (_isRRHHUser || (perfil ?? string.Empty).IndexOf("Administrador", System.StringComparison.OrdinalIgnoreCase) < 0 &&
                (perfil ?? string.Empty).IndexOf("Admin", System.StringComparison.OrdinalIgnoreCase) < 0)
            {
                MessageBox.Show("Acceso denegado. Esta opción solo está disponible para usuarios Administradores.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAuditoria x = new frmAuditoria();
            x.ShowDialog();
        }

        private void cmdRRHH_Click(object sender, EventArgs e)
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

        private void cmdFinanzas_Click(object sender, EventArgs e)
        {
            // En el diseño actual sólo administradores tienen acceso a Finanzas.
            if (_isRRHHUser || (perfil ?? string.Empty).IndexOf("Administrador", StringComparison.OrdinalIgnoreCase) < 0 &&
                (perfil ?? string.Empty).IndexOf("Admin", StringComparison.OrdinalIgnoreCase) < 0)
            {
                MessageBox.Show("Acceso denegado. No tiene permisos para acceder a Finanzas.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: abrir formulario de Finanzas cuando esté disponible
        }

        private void cmdUsuario_Click(object sender, EventArgs e)
        {
            // En el diseño actual sólo administradores tienen acceso a Usuario.
            if (_isRRHHUser || (perfil ?? string.Empty).IndexOf("Administrador", StringComparison.OrdinalIgnoreCase) < 0 &&
                (perfil ?? string.Empty).IndexOf("Admin", StringComparison.OrdinalIgnoreCase) < 0)
            {
                MessageBox.Show("Acceso denegado. No tiene permisos para acceder a Usuario.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: abrir formulario de Usuario cuando esté disponible
        }
    }
}