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
            this.pbFecha = new System.Windows.Forms.PictureBox();
            this.pbHora = new System.Windows.Forms.PictureBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.cmdCerrarSesion = new System.Windows.Forms.Button();
            this.pbERP = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 270);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(444, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblEstado
            // 
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(55, 17);
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
            this.menuStrip1.Size = new System.Drawing.Size(444, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            // 
            // consultarAuditoriaAdminToolStripMenuItem
            // 
            this.consultarAuditoriaAdminToolStripMenuItem.Name = "consultarAuditoriaAdminToolStripMenuItem";
            this.consultarAuditoriaAdminToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.consultarAuditoriaAdminToolStripMenuItem.Text = "Auditoría";
            this.consultarAuditoriaAdminToolStripMenuItem.Click += new System.EventHandler(this.consultarAuditoriaAdminToolStripMenuItem_Click);
            // 
            // rRHHToolStripMenuItem
            // 
            this.rRHHToolStripMenuItem.Name = "rRHHToolStripMenuItem";
            this.rRHHToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.rRHHToolStripMenuItem.Text = "RR.HH.";
            this.rRHHToolStripMenuItem.Click += new System.EventHandler(this.rRHHToolStripMenuItem_Click);
            // 
            // finanzasToolStripMenuItem
            // 
            this.finanzasToolStripMenuItem.Name = "finanzasToolStripMenuItem";
            this.finanzasToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.finanzasToolStripMenuItem.Text = "Finanzas";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // pbFecha
            // 
            this.pbFecha.Image = global::prySilvaERP.Properties.Resources.cal;
            this.pbFecha.Location = new System.Drawing.Point(275, 42);
            this.pbFecha.Name = "pbFecha";
            this.pbFecha.Size = new System.Drawing.Size(20, 17);
            this.pbFecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFecha.TabIndex = 24;
            this.pbFecha.TabStop = false;
            // 
            // pbHora
            // 
            this.pbHora.Image = global::prySilvaERP.Properties.Resources._1;
            this.pbHora.Location = new System.Drawing.Point(368, 42);
            this.pbHora.Name = "pbHora";
            this.pbHora.Size = new System.Drawing.Size(16, 18);
            this.pbHora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbHora.TabIndex = 23;
            this.pbHora.TabStop = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(301, 46);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 22;
            this.lblFecha.Text = "Fecha";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(390, 46);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(30, 13);
            this.lblHora.TabIndex = 21;
            this.lblHora.Text = "Hora";
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPerfil.Location = new System.Drawing.Point(24, 179);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(49, 19);
            this.lblPerfil.TabIndex = 20;
            this.lblPerfil.Text = "Perfil:";
            // 
            // cmdCerrarSesion
            // 
            this.cmdCerrarSesion.Location = new System.Drawing.Point(192, 229);
            this.cmdCerrarSesion.Name = "cmdCerrarSesion";
            this.cmdCerrarSesion.Size = new System.Drawing.Size(84, 35);
            this.cmdCerrarSesion.TabIndex = 19;
            this.cmdCerrarSesion.Text = "Cerrar sesión";
            this.cmdCerrarSesion.UseVisualStyleBackColor = true;
            this.cmdCerrarSesion.Click += new System.EventHandler(this.cmdCerrarSesion_Click);
            // 
            // pbERP
            // 
            this.pbERP.Image = global::prySilvaERP.Properties.Resources.Dynamics;
            this.pbERP.Location = new System.Drawing.Point(24, 28);
            this.pbERP.Name = "pbERP";
            this.pbERP.Size = new System.Drawing.Size(131, 92);
            this.pbERP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbERP.TabIndex = 18;
            this.pbERP.TabStop = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(24, 140);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 19);
            this.lblUsuario.TabIndex = 17;
            this.lblUsuario.Text = "Usuario:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 292);
            this.Controls.Add(this.pbFecha);
            this.Controls.Add(this.pbHora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.cmdCerrarSesion);
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
        private System.Windows.Forms.Button cmdCerrarSesion;
        private System.Windows.Forms.PictureBox pbERP;
        private System.Windows.Forms.Label lblUsuario;
    }
}

