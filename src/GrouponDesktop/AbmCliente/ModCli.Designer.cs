namespace GrouponDesktop.AbmCliente
{
    partial class ModCli
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
            this.masktxtTel = new System.Windows.Forms.MaskedTextBox();
            this.txtDni = new System.Windows.Forms.MaskedTextBox();
            this.masktxtNombre = new System.Windows.Forms.MaskedTextBox();
            this.masktxtCodPos = new System.Windows.Forms.MaskedTextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lstCiudadesElegidas = new System.Windows.Forms.CheckedListBox();
            this.cmbCiudades = new System.Windows.Forms.ComboBox();
            this.txtFecNac = new System.Windows.Forms.TextBox();
            this.lblFecNac = new System.Windows.Forms.Label();
            this.lblCiudades = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCP = new System.Windows.Forms.Label();
            this.lblDire = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.masktxtTel);
            this.groupBox1.Controls.Add(this.txtDni);
            this.groupBox1.Controls.Add(this.masktxtNombre);
            this.groupBox1.Controls.Add(this.masktxtCodPos);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.lstCiudadesElegidas);
            this.groupBox1.Controls.Add(this.cmbCiudades);
            this.groupBox1.Controls.Add(this.txtFecNac);
            this.groupBox1.Controls.Add(this.lblFecNac);
            this.groupBox1.Controls.Add(this.lblCiudades);
            this.groupBox1.Controls.Add(this.button);
            this.groupBox1.Controls.Add(this.lblMail);
            this.groupBox1.Controls.Add(this.lblDNI);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblCP);
            this.groupBox1.Controls.Add(this.lblDire);
            this.groupBox1.Controls.Add(this.lblTel);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 342);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Cliente";
            // 
            // masktxtTel
            // 
            this.masktxtTel.AsciiOnly = true;
            this.masktxtTel.Location = new System.Drawing.Point(18, 155);
            this.masktxtTel.Mask = "999999999999999999";
            this.masktxtTel.Name = "masktxtTel";
            this.masktxtTel.PromptChar = ' ';
            this.masktxtTel.Size = new System.Drawing.Size(286, 20);
            this.masktxtTel.TabIndex = 2;
            // 
            // txtDni
            // 
            this.txtDni.AsciiOnly = true;
            this.txtDni.Location = new System.Drawing.Point(341, 43);
            this.txtDni.Mask = "999999999999999999";
            this.txtDni.Name = "txtDni";
            this.txtDni.PromptChar = ' ';
            this.txtDni.Size = new System.Drawing.Size(286, 20);
            this.txtDni.TabIndex = 6;
            // 
            // masktxtNombre
            // 
            this.masktxtNombre.AsciiOnly = true;
            this.masktxtNombre.Location = new System.Drawing.Point(18, 41);
            this.masktxtNombre.Name = "masktxtNombre";
            this.masktxtNombre.PromptChar = ' ';
            this.masktxtNombre.Size = new System.Drawing.Size(286, 20);
            this.masktxtNombre.TabIndex = 0;
            // 
            // masktxtCodPos
            // 
            this.masktxtCodPos.AsciiOnly = true;
            this.masktxtCodPos.Location = new System.Drawing.Point(18, 259);
            this.masktxtCodPos.Mask = "9999999999";
            this.masktxtCodPos.Name = "masktxtCodPos";
            this.masktxtCodPos.PromptChar = ' ';
            this.masktxtCodPos.Size = new System.Drawing.Size(286, 20);
            this.masktxtCodPos.TabIndex = 4;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Thursday;
            this.monthCalendar1.Location = new System.Drawing.Point(400, 169);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowTodayCircle = false;
            this.monthCalendar1.ShowWeekNumbers = true;
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // lstCiudadesElegidas
            // 
            this.lstCiudadesElegidas.FormattingEnabled = true;
            this.lstCiudadesElegidas.Location = new System.Drawing.Point(343, 198);
            this.lstCiudadesElegidas.Name = "lstCiudadesElegidas";
            this.lstCiudadesElegidas.Size = new System.Drawing.Size(290, 124);
            this.lstCiudadesElegidas.TabIndex = 9;
            // 
            // cmbCiudades
            // 
            this.cmbCiudades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudades.FormattingEnabled = true;
            this.cmbCiudades.Location = new System.Drawing.Point(18, 310);
            this.cmbCiudades.Name = "cmbCiudades";
            this.cmbCiudades.Size = new System.Drawing.Size(286, 21);
            this.cmbCiudades.TabIndex = 5;
            // 
            // txtFecNac
            // 
            this.txtFecNac.Enabled = false;
            this.txtFecNac.Location = new System.Drawing.Point(341, 143);
            this.txtFecNac.Name = "txtFecNac";
            this.txtFecNac.Size = new System.Drawing.Size(176, 20);
            this.txtFecNac.TabIndex = 21;
            // 
            // lblFecNac
            // 
            this.lblFecNac.AutoSize = true;
            this.lblFecNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblFecNac.Location = new System.Drawing.Point(338, 121);
            this.lblFecNac.Name = "lblFecNac";
            this.lblFecNac.Size = new System.Drawing.Size(152, 18);
            this.lblFecNac.TabIndex = 19;
            this.lblFecNac.Text = "Fecha de Nacimiento ";
            // 
            // lblCiudades
            // 
            this.lblCiudades.AutoSize = true;
            this.lblCiudades.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCiudades.Location = new System.Drawing.Point(340, 177);
            this.lblCiudades.Name = "lblCiudades";
            this.lblCiudades.Size = new System.Drawing.Size(139, 18);
            this.lblCiudades.TabIndex = 17;
            this.lblCiudades.Text = "Ciudades preferidas";
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(546, 141);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(87, 23);
            this.button.TabIndex = 8;
            this.button.Text = "Seleccionar";
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMail.Location = new System.Drawing.Point(338, 66);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(45, 18);
            this.lblMail.TabIndex = 16;
            this.lblMail.Text = "Mail *";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDNI.Location = new System.Drawing.Point(338, 20);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(43, 18);
            this.lblDNI.TabIndex = 15;
            this.lblDNI.Text = "DNI *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.Location = new System.Drawing.Point(15, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ciudad de origen *";
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCP.Location = new System.Drawing.Point(15, 238);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(106, 18);
            this.lblCP.TabIndex = 13;
            this.lblCP.Text = "Codigo Postal ";
            // 
            // lblDire
            // 
            this.lblDire.AutoSize = true;
            this.lblDire.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDire.Location = new System.Drawing.Point(15, 191);
            this.lblDire.Name = "lblDire";
            this.lblDire.Size = new System.Drawing.Size(81, 18);
            this.lblDire.TabIndex = 12;
            this.lblDire.Text = "Direccion *";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblTel.Location = new System.Drawing.Point(15, 134);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(76, 18);
            this.lblTel.TabIndex = 11;
            this.lblTel.Text = "Telefono *";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblApellido.Location = new System.Drawing.Point(15, 77);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(69, 18);
            this.lblApellido.TabIndex = 10;
            this.lblApellido.Text = "Apellido *";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblNombre.Location = new System.Drawing.Point(15, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(72, 18);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Nombre *";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(341, 87);
            this.txtMail.MaxLength = 255;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(286, 20);
            this.txtMail.TabIndex = 7;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(18, 212);
            this.txtDireccion.MaxLength = 255;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(286, 20);
            this.txtDireccion.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(18, 98);
            this.txtApellido.MaxLength = 255;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(286, 20);
            this.txtApellido.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(420, 321);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(229, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Los campos marcados con (*) son obliogatorios";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(168, 369);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 23);
            this.btnLimpiar.TabIndex = 22;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(415, 369);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(291, 369);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 23);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ModCli
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(682, 404);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModCli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Datos";
            this.Load += new System.EventHandler(this.ModCli_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtDni;
        private System.Windows.Forms.MaskedTextBox masktxtNombre;
        private System.Windows.Forms.MaskedTextBox masktxtCodPos;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.CheckedListBox lstCiudadesElegidas;
        private System.Windows.Forms.ComboBox cmbCiudades;
        private System.Windows.Forms.TextBox txtFecNac;
        private System.Windows.Forms.Label lblFecNac;
        private System.Windows.Forms.Label lblCiudades;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.Label lblDire;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.MaskedTextBox masktxtTel;

    }
}