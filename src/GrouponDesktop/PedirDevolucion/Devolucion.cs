using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.PedirDevolucion
{
    public partial class Devolucion : Form
    {
        public int idCli = 0;
        private static int saldo = 0;
        public string motivoDevolucion = "";

        public Devolucion()
        {
            InitializeComponent();
        }

        private void Devolucion_Load(object sender, EventArgs e)
        {
            Devolucion_BuscarCli frmBuscarCli;

            idCli = Support.obtenerIdCliente(Support.traerIdUsuario(Support.nombreUsuario));

            if (idCli == 0)
            {
                frmBuscarCli = new Devolucion_BuscarCli(this);
                frmBuscarCli.ShowDialog();
                if (idCli == 0) this.Close();
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
            cmd = new SqlCommand(@"SELECT comp.idCompra, 
                                          cupon.descripcion as 'Descripcion', 
                                          cupon.precio as 'Precio Cuponete', 
                                          cupon.precioFicticio as 'Precio Anterior',
                                          comp.fechaCompra as 'Fecha de compra',
                                          cupon.fechaVencOferta as 'Fecha Venc. Oferta'
                                   FROM LOSGROSOS_RELOADED.CuponComprado comp, LOSGROSOS_RELOADED.Cupon cupon
                                   WHERE comp.idCli = @idCli
                                     AND comp.codigoCupon = cupon.codigoCupon
                                     AND cupon.fechaVencOferta >= @fechaConf
                                     AND comp.fechaDevolucion is null", dbcon);

            cmd.Parameters.Add("@idCli", SqlDbType.Int, 18);
            cmd.Parameters["@idCli"].Value = idCli;

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

            MotivoDevolucion frmMotivo = new MotivoDevolucion(this);

            string mensaje = "";
            string descripcion = "";
            string precio = "";

            descripcion = dgvCupones.CurrentRow.Cells["Descripcion"].Value.ToString();
            precio = dgvCupones.CurrentRow.Cells["Precio Cuponete"].Value.ToString();

            mensaje += "¿Desea devolver el cupón:\n " + descripcion + "?\n\n (Se le acreditará al saldo: $" + precio + ")";

            if (Support.mostrarPregunta(mensaje, "Comprar cupon"))
            {
                frmMotivo.ShowDialog();
                if (motivoDevolucion == "")
                {
                    Support.mostrarAdvertencia("Se ha cancelado la devolución");
                }
                else
                {
                    devolverCupon();
                }
            }            

        }

        private void devolverCupon()
        {
            
                try
                {
                    SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                    dbcon.Open();
                    SqlCommand cmd = new SqlCommand(@"UPDATE LOSGROSOS_RELOADED.CuponComprado 
                                                         SET fechaDevolucion = @fechaConfig, 
                                                             motivoDevol = @motivo 
                                                       WHERE idCompra = @idCompra", dbcon);


                    cmd.Parameters.Add("@fechaConfig", SqlDbType.DateTime);
                    cmd.Parameters["@fechaConfig"].Value = Support.fechaConfig();

                    cmd.Parameters.Add("@motivo", SqlDbType.NVarChar, 255);
                    cmd.Parameters["@motivo"].Value = motivoDevolucion;

                    cmd.Parameters.Add("@idCompra", SqlDbType.Int, 18);
                    cmd.Parameters["@idCompra"].Value = Convert.ToInt16(dgvCupones.CurrentRow.Cells["idCompra"].Value);

                    cmd.ExecuteNonQuery();

                    Support.mostrarInfo("Se ha generado la devolución con éxito");
                    
                    motivoDevolucion = "";

                }
                catch (Exception ex)
                {
                    Support.mostrarError(ex.Message.ToString());
                    this.Close();
                }

                cargarListado();
                cargarSaldo();
           }

        }

    }
