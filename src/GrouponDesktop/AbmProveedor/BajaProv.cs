using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.AbmProveedor
{
    public partial class BajaProv : BuscaProv
    {
        public BajaProv()
        {
            base.ocultarInhab = true;
            InitializeComponent();
        }

        public override void dgvProv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Support.mostrarPregunta("Esta seguro que desea eliminar este Proveedor?", "Eliminar Proveedor"))
            {
                eliminarProv(Convert.ToInt32(dgvProv.CurrentRow.Cells["id"].Value));
                dgvProv.Columns.Clear();
                
            }

        }
        private void eliminarProv(int idProv)
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"EXEC [LOSGROSOS_RELOADED].[P_HabilitacionProveedor] @idProv,'1'", dbcon);
            cmd.Parameters.Add("@idProv", SqlDbType.Int, 100);
            cmd.Parameters["@idProv"].Value = idProv;
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

        private void BajaProv_Load(object sender, EventArgs e)
        {



        }

    }
}
