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
using System.Data.OleDb;
using System;

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

            // Cargar auditoría en dgvAuditoria
            CargarAuditoria();
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

        private void CargarAuditoria()
        {
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                             "|DataDirectory|\\Conexion\\Silva.accdb;Persist Security Info=True";

            var conexion = new CConexion();
            if (!conexion.Conectar(connStr))
            {
                // Si hay error de conexión, dejamos el grid vacío y mostramos estado
                lblEstado.ForeColor = Color.Red;
                lblEstado.Text = "Error al cargar auditoría: " + conexion.ObtenerError();
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

                    // Opcional: formatear columna Fecha_Hora si existe
                    if (dgvAuditoria.Columns.Contains("Fecha_Hora"))
                    {
                        dgvAuditoria.Columns["Fecha_Hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    }
                }
            }
            catch (Exception ex)
            {
                lblEstado.ForeColor = Color.Red;
                lblEstado.Text = "Error al obtener auditoría: " + ex.Message;
            }
            finally
            {
                conexion.Desconectar();
            }
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

        private void cmdCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}