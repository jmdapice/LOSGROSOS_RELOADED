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
    public partial class Registrar_venta : Form
    {
        public Registrar_venta()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cancelar la operación? Se perderan los datos no guardados.", "Mensaje", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            string registrado_venta = "Se ha registrado la venta con éxito.\nEl código de remito generado es el " + soporte.codigo_remito;

            if (camposObligatoriosCompletados()) {
                MessageBox.Show(registrado_venta,"Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                tb_cant.Text = "";
                tb_codart.Text = "";
                soporte.codigo_remito++;
            }
        }

        private bool camposObligatoriosCompletados()
        {
            bool camposValidados = true;
            string str_errores = "Han ocurrido los siguientes errores:\n";

            if (tb_codart.Text == "")
            {
                str_errores += "-Por favor complete el campo 'Código de artículo'\n";
                lbl_codart.ForeColor = Color.Red;
                camposValidados = false;
            }else{
                lbl_codart.ForeColor = Color.Black;
            }

            if (tb_cant.Text == "")
            {
                str_errores += "-Por favor complete el campo 'Cantidad vendida'";
                lbl_cant.ForeColor = Color.Red;
                camposValidados = false;
            }
            else
            {
                lbl_cant.ForeColor = Color.Black;
            }    

            if (!camposValidados) MessageBox.Show(str_errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return camposValidados;
        }

        private void Registrar_venta_Load(object sender, EventArgs e)
        {
            tb_codart.Text = "";
            tb_cant.Text = "";
        }
    }
}
