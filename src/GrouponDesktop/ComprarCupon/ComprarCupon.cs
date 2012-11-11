using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.ComprarCupon
{
    public partial class ComprarCupon : Form
    {
        public int idCli=0;
        private static int saldo = 0;

        public ComprarCupon()
        {
            InitializeComponent();
        }

        private void ComprarCupon_Load(object sender, EventArgs e)
        {
            ComprarCupon_BuscarCli frmBuscarCli;
            
            idCli = Support.obtenerIdCliente(Support.traerIdUsuario(Support.nombreUsuario));

            if (idCli == 0)
            {
                frmBuscarCli = new ComprarCupon_BuscarCli(this);
                frmBuscarCli.ShowDialog();
                if (idCli == 0) this.Close();
            }
            else if(Support.clienteInhabilitado(idCli))
            {
                Support.mostrarError("Usted se encuentra inhabilitado");
                this.Close();
    
            }
            
            cargarListado();
            cargarSaldo();
        }

        private void cargarSaldo() 
        {
            txtSaldo.Text = "";

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
                txtSaldo.Text = Convert.ToString(saldo);

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message.ToString());
                this.Close();
            }
        }

        private void cargarListado()
        {
            dgvCupones.Columns.Clear();
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd;
            cmd = new SqlCommand(@"select distinct cupon.codigoCupon, cupon.descripcion as 'Descripcion',cupon.precio as 'Precio Cuponete',cupon.precioFicticio as 'Precio Anterior'
                                   from LOSGROSOS_RELOADED.Cupon cupon, LOSGROSOS_RELOADED.CuponCiudad ciudad
                                   where cupon.stock > 0
                                   and cupon.cantMaxima > (  SELECT COUNT(*) 
							                                 FROM LOSGROSOS_RELOADED.CuponComprado 
							                                 WHERE idCli = @idCli
							                                 and codigoCupon = cupon.codigoCupon)
                                   and ciudad.idCiudad IN (SELECT idCiudad 
                                                           FROM LOSGROSOS_RELOADED.CiudadesPreferidas
                                                           WHERE idCli = @idCli )
                                   and cupon.publicado='1'
                                   and fechaVencOferta>=@fechaConf
                                   and fechaPubli <= @fechaConf", dbcon);
                     
            cmd.Parameters.Add("@idCli", SqlDbType.Int,18);
            cmd.Parameters["@idCli"].Value = idCli; //Support.obtenerIdCliente(Support.traerIdUsuario(Support.nombreUsuario));

            cmd.Parameters.Add("@fechaConf", SqlDbType.DateTime);
            cmd.Parameters["@fechaConf"].Value = Support.fechaConfig();
            
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
                this.Close();
            }

            dgvCupones.DataSource = dt;
            dgvCupones.Columns[0].Visible = false;
            dgvCupones.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

           
           
        }

        private void dgvCupones_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string mensaje = "";
            string descripcion = "";
            string precio = "";

            descripcion = dgvCupones.CurrentRow.Cells["Descripcion"].Value.ToString();
            precio = dgvCupones.CurrentRow.Cells["Precio Cuponete"].Value.ToString();

            mensaje += "¿Desea comprar el cupón:\n " + descripcion + "?\n\n Precio del cupon: $" + precio;
            
            if(Support.mostrarPregunta(mensaje,"Comprar cupon"))
            {
                comprarCupon();
            }

        }

        private void comprarCupon()
        {

            if (leAlcanzaElSaldo())
            {

                try
                {
                    SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                    dbcon.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO LOSGROSOS_RELOADED.CuponComprado 
                                                 (codigoCupon, idCli, fechaCompra)
                                                 VALUES (@codigoCupon,@idCli,@fechaCompra)", dbcon);


                    cmd.Parameters.Add("@codigoCupon", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@codigoCupon"].Value = dgvCupones.CurrentRow.Cells["codigoCupon"].Value.ToString();

                    cmd.Parameters.Add("@idCli", SqlDbType.Int, 18);
                    cmd.Parameters["@idCli"].Value = idCli;

                    cmd.Parameters.Add("@fechaCompra", SqlDbType.DateTime);
                    cmd.Parameters["@fechaCompra"].Value = Support.fechaConfig();

                    cmd.ExecuteNonQuery();

                    Support.mostrarInfo("Se ha generado la compra con éxito");

                }
                catch (Exception ex)
                {
                    Support.mostrarError(ex.Message.ToString());
                    this.Close();
                }

                cargarListado();
                cargarSaldo();
            }
            else 
            {
                Support.mostrarError("No tiene el saldo suficiente para comprar el cupón.");
            }

        }

        private bool leAlcanzaElSaldo()
        {
            int precioCupon = Convert.ToInt32(dgvCupones.CurrentRow.Cells["Precio Cuponete"].Value);
            return (saldo >= precioCupon );
        }

    }
}
