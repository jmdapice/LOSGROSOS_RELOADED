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
            this.cb_medioPago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_tarjeta = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.txtFechaVenc = new System.Windows.Forms.MaskedTextBox();
            this.txtTarjeta = new System.Windows.Forms.MaskedTextBox();
            this.txtCarga = new System.Windows.Forms.MaskedTextBox();
            this.gb_datosgral.SuspendLayout();
            this.gb_tarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_datosgral
            // 
            this.gb_datosgral.Controls.Add(this.txtCarga);
            this.gb_datosgral.Controls.Add(this.cb_medioPago);
            this.gb_datosgral.Controls.Add(this.label2);
            this.gb_datosgral.Controls.Add(this.label1);
            this.gb_datosgral.Location = new System.Drawing.Point(12, 12);
            this.gb_datosgral.Name = "gb_datosgral";
            this.gb_datosgral.Size = new System.Drawing.Size(289, 143);
            this.gb_datosgral.TabIndex = 0;
            this.gb_datosgral.TabStop = false;
            this.gb_datosgral.Text = "Datos generales";
            // 
            // cb_medioPago
            // 
            this.cb_medioPago.FormattingEnabled = true;
            this.cb_medioPago.Location = new System.Drawing.Point(6, 104);
            this.cb_medioPago.Name = "cb_medioPago";
            this.cb_medioPago.Size = new System.Drawing.Size(164, 21);
            this.cb_medioPago.TabIndex = 3;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Crédito a cargar";
            // 
            // gb_tarjeta
            // 
            this.gb_tarjeta.Controls.Add(this.txtTarjeta);
            this.gb_tarjeta.Controls.Add(this.txtFechaVenc);
            this.gb_tarjeta.Controls.Add(this.txtTitular);
            this.gb_tarjeta.Controls.Add(this.label5);
            this.gb_tarjeta.Controls.Add(this.label4);
            this.gb_tarjeta.Controls.Add(this.label3);
            this.gb_tarjeta.Location = new System.Drawing.Point(12, 161);
            this.gb_tarjeta.Name = "gb_tarjeta";
            this.gb_tarjeta.Size = new System.Drawing.Size(289, 192);
            this.gb_tarjeta.TabIndex = 1;
            this.gb_tarjeta.TabStop = false;
            this.gb_tarjeta.Text = "Tarjeta";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 359);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 31);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(181, 359);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 31);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nro. Tarjeta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.Location = new System.Drawing.Point(3, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha venc. tarjeta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(3, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nombre titular";
            // 
            // txtTitular
            // 
            this.txtTitular.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTitular.Location = new System.Drawing.Point(6, 155);
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Size = new System.Drawing.Size(175, 20);
            this.txtTitular.TabIndex = 8;
            // 
            // txtFechaVenc
            // 
            this.txtFechaVenc.Location = new System.Drawing.Point(6, 105);
            this.txtFechaVenc.Mask = "00/00/0000";
            this.txtFechaVenc.Name = "txtFechaVenc";
            this.txtFechaVenc.Size = new System.Drawing.Size(175, 20);
            this.txtFechaVenc.TabIndex = 9;
            this.txtFechaVenc.ValidatingType = typeof(System.DateTime);
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Location = new System.Drawing.Point(0, 56);
            this.txtTarjeta.Mask = "999999999999999999";
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(175, 20);
            this.txtTarjeta.TabIndex = 10;
            // 
            // txtCarga
            // 
            this.txtCarga.Location = new System.Drawing.Point(6, 46);
            this.txtCarga.Mask = "999999999999999999";
            this.txtCarga.Name = "txtCarga";
            this.txtCarga.Size = new System.Drawing.Size(175, 20);
            this.txtCarga.TabIndex = 11;
            // 
            // CargaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 400);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gb_tarjeta);
            this.Controls.Add(this.gb_datosgral);
            this.Name = "CargaCredito";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_medioPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_tarjeta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtFechaVenc;
        private System.Windows.Forms.MaskedTextBox txtTarjeta;
        private System.Windows.Forms.MaskedTextBox txtCarga;
    }
}