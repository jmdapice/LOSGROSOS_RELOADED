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
    public partial class frmBuscarCli : GrouponDesktop.AbmCliente.ModCliente
    {
        Giftcard frmPadre = null;
        public frmBuscarCli(Giftcard frm)
        {
            frmPadre = frm;
            InitializeComponent();
        }

        private void GiftCard_BuscarCli_Load(object sender, EventArgs e)
        {

        }

        public override void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmPadre.txtDestino.Text = dgvClientes.CurrentRow.Cells["Usuario"].Value.ToString();
            this.Close();
            
        }
    }
}
