namespace GrouponDesktop.RegistroConsumoCupon
{
    partial class RegistrarConsumo
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCupones = new System.Windows.Forms.DataGridView();
            this.gbFiltro.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCupones)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.btnLimpiar);
            this.gbFiltro.Controls.Add(this.btnCancelar);
            this.gbFiltro.Controls.Add(this.btnAceptar);
            this.gbFiltro.Controls.Add(this.txtCliente);
            this.gbFiltro.Controls.Add(this.lblCliente);
            this.gbFiltro.Location = new System.Drawing.Point(12, 15);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(814, 77);
            this.gbFiltro.TabIndex = 4;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtro";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(504, 37);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 23);
            this.btnLimpiar.TabIndex = 21;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(634, 37);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(376, 37);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 23);
            this.btnAceptar.TabIndex = 19;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(22, 37);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(178, 20);
            this.txtCliente.TabIndex = 15;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCliente.Location = new System.Drawing.Point(19, 16);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(53, 18);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCupones);
            this.groupBox1.Location = new System.Drawing.Point(9, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(823, 331);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cupones comprados";
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
            this.dgvCupones.Size = new System.Drawing.Size(811, 306);
            this.dgvCupones.TabIndex = 0;
            // 
            // RegistrarConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 444);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarConsumo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar consumo";
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCupones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCupones;
    }
}