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
    public partial class Carat : Form
    {
        public Carat()
        {
            InitializeComponent();
        }

        private void ts_salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Mensaje", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();    
            }
        
        }

        private void ts_registrarVentas_Click(object sender, EventArgs e)
        {
            Registrar_venta form_vta = new Registrar_venta();
            form_vta.ShowDialog();
        }

        private void registrarCobroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_cobro form_cobro = new Registrar_cobro();
            form_cobro.ShowDialog();
        }


    }
}
