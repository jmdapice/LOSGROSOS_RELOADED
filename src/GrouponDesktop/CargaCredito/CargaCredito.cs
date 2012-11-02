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
            txtFechaVenc.Enabled = true;
            txtTarjeta.Enabled = true;
            txtTitular.Enabled = true;

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

                MessageBox.Show(ex.Message);

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
                txtFechaVenc.Enabled = false;
                txtTarjeta.Enabled = false;
                txtTitular.Enabled = false;

            }
            else { //Crédito

                //gb_tarjeta.Visible = true;
                txtFechaVenc.Enabled = true;
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

            bool No_hay_datos_incompletos = true; //Es una negrada.... ya lo voy a corregir

            String str_seleccionado = cb_medioPago.SelectedValue.ToString();

            if (str_seleccionado == "1") //Crédito
            {
                if (txtFechaVenc.Text == "" ||
                    txtTarjeta.Text == "" ||
                    txtTitular.Text == "")
                {

                    MessageBox.Show("Por favor, complete los campos del grupo 'Tarjeta'");
                    No_hay_datos_incompletos = false;

                }

            }

            if (txtCarga.Text == "")
            {
                MessageBox.Show("Por favor complete el campo 'Crédito a cargar'");
                No_hay_datos_incompletos = false;
            }
            
            if(No_hay_datos_incompletos)
            {

//TODAVIA NO ESTA PROBADA ESTA PARTE
//                try
//                {
//                    SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
//                    dbcon.Open();
//                    SqlCommand cmd = new SqlCommand(@"EXEC LOSGROSOS_RELOADED.P_Insertar_Carga
//                                                      @usuario, @monto, @fecha,
//                                                      @idTipoPago, @numeroTarj,
//                                                      @fechaVenc, @nombreTitular", dbcon);

//                    cmd.Parameters.Add("@usuario", SqlDbType.NVarChar, 100);
//                    cmd.Parameters.Add("@monto", SqlDbType.Int, 18);
//                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
//                    cmd.Parameters.Add("@idTipoPago", SqlDbType.Int, 18);
//                    cmd.Parameters.Add("@numeroTarj", SqlDbType.Int, 18);
//                    cmd.Parameters.Add("@fechaVenc", SqlDbType.DateTime);
//                    cmd.Parameters.Add("@idTipoPago", SqlDbType.NVarChar, 255);

//                    cmd.Parameters["@usuario"].Value = Variables_globales.nombreUsuario;
//                    cmd.Parameters["@monto"].Value = txtCarga.Text;
//                    cmd.Parameters["@fecha"].Value = txtFechaVenc.Text;
//                    cmd.Parameters["@idTipoPago"].Value = str_seleccionado;
//                    cmd.Parameters["@numeroTarj"].Value = txtTarjeta.Text;
//                    cmd.Parameters["@fechaVenc"].Value = txtFechaVenc.Text;
//                    cmd.Parameters["@nombreTitular"].Value = txtTitular;

//                    DataSet dt = new DataSet();
//                    SqlDataAdapter da = new SqlDataAdapter(cmd);
//                    da.Fill(dt);

//                    cb_medioPago.DataSource = dt.Tables[0];
//                    cb_medioPago.DisplayMember = "nombre";
//                    cb_medioPago.ValueMember = "idTipoPago";


//                    dbcon.Close();
//                }//End try
//                catch (Exception ex)
//                {

//                    MessageBox.Show(ex.Message);

//                } //End catch

            }//end txtCarga == ""


        } //end method












    }
}
