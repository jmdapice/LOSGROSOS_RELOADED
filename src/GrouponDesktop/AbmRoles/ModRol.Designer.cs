namespace GrouponDesktop.AbmRoles
{
    partial class ModRol
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
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblNombreRol = new System.Windows.Forms.Label();
            this.txtNomRol = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grpRolModif = new System.Windows.Forms.GroupBox();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.grpFiltros.SuspendLayout();
            this.grpRolModif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.lblNombreRol);
            this.grpFiltros.Controls.Add(this.txtNomRol);
            this.grpFiltros.Location = new System.Drawing.Point(12, 12);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(298, 92);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Buscar por:";
            // 
            // lblNombreRol
            // 
            this.lblNombreRol.AutoSize = true;
            this.lblNombreRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblNombreRol.Location = new System.Drawing.Point(6, 35);
            this.lblNombreRol.Name = "lblNombreRol";
            this.lblNombreRol.Size = new System.Drawing.Size(113, 18);
            this.lblNombreRol.TabIndex = 1;
            this.lblNombreRol.Text = "Nombre de Rol ";
            // 
            // txtNomRol
            // 
            this.txtNomRol.Location = new System.Drawing.Point(6, 56);
            this.txtNomRol.Name = "txtNomRol";
            this.txtNomRol.Size = new System.Drawing.Size(164, 20);
            this.txtNomRol.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(12, 110);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(210, 110);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 23);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // grpRolModif
            // 
            this.grpRolModif.Controls.Add(this.dgvRoles);
            this.grpRolModif.Location = new System.Drawing.Point(12, 148);
            this.grpRolModif.Name = "grpRolModif";
            this.grpRolModif.Size = new System.Drawing.Size(298, 162);
            this.grpRolModif.TabIndex = 3;
            this.grpRolModif.TabStop = false;
            this.grpRolModif.Text = "Elija el Rol que desea modificar:";
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Location = new System.Drawing.Point(7, 20);
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.Size = new System.Drawing.Size(285, 136);
            this.dgvRoles.TabIndex = 0;
            this.dgvRoles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellDoubleClick);
            // 
            // ModRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 322);
            this.Controls.Add(this.grpRolModif);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.grpFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Rol";
           
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.grpRolModif.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblNombreRol;
        private System.Windows.Forms.TextBox txtNomRol;
        private System.Windows.Forms.GroupBox grpRolModif;
        public System.Windows.Forms.DataGridView dgvRoles;
    }
}