namespace GrouponDesktop.AbmProveedor
{
    partial class BuscaProv
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
            this.dgvProv = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblApe = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtRazSoc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProv
            // 
            this.dgvProv.AllowUserToAddRows = false;
            this.dgvProv.AllowUserToDeleteRows = false;
            this.dgvProv.AllowUserToResizeColumns = false;
            this.dgvProv.AllowUserToResizeRows = false;
            this.dgvProv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProv.Location = new System.Drawing.Point(12, 220);
            this.dgvProv.Name = "dgvProv";
            this.dgvProv.ReadOnly = true;
            this.dgvProv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProv.Size = new System.Drawing.Size(867, 232);
            this.dgvProv.TabIndex = 10;
            this.dgvProv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProv_CellContentDoubleClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(779, 180);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 23);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 180);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 23);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.txtCuit);
            this.groupBox1.Controls.Add(this.lblDni);
            this.groupBox1.Controls.Add(this.lblApe);
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtRazSoc);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(867, 162);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Por";
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(341, 58);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(200, 20);
            this.txtCuit.TabIndex = 9;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDni.Location = new System.Drawing.Point(338, 36);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(175, 18);
            this.lblDni.TabIndex = 8;
            this.lblDni.Text = "CUIT (Ej: 20-30456789-9)";
            // 
            // lblApe
            // 
            this.lblApe.AutoSize = true;
            this.lblApe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblApe.Location = new System.Drawing.Point(13, 102);
            this.lblApe.Name = "lblApe";
            this.lblApe.Size = new System.Drawing.Size(35, 18);
            this.lblApe.TabIndex = 6;
            this.lblApe.Text = "Mail";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(13, 123);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(200, 20);
            this.txtMail.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblNombre.Location = new System.Drawing.Point(10, 36);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(97, 18);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Razon Social";
            // 
            // txtRazSoc
            // 
            this.txtRazSoc.Location = new System.Drawing.Point(10, 57);
            this.txtRazSoc.Name = "txtRazSoc";
            this.txtRazSoc.Size = new System.Drawing.Size(200, 20);
            this.txtRazSoc.TabIndex = 0;
            // 
            // BuscaProv
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 464);
            this.Controls.Add(this.dgvProv);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscaProv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Busca Proveedor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvProv;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblApe;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtRazSoc;
        private System.Windows.Forms.TextBox txtCuit;
    }
}