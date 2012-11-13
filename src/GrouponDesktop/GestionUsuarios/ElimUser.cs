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
    public partial class ElimUser : BuscUsuario_Mod
    {
        
        public ElimUser()
        {
            base.mostrarInhab = false;
            InitializeComponent();
        }

        public override void dgvRoles_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Support.mostrarPregunta("¿Esta seguro que quiere eliminarlo?", "Eliminar Usuario"))
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                SqlCommand cmd = new SqlCommand(@"update LOSGROSOS_RELOADED.Usuario 
                                              set inhabilitado='1'
                                              where idUsuario=@idUser", dbcon);
                cmd.Parameters.Add("@idUser", SqlDbType.Int, 18);
                cmd.Parameters["@idUser"].Value = Convert.ToInt32(this.dgvUsers.CurrentRow.Cells["idUsuario"].Value);
                try
                {
                    dbcon.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Support.mostrarError(ex.Message);
                }
                dgvUsers.Columns.Clear();
            }
        }
    }
}
