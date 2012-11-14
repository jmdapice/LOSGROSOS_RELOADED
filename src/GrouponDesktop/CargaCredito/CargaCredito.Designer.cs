namespace GrouponDesktop.CargaCredito
{
    partial class CargaCredito
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
            this.gb_datosgral = new System.Windows.Forms.GroupBox();
            this.txtCarga = new System.Windows.Forms.TextBox();
            this.cb_medioPago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCarga = new System.Windows.Forms.Label();
            this.gb_tarjeta = new System.Windows.Forms.GroupBox();
            this.calendarioVencimiento = new System.Windows.Forms.MonthCalendar();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.txtFechaVenc = new System.Windows.Forms.TextBox();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.gb_datosgral.SuspendLayout();
            this.gb_tarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_datosgral
            // 
            this.gb_datosgral.Controls.Add(this.txtCarga);
            this.gb_datosgral.Controls.Add(this.cb_medioPago);
            this.gb_datosgral.Controls.Add(this.label2);
            this.gb_datosgral.Controls.Add(this.lblCarga);
            this.gb_datosgral.Location = new System.Drawing.Point(12, 12);
            this.gb_datosgral.Name = "gb_datosgral";
            this.gb_datosgral.Size = new System.Drawing.Size(312, 143);
            this.gb_datosgral.TabIndex = 0;
            this.gb_datosgral.TabStop = false;
            this.gb_datosgral.Text = "Datos generales";
            // 
            // txtCarga
            // 
            this.txtCarga.Location = new System.Drawing.Point(12, 46);
            this.txtCarga.MaxLength = 9;
            this.txtCarga.Name = "txtCarga";
            this.txtCarga.Size = new System.Drawing.Size(175, 20);
            this.txtCarga.TabIndex = 1;
            // 
            // cb_medioPago
            // 
            this.cb_medioPago.FormattingEnabled = true;
            this.cb_medioPago.Location = new System.Drawing.Point(12, 104);
            this.cb_medioPago.Name = "cb_medioPago";
            this.cb_medioPago.Size = new System.Drawing.Size(175, 21);
            this.cb_medioPago.TabIndex = 2;
            this.cb_medioPago.SelectedValueChanged += new System.EventHandler(this.cb_medioPago_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(6, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Medio de pago";
            // 
            // lblCarga
            // 
            this.lblCarga.AutoSize = true;
            this.lblCarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCarga.Location = new System.Drawing.Point(9, 25);
            this.lblCarga.Name = "lblCarga";
            this.lblCarga.Size = new System.Drawing.Size(114, 18);
            this.lblCarga.TabIndex = 1;
            this.lblCarga.Text = "Crédito a cargar";
            // 
            // gb_tarjeta
            // 
            this.gb_tarjeta.Controls.Add(this.calendarioVencimiento);
            this.gb_tarjeta.Controls.Add(this.txtTarjeta);
            this.gb_tarjeta.Controls.Add(this.btnSeleccion);
            this.gb_tarjeta.Controls.Add(this.txtFechaVenc);
            this.gb_tarjeta.Controls.Add(this.txtTitular);
            this.gb_tarjeta.Controls.Add(this.label5);
            this.gb_tarjeta.Controls.Add(this.label4);
            this.gb_tarjeta.Controls.Add(this.lblTarjeta);
            this.gb_tarjeta.Location = new System.Drawing.Point(12, 161);
            this.gb_tarjeta.Name = "gb_tarjeta";
            this.gb_tarjeta.Size = new System.Drawing.Size(312, 192);
            this.gb_tarjeta.TabIndex = 1;
            this.gb_tarjeta.TabStop = false;
            this.gb_tarjeta.Text = "Tarjeta";
            // 
            // calendarioVencimiento
            // 
            this.calendarioVencimiento.Location = new System.Drawing.Point(73, 30);
            this.calendarioVencimiento.MaxSelectionCount = 1;
            this.calendarioVencimiento.Name = "calendarioVencimiento";
            this.calendarioVencimiento.TabIndex = 13;
            this.calendarioVencimiento.Visible = false;
            this.calendarioVencimiento.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendarioVencimiento_DateSelected);
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Location = new System.Drawing.Point(12, 55);
            this.txtTarjeta.MaxLength = 9;
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(181, 20);
            this.txtTarjeta.TabIndex = 3;
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Location = new System.Drawing.Point(196, 96);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccion.TabIndex = 13;
            this.btnSeleccion.Text = "Seleccionar";
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // txtFechaVenc
            // 
            this.txtFechaVenc.Enabled = false;
            this.txtFechaVenc.Location = new System.Drawing.Point(12, 99);
            this.txtFechaVenc.Name = "txtFechaVenc";
            this.txtFechaVenc.Size = new System.Drawing.Size(181, 20);
            this.txtFechaVenc.TabIndex = 4;
            // 
            // txtTitular
            // 
            this.txtTitular.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTitular.Location = new System.Drawing.Point(12, 151);
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Size = new System.Drawing.Size(181, 20);
            this.txtTitular.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(18, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nombre titular";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.Location = new System.Drawing.Point(18, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha venc. tarjeta";
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblTarjeta.Location = new System.Drawing.Point(18, 30);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(86, 18);
            this.lblTarjeta.TabIndex = 3;
            this.lblTarjeta.Text = "Nro. Tarjeta";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 359);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(224, 359);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(118, 359);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // CargaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 400);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gb_tarjeta);
            this.Controls.Add(this.gb_datosgral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CargaCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Carga de crédito";
            this.Load += new System.EventHandler(this.CargaCredito_Load);
            this.gb_datosgral.ResumeLayout(false);
            this.gb_datosgral.PerformLayout();
            this.gb_tarjeta.ResumeLayout(false);
            this.gb_tarjeta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_datosgral;
        private System.Windows.Forms.Label lblCarga;
        private System.Windows.Forms.ComboBox cb_medioPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_tarjeta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MonthCalendar calendarioVencimiento;
        private System.Windows.Forms.TextBox txtFechaVenc;
        private System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtCarga;
        private System.Windows.Forms.TextBox txtTarjeta;
    }
}