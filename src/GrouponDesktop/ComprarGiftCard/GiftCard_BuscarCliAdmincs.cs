using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.ComprarGiftCard
{
    public partial class GiftCard_BuscarCliAdmincs : GrouponDesktop.AbmCliente.ModCliente
    {
        Giftcard frmPadre = null;
        public GiftCard_BuscarCliAdmincs(Giftcard frm)
        {
            frmPadre = frm;
            InitializeComponent();
        }

        public override void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idCli = Support.obtenerIdCliente(Support.traerIdUsuario(dgvClientes.CurrentRow.Cells["Usuario"].Value.ToString()));

            if (!Support.clienteInhabilitado(idCli))
            {

                frmPadre.idCliOrigen = idCli;
                this.Close();

            }
            else
            {
                Support.mostrarError("El cliente esta inhabilitado. Elija otro");
            }

        }
    }
}
