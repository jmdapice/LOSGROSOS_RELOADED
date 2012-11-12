namespace GrouponDesktop.PublicarCupon
{
    partial class PublicarCupon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.btnSacarFiltro = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.dgvCupones = new System.Windows.Forms.DataGridView();
            this.gbFiltro.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCupones)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.btnSacarFiltro);
            this.gbFiltro.Controls.Add(this.btn_Buscar);
            this.gbFiltro.Controls.Add(this.btnCancelar);
            this.gbFiltro.Controls.Add(this.btnAplicar);
            this.gbFiltro.Controls.Add(this.txtProveedor);
            this.gbFiltro.Controls.Add(this.lblProveedor);
            this.gbFiltro.Location = new System.Drawing.Point(12, 15);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(872, 77);
            this.gbFiltro.TabIndex = 6;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtro opcional";
            // 
            // btnSacarFiltro
            // 
            this.btnSacarFiltro.Location = new System.Drawing.Point(584, 34);
            this.btnSacarFiltro.Name = "btnSacarFiltro";
            this.btnSacarFiltro.Size = new System.Drawing.Size(100, 23);
            this.btnSacarFiltro.TabIndex = 23;
            this.btnSacarFiltro.Text = "Sacar Filtro";
            this.btnSacarFiltro.UseVisualStyleBackColor = true;
            this.btnSacarFiltro.Click += new System.EventHandler(this.btnSacarFiltro_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(206, 34);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(100, 23);
            this.btn_Buscar.TabIndex = 22;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(714, 34);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(454, 34);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(100, 23);
            this.btnAplicar.TabIndex = 19;
            this.btnAplicar.Text = "Aplicar filtro";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // txtProveedor
            // 
            this.txtProveedor.Enabled = false;
            this.txtProveedor.Location = new System.Drawing.Point(22, 37);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(178, 20);
            this.txtProveedor.TabIndex = 15;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblProveedor.Location = new System.Drawing.Point(19, 16);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(77, 18);
            this.lblProveedor.TabIndex = 2;
            this.lblProveedor.Text = "Proveedor";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.dgvCupones);
            this.gbDatos.Location = new System.Drawing.Point(9, 98);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(875, 331);
            this.gbDatos.TabIndex = 5;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Cupones disponibles para publicar - Fecha: ";
            // 
            // dgvCupones
            // 
            this.dgvCupones.AllowUserToAddRows = false;
            this.dgvCupones.AllowUserToDeleteRows = false;
            this.dgvCupones.AllowUserToResizeRows = false;
            this.dgvCupones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCupones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCupones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCupones.Location = new System.Drawing.Point(6, 19);
            this.dgvCupones.MultiSelect = false;
            this.dgvCupones.Name = "dgvCupones";
            this.dgvCupones.ReadOnly = true;
            this.dgvCupones.RowHeadersVisible = false;
            this.dgvCupones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCupones.ShowEditingIcon = false;
            this.dgvCupones.Size = new System.Drawing.Size(863, 306);
            this.dgvCupones.TabIndex = 0;
            // 
            // PublicarCupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 444);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.gbDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PublicarCupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PublicarCupon";
            this.Load += new System.EventHandler(this.PublicarCupon_Load);
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCupones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Button btnSacarFiltro;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        public System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.DataGridView dgvCupones;
    }
}