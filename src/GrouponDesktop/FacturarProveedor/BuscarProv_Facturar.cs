using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.FacturarProveedor
{
    public partial class BuscarProv_Facturar : AbmProveedor.BuscaProv
    {
        Facturar frmPadre = null;
        public BuscarProv_Facturar(Facturar frm)
        {
            frmPadre = frm;
            InitializeComponent();
        }


        public override void dgvProv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombreUsuario = dgvProv.CurrentRow.Cells["Usuario"].Value.ToString();

            if (Support.proveedorInhabilitado(Support.obtenerIdProveedor(Support.traerIdUsuario(nombreUsuario))))
            {
                Support.mostrarError("El proveedor esta inhabilitado. Elija otro.");
            }
            else
            {
                Support.idProv = Convert.ToInt32(dgvProv.CurrentRow.Cells["id"].Value);
                frmPadre.txtBoxCuit.Text = dgvProv.CurrentRow.Cells["CUIT"].Value.ToString();
                this.Close();
            }
        }
    }
}
