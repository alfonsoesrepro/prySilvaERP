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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpInicio = new System.Windows.Forms.TabPage();
            this.pbFecha = new System.Windows.Forms.PictureBox();
            this.pbHora = new System.Windows.Forms.PictureBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.cmdCerrarSesion = new System.Windows.Forms.Button();
            this.pbERP = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.tpConsulta = new System.Windows.Forms.TabPage();
            this.dgvAuditoria = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbERP)).BeginInit();
            this.tpConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).BeginInit();
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
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpInicio);
            this.tcMain.Controls.Add(this.tpConsulta);
            this.tcMain.Location = new System.Drawing.Point(0, 2);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(444, 269);
            this.tcMain.TabIndex = 9;
            // 
            // tpInicio
            // 
            this.tpInicio.Controls.Add(this.pbFecha);
            this.tpInicio.Controls.Add(this.pbHora);
            this.tpInicio.Controls.Add(this.lblFecha);
            this.tpInicio.Controls.Add(this.lblHora);
            this.tpInicio.Controls.Add(this.lblPerfil);
            this.tpInicio.Controls.Add(this.cmdCerrarSesion);
            this.tpInicio.Controls.Add(this.pbERP);
            this.tpInicio.Controls.Add(this.lblUsuario);
            this.tpInicio.Location = new System.Drawing.Point(4, 22);
            this.tpInicio.Name = "tpInicio";
            this.tpInicio.Padding = new System.Windows.Forms.Padding(3);
            this.tpInicio.Size = new System.Drawing.Size(436, 243);
            this.tpInicio.TabIndex = 0;
            this.tpInicio.Text = "Inicio";
            this.tpInicio.UseVisualStyleBackColor = true;
            // 
            // pbFecha
            // 
            this.pbFecha.Image = global::prySilvaERP.Properties.Resources.cal;
            this.pbFecha.Location = new System.Drawing.Point(271, 17);
            this.pbFecha.Name = "pbFecha";
            this.pbFecha.Size = new System.Drawing.Size(20, 17);
            this.pbFecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFecha.TabIndex = 16;
            this.pbFecha.TabStop = false;
            // 
            // pbHora
            // 
            this.pbHora.Image = global::prySilvaERP.Properties.Resources._1;
            this.pbHora.Location = new System.Drawing.Point(364, 17);
            this.pbHora.Name = "pbHora";
            this.pbHora.Size = new System.Drawing.Size(16, 18);
            this.pbHora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbHora.TabIndex = 15;
            this.pbHora.TabStop = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(297, 21);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 14;
            this.lblFecha.Text = "Fecha";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(386, 21);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(30, 13);
            this.lblHora.TabIndex = 13;
            this.lblHora.Text = "Hora";
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPerfil.Location = new System.Drawing.Point(20, 154);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(49, 19);
            this.lblPerfil.TabIndex = 12;
            this.lblPerfil.Text = "Perfil:";
            // 
            // cmdCerrarSesion
            // 
            this.cmdCerrarSesion.Location = new System.Drawing.Point(188, 204);
            this.cmdCerrarSesion.Name = "cmdCerrarSesion";
            this.cmdCerrarSesion.Size = new System.Drawing.Size(84, 35);
            this.cmdCerrarSesion.TabIndex = 11;
            this.cmdCerrarSesion.Text = "Cerrar sesión";
            this.cmdCerrarSesion.UseVisualStyleBackColor = true;
            this.cmdCerrarSesion.Click += new System.EventHandler(this.cmdCerrarSesion_Click);
            // 
            // pbERP
            // 
            this.pbERP.Image = global::prySilvaERP.Properties.Resources.Dynamics;
            this.pbERP.Location = new System.Drawing.Point(20, 3);
            this.pbERP.Name = "pbERP";
            this.pbERP.Size = new System.Drawing.Size(131, 92);
            this.pbERP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbERP.TabIndex = 10;
            this.pbERP.TabStop = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(20, 115);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 19);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "Usuario:";
            // 
            // tpConsulta
            // 
            this.tpConsulta.Controls.Add(this.dgvAuditoria);
            this.tpConsulta.Location = new System.Drawing.Point(4, 22);
            this.tpConsulta.Name = "tpConsulta";
            this.tpConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsulta.Size = new System.Drawing.Size(436, 243);
            this.tpConsulta.TabIndex = 1;
            this.tpConsulta.Text = "Consultar Auditoría";
            this.tpConsulta.UseVisualStyleBackColor = true;
            // 
            // dgvAuditoria
            // 
            this.dgvAuditoria.AllowUserToAddRows = false;
            this.dgvAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoria.Location = new System.Drawing.Point(8, 6);
            this.dgvAuditoria.Name = "dgvAuditoria";
            this.dgvAuditoria.ReadOnly = true;
            this.dgvAuditoria.RowHeadersVisible = false;
            this.dgvAuditoria.Size = new System.Drawing.Size(420, 231);
            this.dgvAuditoria.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 292);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú ERP";
            this.Load += new System.EventHandler(this.frmMain_Load_1);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tpInicio.ResumeLayout(false);
            this.tpInicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbERP)).EndInit();
            this.tpConsulta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpInicio;
        private System.Windows.Forms.PictureBox pbFecha;
        private System.Windows.Forms.PictureBox pbHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.Button cmdCerrarSesion;
        private System.Windows.Forms.PictureBox pbERP;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TabPage tpConsulta;
        private System.Windows.Forms.DataGridView dgvAuditoria;
    }
}

