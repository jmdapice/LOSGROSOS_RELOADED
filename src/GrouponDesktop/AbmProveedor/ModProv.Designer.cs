namespace GrouponDesktop.AbmProveedor
{
    partial class ModProv
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
            this.txtCuit = new System.Windows.Forms.MaskedTextBox();
            this.cmbRubro = new System.Windows.Forms.ComboBox();
            this.cmbCiudad = new System.Windows.Forms.ComboBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.lblRubro = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblCodPos = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblRazSoc = new System.Windows.Forms.Label();
            this.txtNombreContacto = new System.Windows.Forms.TextBox();
            this.txtCodPos = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCuit);
            this.groupBox1.Controls.Add(this.cmbRubro);
            this.groupBox1.Controls.Add(this.cmbCiudad);
            this.groupBox1.Controls.Add(this.lblContacto);
            this.groupBox1.Controls.Add(this.lblRubro);
            this.groupBox1.Controls.Add(this.lblCuit);
            this.groupBox1.Controls.Add(this.lblCiudad);
            this.groupBox1.Controls.Add(this.lblCodPos);
            this.groupBox1.Controls.Add(this.lblDireccion);
            this.groupBox1.Controls.Add(this.lblTel);
            this.groupBox1.Controls.Add(this.lblMail);
            this.groupBox1.Controls.Add(this.lblRazSoc);
            this.groupBox1.Controls.Add(this.txtNombreContacto);
            this.groupBox1.Controls.Add(this.txtCodPos);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.txtTel);
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.txtRazonSocial);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paso 2";
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(341, 111);
            this.txtCuit.Mask = "00-00000000-0";
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(286, 20);
            this.txtCuit.TabIndex = 20;
            // 
            // cmbRubro
            // 
            this.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRubro.FormattingEnabled = true;
            this.cmbRubro.Location = new System.Drawing.Point(341, 169);
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.Size = new System.Drawing.Size(286, 21);
            this.cmbRubro.TabIndex = 19;
            // 
            // cmbCiudad
            // 
            this.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudad.FormattingEnabled = true;
            this.cmbCiudad.Location = new System.Drawing.Point(341, 53);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(286, 21);
            this.cmbCiudad.TabIndex = 18;
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblContacto.Location = new System.Drawing.Point(338, 205);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(127, 18);
            this.lblContacto.TabIndex = 17;
            this.lblContacto.Text = "Nombre Contacto";
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblRubro.Location = new System.Drawing.Point(338, 148);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(59, 18);
            this.lblRubro.TabIndex = 16;
            this.lblRubro.Text = "Rubro *";
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCuit.Location = new System.Drawing.Point(338, 91);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(52, 18);
            this.lblCuit.TabIndex = 15;
            this.lblCuit.Text = "CUIT *";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCiudad.Location = new System.Drawing.Point(338, 34);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(64, 18);
            this.lblCiudad.TabIndex = 14;
            this.lblCiudad.Text = "Ciudad *";
            // 
            // lblCodPos
            // 
            this.lblCodPos.AutoSize = true;
            this.lblCodPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCodPos.Location = new System.Drawing.Point(27, 262);
            this.lblCodPos.Name = "lblCodPos";
            this.lblCodPos.Size = new System.Drawing.Size(106, 18);
            this.lblCodPos.TabIndex = 13;
            this.lblCodPos.Text = "Codigo Postal ";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDireccion.Location = new System.Drawing.Point(27, 205);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(75, 18);
            this.lblDireccion.TabIndex = 12;
            this.lblDireccion.Text = "Direccion ";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblTel.Location = new System.Drawing.Point(27, 148);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(76, 18);
            this.lblTel.TabIndex = 11;
            this.lblTel.Text = "Telefono *";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMail.Location = new System.Drawing.Point(27, 91);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(45, 18);
            this.lblMail.TabIndex = 10;
            this.lblMail.Text = "Mail *";
            // 
            // lblRazSoc
            // 
            this.lblRazSoc.AutoSize = true;
            this.lblRazSoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblRazSoc.Location = new System.Drawing.Point(27, 34);
            this.lblRazSoc.Name = "lblRazSoc";
            this.lblRazSoc.Size = new System.Drawing.Size(107, 18);
            this.lblRazSoc.TabIndex = 9;
            this.lblRazSoc.Text = "Razon Social *";
            // 
            // txtNombreContacto
            // 
            this.txtNombreContacto.Location = new System.Drawing.Point(341, 226);
            this.txtNombreContacto.Name = "txtNombreContacto";
            this.txtNombreContacto.Size = new System.Drawing.Size(286, 20);
            this.txtNombreContacto.TabIndex = 8;
            // 
            // txtCodPos
            // 
            this.txtCodPos.Location = new System.Drawing.Point(30, 283);
            this.txtCodPos.Name = "txtCodPos";
            this.txtCodPos.Size = new System.Drawing.Size(286, 20);
            this.txtCodPos.TabIndex = 4;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(30, 226);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(286, 20);
            this.txtDireccion.TabIndex = 3;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(30, 169);
            this.txtTel.MaxLength = 18;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(286, 20);
            this.txtTel.TabIndex = 2;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(30, 112);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(286, 20);
            this.txtMail.TabIndex = 1;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(30, 55);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(286, 20);
            this.txtRazonSocial.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(291, 360);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 23);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(397, 360);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(185, 360);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 23);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // ModProv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 404);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModProv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Proveedor";
            this.Load += new System.EventHandler(this.ModProv_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblCodPos;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblRazSoc;
        private System.Windows.Forms.TextBox txtNombreContacto;
        private System.Windows.Forms.TextBox txtCodPos;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbRubro;
        private System.Windows.Forms.ComboBox cmbCiudad;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.MaskedTextBox txtCuit;
    }
}