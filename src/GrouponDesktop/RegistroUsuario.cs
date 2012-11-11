using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
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

            if (frmPadre.Name.Equals("Login"))
            {
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
        }


        private void RegistroUsuario_Load(object sender, EventArgs e)
        {
            //cmbRol.SelectedItem = "CLIENTE";
        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Dispose();
            frmPadre.Show();


        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            lblNomUsuario.ForeColor = System.Drawing.Color.Black;
            label2.ForeColor = System.Drawing.Color.Black;
            label3.ForeColor = System.Drawing.Color.Black;
            label4.ForeColor = System.Drawing.Color.Black;

            if (validarRegistro())
            {
                if (!nombreDuplicado(txtUser.Text.ToString()))
                {
                    if (cmbRol.SelectedItem.ToString().Equals("CLIENTE"))
                    {
                        AbmCliente.AltaCliente frmalta = new AbmCliente.AltaCliente(this);
                        frmalta.ShowDialog();
                    }
                    else
                    {
                        AbmProveedor.AltaProveedor frmalta = new AbmProveedor.AltaProveedor(this);
                        frmalta.ShowDialog();
                    }
                }
                else
                {
                    string strError = "El nombre de usuario elegido ya existe, elija otro";
                    Support.mostrarError(strError);
                }

            }

        }
        private bool validarRegistro()
        {
            bool validado = true;
            string strError = "";
            if (txtUser.Text.Length > 100 || txtUser.Text == "")
            {
                lblNomUsuario.ForeColor = System.Drawing.Color.Red;
                strError += "- La longitud del nombre de usuario es incorrecta\n";
                validado = false;
            }
            if (txtPass1.Text.Length < 8 || txtPass1.Text == "")
            {
                label2.ForeColor = System.Drawing.Color.Red;
                strError += "- La contraseña debe ser mayor a 8 caracteres\n";
                validado = false;
            }
            if (txtPass1.Text != txtPass2.Text)
            {
                label3.ForeColor = System.Drawing.Color.Red;
                strError += "- Las contraseñas ingresadas no coinciden\n";
                validado = false;
            }
            if (!validarRol(cmbRol.SelectedItem.ToString()))
            {
                label4.ForeColor = System.Drawing.Color.Red;
                strError += "- El Rol elegido esta inhabilitado\n";
                validado = false;
            }

            if (!validado) Support.mostrarError(strError);
            return validado;

        }
        private bool nombreDuplicado(string nombreUsuario)
        {
            bool duplicado = false;
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select  *
											from LOSGROSOS_RELOADED.Usuario
											where nombreUsuario=@usuario", dbcon);

            cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 100);
            cmd.Parameters["@usuario"].Value = nombreUsuario;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                dbcon.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }
            if (dt.Rows.Count > 0) duplicado = true;
            dbcon.Close();
            return duplicado;


        }
        private bool validarRol(string rol)
        {
            bool validado = true;
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select inhabilitado
                                            from LOSGROSOS_RELOADED.Rol
                                            where descripcion like @rol", dbcon);

            cmd.Parameters.Add("@rol", SqlDbType.VarChar, 100);
            cmd.Parameters["@rol"].Value = rol;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                dbcon.Open();
                da.Fill(dt);
            }

            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }
            if (dt.Rows[0]["inhabilitado"].ToString() == "1") validado = false;
            dbcon.Close();
            return validado;
        }


    }
}
