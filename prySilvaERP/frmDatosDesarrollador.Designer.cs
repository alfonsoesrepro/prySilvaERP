namespace prySilvaERP
{
    partial class frmDatosDesarrollador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatosDesarrollador));
            this.lblDesarrollador = new System.Windows.Forms.Label();
            this.pbDesarrollador = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesarrollador)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDesarrollador
            // 
            this.lblDesarrollador.AutoSize = true;
            this.lblDesarrollador.Location = new System.Drawing.Point(123, 334);
            this.lblDesarrollador.Name = "lblDesarrollador";
            this.lblDesarrollador.Size = new System.Drawing.Size(250, 26);
            this.lblDesarrollador.TabIndex = 3;
            this.lblDesarrollador.Text = "© 2026 McLOVIN. Todos los derechos reservados.\r\n\r\n";
            // 
            // pbDesarrollador
            // 
            this.pbDesarrollador.Image = global::prySilvaERP.Properties.Resources._61tOwAlN1iL__AC_SL1497_;
            this.pbDesarrollador.Location = new System.Drawing.Point(12, 10);
            this.pbDesarrollador.Name = "pbDesarrollador";
            this.pbDesarrollador.Size = new System.Drawing.Size(471, 297);
            this.pbDesarrollador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDesarrollador.TabIndex = 2;
            this.pbDesarrollador.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(495, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblEstado
            // 
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(55, 17);
            this.lblEstado.Text = "lblEstado";
            // 
            // cmdAtras
            // 
            this.cmdAtras.Location = new System.Drawing.Point(211, 363);
            this.cmdAtras.Name = "cmdAtras";
            this.cmdAtras.Size = new System.Drawing.Size(75, 32);
            this.cmdAtras.TabIndex = 5;
            this.cmdAtras.Text = "Atrás";
            this.cmdAtras.UseVisualStyleBackColor = true;
            this.cmdAtras.Click += new System.EventHandler(this.cmdAtras_Click);
            // 
            // frmDatosDesarrollador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 426);
            this.Controls.Add(this.cmdAtras);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblDesarrollador);
            this.Controls.Add(this.pbDesarrollador);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDatosDesarrollador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos del Desarrollador";
            this.Load += new System.EventHandler(this.frmDatosDesarrollador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDesarrollador)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDesarrollador;
        private System.Windows.Forms.PictureBox pbDesarrollador;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.Button cmdAtras;
    }
}