using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.GestionUsuarios
{
    public partial class CambiarPass : Form
    {
       
        public CambiarPass()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.Black;
            label3.ForeColor = System.Drawing.Color.Black;
            if (validarRegistro())
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                SqlCommand cmd = new SqlCommand(@"UPDATE LOSGROSOS_RELOADED.Usuario
                                                  SET contrasena = @pass
                                                  WHERE idUsuario = @idUser", dbcon);
                cmd.Parameters.Add("@idUser", SqlDbType.Int, 18);
                cmd.Parameters.Add("@pass", SqlDbType.Char, 64);
                cmd.Parameters["@idUser"].Value = Support.traerIdUsuario(Support.nombreUsuario);
                cmd.Parameters["@pass"].Value = Support.GenerarSha256(this.txtPass1.Text);
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
                Support.mostrarInfo("La contraseña fue cambiada correctamente");
                this.Close();

            }

        }

        private bool validarRegistro()
        {
            bool validado = true;
            string strError = "";

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

            if (!validado) Support.mostrarError(strError);
            return validado;

        }
    }
}