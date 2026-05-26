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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cmdCerrarSesion = new System.Windows.Forms.Button();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pbFecha = new System.Windows.Forms.PictureBox();
            this.pbHora = new System.Windows.Forms.PictureBox();
            this.pbERP = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbERP)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 249);
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
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(12, 112);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 19);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario:";
            // 
            // cmdCerrarSesion
            // 
            this.cmdCerrarSesion.Location = new System.Drawing.Point(180, 201);
            this.cmdCerrarSesion.Name = "cmdCerrarSesion";
            this.cmdCerrarSesion.Size = new System.Drawing.Size(84, 35);
            this.cmdCerrarSesion.TabIndex = 3;
            this.cmdCerrarSesion.Text = "Cerrar sesión";
            this.cmdCerrarSesion.UseVisualStyleBackColor = true;
            this.cmdCerrarSesion.Click += new System.EventHandler(this.cmdCerrarSesion_Click);
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPerfil.Location = new System.Drawing.Point(12, 151);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(49, 19);
            this.lblPerfil.TabIndex = 4;
            this.lblPerfil.Text = "Perfil:";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(378, 18);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(30, 13);
            this.lblHora.TabIndex = 5;
            this.lblHora.Text = "Hora";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(289, 18);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha";
            // 
            // pbFecha
            // 
            this.pbFecha.Image = global::prySilvaERP.Properties.Resources.cal;
            this.pbFecha.Location = new System.Drawing.Point(263, 14);
            this.pbFecha.Name = "pbFecha";
            this.pbFecha.Size = new System.Drawing.Size(20, 17);
            this.pbFecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFecha.TabIndex = 8;
            this.pbFecha.TabStop = false;
            // 
            // pbHora
            // 
            this.pbHora.Image = global::prySilvaERP.Properties.Resources._1;
            this.pbHora.Location = new System.Drawing.Point(356, 14);
            this.pbHora.Name = "pbHora";
            this.pbHora.Size = new System.Drawing.Size(16, 18);
            this.pbHora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbHora.TabIndex = 7;
            this.pbHora.TabStop = false;
            // 
            // pbERP
            // 
            this.pbERP.Image = global::prySilvaERP.Properties.Resources.Dynamics;
            this.pbERP.Location = new System.Drawing.Point(12, 0);
            this.pbERP.Name = "pbERP";
            this.pbERP.Size = new System.Drawing.Size(131, 92);
            this.pbERP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbERP.TabIndex = 2;
            this.pbERP.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 271);
            this.Controls.Add(this.pbFecha);
            this.Controls.Add(this.pbHora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.cmdCerrarSesion);
            this.Controls.Add(this.pbERP);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú ERP";
            this.Load += new System.EventHandler(this.frmMain_Load_1);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbERP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox pbERP;
        private System.Windows.Forms.Button cmdCerrarSesion;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.PictureBox pbHora;
        private System.Windows.Forms.PictureBox pbFecha;
    }
}

