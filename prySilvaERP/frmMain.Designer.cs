namespace prySilvaERP
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarAuditoriaAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rRHHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finanzasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.pbFecha = new System.Windows.Forms.PictureBox();
            this.pbHora = new System.Windows.Forms.PictureBox();
            this.pbERP = new System.Windows.Forms.PictureBox();
            this.lblDatos = new System.Windows.Forms.Label();
            this.lblOpciones = new System.Windows.Forms.Label();
            this.cmdAuditoria = new System.Windows.Forms.Button();
            this.cmdRRHH = new System.Windows.Forms.Button();
            this.cmdFinanzas = new System.Windows.Forms.Button();
            this.cmdUsuario = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbERP)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 337);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(464, 24);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(64, 19);
            this.lblEstado.Text = "lblEstado";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.consultarAuditoriaAdminToolStripMenuItem,
            this.rRHHToolStripMenuItem,
            this.finanzasToolStripMenuItem,
            this.usuarioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(464, 27);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.sistemaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // consultarAuditoriaAdminToolStripMenuItem
            // 
            this.consultarAuditoriaAdminToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.consultarAuditoriaAdminToolStripMenuItem.Name = "consultarAuditoriaAdminToolStripMenuItem";
            this.consultarAuditoriaAdminToolStripMenuItem.Size = new System.Drawing.Size(77, 23);
            this.consultarAuditoriaAdminToolStripMenuItem.Text = "Auditoría";
            this.consultarAuditoriaAdminToolStripMenuItem.Click += new System.EventHandler(this.consultarAuditoriaAdminToolStripMenuItem_Click);
            // 
            // rRHHToolStripMenuItem
            // 
            this.rRHHToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rRHHToolStripMenuItem.Name = "rRHHToolStripMenuItem";
            this.rRHHToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.rRHHToolStripMenuItem.Text = "RR.HH.";
            this.rRHHToolStripMenuItem.Click += new System.EventHandler(this.rRHHToolStripMenuItem_Click);
            // 
            // finanzasToolStripMenuItem
            // 
            this.finanzasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.finanzasToolStripMenuItem.Name = "finanzasToolStripMenuItem";
            this.finanzasToolStripMenuItem.Size = new System.Drawing.Size(73, 23);
            this.finanzasToolStripMenuItem.Text = "Finanzas";
            this.finanzasToolStripMenuItem.Click += new System.EventHandler(this.finanzasToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lblFecha.Location = new System.Drawing.Point(359, 46);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(36, 13);
            this.lblFecha.TabIndex = 22;
            this.lblFecha.Text = "Fecha";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lblHora.Location = new System.Drawing.Point(423, 46);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(29, 13);
            this.lblHora.TabIndex = 21;
            this.lblHora.Text = "Hora";
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPerfil.Location = new System.Drawing.Point(25, 243);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(116, 15);
            this.lblPerfil.TabIndex = 20;
            this.lblPerfil.Text = "Perfil: Administrador";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.Location = new System.Drawing.Point(25, 214);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(126, 15);
            this.lblUsuario.TabIndex = 17;
            this.lblUsuario.Text = "Usuario: aa@mail.com";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.Location = new System.Drawing.Point(167, 130);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(161, 19);
            this.lblBienvenida.TabIndex = 25;
            this.lblBienvenida.Text = "Bienvenido/a a tu ERP!";
            // 
            // pbFecha
            // 
            this.pbFecha.Image = global::prySilvaERP.Properties.Resources.cal;
            this.pbFecha.Location = new System.Drawing.Point(333, 42);
            this.pbFecha.Name = "pbFecha";
            this.pbFecha.Size = new System.Drawing.Size(20, 17);
            this.pbFecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFecha.TabIndex = 24;
            this.pbFecha.TabStop = false;
            // 
            // pbHora
            // 
            this.pbHora.Image = global::prySilvaERP.Properties.Resources._1;
            this.pbHora.Location = new System.Drawing.Point(401, 42);
            this.pbHora.Name = "pbHora";
            this.pbHora.Size = new System.Drawing.Size(16, 18);
            this.pbHora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHora.TabIndex = 23;
            this.pbHora.TabStop = false;
            // 
            // pbERP
            // 
            this.pbERP.Image = global::prySilvaERP.Properties.Resources.Dynamics;
            this.pbERP.Location = new System.Drawing.Point(12, 27);
            this.pbERP.Name = "pbERP";
            this.pbERP.Size = new System.Drawing.Size(131, 92);
            this.pbERP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbERP.TabIndex = 18;
            this.pbERP.TabStop = false;
            // 
            // lblDatos
            // 
            this.lblDatos.AutoSize = true;
            this.lblDatos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDatos.Location = new System.Drawing.Point(25, 187);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(104, 15);
            this.lblDatos.TabIndex = 26;
            this.lblDatos.Text = "Datos personales:";
            // 
            // lblOpciones
            // 
            this.lblOpciones.AutoSize = true;
            this.lblOpciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOpciones.Location = new System.Drawing.Point(359, 187);
            this.lblOpciones.Name = "lblOpciones";
            this.lblOpciones.Size = new System.Drawing.Size(61, 15);
            this.lblOpciones.TabIndex = 27;
            this.lblOpciones.Text = "Opciones:";
            // 
            // cmdAuditoria
            // 
            this.cmdAuditoria.Location = new System.Drawing.Point(354, 214);
            this.cmdAuditoria.Name = "cmdAuditoria";
            this.cmdAuditoria.Size = new System.Drawing.Size(75, 23);
            this.cmdAuditoria.TabIndex = 28;
            this.cmdAuditoria.Text = "Auditoría";
            this.cmdAuditoria.UseVisualStyleBackColor = true;
            this.cmdAuditoria.Click += new System.EventHandler(this.cmdAuditoria_Click);
            // 
            // cmdRRHH
            // 
            this.cmdRRHH.Location = new System.Drawing.Point(354, 243);
            this.cmdRRHH.Name = "cmdRRHH";
            this.cmdRRHH.Size = new System.Drawing.Size(75, 23);
            this.cmdRRHH.TabIndex = 29;
            this.cmdRRHH.Text = "RR.HH.";
            this.cmdRRHH.UseVisualStyleBackColor = true;
            this.cmdRRHH.Click += new System.EventHandler(this.cmdRRHH_Click);
            // 
            // cmdFinanzas
            // 
            this.cmdFinanzas.Location = new System.Drawing.Point(354, 272);
            this.cmdFinanzas.Name = "cmdFinanzas";
            this.cmdFinanzas.Size = new System.Drawing.Size(75, 23);
            this.cmdFinanzas.TabIndex = 30;
            this.cmdFinanzas.Text = "Finanzas";
            this.cmdFinanzas.UseVisualStyleBackColor = true;
            this.cmdFinanzas.Click += new System.EventHandler(this.cmdFinanzas_Click);
            // 
            // cmdUsuario
            // 
            this.cmdUsuario.Location = new System.Drawing.Point(354, 301);
            this.cmdUsuario.Name = "cmdUsuario";
            this.cmdUsuario.Size = new System.Drawing.Size(75, 23);
            this.cmdUsuario.TabIndex = 31;
            this.cmdUsuario.Text = "Usuario";
            this.cmdUsuario.UseVisualStyleBackColor = true;
            this.cmdUsuario.Click += new System.EventHandler(this.cmdUsuario_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 361);
            this.Controls.Add(this.cmdUsuario);
            this.Controls.Add(this.cmdFinanzas);
            this.Controls.Add(this.cmdRRHH);
            this.Controls.Add(this.cmdAuditoria);
            this.Controls.Add(this.lblOpciones);
            this.Controls.Add(this.lblDatos);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.pbFecha);
            this.Controls.Add(this.pbHora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.pbERP);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú ERP";
            this.Load += new System.EventHandler(this.frmMain_Load_1);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbERP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarAuditoriaAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rRHHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finanzasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbFecha;
        private System.Windows.Forms.PictureBox pbHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.PictureBox pbERP;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblDatos;
        private System.Windows.Forms.Label lblOpciones;
        private System.Windows.Forms.Button cmdAuditoria;
        private System.Windows.Forms.Button cmdRRHH;
        private System.Windows.Forms.Button cmdFinanzas;
        private System.Windows.Forms.Button cmdUsuario;
    }
}

