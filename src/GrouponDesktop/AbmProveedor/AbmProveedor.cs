using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.AbmProveedor
{
    public partial class AbmProveedor : Form
    {
        public AbmProveedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validar Campos
            //Verificar si existen razonSocial o Cuit en la db
            //Hacer insert usando stored procedure
            //Descargar Form (llamado con showdialog desde el form de registroUsuario)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //no hay que mostrar el form anterior, este se invoca con showdialog
            this.DestroyHandle();
        }
    }
}
