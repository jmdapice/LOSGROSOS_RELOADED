using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using GrouponDesktop.Properties;

namespace GrouponDesktop
{
    public partial class Login : Form
    {
        
        
        //esto habria q ponerlo en otra clase
        public static string byteArrayToString(byte[] inputArray)
        {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }
            return output.ToString();
        }

        public static string GenerarSha256(string phrase)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(phrase));
            return byteArrayToString(hashedDataBytes);
        }
        //----------------------------------------
        
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            SHA256 hash = new SHA256Managed();
            string usuario = txtUsuario.Text.ToString();
            string pass = GenerarSha256(txtPass.Text.ToString());
            string descripRol = "";
            usuario = usuario.ToLower();



            if (this.existeUsuario(usuario))
            {

                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                dbcon.Open();
                SqlCommand cmd = new SqlCommand(@"Select a.intentosFallidos, a.inhabilitado as inhabUser, b.inhabilitado as inhabRol, b.descripcion 
                                            from LOSGROSOS_RELOADED.Usuario a,LOSGROSOS_RELOADED.Rol b 
                                            where a.nombreUsuario=@usuario 
                                            and a.contrasena=@pass and b.idRol=a.idRol", dbcon);

                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@pass", SqlDbType.Char, 64);
                cmd.Parameters["@usuario"].Value = usuario;
                cmd.Parameters["@pass"].Value = pass;


                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    if ((dt.Rows[0]["inhabUser"].ToString() == "1") || (dt.Rows[0]["inhabRol"].ToString() == "1"))
                    {

                        MessageBox.Show("Su usuario esta inhabilitado");
                    }
                    else
                    {

                        cmd.CommandText = @"update LOSGROSOS_RELOADED.Usuario 
                                                  set intentosFallidos = 0
                                                  where nombreUsuario = @usuario";
                        cmd.ExecuteNonQuery();
                        descripRol = dt.Rows[0]["descripcion"].ToString();
                        MessageBox.Show(string.Format("Bienvenido al sistema.\n\n Su nivel de acceso es: {0}", descripRol));

                        Variables_globales.nombreUsuario = usuario;

                        CargaCredito.CargaCredito Formcarga = new CargaCredito.CargaCredito();

                        Formcarga.ShowDialog();

                        //Abrir Menu segun Rol
                    }

                }
                else
                {
                    cmd.CommandText = @"update LOSGROSOS_RELOADED.Usuario 
                                                  set intentosFallidos = intentosFallidos + 1
                                                  where nombreUsuario = @usuario";
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex) //Capturar excepcion
                    {
                        MessageBox.Show("Se ha producido un error: " + ex.Message.ToString());
                    }

                    MessageBox.Show("La contraseña ingresada es incorrecta");
                }
                dbcon.Close();
            }
            else
            {
                MessageBox.Show("El nombre de usuario ingresado es incorrecto");
            }
            
        }
        
        
        private bool existeUsuario(string usuario)
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            dbcon.Open();
            SqlCommand cmd = new SqlCommand(@"Select 1 
                                            from LOSGROSOS_RELOADED.Usuario a,LOSGROSOS_RELOADED.Rol b 
                                            where a.nombreUsuario=@usuario", dbcon);

            cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 100);
            cmd.Parameters["@usuario"].Value = usuario;
          
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dbcon.Close();

            return (dt.Rows.Count > 0);
       
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            RegistroUsuario frmRegistro = new RegistroUsuario(this);
            this.Hide();
            frmRegistro.Show();
            CargaCredito.CargaCredito frmCC = new CargaCredito.CargaCredito();
            frmCC.Show();
        }
    }
}
