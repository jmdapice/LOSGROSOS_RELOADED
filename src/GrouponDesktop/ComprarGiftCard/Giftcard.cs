using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using GrouponDesktop.Properties;
using System.Configuration;

namespace GrouponDesktop.ComprarGiftCard
{
    public partial class Giftcard : Form
    {
        private static int regaloMinimo;
        private static int regaloMaximo;
        private static int idUserDestino;
        private static int idUserOrigen;
        private static int idCliDestino;
        public int idCliOrigen = 0;

        public Giftcard()
        {
            InitializeComponent();
        }

        private void Giftcard_Load(object sender, EventArgs e)
        {

            GiftCard_BuscarCliAdmincs frmBuscar;

            
            lblDestino.ForeColor = System.Drawing.Color.Black;
            lblMonto.ForeColor = System.Drawing.Color.Black;

            regaloMinimo = obtenerSaldo("giftcard_min");
            regaloMaximo = obtenerSaldo("giftcard_max");

            numMonto.Maximum = regaloMaximo;
            numMonto.Minimum = regaloMinimo;
            

            lblRangoSaldo.Text = "El monto debe estar entre los valores " +
                                 Convert.ToString(regaloMinimo)
                                 + " y " + Convert.ToString(regaloMaximo) + ".";

            idCliOrigen = Support.obtenerIdCliente(Support.traerIdUsuario(Support.nombreUsuario));
            if (idCliOrigen == 0)
            {
                frmBuscar = new GiftCard_BuscarCliAdmincs(this);
                frmBuscar.ShowDialog(this);
                if (idCliOrigen == 0) this.Close();
            }
            else if(Support.clienteInhabilitado(idCliOrigen))
            {
                Support.mostrarError("Usted se encuentra inhabilitado");
                this.Close();
            }

            idUserOrigen = Support.traerIdUsuario(Support.nombreUsuario);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            idCliDestino = Support.obtenerIdCliente(Support.traerIdUsuario(txtDestino.Text));

            if (!existenErrores()) 
            {

                try
                {

                    if (validarCompraGiftCard(idCliOrigen, idCliDestino))
                    {
                        SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                        dbcon.Open();
                        SqlCommand cmd = new SqlCommand(@"INSERT INTO 
                                                      LOSGROSOS_RELOADED.GiftCard
                                                      (idCliOrigen,idCliDestino,fecha,monto)
                                                      values 
                                                      (@idCliOrigen, @idCliDestino, @fecha, @monto)", dbcon);

                        cmd.Parameters.Add("@idCliOrigen", SqlDbType.Int, 18);
                        cmd.Parameters.Add("@idCliDestino", SqlDbType.Int, 18);
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime, 20);
                        cmd.Parameters.Add("@monto", SqlDbType.Money);

                        cmd.Parameters["@idCliOrigen"].Value = idCliOrigen;
                        cmd.Parameters["@idCliDestino"].Value = idCliDestino;
                        cmd.Parameters["@fecha"].Value = Support.fechaConfig();
                        cmd.Parameters["@monto"].Value = Convert.ToDecimal(numMonto.Value);

                        cmd.ExecuteNonQuery();

                        Support.mostrarInfo("Se le han cargado $" + numMonto.Value.ToString() + " al usuario " + txtDestino.Text);

                        borrar_pantalla();
                    }
                }
                catch (Exception ex)
                {
                    Support.mostrarError(ex.Message.ToString());
                    this.Close();
                }

            }

        }


        private bool validarCompraGiftCard(int idCliOrigen, int idCliDestino)
        {

            string strError = "Han ocurrido los siguientes errores:\n";
            bool datosValidos = true;

            lblDestino.ForeColor = System.Drawing.Color.Black;
            lblMonto.ForeColor = System.Drawing.Color.Black;

            if (idCliDestino == 0)
            {
                datosValidos = false;
                strError += "-El usuario destino no tiene cliente asociado\n";
                lblDestino.ForeColor = System.Drawing.Color.Red;
            }
            
            if (!tieneSaldoSuficiente(idCliOrigen))
            {
                datosValidos = false; 
                strError += "-Usted no posee suficiente crédito para realizar la compra\n";
                lblMonto.ForeColor = System.Drawing.Color.Red;
            }
                
            if (Support.clienteInhabilitado(idCliDestino))
            {
                datosValidos = false;
                strError += "-El usuario cliente destino se encuentra inhabilitado\n";
                lblDestino.ForeColor = System.Drawing.Color.Red;

            }

            if (!datosValidos) Support.mostrarError(strError);

            return datosValidos;
        }



        private bool existenErrores()
        {

            bool hay_errores = false;

            string strError = "Se han producido los siguientes errores: \n";

            idUserDestino = Support.traerIdUsuario(txtDestino.Text);

            if (idUserDestino == 0)
            {
                strError += "-El usuario no es valido. \n";
                lblDestino.ForeColor = System.Drawing.Color.Red;
                hay_errores = true;
            }
            else if ( idCliOrigen == idCliDestino)
            {
                strError += "-No te podes autoregalar una Gift Card. \n";
                lblDestino.ForeColor = System.Drawing.Color.Red;
                hay_errores = true;
            }
            else
            {
                lblDestino.ForeColor = System.Drawing.Color.Black;
            }

            if(numMonto.Value == 0)
            {
                strError += "-Campo monto incompleto. \n";
                lblMonto.ForeColor = System.Drawing.Color.Red;
                hay_errores = true;
            
            }else{
                lblMonto.ForeColor = System.Drawing.Color.Black;
            }

            if (hay_errores) Support.mostrarError(strError);

            return hay_errores;
        }


        private int obtenerSaldo(string key)
        {
            int saldo = 0;

            try
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                dbcon.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT valor
                                                  FROM LOSGROSOS_RELOADED.Parametrizacion
                                                  WHERE codigo = @key", dbcon);

                cmd.Parameters.Add("@key", SqlDbType.NVarChar,20);
                cmd.Parameters["@key"].Value = key;



                saldo = Convert.ToInt16(cmd.ExecuteScalar());
               
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message.ToString());
                this.Close();
            }

            return saldo;
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {

                e.Handled = true;

            }
        }

        private void verificarCliente()
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

                if (idCli == 0)
                {
                    Support.mostrarError("El usuario no pertenece a un cliente");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message.ToString());
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            borrar_pantalla();
        }
        private void borrar_pantalla()
        {
            this.txtDestino.Clear();
            this.numMonto.Value = numMonto.Minimum;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarCli frm = new frmBuscarCli(this);
            frm.ShowDialog();
        }

        private bool tieneSaldoSuficiente(int idCli) 
        {

            int saldo = 0;

            try
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                dbcon.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT saldo
                                                  FROM LOSGROSOS_RELOADED.Clientes
                                                  WHERE  idCli = @idCli", dbcon);

                cmd.Parameters.Add("@idCli", SqlDbType.NVarChar, 100);
                cmd.Parameters["@idCli"].Value = idCli;

                saldo = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message.ToString());
                this.Close();
            }

            return (saldo >= numMonto.Value);

        }
    }
}
