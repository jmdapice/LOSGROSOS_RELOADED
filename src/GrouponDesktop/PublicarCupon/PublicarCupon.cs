using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.PublicarCupon
{
    public partial class PublicarCupon : Form
    {
        public PublicarCupon()
        {
            InitializeComponent();
            
        }

        private void PublicarCupon_Load(object sender, EventArgs e)
        {
            traerSinFiltro();
            btnSacarFiltro.Enabled = false;
            btnAplicar.Enabled = true;
            gbDatos.Text += Convert.ToString(Support.fechaConfig());
        }

        private void traerConFiltro()
        {

            dgvCupones.Columns.Clear();
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd;
            cmd = new SqlCommand(@"SELECT  cupon.codigoCupon AS 'Cod. Cupón',
	                                       cupon.descripcion AS 'Descripción',
	                                       prov.razonSocial AS 'Razón Social', 
                                           cupon.precio AS 'Precio', 
                                           cupon.precioFicticio AS 'Precio Ant.', 
                                           cupon.stock AS 'Stock'
                                    FROM LOSGROSOS_RELOADED.Cupon cupon, LOSGROSOS_RELOADED.Proveedor prov
                                    WHERE publicado = '0'
                                      AND prov.idProveedor = @idProv
                                      AND cupon.idProveedor = prov.idProveedor
                                      AND cupon.fechaVencOferta >= @fechaConfig", dbcon);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            cmd.Parameters.Add("@idProv", SqlDbType.Int, 18);
            cmd.Parameters["@idProv"].Value = Support.obtenerIdProveedor(Support.traerIdUsuario(txtProveedor.Text));

            cmd.Parameters.Add("@fechaConfig", SqlDbType.DateTime);
            cmd.Parameters["@fechaConfig"].Value = Support.fechaConfig();

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
            dgvCupones.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCupones.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void traerSinFiltro()
        {

            dgvCupones.Columns.Clear();
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd;
            cmd = new SqlCommand(@"SELECT  cupon.codigoCupon AS 'Cod. Cupón',
	                                       cupon.descripcion AS 'Descripción',
	                                       prov.razonSocial AS 'Razón Social', 
                                           cupon.precio AS 'Precio', 
                                           cupon.precioFicticio AS 'Precio Ant.', 
                                           cupon.stock AS 'Stock'
                                    FROM LOSGROSOS_RELOADED.Cupon cupon, LOSGROSOS_RELOADED.Proveedor prov
                                    WHERE publicado = '0'
                                      AND cupon.idProveedor = prov.idProveedor
                                      AND cupon.fechaVencOferta >= @fechaConfig", dbcon);

            cmd.Parameters.Add("@fechaConfig", SqlDbType.DateTime);
            cmd.Parameters["@fechaConfig"].Value = Support.fechaConfig();

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
            dgvCupones.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCupones.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            Publicar_BuscarProv frmBuscar = new Publicar_BuscarProv(this);
            frmBuscar.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Support.mostrarPregunta("¿Desea salir?", "Salir"))
            {
                this.Close();
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {

            if (txtProveedor.Text == "")
            {
                Support.mostrarError("Seleccione un proveedor");
            }
            else
            {
                btnAplicar.Enabled = false;
                btnSacarFiltro.Enabled = true;
                btn_Buscar.Enabled = false;
                traerConFiltro();
            }

        }

        private void btnSacarFiltro_Click(object sender, EventArgs e)
        {
            btnAplicar.Enabled = true;
            btnSacarFiltro.Enabled = false;
            btn_Buscar.Enabled = true;
            txtProveedor.Text = "";
            traerSinFiltro();
        }

        private void dgvCupones_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string mensaje = "";
            string codCupon = "";
            string descripcion = "";

            codCupon = dgvCupones.CurrentRow.Cells["Cod. Cupón"].Value.ToString();
            descripcion = dgvCupones.CurrentRow.Cells["Descripción"].Value.ToString();

            mensaje = "¿Está seguro que desea publicar el cupón " + codCupon + " ?\n" + descripcion;

            if (Support.mostrarPregunta(mensaje, "Publicar cupón"))
            {

                registrarPublicacion();

                if (btnAplicar.Enabled) //Codigo cabeza 2.0
                {
                    traerSinFiltro();
                }
                else
                {
                    traerConFiltro();
                }


            }
            else
            {
                Support.mostrarAdvertencia("No se ha registrado el consumo del cupón");
            }

        }

        private void registrarPublicacion()
        {

            string codCupon = dgvCupones.CurrentRow.Cells["Cod. Cupón"].Value.ToString();

            try
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                dbcon.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE LOSGROSOS_RELOADED.Cupon 
                                                     SET fechaPubli = @fechaConfig,
                                                         publicado = '1'
                                                   WHERE codigoCupon = @cod", dbcon);

                cmd.Parameters.Add("@cod", SqlDbType.VarChar, 50);
                cmd.Parameters["@cod"].Value = codCupon;

                cmd.Parameters.Add("@fechaConfig", SqlDbType.DateTime);
                cmd.Parameters["@fechaConfig"].Value = Support.fechaConfig();

                cmd.ExecuteNonQuery();

                Support.mostrarInfo("Se ha registrado la publicación con éxito");

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message.ToString());
                this.Close();
            }

        }
    }
}
