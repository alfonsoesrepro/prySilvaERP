using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySilvaERP.Conexion
{
    internal class CConexion
    {
        // propiedades de la clase
        public OleDbConnection CNN;
        public DataSet DS;
        public DataTable dtAuditoria;
        private OleDbDataAdapter da;
        private string ERROR = "";

        // constructor de la clase
        public CConexion()
        {
            CNN = null;
            DS = null;
            ERROR = "";
        }

        public bool Conectar(string Cadena)
        {
            bool resultado = false;
            CNN = new OleDbConnection();
            CNN.ConnectionString = Cadena;

            try
            {
                CNN.Open();
                DS = new DataSet();
                resultado = true;
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
            }

            return resultado;
        }

        public bool Desconectar()
        {
            bool resultado = false;

            try
            {
                if (CNN.State == ConnectionState.Open)
                {
                    CNN.Close();
                    resultado = true;
                }
            }
            catch (System.Exception ex)
            {
                ERROR = ex.Message;
            }

            return resultado;
        }

        public string ObtenerError()
        {
            return ERROR;
        }

        /// <summary>
        /// Registra un intento de inicio de sesión en la tabla [Auditoria-sesion].
        /// Columnas esperadas en la tabla:
        ///   Id (Autonumeración),
        ///   Usuario (Texto corto),
        ///   Fecha_Hora (Fecha/Hora),
        ///   [Estado del Login] (Texto corto) -> "Exitoso" / "Fallido",
        ///   [Opcion del sistema] (Texto corto) -> nombre del perfil o "-" si fallido.
        /// Requiere que la conexión `CNN` esté abierta.
        /// </summary>
        /// <param name="usuario">Nombre/identificador del usuario (puede estar vacío)</param>
        /// <param name="estadoLogin">"Exitoso" o "Fallido"</param>
        /// <param name="opcionSistema">Perfil al que ingresó el usuario o "-" si fallido</param>
        /// <returns>número de filas insertadas (1 esperado) o 0 en caso de error</returns>
        public int GrabarIntento(string usuario, string estadoLogin, string opcionSistema)
        {
            try
            {
                if (CNN == null || CNN.State != ConnectionState.Open)
                {
                    ERROR = "Conexión a la base de datos no abierta.";
                    return 0;
                }

                // Usamos nombres de columna entre corchetes por si contienen espacios o guiones
                string sql = "INSERT INTO [Auditoria-sesion] (Usuario, Fecha_Hora, [Estado del Login], [Opcion del sistema]) VALUES (?, ?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(sql, CNN))
                {
                    // Parametro 1: Usuario (Texto corto)
                    cmd.Parameters.Add("@p1", OleDbType.VarChar, 255).Value = string.IsNullOrEmpty(usuario) ? "" : usuario;
                    // Parametro 2: Fecha/Hora
                    cmd.Parameters.Add("@p2", OleDbType.Date).Value = DateTime.Now;
                    // Parametro 3: Estado del Login (Texto corto)
                    cmd.Parameters.Add("@p3", OleDbType.VarChar, 50).Value = string.IsNullOrEmpty(estadoLogin) ? "-" : estadoLogin;
                    // Parametro 4: Opcion del sistema (Texto corto)
                    cmd.Parameters.Add("@p4", OleDbType.VarChar, 255).Value = string.IsNullOrEmpty(opcionSistema) ? "-" : opcionSistema;

                    int filas = cmd.ExecuteNonQuery();
                    if (filas <= 0)
                    {
                        ERROR = "No se insertó ninguna fila. Revise la tabla/nombres de columnas.";
                    }
                    return filas;
                }
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
                return 0;
            }
        }
    }
}