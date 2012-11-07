using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.AbmRoles
{
    public partial class ModRol : Form
    {
        public ModRol()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNomRol.Clear();
            dgvRoles.DataSource = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select descripcion as 'Nombre Rol' from LOSGROSOS_RELOADED.Rol
                                            where descripcion like '%'+@criterio+'%'", dbcon);
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar, 100);
            cmd.Parameters["@criterio"].Value = txtNomRol.Text.ToString();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            try
            {
                dbcon.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }

            dgvRoles.DataSource = dt;
            dgvRoles.AutoResizeColumns();

        }

        private void dgvRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbmRoles.ModRol2 frmModRol2 = new AbmRoles.ModRol2(this);
            frmModRol2.ShowDialog();
        }

    }
}
