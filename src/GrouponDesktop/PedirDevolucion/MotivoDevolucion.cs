using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.PedirDevolucion
{
    public partial class MotivoDevolucion : Form
    {
        PedirDevolucion.Devolucion frmPadre = null;

        public MotivoDevolucion(PedirDevolucion.Devolucion frm)
        {
            frmPadre = frm;
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtDevolucion.Text == "")
            {
                Support.mostrarError("Debe completar el motivo de devolución");
            }
            else
            {
                frmPadre.motivoDevolucion = txtDevolucion.Text;
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            frmPadre.motivoDevolucion = "";
            txtDevolucion.Text = "";
        }

        private void MotivoDevolucion_Load(object sender, EventArgs e)
        {
            txtDevolucion.Text = "";
            frmPadre.motivoDevolucion = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Support.mostrarPregunta("¿Esta seguro que desea salir?\n En ese caso se cancelará la devolución", "Mensaje"))
            {
                frmPadre.motivoDevolucion = "";
                this.Close();
            }
        }
    }
}
