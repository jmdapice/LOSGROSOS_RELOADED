using System;
using System.Collections.Generic;
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
            string usuario=txtUsuario.Text.ToString();
            string pass = GenerarSha256(txtPass.Text.ToString());
            string descripRol = "";
            usuario = usuario.ToLower();
            pass = pass.ToLower();
            
            SqlConnection dbcon = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2012;Persist Security Info=True;User ID=gd;Password=gd2012");
            SqlCommand cmd = new SqlCommand(@"Select b.descripcion 
                                            from LOSGROSOS_RELOADED.Usuario a,LOSGROSOS_RELOADED.Rol b 
                                            where a.nombreUsuario=@usuario 
                                            and a.contrasena=@pass and b.idRol=a.idRol", dbcon);
            
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@pass", SqlDbType.Char, 64);
            cmd.Parameters["@usuario"].Value = usuario;
            cmd.Parameters["@pass"].Value = pass;
            
            dbcon.Open();
            
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                descripRol = dr.GetSqlString(0).ToString();
                MessageBox.Show(string.Format("Bienvenido al sistema.\n\n Su nivel de acceso es: {0}", descripRol));
                AbmCliente.AbmCliente frmAbmCliente = new AbmCliente.AbmCliente(); //namespace.class nombreObjeto = mensaje namespace.class
                frmAbmCliente.Show();
                
            }
            else
                MessageBox.Show("Nombre de usuario y/o contraseña incorrectos");
            


        }
    }
}
