using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.GestionUsuarios
{
    public partial class BuscUsuario_Mod : Form
    {
        public bool mostrarInhab = true;
        
        public BuscUsuario_Mod()
        {
            InitializeComponent();
        }
        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtNomUser.Clear();
            dgvUsers.DataSource = null;
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select nombreUsuario as 'Nombre Usuario',idUsuario,inhabilitado as 'inhab' from LOSGROSOS_RELOADED.Usuario
                                            where nombreUsuario like '%'+@criterio+'%'", dbcon);
            
            cmd.Parameters.Add("@criterio", SqlDbType.VarChar, 100);
            cmd.Parameters["@criterio"].Value = txtNomUser.Text.ToString();
            if(!mostrarInhab)
            {
                cmd.CommandText += " and inhabilitado='0'";
            }
            
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

            dgvUsers.DataSource = dt;
            dgvUsers.Columns["idUsuario"].Visible = false;
            dgvUsers.Columns["inhab"].Visible = false;
            dgvUsers.AutoResizeColumns();

        }


        public virtual void dgvRoles_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ModUser frm = new ModUser(this);
            frm.ShowDialog();
        }




    }
}
