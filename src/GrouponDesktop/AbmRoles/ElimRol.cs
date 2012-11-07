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
    public partial class ElimRol : Form
    {
        public ElimRol()
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
                                            where descripcion like '%'+@criterio+'%'
                                            and inhabilitado='0'", dbcon);
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
            if(MessageBox.Show(this, "Esta seguro que desea eliminar este Rol?", "Eliminar", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                inhabilitarRol(dgvRoles.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
        private void inhabilitarRol(string nombreRol)
        {

            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"update LOSGROSOS_RELOADED.Rol 
                                              set inhabilitado='1'
                                              where descripcion=@nomRol", dbcon);
            cmd.Parameters.Add("@nomRol", SqlDbType.VarChar, 100);
            cmd.Parameters["@nomRol"].Value = nombreRol;
            try
            {
                dbcon.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }

        }

       
    }
}
