using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.ListadoEstadistico
{
    public partial class Listado : Form{
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd;
            cmd = new SqlCommand(@"select distinct year(fecha) as anio from LOSGROSOS_RELOADED.Giftcard
                                  where YEAR(fecha) < @fecha
                                  union
                                  select distinct year(fechaDevolucion) as anio from LOSGROSOS_RELOADED.CuponComprado
                                  where fechaDevolucion is not null
                                  and year(fechaDevolucion) < @fecha", dbcon);

            cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
            cmd.Parameters["@fecha"].Value = Support.fechaConfig();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }

            this.comboBox1.DataSource = dt;
            this.comboBox1.DisplayMember = "anio";
            this.comboBox1.ValueMember = "anio";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.comboBox1.SelectedItem = 0;
            this.checkBox1.Checked = false;
            this.checkBox2.Checked = false;
            this.dgvListado.Columns.Clear();
        }

        private void btnListDev_Click(object sender, EventArgs e)
        {
            if (validado())
            {

                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                SqlCommand cmd;
                cmd = new SqlCommand(@"SELECT TOP 5 p.razonSocial as 'Razon Social',p.cuit as 'CUIT',
                                    (COUNT(c.fechaDevolucion)*100/COUNT(c.fechaCanje))as 'Porcentaje'
                                     FROM LOSGROSOS_RELOADED.CuponComprado c, LOSGROSOS_RELOADED.Cupon cup,
                                     LOSGROSOS_RELOADED.Proveedor p
                                     where  c.codigoCupon = cup.codigoCupon
                                     and cup.idProveedor = p.idProveedor", dbcon);


                int anio = Convert.ToInt32(this.comboBox1.SelectedValue);

                if (this.checkBox1.Checked == true)
                {
                    DateTime fechaDesde = new DateTime(anio, 01, 01, 00, 00, 00);
                    cmd.CommandText += " and (c.fechaDevolucion > @fechaDesde or fechaCanje > @fechaDesde) ";
                    cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime);
                    cmd.Parameters["@fechaDesde"].Value = fechaDesde;
                    DateTime fechaHasta = new DateTime(anio, 06, 30, 23, 59, 59);
                    cmd.CommandText += " and (c.fechaDevolucion < @fechaHasta or fechaCanje < @fechaHasta) ";
                    cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime);
                    cmd.Parameters["@fechaHasta"].Value = fechaHasta;

                }
                else
                {
                    DateTime fechaDesde = new DateTime(anio, 07, 01, 00, 00, 00);
                    cmd.CommandText += " and (c.fechaDevolucion > @fechaDesde or fechaCanje > @fechaDesde) ";
                    cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime);
                    cmd.Parameters["@fechaDesde"].Value = fechaDesde;
                    DateTime fechaHasta = new DateTime(anio, 12, 31, 23, 59, 59);
                    cmd.CommandText += " and (c.fechaDevolucion < @fechaHasta or fechaCanje < @fechaHasta) ";
                    cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime);
                    cmd.Parameters["@fechaHasta"].Value = fechaHasta;
                }

                cmd.CommandText += " group by p.razonSocial,p.cuit order by 3 desc";

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
                dgvListado.DataSource = dt;
                dgvListado.Columns["Razon Social"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnListGift_Click(object sender, EventArgs e)
        {
            if (validado())
            {

                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                SqlCommand cmd;
                cmd = new SqlCommand(@"SELECT TOP 5  u.nombreUsuario as 'Nombre de Usuario',
                                  count(g.idGiftCard) as 'Cantidad de GiftCards Recibidas',
                                  sum(g.monto) as 'Monto Total'  
                                  FROM LOSGROSOS_RELOADED.GiftCard g, LOSGROSOS_RELOADED.Clientes c,
                                  LOSGROSOS_RELOADED.Usuario u
                                  where g.idCliDestino = c.idCli
                                  and u.idUsuario = c.idUsuario", dbcon);

                int anio = Convert.ToInt32(this.comboBox1.SelectedValue);
                
                if (this.checkBox1.Checked == true)
                {
                    DateTime fechaDesde = new DateTime(anio, 01, 01, 00, 00, 00);
                    cmd.CommandText += " and g.fecha > @fechaDesde";
                    cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime);
                    cmd.Parameters["@fechaDesde"].Value = fechaDesde;
                    DateTime fechaHasta = new DateTime(anio, 06, 30, 23, 59, 59);
                    cmd.CommandText += " and g.fecha < @fechaHasta";
                    cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime);
                    cmd.Parameters["@fechaHasta"].Value = fechaHasta;
          
                }
                else
                {
                    DateTime fechaDesde = new DateTime(anio, 07, 01, 00, 00, 00);
                    cmd.CommandText += " and g.fecha > @fechaDesde";
                    cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime);
                    cmd.Parameters["@fechaDesde"].Value = fechaDesde;
                    DateTime fechaHasta = new DateTime(anio, 12, 31, 23, 59, 59);
                    cmd.CommandText += " and g.fecha < @fechaHasta";
                    cmd.Parameters.Add("@fechaHasta", SqlDbType.DateTime);
                    cmd.Parameters["@fechaHasta"].Value = fechaHasta;           
                }


                cmd.CommandText += " group by u.nombreUsuario order by 2 desc";

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
                dgvListado.DataSource = dt;
                dgvListado.Columns["Cantidad de GiftCards Recibidas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

          private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.checkBox2.Enabled = false;
            }
            else { 
                this.checkBox2.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                this.checkBox1.Enabled = false;
            }
            else
            {
                this.checkBox1.Enabled = true;
            }
        }

        private bool validado()
        {
            if((this.checkBox1.Checked == false) && (this.checkBox2.Checked == false)){

                Support.mostrarError("Debe seleccionar un semestre");
                return false;
            }
            return true;
        }


     



  
  
    }
}
