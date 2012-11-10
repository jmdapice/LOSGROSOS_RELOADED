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

        public void dgvClientes_CellDoubleClick2(object sender, DataGridViewCellEventArgs e)
        {
            mostrarInfo("hola");
        }


    }
}
