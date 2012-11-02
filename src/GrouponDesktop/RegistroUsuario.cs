using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop
{
    public partial class RegistroUsuario : Form
    {
        Form frmPadre = null;
        public RegistroUsuario(Form frm)
        {
            frmPadre = frm;
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Cancelar Registro?", "Cancelar", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    this.btnCancelar_Click(this, e);
                    break;
                default:
                    break;
            }
        }
        
        
        private void RegistroUsuario_Load(object sender, EventArgs e)
        {
            cmbRol.SelectedItem = "CLIENTE";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            this.DestroyHandle();
            frmPadre.Show();
            
     
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            if (cmbRol.SelectedItem.ToString().Equals("CLIENTE"))
            {
                AbmCliente.AbmCliente frmalta = new AbmCliente.AbmCliente();
                frmalta.ShowDialog();
            }
            else
            {
                //formaltaprovee
            }

        }

       
    }
}
