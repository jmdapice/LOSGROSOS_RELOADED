using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.PublicarCupon
{
    public partial class Publicar_BuscarProv : AbmProveedor.BuscaProv
    {
        PublicarCupon frmPadre = null;
        public Publicar_BuscarProv(PublicarCupon frm)
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
                frmPadre.txtProveedor.Text = nombreUsuario;
                this.Close();
            }
        }

    }
}
