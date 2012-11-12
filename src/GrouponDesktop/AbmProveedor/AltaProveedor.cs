using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.AbmProveedor
{
    public partial class AltaProveedor : Form
    {
        RegistroUsuario frmPaso1 = null;

        public AltaProveedor()
        { 
            InitializeComponent(); 
        }
        
        public AltaProveedor(RegistroUsuario frmRegistro):this()
        {
            frmPaso1 = frmRegistro;
            
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
                    Application.Exit();
                }

                int idNuevoUser = Support.agregarUsuario(dbcon, 2, frmPaso1.txtPass1.Text, frmPaso1.txtUser.Text);
                guardarNuevoProv(dbcon,idNuevoUser);
                Support.mostrarInfo("Su registro finalizo con exito ");
                dbcon.Close();
                frmPaso1.Close();
                this.Close();
            }
            //Hacer insert usando stored procedure
            //mostrar msgbox
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select nombre, idCiudad 
                                            from LOSGROSOS_RELOADED.Ciudad", dbcon);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
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
            cmd.CommandText = @"Select descripcion, idRubro
                              from LOSGROSOS_RELOADED.Rubro";
            da.Fill(dt2);
            dbcon.Close();

            this.cmbCiudad.DataSource = dt;
            this.cmbCiudad.DisplayMember = "nombre";
            this.cmbCiudad.ValueMember = "idCiudad";
            this.cmbRubro.DataSource = dt2;
            this.cmbRubro.DisplayMember = "descripcion";
            this.cmbRubro.ValueMember = "idRubro";



        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtCodPos.Clear();
            this.txtCuit.Clear();
            this.txtDireccion.Clear();
            this.txtMail.Clear();
            this.txtNombreContacto.Clear();
            this.txtRazonSocial.Clear();
            this.txtTel.Clear();
            this.cmbRubro.SelectedIndex = 0;
            this.cmbCiudad.SelectedIndex = 0;
        }
        private void labelsNegras()
        {
            this.lblCiudad.ForeColor = System.Drawing.Color.Black;
            this.lblCodPos.ForeColor = System.Drawing.Color.Black;
            this.lblContacto.ForeColor = System.Drawing.Color.Black;
            this.lblCuit.ForeColor = System.Drawing.Color.Black;
            this.lblDireccion.ForeColor = System.Drawing.Color.Black;
            this.lblMail.ForeColor = System.Drawing.Color.Black;
            this.lblRazSoc.ForeColor = System.Drawing.Color.Black;
            this.lblRubro.ForeColor = System.Drawing.Color.Black;
            this.lblTel.ForeColor = System.Drawing.Color.Black;


        }
        private bool validado()
        {
            bool valid = true;
            string strError = "";
            if (this.txtRazonSocial.Text == "")
            {
                this.lblRazSoc.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Razon Social, ya que es obligatorio\n";
                valid = false;
            }
            else
            {
                if (this.txtRazonSocial.Text.Length > 255)
                {
                    lblRazSoc.ForeColor = System.Drawing.Color.Red;
                    strError += "- La longitud de la Razon Social excede la permitida\n";
                    valid = false;
                }
                else
                {
                    if (!esUnicoRazSoc(txtRazonSocial.Text))
                    {
                        this.lblRazSoc.ForeColor = System.Drawing.Color.Red;
                        strError += "- Ya hay registrado un proveedor con esa Razon Social\n";
                        valid = false;
                    }
                }

            }
            if (this.txtMail.Text == "")
            {
                this.lblMail.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Mail, ya que es obligatorio\n";
                valid = false;
            }
            else
            {
                if (this.txtMail.Text.Length > 255)
                {
                    lblMail.ForeColor = System.Drawing.Color.Red;
                    strError += "- La longitud del apellido excede la permitida\n";
                    valid = false;
                }
            }
            if (this.txtTel.Text == "")
            {
                lblTel.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Telefono, ya que es obligatorio\n";
                valid = false;
            }
            else
            {
                if (!Support.esNumerico(txtTel.Text))
                {
                    lblTel.ForeColor = System.Drawing.Color.Red;
                    strError += "- El telefono solo admite valores numericos\n";
                    valid = false;
                }
                else
                {
                    txtTel.Text = txtTel.Text.Replace(".", "");
                    txtTel.Text = txtTel.Text.Replace(",", "");
                }
            }
            if (this.txtDireccion.Text.Length > 255)
            {
                this.lblDireccion.ForeColor = System.Drawing.Color.Red;
                strError += "- La longitud de la direccion excede la permitida\n";
                valid = false;
            }
            if (this.txtCodPos.Text.Length > 10)
            {
                this.lblCodPos.ForeColor = System.Drawing.Color.Red;
                strError += "- La longitud del codigo postal excede la permitida\n";
                valid = false;
            }
            else
            {
                if (txtCodPos.Text!="" && !Support.esNumerico(txtCodPos.Text))
                {
                    lblCodPos.ForeColor = System.Drawing.Color.Red;
                    strError += "- El codigo postal solo admite valores numericos\n";
                    valid = false;
                }
            }
            if (txtCuit.MaskCompleted == true)
            {
                if (!esUnicoCuit(txtCuit.Text))
                {
                    this.lblCuit.ForeColor = System.Drawing.Color.Red;
                    strError += "- Ya hay registrado un proveedor con este CUIT\n";
                    valid = false;
                }
            }
            else
            {
                this.lblCuit.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar todos los digitos del CUIT\n";
                valid = false;
            }

            if (this.txtNombreContacto.Text.Length > 255)
            {
                this.lblContacto.ForeColor = System.Drawing.Color.Red;
                strError += "- La longitud del nombre de contacto excede la permitida\n";
                valid = false;
            }
            if (!valid) Support.mostrarError(strError);
            return valid;

        }
        
        public bool esUnicoRazSoc(string str)
        {
            bool esUnico = false;
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select  *
											from LOSGROSOS_RELOADED.Proveedor
											where razonSocial=@razonSoc", dbcon);

            cmd.Parameters.Add("@razonSoc", SqlDbType.VarChar, 255);
            cmd.Parameters["@razonSoc"].Value = str;
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
            if (dt.Rows.Count == 0) esUnico = true;
            dbcon.Close();
            return esUnico;
          
        }
        
        public bool esUnicoCuit(string str)
        {
            bool esUnico = false;
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select  *
											from LOSGROSOS_RELOADED.Proveedor
											where cuit=@cuit", dbcon);

            cmd.Parameters.Add("@cuit", SqlDbType.VarChar, 20);
            cmd.Parameters["@cuit"].Value = str;
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
            if (dt.Rows.Count == 0) esUnico = true;
            dbcon.Close();
            return esUnico;
        }
        private void guardarNuevoProv(SqlConnection dbcon, int idNuevoUser)
        {

            int idCiudad = Convert.ToInt32(this.cmbCiudad.SelectedValue);
            int idRubro = Convert.ToInt32(this.cmbRubro.SelectedValue);

            SqlCommand cmd = new SqlCommand(@"EXEC LOSGROSOS_RELOADED.P_Alta_Proveedor @razonSocial,@domicilio,
                               @idCiudad,@tel,@cuit,@idRubro,@mail,@codPostal, 
                               @nombContacto, @idUsuario", dbcon);

            cmd.Parameters.Add("@razonSocial", SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@domicilio", SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@idCiudad", SqlDbType.Int, 18);
            cmd.Parameters.Add("@tel", SqlDbType.BigInt, 18);
            cmd.Parameters.Add("@cuit", SqlDbType.VarChar,20);
            cmd.Parameters.Add("@idRubro", SqlDbType.Int, 18);
            cmd.Parameters.Add("@mail", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@codPostal", SqlDbType.Int, 10);
            cmd.Parameters.Add("@nombContacto", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@idUsuario", SqlDbType.Int, 18);

            cmd.Parameters["@razonSocial"].Value = this.txtRazonSocial.Text;
            cmd.Parameters["@idCiudad"].Value = idCiudad;
            cmd.Parameters["@tel"].Value = Convert.ToInt64(this.txtTel.Text);
            cmd.Parameters["@cuit"].Value = this.txtCuit.Text;
            cmd.Parameters["@idRubro"].Value = idRubro;
            cmd.Parameters["@mail"].Value = this.txtMail.Text;
            cmd.Parameters["@idUsuario"].Value = idNuevoUser;
            
            if (this.txtDireccion.Text != "")
            {
                cmd.Parameters["@domicilio"].Value = this.txtDireccion.Text;
            }
            else
            {
                cmd.Parameters["@domicilio"].Value = DBNull.Value;
            }
            
            if (this.txtCodPos.Text != "")
            {
                cmd.Parameters["@codPostal"].Value = this.txtCodPos.Text;
            }
            else
            {
                cmd.Parameters["@codPostal"].Value = DBNull.Value;
            }

            if (this.txtNombreContacto.Text != "")
            {
                cmd.Parameters["@nombContacto"].Value = this.txtNombreContacto.Text;
            }
            else
            {
                cmd.Parameters["@nombContacto"].Value = DBNull.Value;
            }

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
}
