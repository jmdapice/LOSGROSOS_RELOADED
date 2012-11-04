namespace GrouponDesktop
{
    partial class AltaRol
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNombRol = new System.Windows.Forms.TextBox();
            this.lblNomRol = new System.Windows.Forms.Label();
            this.lstFuncElegidas = new System.Windows.Forms.CheckedListBox();
            this.lblFun = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(188, 288);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(305, 288);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(68, 288);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 23);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstFuncElegidas);
            this.groupBox1.Controls.Add(this.lblFun);
            this.groupBox1.Controls.Add(this.txtNombRol);
            this.groupBox1.Controls.Add(this.lblNomRol);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 261);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Rol";
            // 
            // txtNombRol
            // 
            this.txtNombRol.Location = new System.Drawing.Point(24, 50);
            this.txtNombRol.MaxLength = 100;
            this.txtNombRol.Name = "txtNombRol";
            this.txtNombRol.Size = new System.Drawing.Size(182, 20);
            this.txtNombRol.TabIndex = 15;
            // 
            // lblNomRol
            // 
            this.lblNomRol.AutoSize = true;
            this.lblNomRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomRol.Location = new System.Drawing.Point(21, 29);
            this.lblNomRol.Name = "lblNomRol";
            this.lblNomRol.Size = new System.Drawing.Size(99, 18);
            this.lblNomRol.TabIndex = 14;
            this.lblNomRol.Text = "Nombre Rol *";
            // 
            // lstFuncElegidas
            // 
            this.lstFuncElegidas.FormattingEnabled = true;
            this.lstFuncElegidas.Location = new System.Drawing.Point(24, 116);
            this.lstFuncElegidas.Name = "lstFuncElegidas";
            this.lstFuncElegidas.Size = new System.Drawing.Size(403, 124);
            this.lstFuncElegidas.TabIndex = 4;
            // 
            // lblFun
            // 
            this.lblFun.AutoSize = true;
            this.lblFun.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFun.Location = new System.Drawing.Point(21, 88);
            this.lblFun.Name = "lblFun";
            this.lblFun.Size = new System.Drawing.Size(141, 18);
            this.lblFun.TabIndex = 18;
            this.lblFun.Text = "Elija funcionalidades";
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 332);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltaRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta";
            this.Load += new System.EventHandler(this.AltaRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNomRol;
        public System.Windows.Forms.TextBox txtNombRol;
        private System.Windows.Forms.CheckedListBox lstFuncElegidas;
        private System.Windows.Forms.Label lblFun;
    }
}