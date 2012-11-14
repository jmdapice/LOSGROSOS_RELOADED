namespace GrouponDesktop.HistorialCupones
{
    partial class historialCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.calendHasta = new System.Windows.Forms.MonthCalendar();
            this.calendDesde = new System.Windows.Forms.MonthCalendar();
            this.dgvCupones = new System.Windows.Forms.DataGridView();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.btnSelecHasta = new System.Windows.Forms.Button();
            this.txtFechaHasta = new System.Windows.Forms.TextBox();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.txtFechaDesde = new System.Windows.Forms.TextBox();
            this.btnSelecDesde = new System.Windows.Forms.Button();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCupones)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.calendHasta);
            this.groupBox1.Controls.Add(this.calendDesde);
            this.groupBox1.Controls.Add(this.dgvCupones);
            this.groupBox1.Location = new System.Drawing.Point(9, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(823, 277);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Historial de compras";
            // 
            // calendHasta
            // 
            this.calendHasta.Location = new System.Drawing.Point(414, 19);
            this.calendHasta.MaxSelectionCount = 1;
            this.calendHasta.Name = "calendHasta";
            this.calendHasta.TabIndex = 15;
            this.calendHasta.Visible = false;
            this.calendHasta.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendHasta_DateChanged);
            // 
            // calendDesde
            // 
            this.calendDesde.Location = new System.Drawing.Point(12, 19);
            this.calendDesde.MaxSelectionCount = 1;
            this.calendDesde.Name = "calendDesde";
            this.calendDesde.TabIndex = 14;
            this.calendDesde.Visible = false;
            this.calendDesde.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendDesde_DateSelected);
            // 
            // dgvCupones
            // 
            this.dgvCupones.AllowUserToAddRows = false;
            this.dgvCupones.AllowUserToDeleteRows = false;
            this.dgvCupones.AllowUserToResizeRows = false;
            this.dgvCupones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCupones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCupones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCupones.Location = new System.Drawing.Point(6, 19);
            this.dgvCupones.MultiSelect = false;
            this.dgvCupones.Name = "dgvCupones";
            this.dgvCupones.ReadOnly = true;
            this.dgvCupones.RowHeadersVisible = false;
            this.dgvCupones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCupones.ShowEditingIcon = false;
            this.dgvCupones.Size = new System.Drawing.Size(811, 252);
            this.dgvCupones.TabIndex = 0;
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.btnSelecHasta);
            this.gbFiltro.Controls.Add(this.txtFechaHasta);
            this.gbFiltro.Controls.Add(this.lblFechaHasta);
            this.gbFiltro.Controls.Add(this.txtFechaDesde);
            this.gbFiltro.Controls.Add(this.btnSelecDesde);
            this.gbFiltro.Controls.Add(this.lblFechaDesde);
            this.gbFiltro.Location = new System.Drawing.Point(12, 12);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(814, 83);
            this.gbFiltro.TabIndex = 2;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtro";
            // 
            // btnSelecHasta
            // 
            this.btnSelecHasta.Location = new System.Drawing.Point(605, 34);
            this.btnSelecHasta.Name = "btnSelecHasta";
            this.btnSelecHasta.Size = new System.Drawing.Size(75, 23);
            this.btnSelecHasta.TabIndex = 18;
            this.btnSelecHasta.Text = "Seleccionar";
            this.btnSelecHasta.UseVisualStyleBackColor = true;
            this.btnSelecHasta.Click += new System.EventHandler(this.btnSelecHasta_Click);
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Enabled = false;
            this.txtFechaHasta.Location = new System.Drawing.Point(421, 37);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(178, 20);
            this.txtFechaHasta.TabIndex = 17;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblFechaHasta.Location = new System.Drawing.Point(418, 16);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(164, 18);
            this.lblFechaHasta.TabIndex = 16;
            this.lblFechaHasta.Text = "Fecha de compra hasta";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Enabled = false;
            this.txtFechaDesde.Location = new System.Drawing.Point(22, 37);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(178, 20);
            this.txtFechaDesde.TabIndex = 15;
            // 
            // btnSelecDesde
            // 
            this.btnSelecDesde.Location = new System.Drawing.Point(206, 37);
            this.btnSelecDesde.Name = "btnSelecDesde";
            this.btnSelecDesde.Size = new System.Drawing.Size(75, 23);
            this.btnSelecDesde.TabIndex = 14;
            this.btnSelecDesde.Text = "Seleccionar";
            this.btnSelecDesde.UseVisualStyleBackColor = true;
            this.btnSelecDesde.Click += new System.EventHandler(this.btnSelecDesde_Click);
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblFechaDesde.Location = new System.Drawing.Point(19, 16);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(168, 18);
            this.lblFechaDesde.TabIndex = 2;
            this.lblFechaDesde.Text = "Fecha de compra desde";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(370, 384);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 23);
            this.btnLimpiar.TabIndex = 21;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(476, 384);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(264, 384);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 23);
            this.btnAceptar.TabIndex = 19;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // historialCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 422);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "historialCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial de compras";
            this.Load += new System.EventHandler(this.historialCompras_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCupones)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCupones;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Button btnSelecDesde;
        private System.Windows.Forms.TextBox txtFechaDesde;
        private System.Windows.Forms.TextBox txtFechaHasta;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.Button btnSelecHasta;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.MonthCalendar calendDesde;
        private System.Windows.Forms.MonthCalendar calendHasta;
    }
}