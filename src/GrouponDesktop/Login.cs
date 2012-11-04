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
            string pass = Support.GenerarSha256(txtPass.Text.ToString());

            usuario = usuario.ToLower();
            
            if (this.existeUsuario(usuario))
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                SqlCommand cmd = new SqlCommand(@"Select a.intentosFallidos, a.inhabilitado as inhabUser,a.idRol 
                                            from LOSGROSOS_RELOADED.Usuario a
                                            where a.nombreUsuario=@usuario 
                                            and a.contrasena=@pass ", dbcon);

                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@pass", SqlDbType.Char, 64);
                cmd.Parameters["@usuario"].Value = usuario;
                cmd.Parameters["@pass"].Value = pass;


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
                
                
                if (dt.Rows.Count > 0)
                {
                    if ((dt.Rows[0]["inhabUser"].ToString() == "1") )
                    {

                        Support.mostrarError("Su usuario esta inhabilitado");
                    }
                    else
                    {

                        cmd.CommandText = @"update LOSGROSOS_RELOADED.Usuario 
                                                  set intentosFallidos = 0
                                                  where nombreUsuario = @usuario";
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Support.mostrarError(ex.Message);
                        }

                        Support.nombreUsuario = usuario;
                        Support.idRol = Convert.ToInt32(dt.Rows[0]["idRol"]);

                        MenuPrincipal frmPrincipal = new MenuPrincipal();
                        frmPrincipal.Show();
                        this.Hide();
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
                        Support.mostrarError(ex.Message);
                    }

                    Support.mostrarError("La contraseña ingresada es incorrecta");
                }
                dbcon.Close();
            }
            else
            {
                Support.mostrarError("El nombre de usuario ingresado es incorrecto");
            }
            
        }
        
        
        private bool existeUsuario(string usuario)
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
           
            SqlCommand cmd = new SqlCommand(@"Select 1 
                                            from LOSGROSOS_RELOADED.Usuario a,LOSGROSOS_RELOADED.Rol b 
                                            where a.nombreUsuario=@usuario", dbcon);

            cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 100);
            cmd.Parameters["@usuario"].Value = usuario;
          
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
