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
        /// Registra un intento fallido de inicio de sesión en la tabla [Auditoria-sesion].
        /// La tabla debe tener columnas: Id (Autonumeración), Usuario (Texto corto), Fecha_Hora (Fecha/Hora).
        /// Requiere que la conexión `CNN` esté abierta.
        /// </summary>
        /// <param name="usuario">Nombre/identificador del usuario (puede estar vacío)</param>
        /// <returns>true si el registro se grabó correctamente; false en caso contrario (ERROR queda con el mensaje)</returns>
        public int GrabarIntentoFallido(string usuario)
        {
            try
            {
                if (CNN == null || CNN.State != ConnectionState.Open)
                {
                    ERROR = "Conexión a la base de datos no abierta.";
                    return 0;
                }

                string sql = "INSERT INTO [Auditoria-sesion] (Usuario, Fecha_Hora) VALUES (?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(sql, CNN))
                {
                    // Parametro 1: texto corto (ajusta la longitud si hace falta)
                    cmd.Parameters.Add("@p1", OleDbType.VarChar, 255).Value = string.IsNullOrEmpty(usuario) ? "" : usuario;
                    // Parametro 2: fecha/hora
                    cmd.Parameters.Add("@p2", OleDbType.Date).Value = DateTime.Now;

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