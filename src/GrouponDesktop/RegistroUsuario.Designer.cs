namespace GrouponDesktop
{
    partial class RegistroUsuario
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass1 = new System.Windows.Forms.TextBox();
            this.txtPass2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNomUsuario = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.CausesValidation = false;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtPass1);
            this.groupBox1.Controls.Add(this.txtPass2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblNomUsuario);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnSiguiente);
            this.groupBox1.Controls.Add(this.cmbRol);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 286);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paso 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Los campos marcados con (*) son obliogatorios";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(101, 40);
            this.txtUser.MaxLength = 100;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(182, 20);
            this.txtUser.TabIndex = 0;
            // 
            // txtPass1
            // 
            this.txtPass1.Location = new System.Drawing.Point(101, 85);
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.PasswordChar = '*';
            this.txtPass1.Size = new System.Drawing.Size(182, 20);
            this.txtPass1.TabIndex = 1;
            // 
            // txtPass2
            // 
            this.txtPass2.Location = new System.Drawing.Point(101, 130);
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.PasswordChar = '*';
            this.txtPass2.Size = new System.Drawing.Size(182, 20);
            this.txtPass2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(105, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "Seleccione su Rol *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(105, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Repetir Contraseña *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Contraseña *";
            // 
            // lblNomUsuario
            // 
            this.lblNomUsuario.AutoSize = true;
            this.lblNomUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomUsuario.Location = new System.Drawing.Point(105, 21);
            this.lblNomUsuario.Name = "lblNomUsuario";
            this.lblNomUsuario.Size = new System.Drawing.Size(128, 18);
            this.lblNomUsuario.TabIndex = 13;
            this.lblNomUsuario.Text = "Nombre Usuario *";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(202, 216);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(82, 216);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(100, 23);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Items.AddRange(new object[] {
            "CLIENTE",
            "PROVEEDOR"});
            this.cmbRol.Location = new System.Drawing.Point(101, 175);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(182, 21);
            this.cmbRol.TabIndex = 3;
            // 
            // RegistroUsuario
            // 
            this.AcceptButton = this.btnSiguiente;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(409, 310);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistroUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrarse";
            this.Load += new System.EventHandler(this.RegistroUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPass2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNomUsuario;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtUser;
        public System.Windows.Forms.TextBox txtPass1;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmbRol;

    }
}