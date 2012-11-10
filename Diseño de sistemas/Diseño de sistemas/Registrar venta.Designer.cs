namespace Diseño_de_sistemas
{
    partial class Registrar_venta
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
            this.lbl_codart = new System.Windows.Forms.Label();
            this.tb_codart = new System.Windows.Forms.MaskedTextBox();
            this.tb_cant = new System.Windows.Forms.MaskedTextBox();
            this.lbl_cant = new System.Windows.Forms.Label();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_articulos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_articulos
            // 
            this.gb_articulos.Controls.Add(this.tb_cant);
            this.gb_articulos.Controls.Add(this.tb_codart);
            this.gb_articulos.Controls.Add(this.lbl_cant);
            this.gb_articulos.Controls.Add(this.lbl_codart);
            this.gb_articulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_articulos.Location = new System.Drawing.Point(11, 15);
            this.gb_articulos.Name = "gb_articulos";
            this.gb_articulos.Size = new System.Drawing.Size(301, 148);
            this.gb_articulos.TabIndex = 0;
            this.gb_articulos.TabStop = false;
            this.gb_articulos.Text = "Datos a cargar";
            // 
            // lbl_codart
            // 
            this.lbl_codart.AutoSize = true;
            this.lbl_codart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_codart.Location = new System.Drawing.Point(15, 31);
            this.lbl_codart.Name = "lbl_codart";
            this.lbl_codart.Size = new System.Drawing.Size(145, 17);
            this.lbl_codart.TabIndex = 5;
            this.lbl_codart.Text = "Código de artículo: (*)";
            // 
            // tb_codart
            // 
            this.tb_codart.Location = new System.Drawing.Point(18, 51);
            this.tb_codart.Mask = "9999999999";
            this.tb_codart.Name = "tb_codart";
            this.tb_codart.PromptChar = ' ';
            this.tb_codart.Size = new System.Drawing.Size(168, 23);
            this.tb_codart.TabIndex = 6;
            // 
            // tb_cant
            // 
            this.tb_cant.Location = new System.Drawing.Point(18, 111);
            this.tb_cant.Mask = "9999999999";
            this.tb_cant.Name = "tb_cant";
            this.tb_cant.PromptChar = ' ';
            this.tb_cant.Size = new System.Drawing.Size(168, 23);
            this.tb_cant.TabIndex = 8;
            // 
            // lbl_cant
            // 
            this.lbl_cant.AutoSize = true;
            this.lbl_cant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cant.Location = new System.Drawing.Point(15, 91);
            this.lbl_cant.Name = "lbl_cant";
            this.lbl_cant.Size = new System.Drawing.Size(141, 17);
            this.lbl_cant.TabIndex = 7;
            this.lbl_cant.Text = "Cantidad vendida: (*)";
            // 
            // btn_registrar
            // 
            this.btn_registrar.Location = new System.Drawing.Point(11, 188);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(113, 26);
            this.btn_registrar.TabIndex = 1;
            this.btn_registrar.Text = "Registrar venta";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(199, 188);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(113, 26);
            this.btn_cancelar.TabIndex = 2;
            this.btn_cancelar.Text = "Cancelar operación";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Los campos que poseen (*) son obligatorios";
            // 
            // Registrar_venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 279);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.gb_articulos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Registrar_venta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar venta";
            this.Load += new System.EventHandler(this.Registrar_venta_Load);
            this.gb_articulos.ResumeLayout(false);
            this.gb_articulos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_articulos;
        private System.Windows.Forms.Label lbl_codart;
        private System.Windows.Forms.MaskedTextBox tb_cant;
        private System.Windows.Forms.MaskedTextBox tb_codart;
        private System.Windows.Forms.Label lbl_cant;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label label1;
    }
}