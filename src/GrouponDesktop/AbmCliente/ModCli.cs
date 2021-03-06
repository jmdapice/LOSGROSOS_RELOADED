﻿using System;
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
    public partial class ModCli : Form
    {
        AbmCliente.ModCliente frmPadre = null;
        bool listaCambio = false;
        bool habPresionado = false;

        public ModCli(AbmCliente.ModCliente frmMod)
        {
            frmPadre = frmMod;
            InitializeComponent();
        }

        private void ModCli_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = frmPadre.dgvClientes.CurrentRow.Cells["Nombre"].Value.ToString();
            this.txtApellido.Text = frmPadre.dgvClientes.CurrentRow.Cells["Apellido"].Value.ToString();
            this.txtDni.Text = frmPadre.dgvClientes.CurrentRow.Cells["Dni"].Value.ToString();
            this.txtMail.Text = frmPadre.dgvClientes.CurrentRow.Cells["Email"].Value.ToString();
            this.txtTel.Text = frmPadre.dgvClientes.CurrentRow.Cells["Telefono"].Value.ToString();
            this.txtFecNac.Text = frmPadre.dgvClientes.CurrentRow.Cells["Fecha Nacimiento"].Value.ToString();
            this.txtDireccion.Text = frmPadre.dgvClientes.CurrentRow.Cells["Direccion"].Value.ToString();
            this.txtCP.Text = frmPadre.dgvClientes.CurrentRow.Cells["CP"].Value.ToString();

            DateTime fechaActual = Support.fechaConfig();
            this.monthCalendar1.MaxDate = fechaActual;
            this.monthCalendar1.TodayDate = fechaActual;

            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select RTRIM(nombre) as nombre, idCiudad 
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

            //carga al combobox la cuidad
            foreach (DataRow r in dt2.Rows)
            {

                if (r["nombre"].ToString().Equals(this.frmPadre.dgvClientes.CurrentRow.Cells["ciudad"].Value.ToString()))
                {
                    cmbCiudades.SelectedValue = r["idCiudad"];
                }

            }


            int idCliente = Convert.ToInt32(frmPadre.dgvClientes.CurrentRow.Cells["id"].Value);
            cmd.CommandText = @"Select idCiudad 
                                from LOSGROSOS_RELOADED.CiudadesPreferidas 
                                where idCli=@idCliente";
            cmd.Parameters.Add("@idCliente", SqlDbType.VarChar, 100);
            cmd.Parameters["@idCliente"].Value = idCliente;

            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd);
            try
            {
                da3.Fill(dt3);
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }

            if (frmPadre.dgvClientes.CurrentRow.Cells["inhabilitado"].Value.ToString().Equals("1"))
            {
                btnHabilitar.Enabled = true;
                btnHabilitar.Text = "Habilitar";
            }



            foreach (DataRow fila in dt3.Rows)
            {

                for (int i = 0; i < lstCiudadesElegidas.Items.Count; i++)
                {
                    if (fila["idCiudad"].Equals((lstCiudadesElegidas.Items[i] as DataRowView).Row["idCiudad"]))
                    {//Si la funcionalidad en la dataTable coincide con una de la lista, hay que checkearla
                        lstCiudadesElegidas.SetItemChecked(i, true);
                    }
                }


            }
            dbcon.Close();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtApellido.Clear();
            this.txtDireccion.Clear();
            this.txtDni.Clear();
            this.txtFecNac.Clear();
            this.txtMail.Clear();
            this.txtNombre.Clear();
            this.txtCP.Clear();
            this.txtTel.Clear();
            this.cmbCiudades.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

                if (habPresionado)
                {
                    actualizarHabilitado(dbcon);
                }
                modificarCliente(dbcon);
                Support.mostrarInfo("La modificacion se realizo con exito ");
                dbcon.Close();
                this.Close();
                frmPadre.btnLimpiar_Click(this, e);

            }

        }


        private void actualizarHabilitado(SqlConnection dbcon)
        {

            SqlCommand cmd = new SqlCommand(@"EXEC LOSGROSOS_RELOADED.P_HabilitacionCliente 
                                            @idCli,'0'", dbcon);


            cmd.Parameters.Add("@idCli", SqlDbType.Int, 18);
            cmd.Parameters["@idCli"].Value = Convert.ToInt32(frmPadre.dgvClientes.CurrentRow.Cells["id"].Value);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }

        }


        private bool validar()
        {
            bool validado = true;
            string strError = "";
            if (this.txtNombre.Text == "")
            {
                lblNombre.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Nombre, ya que es obligatorio\n";
                validado = false;
            }

            if (this.txtApellido.Text == "")
            {
                lblApellido.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Apellido, ya que es obligatorio\n";
                validado = false;
            }

            if (this.txtTel.Text == "")
            {
                lblTel.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Telefono, ya que es obligatorio\n";
                validado = false;
            }
            else
            {
                if (!Support.esNumerico(txtTel.Text))
                {
                    lblTel.ForeColor = System.Drawing.Color.Red;
                    strError += "- El telefono solo admite valores numericos\n";
                    validado = false;
                }
                else
                {
                    txtTel.Text = txtTel.Text.Replace(".", "");
                    txtTel.Text = txtTel.Text.Replace(",", "");
                    if (!validarTelUnico(Convert.ToInt64(this.txtTel.Text)))
                    {
                        lblTel.ForeColor = System.Drawing.Color.Red;
                        strError += "- Ya hay registrado un cliente con este telefono\n";
                        validado = false;
                    }
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
            else
            {
                if (!Support.esNumerico(txtDni.Text))
                {
                    lblDNI.ForeColor = System.Drawing.Color.Red;
                    strError += "- El DNI solo admite valores numericos\n";
                    validado = false;
                }
                else
                {
                    txtDni.Text = txtDni.Text.Replace(".", "");
                    txtDni.Text = txtDni.Text.Replace(",", "");
                    if (!validarDniUnico(Convert.ToInt64(this.txtDni.Text)))
                    {
                        lblDNI.ForeColor = System.Drawing.Color.Red;
                        strError += "- Ya hay registrado un cliente con este DNI\n";
                        validado = false;
                    }
                }

            }

            if (this.txtMail.Text == "")
            {
                lblMail.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe completar el campo Mail, ya que es obligatorio\n";
                validado = false;
            }

            if (this.txtCP.Text != "")
            {
                if (!Support.esNumerico(txtCP.Text))
                {
                    lblCP.ForeColor = System.Drawing.Color.Red;
                    strError += "- El Codigo Postal solo admite valores numericos\n";
                    validado = false;
                }
                else
                {
                    txtCP.Text = txtCP.Text.Replace(".", "");
                    txtCP.Text = txtCP.Text.Replace(",", "");
                }
            }

            if (!validado) Support.mostrarError(strError);
            return validado;

        }


        private bool validarTelUnico(Int64 tel)
        {
            bool telUnico = false;
            int idCliente = Convert.ToInt32(frmPadre.dgvClientes.CurrentRow.Cells["id"].Value);
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select  *
											from LOSGROSOS_RELOADED.Clientes
											where tel=@tel
                                            and idCli != @idCli", dbcon);

            cmd.Parameters.Add("@tel", SqlDbType.BigInt, 18);
            cmd.Parameters.Add("@idCli", SqlDbType.Int, 18);
            cmd.Parameters["@tel"].Value = tel;
            cmd.Parameters["@idCli"].Value = idCliente;
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

        private bool validarDniUnico(Int64 dni)
        {
            bool dniUnico = false;
            int idCliente = Convert.ToInt32(frmPadre.dgvClientes.CurrentRow.Cells["id"].Value);
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select  *
											from LOSGROSOS_RELOADED.Clientes
											where dni=@dni
                                            and idCli != @idCli", dbcon);

            cmd.Parameters.Add("@dni", SqlDbType.BigInt, 18);
            cmd.Parameters.Add("@idCli", SqlDbType.Int, 18);
            cmd.Parameters["@idCli"].Value = idCliente;
            cmd.Parameters["@dni"].Value = dni;
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
            if (dt.Rows.Count == 0) dniUnico = true;
            dbcon.Close();
            return dniUnico;

        }

        private void labelsNegras()
        {
            lblNombre.ForeColor = System.Drawing.Color.Black;
            lblApellido.ForeColor = System.Drawing.Color.Black;
            lblDire.ForeColor = System.Drawing.Color.Black;
            lblDNI.ForeColor = System.Drawing.Color.Black;
            lblMail.ForeColor = System.Drawing.Color.Black;
            lblTel.ForeColor = System.Drawing.Color.Black;
            lblCP.ForeColor = System.Drawing.Color.Black;
        }

        private void modificarCliente(SqlConnection dbcon)
        {
            int idCiudad = Convert.ToInt32(cmbCiudades.SelectedValue);
            int idCliente = Convert.ToInt32(frmPadre.dgvClientes.CurrentRow.Cells["id"].Value);
            SqlCommand cmd = new SqlCommand(@"EXEC LOSGROSOS_RELOADED.P_Modificar_Cliente 
                               @idCli,@nombre,@apellido,
                               @dni,@direccion, @tel, @mail,@fechaNac, 
                               @idCiudad, @codPostal", dbcon);

            cmd.Parameters.Add("@idCli", SqlDbType.Int, 18);
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@dni", SqlDbType.BigInt, 18);
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@tel", SqlDbType.BigInt, 18);
            cmd.Parameters.Add("@mail", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@fechaNac", SqlDbType.DateTime);
            cmd.Parameters.Add("@idCiudad", SqlDbType.Int, 18);
            cmd.Parameters.Add("@codPostal", SqlDbType.BigInt, 10);

            cmd.Parameters["@idCli"].Value = idCliente;
            cmd.Parameters["@nombre"].Value = this.txtNombre.Text;
            cmd.Parameters["@apellido"].Value = this.txtApellido.Text;
            cmd.Parameters["@dni"].Value = Convert.ToInt64(this.txtDni.Text);
            cmd.Parameters["@direccion"].Value = this.txtDireccion.Text;
            cmd.Parameters["@tel"].Value = Convert.ToInt64(this.txtTel.Text);
            cmd.Parameters["@mail"].Value = this.txtMail.Text;
            cmd.Parameters["@idCiudad"].Value = idCiudad;


            if (this.txtFecNac.Text != "")
            {
                cmd.Parameters["@fechaNac"].Value = Convert.ToDateTime(this.txtFecNac.Text);
            }
            else
            {
                cmd.Parameters["@fechaNac"].Value = DBNull.Value;
            }
            if (this.txtCP.Text != "")
            {
                cmd.Parameters["@codPostal"].Value = Convert.ToInt64(this.txtCP.Text);
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


            if (listaCambio)
            {
                modificarCiudadesPreferidas(dbcon, idCliente, lstCiudadesElegidas);
            }

        }

        private void lstCiudadesElegidas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            listaCambio = true;
        }
        private void modificarCiudadesPreferidas(SqlConnection dbcon, int idCli, CheckedListBox lista)
        {

            SqlCommand cmd = dbcon.CreateCommand();
            dbcon.Open();
            SqlTransaction trans = dbcon.BeginTransaction("Trans");
            cmd.Connection = dbcon;
            cmd.Transaction = trans;
            cmd.Parameters.Add("@idCli", SqlDbType.Int, 18);
            cmd.Parameters["@idCli"].Value = idCli;


            try
            {
                //Borro todas las ciudades que tenia cargadas
                cmd.CommandText = @"delete LOSGROSOS_RELOADED.PermisoPorRol 
                                    from LOSGROSOS_RELOADED.CiudadesPreferidas
                                    where idCli=@idCli";
                cmd.ExecuteNonQuery();

                //Agrego las ciudades 

                cmd.Parameters.Add("@idCiudad", SqlDbType.Int, 18);
                cmd.CommandText = @"insert into LOSGROSOS_RELOADED.CiudadesPreferidas (idCiudad,idCli)
                                            values (@idCiudad,@idCli)";
                foreach (DataRowView item in lista.CheckedItems)
                {
                    cmd.Parameters["@idCiudad"].Value = Convert.ToInt32(item["idCiudad"]);
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
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

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            habPresionado = true;
            btnHabilitar.Text = "Habilitado";
            btnHabilitar.Enabled = false;
        }


    }
}
