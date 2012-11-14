using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.ArmarCupon
{
    
    
    public partial class ArmarCupon : Form
    {
        private string separadorDecimal = NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
        public int idProv = 0;
        
        public ArmarCupon()
        {
            InitializeComponent();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            labelsNegras();
            if (validado())
            {
                SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());

                try
                {
                    dbcon.Open();
                }
                catch (Exception ex)
                {
                    Support.mostrarError(ex.Message);
                }



                guardarCupon(dbcon);
                Support.mostrarInfo("Cupon cargado con exito");
                dbcon.Close();
                this.Close();
            }
        }


        private bool validado()
        {
            bool valid = true;
            string strError = "";
            if (this.txtDescripcion.Text == "")
            {
                this.lblDescripcion.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Descripcion\n";
                valid = false;
            }
            
            if (this.txtFechaPub.Text == "")
            {
                this.lblFecPub.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Fecha de Publicacion\n";
                valid = false;
            }
            
            if (this.txtPrecioFict.Text == "")
            {
                this.lblPrecioFic.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Precio Ficticio\n";
                valid = false;
            }
            else
            {
                if (!Support.esNumerico(this.txtPrecioFict.Text))
                {
                    this.lblPrecioFic.ForeColor = System.Drawing.Color.Red;
                    strError += "- Debe ingresar valores numericos en Precio Ficticio\n";
                    valid = false;
                }
                else
                {
                    this.txtPrecioFict.Text = this.txtPrecioFict.Text.Replace(",", separadorDecimal);
                    this.txtPrecioFict.Text = this.txtPrecioFict.Text.Replace(".", separadorDecimal);
                }
            }

            if (this.txtPrecioReal.Text == "")
            {
                this.lblPrecioReal.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Precio Real\n";
                valid = false;
            }
            else
            {
                if (!Support.esNumerico(this.txtPrecioReal.Text))
                {
                    this.lblPrecioFic.ForeColor = System.Drawing.Color.Red;
                    strError += "- Debe ingresar valores numericos en Precio Real\n";
                    valid = false;
                }
                else
                {
                    this.txtPrecioReal.Text = this.txtPrecioReal.Text.Replace(",", separadorDecimal);
                    this.txtPrecioReal.Text = this.txtPrecioReal.Text.Replace(".", separadorDecimal);
                }
            }
            
            if (this.txtCantDisp.Text == "")
            {
                this.lblCantDisp.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Cantidad Disponible\n";
                valid = false;
            }
            else
            {
                if (!Support.esNumerico(this.txtCantDisp.Text) || this.txtCantDisp.Text.Contains('.')
                    || this.txtCantDisp.Text.Contains(','))
                {
                    this.lblCantDisp.ForeColor = System.Drawing.Color.Red;
                    strError += "- Debe ingresar valores numericos enteros en Cantidad Disponible\n";
                    valid = false;
                }
              
            }
            if (this.txtCantMax.Text == "")
            {
                this.lblCantMax.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Cantidad Maxima de Compra\n";
                valid = false;
            }
            else
            {
                if (!Support.esNumerico(this.txtCantMax.Text)|| this.txtCantMax.Text.Contains('.')
                    || this.txtCantMax.Text.Contains(','))
                {
                    this.lblCantMax.ForeColor = System.Drawing.Color.Red;
                    strError += "- Debe ingresar valores numericos enteros en Cantidad Maxima de Compra\n";
                    valid = false;
                }
               
            }
            if (this.txtVencCanje.Text == "")
            {
                this.lblVencCanje.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Fecha Vencimiento Canje\n";
                valid = false;
            }
            if (this.txtVencOferta.Text == "")
            {
                this.lblVencOferta.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Fecha Vencimiento Oferta\n";
                valid = false;
            }
            if (lstCiudades.CheckedItems.Count == 0)
            {
                this.lblCiudades.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe seleccionar al menos una Ciudad\n";
                valid = false;
            }
           
            if (!valid) Support.mostrarError(strError);
            return valid;

        }


        private void labelsNegras()
        {
            this.lblCantDisp.ForeColor = System.Drawing.Color.Black;
            this.lblCantMax.ForeColor = System.Drawing.Color.Black;
            this.lblCiudades.ForeColor = System.Drawing.Color.Black;
            this.lblDescripcion.ForeColor = System.Drawing.Color.Black;
            this.lblFecPub.ForeColor = System.Drawing.Color.Black;
            this.lblPrecioFic.ForeColor = System.Drawing.Color.Black;
            this.lblPrecioReal.ForeColor = System.Drawing.Color.Black;
            this.lblVencCanje.ForeColor = System.Drawing.Color.Black;
            this.lblVencOferta.ForeColor = System.Drawing.Color.Black;
        }
     

        private void ArmarCupon_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = Support.fechaConfig();
            this.monthCalendar1.TodayDate = fechaActual;
            this.monthCalendar2.TodayDate = fechaActual;
            this.monthCalendar3.TodayDate = fechaActual;

            idProv = Support.obtenerIdProveedor(Support.traerIdUsuario(Support.nombreUsuario));
            if (idProv == 0)
            {
                ArmarCupon_BuscarProv frmBuscarProv = new ArmarCupon_BuscarProv(this);
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
            
            
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select nombre, idCiudad 
                                            from LOSGROSOS_RELOADED.Ciudad", dbcon);
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
            dbcon.Close();
            this.lstCiudades.DataSource = dt;
            this.lstCiudades.DisplayMember = "nombre";
            this.lstCiudades.ValueMember = "idCiudad";
        }

        private void btnFecPubli_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.txtFechaPub.Text = this.monthCalendar1.SelectionStart.ToShortDateString();
            this.monthCalendar1.Visible = false;
        }

        private void btnFecVenc_Click(object sender, EventArgs e)
        {
            this.monthCalendar2.Visible = true;
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.txtVencOferta.Text = this.monthCalendar2.SelectionStart.ToShortDateString();
            this.monthCalendar2.Visible = false;
        }

        private void btnFecVencCanje_Click(object sender, EventArgs e)
        {
            this.monthCalendar3.Visible = true;
        }
        private void monthCalendar3_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.txtVencCanje.Text = this.monthCalendar3.SelectionStart.ToShortDateString();
            this.monthCalendar3.Visible = false;
        }

        private void guardarCupon(SqlConnection dbcon)
        {
            int idNuevoCupon = 0;
         

            SqlCommand cmd = new SqlCommand(@"EXEC LOSGROSOS_RELOADED.P_Alta_Cupon 
                                              @precio, @precioFicticio, @descripcion, 
                                              @idProveedor, @cantMaxima, @fechaPubli, @fechaVencOferta,
                                              @stock, @fechaVencCanje", dbcon);

            cmd.Parameters.Add("@precio", SqlDbType.Float, 18);
            cmd.Parameters.Add("@precioFicticio", SqlDbType.Float, 18);
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@idProveedor", SqlDbType.Int, 18);
            cmd.Parameters.Add("@cantMaxima", SqlDbType.Int, 18);
            cmd.Parameters.Add("@fechaPubli", SqlDbType.DateTime);
            cmd.Parameters.Add("@fechaVencOferta", SqlDbType.DateTime);
            cmd.Parameters.Add("@stock", SqlDbType.Int, 18);
            cmd.Parameters.Add("@fechaVencCanje", SqlDbType.DateTime);

            cmd.Parameters["@precio"].Value = Convert.ToDouble(this.txtPrecioReal.Text);
            cmd.Parameters["@precioFicticio"].Value = Convert.ToDouble(this.txtPrecioFict.Text);
            cmd.Parameters["@descripcion"].Value = this.txtDescripcion.Text;
            cmd.Parameters["@idProveedor"].Value = idProv;
            cmd.Parameters["@cantMaxima"].Value = Convert.ToDecimal(this.txtCantMax.Text);
            cmd.Parameters["@fechaPubli"].Value = Convert.ToDateTime(this.txtFechaPub.Text);
            cmd.Parameters["@fechaVencOferta"].Value = Convert.ToDateTime(this.txtVencOferta.Text);
            cmd.Parameters["@stock"].Value = Convert.ToDecimal(this.txtCantDisp.Text);
            cmd.Parameters["@fechaVencCanje"].Value = Convert.ToDateTime(this.txtVencCanje.Text);

            try
            {

               idNuevoCupon = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
                Application.Exit();
            }


            agregarCiudadesCupon(dbcon, idNuevoCupon);
        }
        private void agregarCiudadesCupon(SqlConnection dbcon, int idCupon)
        {
            SqlCommand cmd = new SqlCommand(@"insert into LOSGROSOS_RELOADED.CuponCiudad (idCiudad,codigoCupon)
                                            values (@idCiudad,@idCupon)", dbcon);

            cmd.Parameters.Add("@idCupon", SqlDbType.VarChar, 50);
            cmd.Parameters["@idCupon"].Value = idCupon.ToString();
            cmd.Parameters.Add("@idCiudad", SqlDbType.Int, 18);

            foreach (DataRowView item in lstCiudades.CheckedItems)
            {
                cmd.Parameters["@idCiudad"].Value = Convert.ToInt32(item["idCiudad"]);
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Support.mostrarError(ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

       

    }
}
