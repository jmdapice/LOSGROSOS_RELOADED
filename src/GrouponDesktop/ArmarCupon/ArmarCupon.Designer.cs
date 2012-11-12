namespace GrouponDesktop.ArmarCupon
{
    partial class ArmarCupon
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnFecVencCanje = new System.Windows.Forms.Button();
            this.btnFecVenc = new System.Windows.Forms.Button();
            this.btnFecPubli = new System.Windows.Forms.Button();
            this.lstCiudades = new System.Windows.Forms.CheckedListBox();
            this.txtCantMax = new System.Windows.Forms.TextBox();
            this.txtPrecioFict = new System.Windows.Forms.TextBox();
            this.txtPrecioReal = new System.Windows.Forms.TextBox();
            this.txtCantDisp = new System.Windows.Forms.TextBox();
            this.lblCantMax = new System.Windows.Forms.Label();
            this.lblCantDisp = new System.Windows.Forms.Label();
            this.lblCiudades = new System.Windows.Forms.Label();
            this.lblPrecioFic = new System.Windows.Forms.Label();
            this.lblPrecioReal = new System.Windows.Forms.Label();
            this.lblVencCanje = new System.Windows.Forms.Label();
            this.txtVencCanje = new System.Windows.Forms.TextBox();
            this.txtVencOferta = new System.Windows.Forms.TextBox();
            this.lblVencOferta = new System.Windows.Forms.Label();
            this.lblFecPub = new System.Windows.Forms.Label();
            this.txtFechaPub = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar3 = new System.Windows.Forms.MonthCalendar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.monthCalendar3);
            this.groupBox1.Controls.Add(this.monthCalendar2);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.btnFecVencCanje);
            this.groupBox1.Controls.Add(this.btnFecVenc);
            this.groupBox1.Controls.Add(this.btnFecPubli);
            this.groupBox1.Controls.Add(this.lstCiudades);
            this.groupBox1.Controls.Add(this.txtCantMax);
            this.groupBox1.Controls.Add(this.txtPrecioFict);
            this.groupBox1.Controls.Add(this.txtPrecioReal);
            this.groupBox1.Controls.Add(this.txtCantDisp);
            this.groupBox1.Controls.Add(this.lblCantMax);
            this.groupBox1.Controls.Add(this.lblCantDisp);
            this.groupBox1.Controls.Add(this.lblCiudades);
            this.groupBox1.Controls.Add(this.lblPrecioFic);
            this.groupBox1.Controls.Add(this.lblPrecioReal);
            this.groupBox1.Controls.Add(this.lblVencCanje);
            this.groupBox1.Controls.Add(this.txtVencCanje);
            this.groupBox1.Controls.Add(this.txtVencOferta);
            this.groupBox1.Controls.Add(this.lblVencOferta);
            this.groupBox1.Controls.Add(this.lblFecPub);
            this.groupBox1.Controls.Add(this.txtFechaPub);
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 358);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Cupon";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(250, 99);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 19;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // btnFecVencCanje
            // 
            this.btnFecVencCanje.Location = new System.Drawing.Point(143, 215);
            this.btnFecVencCanje.Name = "btnFecVencCanje";
            this.btnFecVencCanje.Size = new System.Drawing.Size(100, 23);
            this.btnFecVencCanje.TabIndex = 18;
            this.btnFecVencCanje.Text = "Seleccionar";
            this.btnFecVencCanje.UseVisualStyleBackColor = true;
            this.btnFecVencCanje.Click += new System.EventHandler(this.btnFecVencCanje_Click);
            // 
            // btnFecVenc
            // 
            this.btnFecVenc.Location = new System.Drawing.Point(143, 161);
            this.btnFecVenc.Name = "btnFecVenc";
            this.btnFecVenc.Size = new System.Drawing.Size(100, 23);
            this.btnFecVenc.TabIndex = 4;
            this.btnFecVenc.Text = "Seleccionar";
            this.btnFecVenc.UseVisualStyleBackColor = true;
            this.btnFecVenc.Click += new System.EventHandler(this.btnFecVenc_Click);
            // 
            // btnFecPubli
            // 
            this.btnFecPubli.Location = new System.Drawing.Point(143, 99);
            this.btnFecPubli.Name = "btnFecPubli";
            this.btnFecPubli.Size = new System.Drawing.Size(100, 23);
            this.btnFecPubli.TabIndex = 4;
            this.btnFecPubli.Text = "Seleccionar";
            this.btnFecPubli.UseVisualStyleBackColor = true;
            this.btnFecPubli.Click += new System.EventHandler(this.btnFecPubli_Click);
            // 
            // lstCiudades
            // 
            this.lstCiudades.FormattingEnabled = true;
            this.lstCiudades.Location = new System.Drawing.Point(406, 215);
            this.lstCiudades.Name = "lstCiudades";
            this.lstCiudades.Size = new System.Drawing.Size(220, 124);
            this.lstCiudades.TabIndex = 17;
            // 
            // txtCantMax
            // 
            this.txtCantMax.Location = new System.Drawing.Point(406, 161);
            this.txtCantMax.MaxLength = 9;
            this.txtCantMax.Name = "txtCantMax";
            this.txtCantMax.Size = new System.Drawing.Size(220, 20);
            this.txtCantMax.TabIndex = 16;
            // 
            // txtPrecioFict
            // 
            this.txtPrecioFict.Location = new System.Drawing.Point(23, 269);
            this.txtPrecioFict.MaxLength = 9;
            this.txtPrecioFict.Name = "txtPrecioFict";
            this.txtPrecioFict.Size = new System.Drawing.Size(220, 20);
            this.txtPrecioFict.TabIndex = 15;
            // 
            // txtPrecioReal
            // 
            this.txtPrecioReal.Location = new System.Drawing.Point(23, 323);
            this.txtPrecioReal.MaxLength = 9;
            this.txtPrecioReal.Name = "txtPrecioReal";
            this.txtPrecioReal.Size = new System.Drawing.Size(220, 20);
            this.txtPrecioReal.TabIndex = 14;
            // 
            // txtCantDisp
            // 
            this.txtCantDisp.Location = new System.Drawing.Point(406, 102);
            this.txtCantDisp.MaxLength = 9;
            this.txtCantDisp.Name = "txtCantDisp";
            this.txtCantDisp.Size = new System.Drawing.Size(220, 20);
            this.txtCantDisp.TabIndex = 13;
            // 
            // lblCantMax
            // 
            this.lblCantMax.AutoSize = true;
            this.lblCantMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCantMax.Location = new System.Drawing.Point(403, 135);
            this.lblCantMax.Name = "lblCantMax";
            this.lblCantMax.Size = new System.Drawing.Size(200, 18);
            this.lblCantMax.TabIndex = 12;
            this.lblCantMax.Text = "Cantidad Maxima de Compra";
            // 
            // lblCantDisp
            // 
            this.lblCantDisp.AutoSize = true;
            this.lblCantDisp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCantDisp.Location = new System.Drawing.Point(403, 81);
            this.lblCantDisp.Name = "lblCantDisp";
            this.lblCantDisp.Size = new System.Drawing.Size(139, 18);
            this.lblCantDisp.TabIndex = 11;
            this.lblCantDisp.Text = "Cantidad Disponible";
            // 
            // lblCiudades
            // 
            this.lblCiudades.AutoSize = true;
            this.lblCiudades.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCiudades.Location = new System.Drawing.Point(403, 189);
            this.lblCiudades.Name = "lblCiudades";
            this.lblCiudades.Size = new System.Drawing.Size(70, 18);
            this.lblCiudades.TabIndex = 10;
            this.lblCiudades.Text = "Ciudades";
            // 
            // lblPrecioFic
            // 
            this.lblPrecioFic.AutoSize = true;
            this.lblPrecioFic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblPrecioFic.Location = new System.Drawing.Point(20, 243);
            this.lblPrecioFic.Name = "lblPrecioFic";
            this.lblPrecioFic.Size = new System.Drawing.Size(102, 18);
            this.lblPrecioFic.TabIndex = 9;
            this.lblPrecioFic.Text = "Precio Ficticio";
            // 
            // lblPrecioReal
            // 
            this.lblPrecioReal.AutoSize = true;
            this.lblPrecioReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblPrecioReal.Location = new System.Drawing.Point(20, 297);
            this.lblPrecioReal.Name = "lblPrecioReal";
            this.lblPrecioReal.Size = new System.Drawing.Size(85, 18);
            this.lblPrecioReal.TabIndex = 8;
            this.lblPrecioReal.Text = "Precio Real";
            // 
            // lblVencCanje
            // 
            this.lblVencCanje.AutoSize = true;
            this.lblVencCanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblVencCanje.Location = new System.Drawing.Point(20, 189);
            this.lblVencCanje.Name = "lblVencCanje";
            this.lblVencCanje.Size = new System.Drawing.Size(176, 18);
            this.lblVencCanje.TabIndex = 7;
            this.lblVencCanje.Text = "Fecha Vencimiento Canje";
            // 
            // txtVencCanje
            // 
            this.txtVencCanje.Location = new System.Drawing.Point(23, 215);
            this.txtVencCanje.Name = "txtVencCanje";
            this.txtVencCanje.ReadOnly = true;
            this.txtVencCanje.Size = new System.Drawing.Size(114, 20);
            this.txtVencCanje.TabIndex = 6;
            // 
            // txtVencOferta
            // 
            this.txtVencOferta.Location = new System.Drawing.Point(23, 161);
            this.txtVencOferta.Name = "txtVencOferta";
            this.txtVencOferta.ReadOnly = true;
            this.txtVencOferta.Size = new System.Drawing.Size(114, 20);
            this.txtVencOferta.TabIndex = 5;
            // 
            // lblVencOferta
            // 
            this.lblVencOferta.AutoSize = true;
            this.lblVencOferta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblVencOferta.Location = new System.Drawing.Point(20, 135);
            this.lblVencOferta.Name = "lblVencOferta";
            this.lblVencOferta.Size = new System.Drawing.Size(179, 18);
            this.lblVencOferta.TabIndex = 4;
            this.lblVencOferta.Text = "Fecha Vencimiento Oferta";
            // 
            // lblFecPub
            // 
            this.lblFecPub.AutoSize = true;
            this.lblFecPub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblFecPub.Location = new System.Drawing.Point(20, 81);
            this.lblFecPub.Name = "lblFecPub";
            this.lblFecPub.Size = new System.Drawing.Size(129, 18);
            this.lblFecPub.TabIndex = 3;
            this.lblFecPub.Text = "Fecha Publicacion";
            // 
            // txtFechaPub
            // 
            this.txtFechaPub.Location = new System.Drawing.Point(23, 102);
            this.txtFechaPub.Name = "txtFechaPub";
            this.txtFechaPub.ReadOnly = true;
            this.txtFechaPub.Size = new System.Drawing.Size(114, 20);
            this.txtFechaPub.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDescripcion.Location = new System.Drawing.Point(20, 27);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(87, 18);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(23, 53);
            this.txtDescripcion.MaxLength = 255;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(603, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(163, 376);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 23);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(286, 376);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(409, 376);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(246, 127);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 20;
            this.monthCalendar2.Visible = false;
            this.monthCalendar2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateChanged);
            // 
            // monthCalendar3
            // 
            this.monthCalendar3.Location = new System.Drawing.Point(246, 161);
            this.monthCalendar3.Name = "monthCalendar3";
            this.monthCalendar3.TabIndex = 21;
            this.monthCalendar3.Visible = false;
            this.monthCalendar3.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar3_DateChanged);
            // 
            // ArmarCupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 419);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArmarCupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ArmarCupon";
            this.Load += new System.EventHandler(this.ArmarCupon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblFecPub;
        private System.Windows.Forms.TextBox txtFechaPub;
        private System.Windows.Forms.Label lblVencCanje;
        private System.Windows.Forms.TextBox txtVencCanje;
        private System.Windows.Forms.TextBox txtVencOferta;
        private System.Windows.Forms.Label lblVencOferta;
        private System.Windows.Forms.Label lblCantMax;
        private System.Windows.Forms.Label lblCantDisp;
        private System.Windows.Forms.Label lblCiudades;
        private System.Windows.Forms.Label lblPrecioFic;
        private System.Windows.Forms.Label lblPrecioReal;
        private System.Windows.Forms.TextBox txtCantMax;
        private System.Windows.Forms.TextBox txtPrecioFict;
        private System.Windows.Forms.TextBox txtPrecioReal;
        private System.Windows.Forms.TextBox txtCantDisp;
        private System.Windows.Forms.CheckedListBox lstCiudades;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFecVenc;
        private System.Windows.Forms.Button btnFecPubli;
        private System.Windows.Forms.Button btnFecVencCanje;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.MonthCalendar monthCalendar3;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
    }
}