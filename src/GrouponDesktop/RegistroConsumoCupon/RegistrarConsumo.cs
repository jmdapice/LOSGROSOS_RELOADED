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
        public RegistrarConsumo()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            dgvCupones.Columns.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
