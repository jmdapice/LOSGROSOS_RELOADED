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
    public partial class ModProv : Form
    {
        bool habPresionado = false;
        BuscaProv frmPadre;
        public ModProv(BuscaProv frm)
        {
            frmPadre = frm;
            InitializeComponent();
        }

        private void ModProv_Load(object sender, EventArgs e)
        {
            cargarCombos();
            cargarTextos();
            if (frmPadre.dgvProv.CurrentRow.Cells["inhab"].Value.ToString().Equals("1"))
            {
                btnHabilitar.Enabled = true;
                btnHabilitar.Text = "Habilitar";
            }
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
        private void cargarCombos()
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select RTRIM(nombre) as 'nombre', idCiudad 
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

            foreach (DataRow r in dt.Rows)
            {

                if (r["nombre"].ToString().Equals(this.frmPadre.dgvProv.CurrentRow.Cells["Ciudad"].Value.ToString()))
                {
                    this.cmbCiudad.SelectedValue = r["idCiudad"];
                }

            }
            foreach (DataRow r in dt2.Rows)
            {

                if (r["descripcion"].ToString().Equals(this.frmPadre.dgvProv.CurrentRow.Cells["Rubro"].Value.ToString()))
                {
                    this.cmbRubro.SelectedValue = r["idRubro"];
                }

            }

        }
        private void cargarTextos()
        {
            this.txtCodPos.Text = frmPadre.dgvProv.CurrentRow.Cells["CP"].Value.ToString();
            this.txtCuit.Text = frmPadre.dgvProv.CurrentRow.Cells["CUIT"].Value.ToString();
            this.txtDireccion.Text = frmPadre.dgvProv.CurrentRow.Cells["Domicilio"].Value.ToString();
            this.txtMail.Text = frmPadre.dgvProv.CurrentRow.Cells["Mail"].Value.ToString();
            this.txtNombreContacto.Text = frmPadre.dgvProv.CurrentRow.Cells["Contacto"].Value.ToString();
            this.txtRazonSocial.Text = frmPadre.dgvProv.CurrentRow.Cells["Razon Social"].Value.ToString();
            this.txtTel.Text = frmPadre.dgvProv.CurrentRow.Cells["Telefono"].Value.ToString();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
                
                if (habPresionado)
                {
                    actualizarHabilitado(dbcon);
                }
                
                guardarModProv(dbcon);
                Support.mostrarInfo("Los cambios han sido guardados");
                dbcon.Close();
                this.Close();
                frmPadre.btnLimpiar_Click(this, e);
                
                
                
            }

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
                if (txtCodPos.Text != "" && !Support.esNumerico(txtCodPos.Text))
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
            int idProv = Convert.ToInt32(frmPadre.dgvProv.CurrentRow.Cells["id"].Value);
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select  *
											from LOSGROSOS_RELOADED.Proveedor
											where razonSocial=@razonSoc
                                            and idProveedor!=@idProv", dbcon);

            cmd.Parameters.Add("@razonSoc", SqlDbType.VarChar, 255);
            cmd.Parameters["@razonSoc"].Value = str;
            cmd.Parameters.Add("@idProv", SqlDbType.Int, 18);
            cmd.Parameters["@idProv"].Value = idProv;
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
            int idProv = Convert.ToInt32(frmPadre.dgvProv.CurrentRow.Cells["id"].Value);
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select  *
											from LOSGROSOS_RELOADED.Proveedor
											where cuit=@cuit
                                            and idProveedor!=@idProv", dbcon);

            cmd.Parameters.Add("@idProv", SqlDbType.Int, 18);
            cmd.Parameters["@idProv"].Value = idProv;
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
        private void guardarModProv(SqlConnection dbcon)
        {

            int idCiudad = Convert.ToInt32(this.cmbCiudad.SelectedValue);
            int idRubro = Convert.ToInt32(this.cmbRubro.SelectedValue);

            SqlCommand cmd = new SqlCommand(@"EXEC LOSGROSOS_RELOADED.P_Modificar_Proveedor 
                               @idProv,@razonSocial,@domicilio,
                               @idCiudad,@tel,@cuit,@idRubro,@mail,@codPostal, 
                               @nombContacto", dbcon);

            cmd.Parameters.Add("@idProv", SqlDbType.Int, 18);
            cmd.Parameters.Add("@razonSocial", SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@domicilio", SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@idCiudad", SqlDbType.Int, 18);
            cmd.Parameters.Add("@tel", SqlDbType.BigInt, 18);
            cmd.Parameters.Add("@cuit", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@idRubro", SqlDbType.Int, 18);
            cmd.Parameters.Add("@mail", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@codPostal", SqlDbType.Int, 10);
            cmd.Parameters.Add("@nombContacto", SqlDbType.VarChar, 255);

            cmd.Parameters["@idProv"].Value = Convert.ToInt32(frmPadre.dgvProv.CurrentRow.Cells["id"].Value);
            cmd.Parameters["@razonSocial"].Value = this.txtRazonSocial.Text;
            cmd.Parameters["@idCiudad"].Value = idCiudad;
            cmd.Parameters["@tel"].Value = Convert.ToInt64(this.txtTel.Text);
            cmd.Parameters["@cuit"].Value = this.txtCuit.Text;
            cmd.Parameters["@idRubro"].Value = idRubro;
            cmd.Parameters["@mail"].Value = this.txtMail.Text;
            

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

        private void btnHabilitar_Click(object sender, EventArgs e)
        {

            habPresionado = true;    
            btnHabilitar.Enabled = false;
            btnHabilitar.Text = "Habilitado";
           
        
        }
        private void actualizarHabilitado(SqlConnection dbcon)
        {
            
            SqlCommand cmd = new SqlCommand(@"EXEC LOSGROSOS_RELOADED.P_HabilitacionProveedor 
                                            @idProv,'0'",dbcon);


            cmd.Parameters.Add("@idProv", SqlDbType.Int, 18); 
            cmd.Parameters["@idProv"].Value = Convert.ToInt32(frmPadre.dgvProv.CurrentRow.Cells["id"].Value);
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
