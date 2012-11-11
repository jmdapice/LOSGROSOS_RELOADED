using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.HistorialCupones
{
    public partial class historialCompras : Form
    {
        public int idCli = 0;

        public historialCompras()
        {
            InitializeComponent();
        }

        private void historialCompras_Load(object sender, EventArgs e)
        {

            historialCompra_BuscarCli frmBuscarCli;

            idCli = Support.obtenerIdCliente(Support.traerIdUsuario(Support.nombreUsuario));
            if (idCli == 0) 
            {
                frmBuscarCli = new historialCompra_BuscarCli(this);
                frmBuscarCli.ShowDialog();
                if (idCli == 0) this.Close();
            }

            txtFechaHasta.Text = "";
            txtFechaDesde.Text = "";
            dgvCupones.Columns.Clear();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFechaDesde.Text = "";
            txtFechaHasta.Text = "";
            dgvCupones.Columns.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Support.mostrarPregunta("¿Seguro que desea salir?", "Salir"))
            {
                this.Close();
            }
        }

        private void btnSelecDesde_Click(object sender, EventArgs e)
        {
            calendDesde.Visible = true;
        }

        private void btnSelecHasta_Click(object sender, EventArgs e)
        {
            calendHasta.Visible = true;
        }

        private void calendDesde_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFechaDesde.Text = calendDesde.SelectionStart.ToShortDateString();
            calendDesde.Visible = false;
        }

        private void calendHasta_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtFechaHasta.Text = calendHasta.SelectionStart.ToShortDateString();
            calendHasta.Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            string consulta = tuConsulta();


            dgvCupones.Columns.Clear();
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd;
            cmd = new SqlCommand(consulta, dbcon);

            cmd.Parameters.Add("@idCli", SqlDbType.Int, 18);
            cmd.Parameters["@idCli"].Value = idCli;

            if (txtFechaDesde.Text != "")
            {
                cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime);
                cmd.Parameters["@fechaDesde"].Value = Convert.ToDateTime(txtFechaDesde.Text);
            }

            if (txtFechaHasta.Text != "")
            {
                cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime);
                cmd.Parameters["@fechaHasta"].Value = Convert.ToDateTime(txtFechaHasta.Text);
            }

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

        private string tuConsulta()
        {
            string consulta = @"SELECT comp.idCompra, 
                                       cupon.descripcion as 'Descripción', 
                                       comp.fechaCompra as 'Fecha de compra',
                                       ( CASE
                                              WHEN comp.idFactura is not null THEN 'Facturado'
                                              WHEN comp.fechaDevolucion is not null THEN 'Devuelto'
                                              WHEN comp.fechaCanje is not null THEN 'Usado'
                                              ELSE 'Comprado' 
                                         END
                                            ) as 'Estado'
                                    FROM LOSGROSOS_RELOADED.CuponComprado comp, LOSGROSOS_RELOADED.Cupon cupon
                                    WHERE comp.codigoCupon = cupon.codigoCupon
                                      AND comp.idCli = @idCli";

            if (txtFechaDesde.Text != "")
                consulta += " AND comp.fechaCompra >= @fechaDesde";

            if(txtFechaHasta.Text != "") 
                consulta += " AND comp.fechaCompra <= @fechaHasta";

            consulta += " ORDER BY comp.idCompra";
            return consulta;
        }


    }
}
