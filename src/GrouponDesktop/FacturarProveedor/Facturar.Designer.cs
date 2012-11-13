namespace GrouponDesktop.FacturarProveedor
{
    partial class Facturar
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxCuit = new System.Windows.Forms.TextBox();
            this.btnBuscProv = new System.Windows.Forms.Button();
            this.btnSelecHasta = new System.Windows.Forms.Button();
            this.txtFechaHasta = new System.Windows.Forms.TextBox();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.txtFechaDesde = new System.Windows.Forms.TextBox();
            this.btnSelecDesde = new System.Windows.Forms.Button();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.calendarDesde = new System.Windows.Forms.MonthCalendar();
            this.calendHasta = new System.Windows.Forms.MonthCalendar();
            this.dgvProv = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBoxCuit);
            this.groupBox1.Controls.Add(this.btnBuscProv);
            this.groupBox1.Controls.Add(this.btnSelecHasta);
            this.groupBox1.Controls.Add(this.txtFechaHasta);
            this.groupBox1.Controls.Add(this.lblFechaHasta);
            this.groupBox1.Controls.Add(this.txtFechaDesde);
            this.groupBox1.Controls.Add(this.btnSelecDesde);
            this.groupBox1.Controls.Add(this.lblFechaDesde);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el intervalo de fechas para facturar";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblTotal.Location = new System.Drawing.Point(585, 16);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(157, 18);
            this.lblTotal.TabIndex = 31;
            this.lblTotal.Text = "Importe Total Factura: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "CUIT:";
            // 
            // txtBoxCuit
            // 
            this.txtBoxCuit.Enabled = false;
            this.txtBoxCuit.Location = new System.Drawing.Point(31, 49);
            this.txtBoxCuit.Name = "txtBoxCuit";
            this.txtBoxCuit.Size = new System.Drawing.Size(178, 20);
            this.txtBoxCuit.TabIndex = 29;
            // 
            // btnBuscProv
            // 
            this.btnBuscProv.Location = new System.Drawing.Point(244, 49);
            this.btnBuscProv.Name = "btnBuscProv";
            this.btnBuscProv.Size = new System.Drawing.Size(134, 23);
            this.btnBuscProv.TabIndex = 28;
            this.btnBuscProv.Text = "Seleccionar Proveedor";
            this.btnBuscProv.UseVisualStyleBackColor = true;
            this.btnBuscProv.Click += new System.EventHandler(this.btnBuscProv_Click);
            // 
            // btnSelecHasta
            // 
            this.btnSelecHasta.Location = new System.Drawing.Point(597, 87);
            this.btnSelecHasta.Name = "btnSelecHasta";
            this.btnSelecHasta.Size = new System.Drawing.Size(100, 23);
            this.btnSelecHasta.TabIndex = 27;
            this.btnSelecHasta.Text = "Seleccionar";
            this.btnSelecHasta.UseVisualStyleBackColor = true;
            this.btnSelecHasta.Click += new System.EventHandler(this.btnSelecHasta_Click);
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Enabled = false;
            this.txtFechaHasta.Location = new System.Drawing.Point(387, 90);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(178, 20);
            this.txtFechaHasta.TabIndex = 26;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblFechaHasta.Location = new System.Drawing.Point(384, 69);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(91, 18);
            this.lblFechaHasta.TabIndex = 25;
            this.lblFechaHasta.Text = "Hasta fecha:";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Enabled = false;
            this.txtFechaDesde.Location = new System.Drawing.Point(31, 93);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(178, 20);
            this.txtFechaDesde.TabIndex = 24;
            // 
            // btnSelecDesde
            // 
            this.btnSelecDesde.Location = new System.Drawing.Point(245, 90);
            this.btnSelecDesde.Name = "btnSelecDesde";
            this.btnSelecDesde.Size = new System.Drawing.Size(100, 23);
            this.btnSelecDesde.TabIndex = 23;
            this.btnSelecDesde.Text = "Seleccionar";
            this.btnSelecDesde.UseVisualStyleBackColor = true;
            this.btnSelecDesde.Click += new System.EventHandler(this.btnSelecDesde_Click);
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblFechaDesde.Location = new System.Drawing.Point(28, 72);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(155, 18);
            this.lblFechaDesde.TabIndex = 22;
            this.lblFechaDesde.Text = "Facturar desde fecha: ";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(284, 419);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 23);
            this.btnLimpiar.TabIndex = 30;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(496, 419);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(390, 419);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 23);
            this.btnAceptar.TabIndex = 28;
            this.btnAceptar.Text = "Facturar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.calendarDesde);
            this.groupBox2.Controls.Add(this.calendHasta);
            this.groupBox2.Controls.Add(this.dgvProv);
            this.groupBox2.Location = new System.Drawing.Point(12, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(857, 264);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Cupones a Facturar";
            // 
            // calendarDesde
            // 
            this.calendarDesde.Location = new System.Drawing.Point(93, 0);
            this.calendarDesde.MaxSelectionCount = 1;
            this.calendarDesde.Name = "calendarDesde";
            this.calendarDesde.TabIndex = 34;
            this.calendarDesde.Visible = false;
            this.calendarDesde.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendarDesde_DateSelected);
            // 
            // calendHasta
            // 
            this.calendHasta.Location = new System.Drawing.Point(426, 0);
            this.calendHasta.MaxSelectionCount = 1;
            this.calendHasta.Name = "calendHasta";
            this.calendHasta.TabIndex = 33;
            this.calendHasta.Visible = false;
            this.calendHasta.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendHasta_DateSelected);
            // 
            // dgvProv
            // 
            this.dgvProv.AllowUserToAddRows = false;
            this.dgvProv.AllowUserToDeleteRows = false;
            this.dgvProv.AllowUserToResizeColumns = false;
            this.dgvProv.AllowUserToResizeRows = false;
            this.dgvProv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProv.Location = new System.Drawing.Point(6, 19);
            this.dgvProv.Name = "dgvProv";
            this.dgvProv.ReadOnly = true;
            this.dgvProv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProv.Size = new System.Drawing.Size(845, 239);
            this.dgvProv.TabIndex = 32;
            // 
            // Facturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 454);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Facturar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Periodo Facturacion";
            this.Load += new System.EventHandler(this.BuscarParaFacturar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelecHasta;
        private System.Windows.Forms.TextBox txtFechaHasta;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.TextBox txtFechaDesde;
        private System.Windows.Forms.Button btnSelecDesde;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView dgvProv;
        private System.Windows.Forms.MonthCalendar calendHasta;
        private System.Windows.Forms.MonthCalendar calendarDesde;
        private System.Windows.Forms.Button btnBuscProv;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtBoxCuit;
        private System.Windows.Forms.Label lblTotal;

    }
}