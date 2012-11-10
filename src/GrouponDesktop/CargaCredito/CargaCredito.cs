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

namespace GrouponDesktop.CargaCredito
{
    public partial class CargaCredito : Form
    {
        public CargaCredito()
        {
            InitializeComponent();
        }


        private void CargaCredito_Load(object sender, EventArgs e)
        {

//Inicialización grupo pantallas
            //gb_tarjeta.Visible = false;
            txtTarjeta.Enabled = true;
            txtTitular.Enabled = true;
            btnSeleccion.Enabled = true;

//Verifico que el que ejecuta esta funcionalidad tiene un cliente asociado
            verificarCliente();

//Carga de combobox
            try
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                dbcon.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM LOSGROSOS_RELOADED.TipoPago", dbcon);

                DataSet dt = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                cb_medioPago.DataSource = dt.Tables[0];
                cb_medioPago.DisplayMember = "nombre";
                cb_medioPago.ValueMember = "idTipoPago";


                dbcon.Close();
            }
            catch (Exception ex) {

                Support.mostrarError(ex.Message);

            }           

        }

        private void cb_medioPago_SelectedValueChanged(object sender, EventArgs e)
        {
            String str_seleccionado = cb_medioPago.SelectedValue.ToString();

            if (str_seleccionado == "2") //Al contado
            {
//Proximamente, el grupo tarjeta va a desaparecer y el form cambiara de tamaño
                //gb_tarjeta.Visible = false;
                txtFechaVenc.Text = "";
                txtTitular.Text = "";
                txtTarjeta.Text = "";
                btnSeleccion.Enabled = false;
                txtTarjeta.Enabled = false;
                txtTitular.Enabled = false;

            }
            else { //Crédito

                //gb_tarjeta.Visible = true;
                btnSeleccion.Enabled = true;
                txtTarjeta.Enabled = true;
                txtTitular.Enabled = true;

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string strError="";
            DateTime fechaHoy = DateTime.Now;
            bool No_hay_datos_incompletos = true; //Es una negrada.... ya lo voy a corregir

            String str_seleccionado = cb_medioPago.SelectedValue.ToString();

            if (str_seleccionado == "1") //Crédito
            {
                if (txtFechaVenc.Text == "" ||
                    txtTarjeta.Text == "" ||
                    txtTitular.Text == "")
                {

                    strError += "- Por favor, complete los campos del grupo 'Tarjeta'\n";
                    No_hay_datos_incompletos = false;

                }

            }

            if (txtCarga.Text == "")
            {
                strError += "- Por favor complete el campo 'Crédito a cargar'\n";
                No_hay_datos_incompletos = false;
            }

            if (!tarjetaNoVencida())
            {
                strError += "- La tarjeta ingresada esta vencida\n";
                No_hay_datos_incompletos = false;
            }

            if (No_hay_datos_incompletos)
            {

                try
                {
                    SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                    dbcon.Open();
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = dbcon;


                    cmd.Parameters.Add("@usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters.Add("@monto", SqlDbType.Int, 18);
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
                    cmd.Parameters.Add("@idTipoPago", SqlDbType.Int, 18);
 
                    cmd.Parameters["@usuario"].Value = Support.nombreUsuario;
                    cmd.Parameters["@monto"].Value = txtCarga.Text;
                    cmd.Parameters["@fecha"].Value = Convert.ToDateTime(fechaHoy); //Cambiar por fecha archivo config
                    cmd.Parameters["@idTipoPago"].Value = str_seleccionado;

                    if (cb_medioPago.SelectedValue.ToString() == "1")
                    {
                        cmd.Parameters.Add("@numeroTarj", SqlDbType.Int, 18);
                        cmd.Parameters.Add("@fechaVenc", SqlDbType.DateTime);
                        cmd.Parameters.Add("@nombreTitularTarj", SqlDbType.NVarChar, 255);

                        cmd.Parameters["@fechaVenc"].Value = Convert.ToDateTime(txtFechaVenc.Text);
                        cmd.Parameters["@nombreTitularTarj"].Value = txtTitular.Text;
                        cmd.Parameters["@numeroTarj"].Value = txtTarjeta.Text;

                        cmd.CommandText = @"EXEC LOSGROSOS_RELOADED.P_Insertar_Carga
                                                      @usuario, @monto, @fecha,
                                                      @idTipoPago, @numeroTarj,
                                                      @fechaVenc, @nombreTitularTarj";

                    }
                    else {

                        cmd.CommandText = @"EXEC LOSGROSOS_RELOADED.P_Insertar_Carga
                                                      @usuario, @monto, @fecha,
                                                      @idTipoPago";

                    }
                    
                    cmd.ExecuteNonQuery();

                    Support.mostrarInfo("Se ha realizado la carga con éxito");
                    borrar_pantalla();



                    //DataSet dt = new DataSet();
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //da.Fill(dt);

                    //cb_medioPago.DataSource = dt.Tables[0];
                    //cb_medioPago.DisplayMember = "nombre";
                    //cb_medioPago.ValueMember = "idTipoPago";


                    dbcon.Close();
                }//End try
                catch (Exception ex)
                {
                    Support.mostrarError(ex.Message.ToString());
                    this.Close();

                } //End catch

            }
            else
            {
                Support.mostrarError(strError);

            }


        } //end method

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            calendarioVencimiento.Visible = true;
        }

        private void calendarioVencimiento_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.txtFechaVenc.Text = this.calendarioVencimiento.SelectionStart.ToShortDateString();
            this.calendarioVencimiento.Visible = false;
        }

        private void borrar_pantalla()
        {
            txtCarga.Text = "";
            txtFechaVenc.Text = "";
            txtTarjeta.Text = "";
            txtTitular.Text = "";
        }

        private bool tarjetaNoVencida()
        {
            bool noEstaVencida = true;
            DateTime fechaHoy = DateTime.Now; //Cambiar por fecha arch. config

            if (txtFechaVenc.Text != "")
            {
                if( Support.obtenerFechaInt((Convert.ToDateTime(txtFechaVenc.Text))) < Support.obtenerFechaInt(fechaHoy))
                {
                    noEstaVencida = false;
                }
            }

            return noEstaVencida;
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



    }
}
