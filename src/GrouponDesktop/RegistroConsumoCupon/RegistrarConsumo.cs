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
    public partial class RegistrarConsumo : Form
    {
        public int idProv = 0;

        public RegistrarConsumo()
        {
            InitializeComponent();
        }

        private void RegistrarConsumo_Load(object sender, EventArgs e)
        {
            RegistroConsumoCupon.Consumo_BuscarProv frmBuscarProv;

            idProv = Support.obtenerIdProveedor(Support.traerIdUsuario(Support.nombreUsuario));
            if (idProv == 0)
            {
                frmBuscarProv = new RegistroConsumoCupon.Consumo_BuscarProv(this);
                if (idProv == 0) this.Close();
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            dgvCupones.Columns.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Support.mostrarPregunta("¿Desea salir?", "Salir"))
            {
                this.Close();
            }
        }

        private void btn_B_Click(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            RegistroConsumoCupon.Consumo_BuscarCli frmBuscar = new RegistroConsumoCupon.Consumo_BuscarCli(this);
            frmBuscar.ShowDialog();
        }

    }
}
