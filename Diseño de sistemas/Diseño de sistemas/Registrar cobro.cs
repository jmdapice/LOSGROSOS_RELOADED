using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diseño_de_sistemas
{
    public partial class Registrar_cobro : Form
    {
        public Registrar_cobro()
        {
            InitializeComponent();
        }

        private void Registrar_cobro_Load(object sender, EventArgs e)
        {
            cb_medioPago.SelectedIndex = 0;
            tb_remito.Text = "";
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            string registrado_venta = "Se ha registrado el cobro con éxito.\nEl número de factura es el " + soporte.codigo_factura;

            if (camposObligatoriosCompletados())
            {
                MessageBox.Show(registrado_venta, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cb_medioPago.SelectedIndex = 0;
                tb_remito.Text = "";
                soporte.codigo_factura++;
            }
        }

        private bool camposObligatoriosCompletados()
        {
            bool camposValidados = true;
            string str_errores = "Han ocurrido los siguientes errores:\n";

            if (tb_remito.Text == "")
            {
                str_errores += "-Por favor complete el campo 'Código de artículo'\n";
                lbl_remito.ForeColor = Color.Red;
                camposValidados = false;
            }
            else
            {
                lbl_remito.ForeColor = Color.Black;
            }

            if (cb_medioPago.SelectedItem == "" || ( cb_medioPago.SelectedItem != "Efectivo"
                && cb_medioPago.SelectedItem != "Débito" && cb_medioPago.SelectedItem != "Crédito"))
            {
                str_errores += "-El medio de pago no es válido";
                lbl_medioPago.ForeColor = Color.Red;
                camposValidados = false;
            }
            else
            {
                lbl_medioPago.ForeColor = Color.Black;
            }

            if (!camposValidados) MessageBox.Show(str_errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return camposValidados;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cancelar la operación? Se perderan los datos no guardados.", "Mensaje", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

    }
}
