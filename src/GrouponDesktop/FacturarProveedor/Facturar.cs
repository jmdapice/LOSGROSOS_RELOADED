using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.FacturarProveedor
{
    public partial class Facturar : Form
    {
    
        public Facturar()
        {
            InitializeComponent();
        }

        private void btnSelecDesde_Click(object sender, EventArgs e)
        {
            this.calendarDesde.Visible = true;
        }

        private void btnSelecHasta_Click(object sender, EventArgs e)
        {
            this.calendHasta.Visible = true;
        }

        private void calendarDesde_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFechaDesde.Text = calendarDesde.SelectionStart.ToShortDateString();
            calendarDesde.Visible = false;
        }

        private void calendHasta_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFechaHasta.Text = calendHasta.SelectionStart.ToShortDateString();
            calendHasta.Visible = false;
        }

        private void BuscarParaFacturar_Load(object sender, EventArgs e)
        {

     
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtFechaDesde.Clear();
            this.txtFechaHasta.Clear();
            this.txtBoxCuit.Clear();
            this.dgvProv.Columns.Clear();
            this.lblTotal.Text = "Importe Total Factura: ";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.dgvProv.Columns.Clear();
            this.lblTotal.Text = "Importe Total Factura: ";

            if (this.txtBoxCuit.Text != "")
            {

                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                SqlCommand cmd;
                cmd = new SqlCommand(@"SELECT c.codigoCupon as 'Codigo de Cupon',
                                c.fechaCompra as 'Fecha de Compra',c.fechaCanje as 'Fecha de Entrega',c.idFactura,
                                cup.idProveedor, cup.precio as 'Precio'
                                FROM LOSGROSOS_RELOADED.CuponComprado c, LOSGROSOS_RELOADED.Cupon cup
                                where fechaCanje is not null 
                                and fechaDevolucion is null
                                and idFactura is null
                                and c.codigoCupon = cup.codigoCupon
                                and cup.idProveedor = @idProv", dbcon);

                cmd.Parameters.Add("@idProv", SqlDbType.VarChar, 255);
                cmd.Parameters["@idProv"].Value = Support.idProv;

                if (txtFechaDesde.Text != "")
                {
                    cmd.CommandText += " and fechaCanje < @fechaDesde";
                    cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime);
                    cmd.Parameters["@fechaDesde"].Value = Convert.ToDateTime(txtFechaDesde.Text);

                }

                if (txtFechaHasta.Text != "")
                {
                    cmd.CommandText += "    and fechaCanje > @fechaHasta";
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
                }

               
                if (dt.Rows.Count > 0)
                {
                    this.dgvProv.DataSource = dt;
                    dgvProv.Columns["idProveedor"].Visible = false;
                    dgvProv.Columns["idFactura"].Visible = false;
                    dgvProv.Columns["Codigo de Cupon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    facturarProv(dbcon, calcularTotalFactura(dt));
                }
                else
                {
                    Support.mostrarInfo("No hay cupones para facturar en el periodo seleccionado");
                }
            }
            else
            {
                Support.mostrarError("Se debe ingresar un Proveedor");
            }

        }

        private void btnBuscProv_Click(object sender, EventArgs e)
        {
            BuscarProv_Facturar frm = new BuscarProv_Facturar(this);
            frm.ShowDialog();
        }

        private double calcularTotalFactura(DataTable dt)
        {
            double total = 0;
            foreach (DataRow r in dt.Rows)
            {
                total += Convert.ToDouble(r["Precio"]);
            }
            lblTotal.Text += " "+total.ToString();
            return total;
        }

        private void facturarProv(SqlConnection dbcon,double total)
        {
            int nroFact = 0;
            SqlCommand cmd = dbcon.CreateCommand();
            SqlTransaction trans = dbcon.BeginTransaction("Trans");
            cmd.Connection = dbcon;
            cmd.Transaction = trans;
            cmd.Parameters.Add("@idProv", SqlDbType.Int, 18);
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
            cmd.Parameters.Add("@total", SqlDbType.Float, 10);
            cmd.Parameters["@idProv"].Value = Support.idProv;
            cmd.Parameters["@fecha"].Value = Support.fechaConfig();
            cmd.Parameters["@total"].Value = total;

            try
            {
                cmd.CommandText = @"select MAX(facturaNro) from LOSGROSOS_RELOADED.Factura";

                nroFact = Convert.ToInt32(cmd.ExecuteScalar())+1;
                cmd.Parameters.Add("@nroFact", SqlDbType.Int, 18);
                cmd.Parameters["@nroFact"].Value = nroFact;

                cmd.CommandText = @"INSERT INTO LOSGROSOS_RELOADED.Factura
                                   (fechaFact,facturaNro,importe,idProveedor)
                                    VALUES (@fecha,@nroFact,@total,@idProv)";
                cmd.ExecuteNonQuery();
                
                cmd.CommandText = @"UPDATE LOSGROSOS_RELOADED.CuponComprado
                                    SET LOSGROSOS_RELOADED.CuponComprado.idFactura = 
                                    (select idFactura from LOSGROSOS_RELOADED.Factura
                                    where facturaNro = @nroFact)
                                    FROM LOSGROSOS_RELOADED.CuponComprado c, LOSGROSOS_RELOADED.Cupon cup
                                    where fechaCanje is not null 
                                    and fechaDevolucion is null
                                    and idFactura is null
                                    and c.codigoCupon = cup.codigoCupon
                                    and cup.idProveedor = @idProv";

                if (txtFechaDesde.Text != "")
                {
                    cmd.CommandText += " and fechaCanje < @fechaDesde";
                    cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime);
                    cmd.Parameters["@fechaDesde"].Value = Convert.ToDateTime(txtFechaDesde.Text);

                }

                if (txtFechaHasta.Text != "")
                {
                    cmd.CommandText += "    and fechaCanje > @fechaHasta";
                    cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime);
                    cmd.Parameters["@fechaHasta"].Value = Convert.ToDateTime(txtFechaHasta.Text);
                }

                cmd.ExecuteNonQuery();
                trans.Commit();
                Support.mostrarInfo("El total de la Factura N°"+nroFact.ToString()+" es: $"+total.ToString());
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);

                try
                {
                    trans.Rollback();
                }
                catch (Exception ex2)
                {
                    Support.mostrarError(ex2.Message);
                }
            }
            dbcon.Close();

        }

    
    }
}
