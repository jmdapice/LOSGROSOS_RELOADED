using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.RegistroConsumoCupon
{
    public partial class RegistrarConsumo : Form
    {
        public int idProv = 0;

        public RegistrarConsumo()
        {
            InitializeComponent();
        }

        private void RegistrarConsumo_Load(object sender, EventArgs e)
        {
            RegistroConsumoCupon.Consumo_BuscarProv frmBuscarProv;

            idProv = Support.obtenerIdProveedor(Support.traerIdUsuario(Support.nombreUsuario));
            if (idProv == 0)
            {
                frmBuscarProv = new RegistroConsumoCupon.Consumo_BuscarProv(this);
                frmBuscarProv.ShowDialog();
                if (idProv == 0) this.Close();
            }
            else
            {
                if (Support.proveedorInhabilitado(idProv))
                {
                    Support.mostrarError("Usted se encuentra inhabilitado");
                    this.Close();
                }
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblCliente.ForeColor = System.Drawing.Color.Black;
            txtCliente.Text = "";
            dgvCupones.Columns.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            
                this.Close();
            
        }

        private void btn_B_Click(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            RegistroConsumoCupon.Consumo_BuscarCli frmBuscar = new RegistroConsumoCupon.Consumo_BuscarCli(this);
            frmBuscar.ShowDialog();

        }

        private bool estaCompletoCliente()
        {
            bool lleno = true;

            if (txtCliente.Text == "")
            {
                lleno = false;
                lblCliente.ForeColor = System.Drawing.Color.Red;
                Support.mostrarError("Complete el campo cliente");
            }
            else
            {
                lblCliente.ForeColor = System.Drawing.Color.Black;
            }

            return lleno;
        }

        private void traerCupones()
        {

            dgvCupones.Columns.Clear();
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd;
            cmd = new SqlCommand(@"SELECT comp.idCompra AS 'idCompra', 
                                              comp.codigoCupon AS 'Cód. Cupón', 
                                              cupon.descripcion AS 'Descripción', 
                                              comp.fechaCompra AS 'Fecha compra'
                                        FROM LOSGROSOS_RELOADED.CuponComprado comp, LOSGROSOS_RELOADED.Cupon cupon
                                        WHERE cupon.idProveedor = @idProv
                                          AND comp.idCli = @idCli
                                          AND comp.fechaDevolucion is null
                                          AND comp.fechaCanje is null
                                          AND comp.codigoCupon = cupon.codigoCupon
                                          AND cupon.fechaVencOferta >= @fechaConfig", dbcon);

            cmd.Parameters.Add("@idCli", SqlDbType.Int, 18);
            cmd.Parameters["@idCli"].Value = Support.obtenerIdCliente(Support.traerIdUsuario(txtCliente.Text));

            cmd.Parameters.Add("@idProv", SqlDbType.Int, 18);
            cmd.Parameters["@idProv"].Value = idProv;

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
            dgvCupones.Columns[0].Visible = false;
            dgvCupones.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (estaCompletoCliente())
            {
                dgvCupones.Columns.Clear();               
                traerCupones();
            }
        }

        private void dgvCupones_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string mensaje = "";
            string codCupon = "";
            string descripcion = "";

            codCupon = dgvCupones.CurrentRow.Cells["Cód. Cupón"].Value.ToString();
            descripcion = dgvCupones.CurrentRow.Cells["Descripción"].Value.ToString();

            mensaje = "¿Está seguro que desea registrar el cupón " + codCupon + " ?\n" + descripcion;

            if (Support.mostrarPregunta(mensaje, "Registrar Consumo"))
            {

                registrarConsumo();
                traerCupones();

            }
            else
            {
                Support.mostrarAdvertencia("No se ha registrado el consumo del cupón");
            }


        }

        private void registrarConsumo()
        {

            int idCompra = Convert.ToInt32(dgvCupones.CurrentRow.Cells["idCompra"].Value.ToString());

            try
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                dbcon.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE LOSGROSOS_RELOADED.CuponComprado 
                                                     SET fechaCanje = @fechaCanje
                                                   WHERE idCompra = @idCompra", dbcon);

                cmd.Parameters.Add("@idCompra", SqlDbType.Int, 18);
                cmd.Parameters["@idCompra"].Value = idCompra;

                cmd.Parameters.Add("@fechaCanje", SqlDbType.DateTime);
                cmd.Parameters["@fechaCanje"].Value = Support.fechaConfig();

                cmd.ExecuteNonQuery();

                Support.mostrarInfo("Se ha generado el canje con éxito");

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message.ToString());
                this.Close();
            }

        }

    }
}
