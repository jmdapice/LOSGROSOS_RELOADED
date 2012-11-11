using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.HistorialCupones
{
    public partial class historialCompra_BuscarCli : AbmCliente.ModCliente
    {
        HistorialCupones.historialCompras frmPadre = null;
        public historialCompra_BuscarCli(HistorialCupones.historialCompras frm)
        {
            frmPadre = frm;
            InitializeComponent();
        }

        public override void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int idCli = Support.obtenerIdCliente(Support.traerIdUsuario(dgvClientes.CurrentRow.Cells["Usuario"].Value.ToString()));

            if (!Support.clienteInhabilitado(idCli))
            {
                frmPadre.idCli = idCli;
                this.Close();
            }
            else
            {
                Support.mostrarError("El cliente esta inhabilitado. Elija otro");
            }

        }
    }
}
