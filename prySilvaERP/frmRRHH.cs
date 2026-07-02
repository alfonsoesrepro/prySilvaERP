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
            this.Load += frmRRHH_Load;
        }

        private void frmRRHH_Load(object sender, EventArgs e)
        {
            CheckDbStatus();

            cmbRedesR.SelectedIndex = 0;
            cmbRedesM.SelectedIndex = 0;

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
                        cmbLocalidadR.DisplayMember = "Localidad";
                        cmbLocalidadR.ValueMember = "Id";
                        cmbLocalidadR.DataSource = dt;
                        cmbLocalidadM.DisplayMember = "Localidad";
                        cmbLocalidadM.ValueMember = "Id";
                        cmbLocalidadM.DataSource = dt.Copy();
                    }
                    else
                    {
                        cmbLocalidadR.DataSource = null;
                        cmbLocalidadR.Items.Clear();
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

            // Cargar datos en los DataGridViews: Usuario, Domicilio_usuario, Contacto_usuario
            var conexion2 = new CConexion();
            if (!conexion2.Conectar(connStr))
            {
                string err = conexion2.ObtenerError();
                MessageBox.Show("Error al conectar a la base de datos para cargar tablas: " + (string.IsNullOrWhiteSpace(err) ? "desconocido" : err),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Usuario
                try
                {
                    string sqlU = "SELECT * FROM Usuario";
                    using (OleDbCommand cmd = new OleDbCommand(sqlU, conexion2.CNN))
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvGeneral.DataSource = dt;

                        // Poblar cmbBuscar con DNI (Value = Id)
                        try
                        {
                            DataTable dtBuscar = dt.Copy();
                            cmbBuscar.DisplayMember = "DNI";
                            cmbBuscar.ValueMember = "Id";
                            cmbBuscar.DataSource = dtBuscar;
                        }
                        catch { }
                    }
                }
                catch (Exception exU)
                {
                    MessageBox.Show("No se pudieron cargar los usuarios: " + exU.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Domicilio_usuario
                try
                {
                    string sqlD = "SELECT * FROM Domicilio_usuario";
                    using (OleDbCommand cmd = new OleDbCommand(sqlD, conexion2.CNN))
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvDomicilios.DataSource = dt;
                    }
                }
                catch (Exception exD)
                {
                    MessageBox.Show("No se pudieron cargar los domicilios: " + exD.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Contacto_usuario
                try
                {
                    string sqlC = "SELECT * FROM Contacto_usuario";
                    using (OleDbCommand cmd = new OleDbCommand(sqlC, conexion2.CNN))
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvContactos.DataSource = dt;
                    }
                }
                catch (Exception exC)
                {
                    MessageBox.Show("No se pudieron cargar los contactos: " + exC.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                conexion2.Desconectar();
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
                        cmbProvinciaR.DisplayMember = "Provincia";
                        cmbProvinciaR.ValueMember = "Id";
                        cmbProvinciaR.DataSource = dt;
                        cmbProvinciaM.DisplayMember = "Provincia";
                        cmbProvinciaM.ValueMember = "Id";
                        cmbProvinciaM.DataSource = dt.Copy();
                    }
                    else
                    {
                        cmbProvinciaR.DataSource = null;
                        cmbProvinciaR.Items.Clear();
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

            // Cargar perfiles desde la tabla Perfil y asignar DisplayMember / ValueMember
            if (!conexion.Conectar(connStr))
            {
                string err = conexion.ObtenerError();
                MessageBox.Show("Error al conectar a la base de datos para cargar perfiles: " + (string.IsNullOrWhiteSpace(err) ? "desconocido" : err),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sqlPerfiles = "SELECT Id_perfil, Nombre FROM Perfil ORDER BY Nombre";
                using (OleDbCommand cmd = new OleDbCommand(sqlPerfiles, conexion.CNN))
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        cmbPerfilR.DisplayMember = "Nombre";
                        cmbPerfilR.ValueMember = "Id";
                        cmbPerfilR.DataSource = dt;
                        // Seleccionar el primer perfil por defecto (ej. "Administrador")
                        cmbPerfilR.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbPerfilR.DataSource = null;
                        cmbPerfilR.Items.Clear();
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error al obtener perfiles: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar perfiles: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        private void cmdAtrás_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckDbStatus()
        {
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                             "|DataDirectory|\\Conexion\\Silva.accdb;Persist Security Info=True";

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

            conexion.Desconectar();
        }

        private void tpRegistrar_Click(object sender, EventArgs e)
        {

        }

        private void cmbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscar.SelectedValue == null) return;
            int idUsuario = 0;
            if (!int.TryParse(cmbBuscar.SelectedValue.ToString(), out idUsuario)) return;

            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                "|DataDirectory|\\Conexion\\Silva.accdb;Persist Security Info=True";
            var conexion = new CConexion();
            if (!conexion.Conectar(connStr))
            {
                MessageBox.Show("Error al conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cargar datos de Usuario
                string sqlU = "SELECT * FROM Usuario WHERE Id = ?";
                using (OleDbCommand cmd = new OleDbCommand(sqlU, conexion.CNN))
                {
                    cmd.Parameters.Add("@p1", OleDbType.Integer).Value = idUsuario;
                    using (OleDbDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            txtNombreM.Text = rdr["Nombre"] != DBNull.Value ? rdr["Nombre"].ToString() : string.Empty;
                            txtApellidoM.Text = rdr["Apellido"] != DBNull.Value ? rdr["Apellido"].ToString() : string.Empty;
                            txtMailM.Text = rdr["Mail"] != DBNull.Value ? rdr["Mail"].ToString() : string.Empty;
                        }
                    }
                }

                // Cargar domicilio
                string sqlD = "SELECT * FROM Domicilio_usuario WHERE Id_usuario = ?";
                using (OleDbCommand cmd = new OleDbCommand(sqlD, conexion.CNN))
                {
                    cmd.Parameters.Add("@p1", OleDbType.Integer).Value = idUsuario;
                    using (OleDbDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            txtGeoM.Text = rdr["GPS"] != DBNull.Value ? rdr["GPS"].ToString() : string.Empty;
                            txtDireccionM.Text = rdr["Direccion"] != DBNull.Value ? rdr["Direccion"].ToString() : string.Empty;
                            string provincia = rdr["Provincia"] != DBNull.Value ? rdr["Provincia"].ToString() : string.Empty;
                            string localidad = rdr["Localidad"] != DBNull.Value ? rdr["Localidad"].ToString() : string.Empty;

                            // Seleccionar provincia por texto
                            try
                            {
                                for (int i = 0; i < cmbProvinciaM.Items.Count; i++)
                                {
                                    var drv = cmbProvinciaM.Items[i] as DataRowView;
                                    if (drv != null && drv["Provincia"].ToString().Equals(provincia, StringComparison.OrdinalIgnoreCase))
                                    {
                                        cmbProvinciaM.SelectedIndex = i;
                                        break;
                                    }
                                }
                            }
                            catch { }

                            try
                            {
                                for (int i = 0; i < cmbLocalidadM.Items.Count; i++)
                                {
                                    var drv = cmbLocalidadM.Items[i] as DataRowView;
                                    if (drv != null && drv["Localidad"].ToString().Equals(localidad, StringComparison.OrdinalIgnoreCase))
                                    {
                                        cmbLocalidadM.SelectedIndex = i;
                                        break;
                                    }
                                }
                            }
                            catch { }
                        }
                        else
                        {
                            txtGeoM.Text = string.Empty;
                            txtDireccionM.Text = string.Empty;
                            cmbProvinciaM.SelectedIndex = -1;
                            cmbLocalidadM.SelectedIndex = -1;
                        }
                    }
                }

                // Cargar contacto
                string sqlC = "SELECT * FROM Contacto_usuario WHERE Id_usuario = ?";
                using (OleDbCommand cmd = new OleDbCommand(sqlC, conexion.CNN))
                {
                    cmd.Parameters.Add("@p1", OleDbType.Integer).Value = idUsuario;
                    using (OleDbDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            txtTelefonoM.Text = rdr["Telefono"] != DBNull.Value ? rdr["Telefono"].ToString() : string.Empty;
                            int idRed = rdr["IdRedSocial"] != DBNull.Value ? Convert.ToInt32(rdr["IdRedSocial"]) : 0;
                            if (idRed > 0)
                            {
                                // Obtener nombre de la red
                                try
                                {
                                    using (OleDbCommand cmdRed = new OleDbCommand("SELECT Nombre FROM Red_social WHERE IdRedSocial = ?", conexion.CNN))
                                    {
                                        cmdRed.Parameters.Add("@p1", OleDbType.Integer).Value = idRed;
                                        object obj = cmdRed.ExecuteScalar();
                                        if (obj != null)
                                        {
                                            string nombreRed = obj.ToString();
                                            // Seleccionar en cmbRedesM si coincide con alguna de sus entradas
                                            for (int i = 0; i < cmbRedesM.Items.Count; i++)
                                            {
                                                if (cmbRedesM.Items[i].ToString().Equals(nombreRed, StringComparison.OrdinalIgnoreCase))
                                                {
                                                    cmbRedesM.SelectedIndex = i;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                catch { }
                            }
                            else
                            {
                                cmbRedesM.SelectedIndex = -1;
                            }
                        }
                        else
                        {
                            txtTelefonoM.Text = string.Empty;
                            cmbRedesM.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.SelectedValue == null) return;
            int idUsuario = 0;
            if (!int.TryParse(cmbBuscar.SelectedValue.ToString(), out idUsuario)) return;

            string nombre = txtNombreM.Text.Trim();
            string apellido = txtApellidoM.Text.Trim();
            string mail = txtMailM.Text.Trim();
            string telefono = txtTelefonoM.Text.Trim();
            string gps = txtGeoM.Text.Trim();
            string direccion = txtDireccionM.Text.Trim();
            string provincia = cmbProvinciaM.SelectedItem != null ? (cmbProvinciaM.SelectedItem as DataRowView)?["Provincia"].ToString() : string.Empty;
            string localidad = cmbLocalidadM.SelectedItem != null ? (cmbLocalidadM.SelectedItem as DataRowView)?["Localidad"].ToString() : string.Empty;
            string nombreRed = cmbRedesM.SelectedItem != null ? cmbRedesM.SelectedItem.ToString() : string.Empty;

            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                "|DataDirectory|\\Conexion\\Silva.accdb;Persist Security Info=True";
            var conexion = new CConexion();
            if (!conexion.Conectar(connStr))
            {
                MessageBox.Show("Error al conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Actualizar Usuario
                using (OleDbCommand cmd = new OleDbCommand("UPDATE Usuario SET Nombre = ?, Apellido = ?, Mail = ? WHERE Id = ?", conexion.CNN))
                {
                    cmd.Parameters.Add("@p1", OleDbType.VarChar, 255).Value = nombre;
                    cmd.Parameters.Add("@p2", OleDbType.VarChar, 255).Value = apellido;
                    cmd.Parameters.Add("@p3", OleDbType.VarChar, 255).Value = mail;
                    cmd.Parameters.Add("@p4", OleDbType.Integer).Value = idUsuario;
                    cmd.ExecuteNonQuery();
                }

                // Actualizar o insertar domicilio
                int countDom = 0;
                using (OleDbCommand cmdCount = new OleDbCommand("SELECT COUNT(*) FROM Domicilio_usuario WHERE Id_usuario = ?", conexion.CNN))
                {
                    cmdCount.Parameters.Add("@p1", OleDbType.Integer).Value = idUsuario;
                    object res = cmdCount.ExecuteScalar();
                    if (res != null) int.TryParse(res.ToString(), out countDom);
                }

                if (countDom > 0)
                {
                    using (OleDbCommand cmd = new OleDbCommand("UPDATE Domicilio_usuario SET GPS = ?, Provincia = ?, Localidad = ?, Direccion = ? WHERE Id_usuario = ?", conexion.CNN))
                    {
                        cmd.Parameters.Add("@p1", OleDbType.VarChar, 255).Value = gps;
                        cmd.Parameters.Add("@p2", OleDbType.VarChar, 255).Value = provincia;
                        cmd.Parameters.Add("@p3", OleDbType.VarChar, 255).Value = localidad;
                        cmd.Parameters.Add("@p4", OleDbType.VarChar, 255).Value = direccion;
                        cmd.Parameters.Add("@p5", OleDbType.Integer).Value = idUsuario;
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (OleDbCommand cmd = new OleDbCommand("INSERT INTO Domicilio_usuario (Id_usuario, GPS, Provincia, Localidad, Direccion) VALUES (?, ?, ?, ?, ?)", conexion.CNN))
                    {
                        cmd.Parameters.Add("@p1", OleDbType.Integer).Value = idUsuario;
                        cmd.Parameters.Add("@p2", OleDbType.VarChar, 255).Value = gps;
                        cmd.Parameters.Add("@p3", OleDbType.VarChar, 255).Value = provincia;
                        cmd.Parameters.Add("@p4", OleDbType.VarChar, 255).Value = localidad;
                        cmd.Parameters.Add("@p5", OleDbType.VarChar, 255).Value = direccion;
                        cmd.ExecuteNonQuery();
                    }
                }

                // Gestionar red social y contacto
                int idRedSocial = 0;
                if (!string.IsNullOrWhiteSpace(nombreRed))
                {
                    using (OleDbCommand cmdFind = new OleDbCommand("SELECT IdRedSocial FROM Red_social WHERE Nombre = ?", conexion.CNN))
                    {
                        cmdFind.Parameters.Add("@p1", OleDbType.VarChar, 255).Value = nombreRed;
                        object obj = cmdFind.ExecuteScalar();
                        if (obj != null && int.TryParse(obj.ToString(), out idRedSocial) && idRedSocial > 0)
                        {
                        }
                        else
                        {
                            using (OleDbCommand cmdIns = new OleDbCommand("INSERT INTO Red_social (Nombre) VALUES (?)", conexion.CNN))
                            {
                                cmdIns.Parameters.Add("@p1", OleDbType.VarChar, 255).Value = nombreRed;
                                cmdIns.ExecuteNonQuery();
                            }
                            using (OleDbCommand cmdId = new OleDbCommand("SELECT @@IDENTITY", conexion.CNN))
                            {
                                object idObj = cmdId.ExecuteScalar();
                                if (idObj != null) idRedSocial = Convert.ToInt32(idObj);
                            }
                        }
                    }
                }

                int countCont = 0;
                using (OleDbCommand cmdCount = new OleDbCommand("SELECT COUNT(*) FROM Contacto_usuario WHERE Id_usuario = ?", conexion.CNN))
                {
                    cmdCount.Parameters.Add("@p1", OleDbType.Integer).Value = idUsuario;
                    object res = cmdCount.ExecuteScalar();
                    if (res != null) int.TryParse(res.ToString(), out countCont);
                }

                if (countCont > 0)
                {
                    using (OleDbCommand cmd = new OleDbCommand("UPDATE Contacto_usuario SET Telefono = ?, IdRedSocial = ? WHERE Id_usuario = ?", conexion.CNN))
                    {
                        cmd.Parameters.Add("@p1", OleDbType.VarChar, 50).Value = telefono;
                        if (idRedSocial > 0)
                            cmd.Parameters.Add("@p2", OleDbType.Integer).Value = idRedSocial;
                        else
                            cmd.Parameters.Add("@p2", OleDbType.Integer).Value = DBNull.Value;
                        cmd.Parameters.Add("@p3", OleDbType.Integer).Value = idUsuario;
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (OleDbCommand cmd = new OleDbCommand("INSERT INTO Contacto_usuario (Id_usuario, Telefono, IdRedSocial) VALUES (?, ?, ?)", conexion.CNN))
                    {
                        cmd.Parameters.Add("@p1", OleDbType.Integer).Value = idUsuario;
                        cmd.Parameters.Add("@p2", OleDbType.VarChar, 50).Value = telefono;
                        if (idRedSocial > 0)
                            cmd.Parameters.Add("@p3", OleDbType.Integer).Value = idRedSocial;
                        else
                            cmd.Parameters.Add("@p3", OleDbType.Integer).Value = DBNull.Value;
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario modificado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Refrescar DataGridViews para mostrar los cambios
                try
                {
                    RefreshDataGrids();
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        private void RefreshDataGrids()
        {
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                "|DataDirectory|\\Conexion\\Silva.accdb;Persist Security Info=True";

            var conexion = new CConexion();
            if (!conexion.Conectar(connStr))
            {
                string err = conexion.ObtenerError();
                MessageBox.Show("Error al conectar a la base de datos para refrescar tablas: " + (string.IsNullOrWhiteSpace(err) ? "desconocido" : err),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Usuario
                try
                {
                    string sqlU = "SELECT * FROM Usuario";
                    using (OleDbCommand cmd = new OleDbCommand(sqlU, conexion.CNN))
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvGeneral.DataSource = dt;
                    }
                }
                catch (Exception exU)
                {
                    MessageBox.Show("No se pudieron cargar los usuarios: " + exU.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Domicilio_usuario
                try
                {
                    string sqlD = "SELECT * FROM Domicilio_usuario";
                    using (OleDbCommand cmd = new OleDbCommand(sqlD, conexion.CNN))
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvDomicilios.DataSource = dt;
                    }
                }
                catch (Exception exD)
                {
                    MessageBox.Show("No se pudieron cargar los domicilios: " + exD.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Contacto_usuario
                try
                {
                    string sqlC = "SELECT * FROM Contacto_usuario";
                    using (OleDbCommand cmd = new OleDbCommand(sqlC, conexion.CNN))
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvContactos.DataSource = dt;
                    }
                }
                catch (Exception exC)
                {
                    MessageBox.Show("No se pudieron cargar los contactos: " + exC.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            // Validaciones mínimas
            string nombre = txtNombreR.Text.Trim();
            string apellido = txtApellidoR.Text.Trim();
            string mail = txtMailR.Text.Trim();
            string contrasena = txtContrasenaR.Text.Trim();
            string dni = txtDniR.Text.Trim();
            bool activo = chkActivo.Checked;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(mail))
            {
                MessageBox.Show("Por favor complete Nombre, Apellido y Mail.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                "|DataDirectory|\\Conexion\\Silva.accdb;Persist Security Info=True";

            var conexion = new CConexion();
            if (!conexion.Conectar(connStr))
            {
                string err = conexion.ObtenerError();
                MessageBox.Show("Error al conectar a la base de datos: " + (string.IsNullOrWhiteSpace(err) ? "desconocido" : err),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Comprobar duplicados por DNI (si se ingresó) y Mail
                if (!string.IsNullOrWhiteSpace(dni))
                {
                    string sqlCheckDni = "SELECT COUNT(*) FROM Usuario WHERE DNI = ?";
                    using (OleDbCommand cmdCheck = new OleDbCommand(sqlCheckDni, conexion.CNN))
                    {
                        cmdCheck.Parameters.Add("@p1", OleDbType.VarChar, 50).Value = dni;
                        object res = cmdCheck.ExecuteScalar();
                        int count = 0;
                        if (res != null && int.TryParse(res.ToString(), out count) && count > 0)
                        {
                            MessageBox.Show("Ya existe un usuario con el mismo DNI.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(mail))
                {
                    string sqlCheckMail = "SELECT COUNT(*) FROM Usuario WHERE Mail = ?";
                    using (OleDbCommand cmdCheck = new OleDbCommand(sqlCheckMail, conexion.CNN))
                    {
                        cmdCheck.Parameters.Add("@p1", OleDbType.VarChar, 255).Value = mail;
                        object res = cmdCheck.ExecuteScalar();
                        int count = 0;
                        if (res != null && int.TryParse(res.ToString(), out count) && count > 0)
                        {
                            MessageBox.Show("Ya existe un usuario con el mismo Mail.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                string sql = "INSERT INTO Usuario (Nombre, Apellido, Mail, Contrasena, DNI, Activo) VALUES (?, ?, ?, ?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(sql, conexion.CNN))
                {
                    cmd.Parameters.Add("@p1", OleDbType.VarChar, 255).Value = nombre;
                    cmd.Parameters.Add("@p2", OleDbType.VarChar, 255).Value = apellido;
                    cmd.Parameters.Add("@p3", OleDbType.VarChar, 255).Value = mail;
                    cmd.Parameters.Add("@p4", OleDbType.VarChar, 255).Value = contrasena;
                    cmd.Parameters.Add("@p5", OleDbType.VarChar, 50).Value = dni;
                    cmd.Parameters.Add("@p6", OleDbType.Boolean).Value = activo;

                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        // Obtener Id recién insertado en Access
                        int nuevoIdUsuario = -1;
                        try
                        {
                            using (OleDbCommand cmdId = new OleDbCommand("SELECT @@IDENTITY", conexion.CNN))
                            {
                                object idObj = cmdId.ExecuteScalar();
                                if (idObj != null)
                                {
                                    // @@IDENTITY puede devolver decimal en OleDb
                                    nuevoIdUsuario = Convert.ToInt32(idObj);
                                }
                            }
                        }
                        catch
                        {
                            // Si falla la obtención del ID, continuar sin relación
                            nuevoIdUsuario = -1;
                        }

                        // Insertar relación Usuario-Perfil si hay perfil seleccionado y obtuvimos el Id de usuario
                        try
                        {
                            if (nuevoIdUsuario > 0 && cmbPerfilR != null && cmbPerfilR.SelectedValue != null)
                            {
                                int idPerfil = 0;
                                try
                                {
                                    idPerfil = Convert.ToInt32(cmbPerfilR.SelectedValue);
                                }
                                catch { idPerfil = 0; }

                                if (idPerfil > 0)
                                {
                                    string sqlRel = "INSERT INTO [Relacion-usuario-perfil] (Id_usuario, Id_perfil) VALUES (?, ?)";
                                    using (OleDbCommand cmdRel = new OleDbCommand(sqlRel, conexion.CNN))
                                    {
                                        cmdRel.Parameters.Add("@p1", OleDbType.Integer).Value = nuevoIdUsuario;
                                        cmdRel.Parameters.Add("@p2", OleDbType.Integer).Value = idPerfil;
                                        cmdRel.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        catch (Exception exRel)
                        {
                            // No interrumpir el flujo principal si la relación falla; informar al usuario
                            MessageBox.Show("Empleado registrado pero no se pudo guardar la relación con el perfil: " + exRel.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // Insertar domicilio del usuario en Domicilio_usuario
                        try
                        {
                            if (nuevoIdUsuario > 0)
                            {
                                string gps = txtGeoR != null ? txtGeoR.Text.Trim() : string.Empty;
                                string direccion = txtDireccionR != null ? txtDireccionR.Text.Trim() : string.Empty;
                                string provincia = (cmbProvinciaR != null && cmbProvinciaR.SelectedItem != null) ? cmbProvinciaR.Text : string.Empty;
                                string localidad = (cmbLocalidadR != null && cmbLocalidadR.SelectedItem != null) ? cmbLocalidadR.Text : string.Empty;

                                string sqlDom = "INSERT INTO Domicilio_usuario (Id_usuario, GPS, Provincia, Localidad, Direccion) VALUES (?, ?, ?, ?, ?)";
                                using (OleDbCommand cmdDom = new OleDbCommand(sqlDom, conexion.CNN))
                                {
                                    cmdDom.Parameters.Add("@p1", OleDbType.Integer).Value = nuevoIdUsuario;
                                    cmdDom.Parameters.Add("@p2", OleDbType.VarChar, 255).Value = string.IsNullOrEmpty(gps) ? "" : gps;
                                    cmdDom.Parameters.Add("@p3", OleDbType.VarChar, 255).Value = provincia;
                                    cmdDom.Parameters.Add("@p4", OleDbType.VarChar, 255).Value = localidad;
                                    cmdDom.Parameters.Add("@p5", OleDbType.VarChar, 255).Value = direccion;

                                    cmdDom.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (Exception exDom)
                        {
                            MessageBox.Show("Empleado registrado pero no se pudo guardar el domicilio: " + exDom.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // Insertar contacto del usuario en Contacto_usuario y asegurar que exista la red social en Red_social
                        try
                        {
                            if (nuevoIdUsuario > 0)
                            {
                                string telefono = txtTelefonoR != null ? txtTelefonoR.Text.Trim() : string.Empty;
                                string redesValor = txtRedesR != null ? txtRedesR.Text.Trim() : string.Empty; // valor/alias en la red
                                string nombreRed = (cmbRedesR != null && cmbRedesR.SelectedItem != null) ? cmbRedesR.Text : string.Empty;

                                int idRedSocial = 0;
                                if (!string.IsNullOrWhiteSpace(nombreRed))
                                {
                                    // Buscar si la red social ya existe
                                    string sqlFind = "SELECT IdRedSocial FROM Red_social WHERE Nombre = ?";
                                    using (OleDbCommand cmdFind = new OleDbCommand(sqlFind, conexion.CNN))
                                    {
                                        cmdFind.Parameters.Add("@p1", OleDbType.VarChar, 255).Value = nombreRed;
                                        object obj = cmdFind.ExecuteScalar();
                                        if (obj != null && int.TryParse(obj.ToString(), out idRedSocial) && idRedSocial > 0)
                                        {
                                            // encontrada
                                        }
                                        else
                                        {
                                            // Insertar nueva red social
                                            string sqlInsRed = "INSERT INTO Red_social (Nombre) VALUES (?)";
                                            using (OleDbCommand cmdInsRed = new OleDbCommand(sqlInsRed, conexion.CNN))
                                            {
                                                cmdInsRed.Parameters.Add("@p1", OleDbType.VarChar, 255).Value = nombreRed;
                                                cmdInsRed.ExecuteNonQuery();
                                            }
                                            // Obtener id
                                            using (OleDbCommand cmdIdRed = new OleDbCommand("SELECT @@IDENTITY", conexion.CNN))
                                            {
                                                object idObj = cmdIdRed.ExecuteScalar();
                                                if (idObj != null) idRedSocial = Convert.ToInt32(idObj);
                                            }
                                        }
                                    }
                                }

                                // Insertar en Contacto_usuario: Id_usuario, Telefono, IdRedSocial
                                string sqlContacto = "INSERT INTO Contacto_usuario (Id_usuario, Telefono, IdRedSocial) VALUES (?, ?, ?)";
                                using (OleDbCommand cmdContacto = new OleDbCommand(sqlContacto, conexion.CNN))
                                {
                                    cmdContacto.Parameters.Add("@p1", OleDbType.Integer).Value = nuevoIdUsuario;
                                    cmdContacto.Parameters.Add("@p2", OleDbType.VarChar, 50).Value = telefono;
                                    if (idRedSocial > 0)
                                        cmdContacto.Parameters.Add("@p3", OleDbType.Integer).Value = idRedSocial;
                                    else
                                        cmdContacto.Parameters.Add("@p3", OleDbType.Integer).Value = DBNull.Value;

                                    cmdContacto.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (Exception exCont)
                        {
                            MessageBox.Show("Empleado registrado pero no se pudo guardar el contacto: " + exCont.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        MessageBox.Show("Empleado registrado correctamente.", "Registro OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Limpiar campos
                        txtNombreR.Text = string.Empty;
                        txtApellidoR.Text = string.Empty;
                        txtMailR.Text = string.Empty;
                        txtContrasenaR.Text = string.Empty;
                        txtDniR.Text = string.Empty;
                        chkActivo.Checked = false;
                        if (cmbPerfilR != null && cmbPerfilR.Items.Count > 0) cmbPerfilR.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error al insertar en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        private void lblUsuarioRed_Click(object sender, EventArgs e)
        {

        }
    }
}