using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.RegistroConsumoCupon
{
    public partial class Consumo_BuscarProv : AbmProveedor.BuscaProv
    {
        RegistroConsumoCupon.RegistrarConsumo frmPadre = null;
        public Consumo_BuscarProv(RegistroConsumoCupon.RegistrarConsumo frm)
        {
            frmPadre = frm;
            InitializeComponent();
        }

        public override void dgvProv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idProv = Support.obtenerIdProveedor(Support.traerIdUsuario(dgvProv.CurrentRow.Cells["Usuario"].Value.ToString()));

            if (Support.proveedorInhabilitado(idProv))
            {
                Support.mostrarError("El proveedor esta inhabilitado. Elija otro.");
            }
            else
            {
                frmPadre.idProv = idProv;
                this.Close();
            }
        }

    }
}
