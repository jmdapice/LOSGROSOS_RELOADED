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
    public partial class ModUser : Form
    {
        bool habPresionado = false;
        BuscUsuario_Mod frmPadre = null;
        public ModUser(BuscUsuario_Mod frm)
        {
            frmPadre = frm;
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
                cmd.Parameters["@idUser"].Value = Convert.ToInt32(frmPadre.dgvUsers.CurrentRow.Cells["idUsuario"].Value);
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

                if (habPresionado)
                {
                    actualizarHabilitado(dbcon);
                }
                frmPadre.dgvUsers.Columns.Clear();
                Support.mostrarInfo("Los cambios fueron guardados");
                this.Close();
            
            }
            
        }

        private bool validarRegistro()
        {
            bool validado = true;
            string strError = "";
   
            if (txtPass1.Text.Length < 8 && txtPass1.Text.Length >0)
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

        private void button1_Click(object sender, EventArgs e)
        {
            habPresionado = true;
            btnHabilitar.Text = "Habilitado";
            btnHabilitar.Enabled = false;
        }

        private void ModUser_Load(object sender, EventArgs e)
        {
            txtUser.Text = frmPadre.dgvUsers.CurrentRow.Cells["Nombre Usuario"].Value.ToString();
            if (frmPadre.dgvUsers.CurrentRow.Cells["inhab"].Value.ToString().Equals("1"))
            {
                btnHabilitar.Enabled = true;
                btnHabilitar.Text = "Habilitar";
            }
        }
        private void actualizarHabilitado(SqlConnection dbcon)
        {

            SqlCommand cmd = new SqlCommand(@"update LOSGROSOS_RELOADED.Usuario 
                                                  set inhabilitado='0'
                                                  where idUsuario = @usuario", dbcon);


            cmd.Parameters.Add("@usuario", SqlDbType.Int, 18);
            cmd.Parameters["@usuario"].Value = Convert.ToInt32(frmPadre.dgvUsers.CurrentRow.Cells["idUsuario"].Value);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }


        }
    }
}
