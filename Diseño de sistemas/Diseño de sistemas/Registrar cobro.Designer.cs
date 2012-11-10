namespace Diseño_de_sistemas
{
    partial class Registrar_cobro
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
            this.gb_articulos = new System.Windows.Forms.GroupBox();
            this.tb_remito = new System.Windows.Forms.MaskedTextBox();
            this.lbl_medioPago = new System.Windows.Forms.Label();
            this.lbl_remito = new System.Windows.Forms.Label();
            this.cb_medioPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.gb_articulos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_articulos
            // 
            this.gb_articulos.Controls.Add(this.cb_medioPago);
            this.gb_articulos.Controls.Add(this.tb_remito);
            this.gb_articulos.Controls.Add(this.lbl_medioPago);
            this.gb_articulos.Controls.Add(this.lbl_remito);
            this.gb_articulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_articulos.Location = new System.Drawing.Point(8, 12);
            this.gb_articulos.Name = "gb_articulos";
            this.gb_articulos.Size = new System.Drawing.Size(301, 162);
            this.gb_articulos.TabIndex = 1;
            this.gb_articulos.TabStop = false;
            this.gb_articulos.Text = "Datos a cargar";
            // 
            // tb_remito
            // 
            this.tb_remito.Location = new System.Drawing.Point(18, 51);
            this.tb_remito.Mask = "9999999999";
            this.tb_remito.Name = "tb_remito";
            this.tb_remito.PromptChar = ' ';
            this.tb_remito.Size = new System.Drawing.Size(168, 23);
            this.tb_remito.TabIndex = 6;
            // 
            // lbl_medioPago
            // 
            this.lbl_medioPago.AutoSize = true;
            this.lbl_medioPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_medioPago.Location = new System.Drawing.Point(15, 91);
            this.lbl_medioPago.Name = "lbl_medioPago";
            this.lbl_medioPago.Size = new System.Drawing.Size(125, 17);
            this.lbl_medioPago.TabIndex = 7;
            this.lbl_medioPago.Text = "Medio de pago: (*)";
            // 
            // lbl_remito
            // 
            this.lbl_remito.AutoSize = true;
            this.lbl_remito.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_remito.Location = new System.Drawing.Point(15, 31);
            this.lbl_remito.Name = "lbl_remito";
            this.lbl_remito.Size = new System.Drawing.Size(138, 17);
            this.lbl_remito.TabIndex = 5;
            this.lbl_remito.Text = "Código de remito: (*)";
            // 
            // cb_medioPago
            // 
            this.cb_medioPago.FormattingEnabled = true;
            this.cb_medioPago.Items.AddRange(new object[] {
            "Efectivo",
            "Débito",
            "Crédito"});
            this.cb_medioPago.Location = new System.Drawing.Point(18, 120);
            this.cb_medioPago.Name = "cb_medioPago";
            this.cb_medioPago.Size = new System.Drawing.Size(167, 24);
            this.cb_medioPago.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Los campos que poseen (*) son obligatorios";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(196, 201);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(113, 26);
            this.btn_cancelar.TabIndex = 5;
            this.btn_cancelar.Text = "Cancelar operación";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_registrar
            // 
            this.btn_registrar.Location = new System.Drawing.Point(8, 201);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(113, 26);
            this.btn_registrar.TabIndex = 4;
            this.btn_registrar.Text = "Registrar cobro";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // Registrar_cobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 288);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.gb_articulos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Registrar_cobro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar cobro";
            this.Load += new System.EventHandler(this.Registrar_cobro_Load);
            this.gb_articulos.ResumeLayout(false);
            this.gb_articulos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_articulos;
        private System.Windows.Forms.ComboBox cb_medioPago;
        private System.Windows.Forms.MaskedTextBox tb_remito;
        private System.Windows.Forms.Label lbl_medioPago;
        private System.Windows.Forms.Label lbl_remito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_registrar;
    }
}