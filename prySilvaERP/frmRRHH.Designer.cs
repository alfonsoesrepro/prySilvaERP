namespace prySilvaERP
{
    partial class frmRRHH
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRRHH));
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.gbDomicilio = new System.Windows.Forms.GroupBox();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.txtGeo = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblGeo = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.gbContacto = new System.Windows.Forms.GroupBox();
            this.txtRedes = new System.Windows.Forms.TextBox();
            this.cmbRedes = new System.Windows.Forms.ComboBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.lblRedes = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.tcRRHH = new System.Windows.Forms.TabControl();
            this.tpDatosPersonales = new System.Windows.Forms.TabPage();
            this.tpDomicilio = new System.Windows.Forms.TabPage();
            this.tpContacto = new System.Windows.Forms.TabPage();
            this.tpActivacion = new System.Windows.Forms.TabPage();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.gbDomicilio.SuspendLayout();
            this.gbContacto.SuspendLayout();
            this.tcRRHH.SuspendLayout();
            this.tpDatosPersonales.SuspendLayout();
            this.tpDomicilio.SuspendLayout();
            this.tpContacto.SuspendLayout();
            this.tpActivacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(30, 56);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(26, 13);
            this.lblDNI.TabIndex = 0;
            this.lblDNI.Text = "DNI";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(30, 88);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(30, 121);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // txtDNI
            // 
            this.txtDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDNI.Location = new System.Drawing.Point(139, 53);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Location = new System.Drawing.Point(139, 86);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Location = new System.Drawing.Point(139, 119);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // gbDomicilio
            // 
            this.gbDomicilio.Controls.Add(this.cmbProvincia);
            this.gbDomicilio.Controls.Add(this.lblProvincia);
            this.gbDomicilio.Controls.Add(this.cmbLocalidad);
            this.gbDomicilio.Controls.Add(this.txtGeo);
            this.gbDomicilio.Controls.Add(this.txtDireccion);
            this.gbDomicilio.Controls.Add(this.lblLocalidad);
            this.gbDomicilio.Controls.Add(this.lblGeo);
            this.gbDomicilio.Controls.Add(this.lblDireccion);
            this.gbDomicilio.Location = new System.Drawing.Point(46, 9);
            this.gbDomicilio.Name = "gbDomicilio";
            this.gbDomicilio.Size = new System.Drawing.Size(200, 185);
            this.gbDomicilio.TabIndex = 6;
            this.gbDomicilio.TabStop = false;
            this.gbDomicilio.Text = "Domicilio";
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(106, 141);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(73, 21);
            this.cmbProvincia.TabIndex = 7;
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(12, 144);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(51, 13);
            this.lblProvincia.TabIndex = 6;
            this.lblProvincia.Text = "Provincia";
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(106, 103);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(73, 21);
            this.cmbLocalidad.TabIndex = 5;
            // 
            // txtGeo
            // 
            this.txtGeo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGeo.Location = new System.Drawing.Point(79, 68);
            this.txtGeo.Name = "txtGeo";
            this.txtGeo.Size = new System.Drawing.Size(100, 20);
            this.txtGeo.TabIndex = 4;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Location = new System.Drawing.Point(79, 33);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 3;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(12, 106);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(53, 13);
            this.lblLocalidad.TabIndex = 2;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lblGeo
            // 
            this.lblGeo.AutoSize = true;
            this.lblGeo.Location = new System.Drawing.Point(12, 70);
            this.lblGeo.Name = "lblGeo";
            this.lblGeo.Size = new System.Drawing.Size(27, 13);
            this.lblGeo.TabIndex = 1;
            this.lblGeo.Text = "Geo";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(12, 35);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 0;
            this.lblDireccion.Text = "Dirección";
            // 
            // gbContacto
            // 
            this.gbContacto.Controls.Add(this.txtRedes);
            this.gbContacto.Controls.Add(this.cmbRedes);
            this.gbContacto.Controls.Add(this.textBox6);
            this.gbContacto.Controls.Add(this.textBox7);
            this.gbContacto.Controls.Add(this.lblRedes);
            this.gbContacto.Controls.Add(this.lblTelefono);
            this.gbContacto.Controls.Add(this.lblMail);
            this.gbContacto.Location = new System.Drawing.Point(46, 9);
            this.gbContacto.Name = "gbContacto";
            this.gbContacto.Size = new System.Drawing.Size(200, 188);
            this.gbContacto.TabIndex = 7;
            this.gbContacto.TabStop = false;
            this.gbContacto.Text = "Contacto";
            // 
            // txtRedes
            // 
            this.txtRedes.Location = new System.Drawing.Point(79, 141);
            this.txtRedes.Name = "txtRedes";
            this.txtRedes.Size = new System.Drawing.Size(100, 20);
            this.txtRedes.TabIndex = 9;
            // 
            // cmbRedes
            // 
            this.cmbRedes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRedes.FormattingEnabled = true;
            this.cmbRedes.Items.AddRange(new object[] {
            "Facebook",
            "Instagram",
            "X",
            "Telegram",
            "Tiktok"});
            this.cmbRedes.Location = new System.Drawing.Point(106, 104);
            this.cmbRedes.Name = "cmbRedes";
            this.cmbRedes.Size = new System.Drawing.Size(73, 21);
            this.cmbRedes.TabIndex = 7;
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Location = new System.Drawing.Point(79, 68);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 4;
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.Location = new System.Drawing.Point(79, 31);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 3;
            // 
            // lblRedes
            // 
            this.lblRedes.AutoSize = true;
            this.lblRedes.Location = new System.Drawing.Point(12, 107);
            this.lblRedes.Name = "lblRedes";
            this.lblRedes.Size = new System.Drawing.Size(79, 13);
            this.lblRedes.TabIndex = 2;
            this.lblRedes.Text = "Redes sociales";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(12, 70);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 1;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(12, 33);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(26, 13);
            this.lblMail.TabIndex = 0;
            this.lblMail.Text = "Mail";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.ForeColor = System.Drawing.Color.Green;
            this.chkActivo.Location = new System.Drawing.Point(196, 92);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 8;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // tcRRHH
            // 
            this.tcRRHH.Controls.Add(this.tpDatosPersonales);
            this.tcRRHH.Controls.Add(this.tpDomicilio);
            this.tcRRHH.Controls.Add(this.tpContacto);
            this.tcRRHH.Controls.Add(this.tpActivacion);
            this.tcRRHH.Location = new System.Drawing.Point(1, 0);
            this.tcRRHH.Name = "tcRRHH";
            this.tcRRHH.SelectedIndex = 0;
            this.tcRRHH.Size = new System.Drawing.Size(298, 229);
            this.tcRRHH.TabIndex = 8;
            this.tcRRHH.Tag = "";
            // 
            // tpDatosPersonales
            // 
            this.tpDatosPersonales.Controls.Add(this.txtApellido);
            this.tpDatosPersonales.Controls.Add(this.lblDNI);
            this.tpDatosPersonales.Controls.Add(this.lblApellido);
            this.tpDatosPersonales.Controls.Add(this.lblNombre);
            this.tpDatosPersonales.Controls.Add(this.txtNombre);
            this.tpDatosPersonales.Controls.Add(this.txtDNI);
            this.tpDatosPersonales.Location = new System.Drawing.Point(4, 22);
            this.tpDatosPersonales.Name = "tpDatosPersonales";
            this.tpDatosPersonales.Padding = new System.Windows.Forms.Padding(3);
            this.tpDatosPersonales.Size = new System.Drawing.Size(290, 203);
            this.tpDatosPersonales.TabIndex = 0;
            this.tpDatosPersonales.Text = "Datos personales";
            this.tpDatosPersonales.UseVisualStyleBackColor = true;
            // 
            // tpDomicilio
            // 
            this.tpDomicilio.Controls.Add(this.gbDomicilio);
            this.tpDomicilio.Location = new System.Drawing.Point(4, 22);
            this.tpDomicilio.Name = "tpDomicilio";
            this.tpDomicilio.Padding = new System.Windows.Forms.Padding(3);
            this.tpDomicilio.Size = new System.Drawing.Size(290, 203);
            this.tpDomicilio.TabIndex = 1;
            this.tpDomicilio.Text = "Domicilio";
            this.tpDomicilio.UseVisualStyleBackColor = true;
            // 
            // tpContacto
            // 
            this.tpContacto.Controls.Add(this.gbContacto);
            this.tpContacto.Location = new System.Drawing.Point(4, 22);
            this.tpContacto.Name = "tpContacto";
            this.tpContacto.Padding = new System.Windows.Forms.Padding(3);
            this.tpContacto.Size = new System.Drawing.Size(290, 203);
            this.tpContacto.TabIndex = 2;
            this.tpContacto.Text = "Contacto";
            this.tpContacto.UseVisualStyleBackColor = true;
            // 
            // tpActivacion
            // 
            this.tpActivacion.Controls.Add(this.lblPregunta);
            this.tpActivacion.Controls.Add(this.chkActivo);
            this.tpActivacion.Location = new System.Drawing.Point(4, 22);
            this.tpActivacion.Name = "tpActivacion";
            this.tpActivacion.Padding = new System.Windows.Forms.Padding(3);
            this.tpActivacion.Size = new System.Drawing.Size(290, 203);
            this.tpActivacion.TabIndex = 3;
            this.tpActivacion.Text = "Activar/Desactivar cuenta";
            this.tpActivacion.UseVisualStyleBackColor = true;
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Location = new System.Drawing.Point(21, 93);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(139, 13);
            this.lblPregunta.TabIndex = 9;
            this.lblPregunta.Text = "Mantener empleado activo?";
            // 
            // frmRRHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 228);
            this.Controls.Add(this.tcRRHH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRRHH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.frmRRHH_Load);
            this.gbDomicilio.ResumeLayout(false);
            this.gbDomicilio.PerformLayout();
            this.gbContacto.ResumeLayout(false);
            this.gbContacto.PerformLayout();
            this.tcRRHH.ResumeLayout(false);
            this.tpDatosPersonales.ResumeLayout(false);
            this.tpDatosPersonales.PerformLayout();
            this.tpDomicilio.ResumeLayout(false);
            this.tpContacto.ResumeLayout(false);
            this.tpActivacion.ResumeLayout(false);
            this.tpActivacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox gbDomicilio;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblGeo;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.TextBox txtGeo;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.GroupBox gbContacto;
        private System.Windows.Forms.ComboBox cmbRedes;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label lblRedes;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtRedes;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.TabControl tcRRHH;
        private System.Windows.Forms.TabPage tpDatosPersonales;
        private System.Windows.Forms.TabPage tpDomicilio;
        private System.Windows.Forms.TabPage tpContacto;
        private System.Windows.Forms.TabPage tpActivacion;
        private System.Windows.Forms.Label lblPregunta;
    }
}