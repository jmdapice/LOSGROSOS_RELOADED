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
        public static int idCli;

        public ComprarCupon()
        {
            InitializeComponent();
        }

        private void ComprarCupon_Load(object sender, EventArgs e)
        {
            if (idCli == 0)
                idCli = Support.obtenerIdCliente(Support.traerIdUsuario(Support.nombreUsuario));
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

                txtSaldo.Text = Convert.ToString(cmd.ExecuteScalar());

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



        }
    }
}
