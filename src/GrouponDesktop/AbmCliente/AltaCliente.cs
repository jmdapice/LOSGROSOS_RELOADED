using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.AbmCliente
{
    public partial class AltaCliente : Form
    {
        RegistroUsuario frmPaso1 = null;
        public AltaCliente(RegistroUsuario frmRegistro)
        {
            frmPaso1 = frmRegistro;
            InitializeComponent();
        }

        private void AbmCliente_Load(object sender, EventArgs e)
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
                da.Fill(dt2);

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }
            dbcon.Close();
            this.lstCiudadesElegidas.DataSource = dt;
            this.lstCiudadesElegidas.DisplayMember = "nombre";
            this.lstCiudadesElegidas.ValueMember = "idCiudad";
            this.cmbCiudades.DataSource = dt2;
            this.cmbCiudades.DisplayMember = "nombre";
            this.cmbCiudades.ValueMember = "idCiudad";


        }

        private void button_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.txtFecNac.Text = this.monthCalendar1.SelectionStart.ToShortDateString();
            this.monthCalendar1.Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtApellido.Clear();
            this.txtDireccion.Clear();
            this.txtDni.Clear();
            this.txtFecNac.Clear();
            this.txtMail.Clear();
            this.masktxtNombre.Clear();
            this.masktxtCodPos.Clear();
            this.masktxtTel.Clear();
            this.cmbCiudades.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            labelsNegras();
            if (validar())
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
                int idNuevoUser = agregarUsuario(dbcon);
                guardarNuevoCliente(dbcon, idNuevoUser);
                MessageBox.Show("Su registro finalizo con exito ");
                frmPaso1.btnCancelar_Click(this,e);
                dbcon.Close();
                this.Close();
       
            }
        }

        private bool validar()
        {
            bool validado = true;
            string strError = "";
            if (this.masktxtNombre.Text == "")
            {
                lblNombre.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Nombre, ya que es obligatorio\n";
                validado = false;
            }
            else
            {
                if (this.masktxtNombre.Text.Length > 255)
                {
                    lblNombre.ForeColor = System.Drawing.Color.Red;
                    strError += "- La longitud del nombre excede la permitida\n";
                    validado = false;
                }

            }
            if (this.txtApellido.Text == "")
            {
                lblApellido.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Apellido, ya que es obligatorio\n";
                validado = false;
            }
            else
            {
                if (this.txtApellido.Text.Length > 255)
                {
                    lblApellido.ForeColor = System.Drawing.Color.Red;
                    strError += "- La longitud del apellido excede la permitida\n";
                    validado = false;
                }
            }
            if (this.masktxtTel.Text == "")
            {
                lblTel.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Telefono, ya que es obligatorio\n";
                validado = false;
            }
            else
            {
                if (!validarTelUnico(Convert.ToInt32(this.masktxtTel.Text)))
                {
                    lblTel.ForeColor = System.Drawing.Color.Red;
                    strError += "- Ya hay registrado un cliente con este telefono\n";
                    validado = false;
                }
            }
            if (this.txtDireccion.Text == "")
            {
                lblDire.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Direccion, ya que es obligatorio\n";
                validado = false;
            }
            if (this.txtDni.Text == "")
            {
                lblDNI.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo DNI, ya que es obligatorio\n";
                validado = false;
            }
            if (this.txtMail.Text == "")
            {
                lblMail.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Mail, ya que es obligatorio\n";
                validado = false;
            }

            if (!validado) Support.mostrarError(strError);
            return validado;

        }


        private bool validarTelUnico(Int32 tel)
        {
            bool telUnico = false;
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select  *
											from LOSGROSOS_RELOADED.Clientes
											where tel=@tel", dbcon);

            cmd.Parameters.Add("@tel", SqlDbType.Int, 18);
            cmd.Parameters["@tel"].Value = tel;
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
            if (dt.Rows.Count == 0) telUnico = true;
            dbcon.Close();
            return telUnico;

        }

        private void labelsNegras()
        {
            lblNombre.ForeColor = System.Drawing.Color.Black;
            lblApellido.ForeColor = System.Drawing.Color.Black;
            lblDire.ForeColor = System.Drawing.Color.Black;
            lblDNI.ForeColor = System.Drawing.Color.Black;
            lblMail.ForeColor = System.Drawing.Color.Black;
            lblTel.ForeColor = System.Drawing.Color.Black;
        }

        private int agregarUsuario(SqlConnection dbcon)
        {
            SqlCommand cmd = new SqlCommand(@"insert into LOSGROSOS_RELOADED.Usuario 
                                            (nombreUsuario,contrasena,idRol)
                                            values (@nombre,@pass,@idRol)", dbcon);

            string pass = Support.GenerarSha256(this.frmPaso1.txtPass1.Text.ToString());
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100);
            cmd.Parameters["@nombre"].Value = this.frmPaso1.txtUser.Text.ToString();
            cmd.Parameters.Add("@pass",SqlDbType.Char, 64);
            cmd.Parameters["@pass"].Value = pass;
            cmd.Parameters.Add("@idRol", SqlDbType.Int, 18);
            cmd.Parameters["@idRol"].Value = 1;

            int idNuevoUser = 0;
            try
            {

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }

            cmd.CommandText = @"select idUsuario from LOSGROSOS_RELOADED.Usuario
                                    where nombreUsuario=@nombre";

            try
            {

                idNuevoUser = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }

            return idNuevoUser;
        }

        private void guardarNuevoCliente(SqlConnection dbcon, int idNuevoUser)
        {

            int idCiudad = Convert.ToInt32(cmbCiudades.SelectedValue);

            SqlCommand cmd = new SqlCommand(@"EXEC LOSGROSOS_RELOADED.P_ALta_Cliente @nombre,@apellido,
                               @dni,@direccion, @tel, @mail,@fechaNac, 
                               @idCiudad, @codPostal, @saldo, @idUsuario
                               SELECT * FROM LOSGROSOS_RELOADED.Clientes",dbcon);

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@dni", SqlDbType.Int, 18);
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@tel", SqlDbType.Int, 18);
            cmd.Parameters.Add("@mail", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@fechaNac", SqlDbType.DateTime);
            cmd.Parameters.Add("@idCiudad", SqlDbType.Int, 18);
            cmd.Parameters.Add("@codPostal", SqlDbType.Int, 10);
            cmd.Parameters.Add("@saldo", SqlDbType.Float, 18);
            cmd.Parameters.Add("@idUsuario", SqlDbType.Int, 18);

            cmd.Parameters["@nombre"].Value = this.masktxtNombre.Text;
            cmd.Parameters["@apellido"].Value = this.txtApellido.Text;
            cmd.Parameters["@dni"].Value = Convert.ToInt32(this.txtDni.Text);
            cmd.Parameters["@direccion"].Value = this.txtDireccion.Text;
            cmd.Parameters["@tel"].Value = Convert.ToInt32(this.masktxtTel.Text);
            cmd.Parameters["@mail"].Value = this.txtMail.Text;
            cmd.Parameters["@idCiudad"].Value = idCiudad;
            cmd.Parameters["@saldo"].Value = Support.saldoBienvenida;
            cmd.Parameters["@idUsuario"].Value = idNuevoUser;
            if(this.txtFecNac.Text != "")
            {
                cmd.Parameters["@fechaNac"].Value = Convert.ToDateTime(this.txtFecNac.Text);
            }else{
                cmd.Parameters["@fechaNac"].Value = DBNull.Value;
            }
            if(this.masktxtCodPos.Text != "")
            {
                cmd.Parameters["@codPostal"].Value = Convert.ToInt32(this.masktxtCodPos.Text);
            }
            else
            {
                cmd.Parameters["@codPostal"].Value = DBNull.Value;
            }

            try
            {

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }


            cmd.CommandText = @"select idCli from LOSGROSOS_RELOADED.Clientes
                               where tel=@tel";
            int idNuevoCli = 0;
            try
            {
               idNuevoCli = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }

            if (this.lstCiudadesElegidas.CheckedItems.Count > 0)
            {

                agregarCiudadesPreferidas(dbcon, idNuevoCli);
            }

       }

        private void agregarCiudadesPreferidas(SqlConnection dbcon, int idCliente)
        {
            SqlCommand cmd = new SqlCommand(@"insert into LOSGROSOS_RELOADED.CiudadesPreferidas (idCiudad,idCli)
                                            values (@idCiudad,@idCli)", dbcon);
           
            cmd.Parameters.Add("@idCli", SqlDbType.Int, 18);
            cmd.Parameters["@idCli"].Value = idCliente;
            cmd.Parameters.Add("@idCiudad", SqlDbType.Int, 18);

            foreach (DataRowView item in lstCiudadesElegidas.CheckedItems)
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


    }
}
