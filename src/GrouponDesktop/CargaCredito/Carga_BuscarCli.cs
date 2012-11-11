using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.CargaCredito
{
    public partial class Carga_BuscarCli : GrouponDesktop.AbmCliente.ModCliente
    {
        CargaCredito frmPadre = null;

        public Carga_BuscarCli(CargaCredito frm)
        {
            frmPadre = frm;
            InitializeComponent();
        }

        public override void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombreUsuario = dgvClientes.CurrentRow.Cells["Usuario"].Value.ToString();

            if (!Support.clienteInhabilitado(Support.obtenerIdCliente(Support.traerIdUsuario(nombreUsuario))))
            {

                frmPadre.nombreUsuario = nombreUsuario;
                this.Close();
            }
            else
            {
                Support.mostrarError("El cliente se encuentra inhabilitado. Elija otro");
            }

        }
    }
}
