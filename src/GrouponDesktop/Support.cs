using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using GrouponDesktop.Properties;
using System.Configuration;

namespace GrouponDesktop
{
    class Support
    {

//Aca se definen las variables globales
        public static string nombreUsuario;
        public static int idRol;
        public static float saldoBienvenida = 10;
        public static void mostrarError(string str)
        {
            MessageBox.Show(str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void mostrarInfo(string str) 
        {
            MessageBox.Show(str, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool mostrarPregunta(string pregunta, string titulo)
        {
            return (MessageBox.Show(pregunta, titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK);
        }

        public static void mostrarAdvertencia(string str)
        {
            MessageBox.Show(str, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

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

        public static int obtenerFechaInt(DateTime fecha)
        {
            return (fecha.Year * 10000 + fecha.Month * 100 + fecha.Day);
        }

        public static DateTime fechaConfig()
        {
            return Convert.ToDateTime(GrouponDesktop.Properties.Settings.Default["fechaConfig"]);
        }

        public static bool verificarCliente()
        {
            int idUsuario = 0;
            int idCli = 0;

            try
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                dbcon.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT idUsuario
                                                  FROM LOSGROSOS_RELOADED.Usuario
                                                  WHERE  nombreUsuario = @nombreUsuario", dbcon);

                cmd.Parameters.Add("@nombreUsuario", SqlDbType.NVarChar, 100);
                cmd.Parameters["@nombreUsuario"].Value = Support.nombreUsuario;



                idUsuario = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = @"SELECT idCli
                                    FROM LOSGROSOS_RELOADED.Clientes
                                    WHERE idUsuario = @idUsuario";

                cmd.Parameters.Add("@idUsuario", SqlDbType.Int, 18);
                cmd.Parameters["@idUsuario"].Value = idUsuario;

                idCli = Convert.ToInt32(cmd.ExecuteScalar());

                dbcon.Close();

                if (idCli == 0)
                {
                    Support.mostrarError("El usuario no pertenece a un cliente");
                    return false;
                }
                else
                {

                    if(Support.clienteInhabilitado(idCli))
                    {
                        Support.mostrarError("El cliente esta inhabilitado");
                        return false;                
                    }
                    
                }

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message.ToString());
                return false;
            }

            return true;
        }

        public static bool clienteInhabilitado(int idCli)
        {

            string inhabilitado = "";

            try
            {

                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                dbcon.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT inhabilitado
                                                  FROM LOSGROSOS_RELOADED.Clientes
                                                  WHERE idCli = @idCli", dbcon);

                cmd.Parameters.Add("@idCli", SqlDbType.Int, 18);
                cmd.Parameters["@idCli"].Value = idCli;

                inhabilitado = Convert.ToString(cmd.ExecuteScalar());

                dbcon.Close();

                if (inhabilitado.Equals("1"))
                {
                    return true;
                }


            }
            catch (Exception ex) 
            {
                Support.mostrarError(ex.Message.ToString());
                return true;
            }

            return false;

        }

        public static int traerIdUsuario(string nombreUsuario)
        {
            int idUser = 0;

            try
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                dbcon.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT idUsuario
                                                  FROM LOSGROSOS_RELOADED.Usuario
                                                  WHERE  nombreUsuario = @nombreUsuario", dbcon);

                cmd.Parameters.Add("@nombreUsuario", SqlDbType.NVarChar, 100);
                cmd.Parameters["@nombreUsuario"].Value = nombreUsuario;

                idUser = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message.ToString());
            }

            return idUser;
        }

        public static int obtenerIdCliente(int idUser)
        {

            int idCliente = 0;
            try
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                dbcon.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT idCli
                                                  FROM LOSGROSOS_RELOADED.Clientes
                                                  WHERE idUsuario = @idUser", dbcon);

                cmd.Parameters.Add("@idUser", SqlDbType.NVarChar, 20);
                cmd.Parameters["@idUser"].Value = idUser;



                idCliente = Convert.ToInt16(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message.ToString());
            }

            return idCliente;
        }
        
        public static bool esNumerico(string str)
        {            
            double Num;
            return double.TryParse(str.Trim(), out Num);
        }
        public static int agregarUsuario(SqlConnection dbcon,int idRol,string password,string username)
        {
            SqlCommand cmd = new SqlCommand(@"insert into LOSGROSOS_RELOADED.Usuario 
                                            (nombreUsuario,contrasena,idRol)
                                            values (@nombre,@pass,@idRol)", dbcon);

            string pass = Support.GenerarSha256(password);
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100);
            cmd.Parameters["@nombre"].Value = username;
            cmd.Parameters.Add("@pass", SqlDbType.Char, 64);
            cmd.Parameters["@pass"].Value = pass;
            cmd.Parameters.Add("@idRol", SqlDbType.Int, 18);
            cmd.Parameters["@idRol"].Value = idRol;

            int idNuevoUser = 0;
            try
            {

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }


            cmd.CommandText = @"select idUsuario from LOSGROSOS_RELOADED.Usuario
                                    where nombreUsuario=@nombre";

            try
            {

                idNuevoUser = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }

            return idNuevoUser;
        }


        public static int obtenerIdProveedor(string idUser)
        {
            int idProveedor = 0;

            try
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                dbcon.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT idProveedor
                                                  FROM LOSGROSOS_RELOADED.Proveedor
                                                  WHERE idUsuario = @idUser", dbcon);

                cmd.Parameters.Add("@idUser", SqlDbType.NVarChar, 20);
                cmd.Parameters["@idUser"].Value = idUser;



                idProveedor = Convert.ToInt16(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message.ToString());
            }

            return idProveedor;

        }


    }
}
