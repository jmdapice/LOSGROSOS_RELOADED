using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.GestionUsuarios
{
    public partial class AltaUsuario : Form
    {
        public AltaUsuario()
        {
            InitializeComponent();
        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select descripcion, idRol 
                                            from LOSGROSOS_RELOADED.Rol
                                            where descripcion != 'Cliente'
                                            and descripcion !='Proveedor'", dbcon);
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
            this.cmbRol.DataSource = dt;
            this.cmbRol.DisplayMember = "descripcion";
            this.cmbRol.ValueMember = "idRol";
        
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            lblNomUsuario.ForeColor = System.Drawing.Color.Black;
            label2.ForeColor = System.Drawing.Color.Black;
            label3.ForeColor = System.Drawing.Color.Black;
            label4.ForeColor = System.Drawing.Color.Black;

            if (validarRegistro())
            {
                if (!nombreDuplicado(txtUser.Text.ToString()))
                {
                    SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
                    dbcon.Open();
                    Support.agregarUsuario(dbcon,Convert.ToInt32(this.cmbRol.SelectedValue),this.txtPass1.Text,this.txtUser.Text);
                    dbcon.Close();
                }
                else
                {
                    string strError = "El nombre de usuario elegido ya existe, elija otro";
                    Support.mostrarError(strError);
                }

            }
        }
        private bool validarRegistro()
        {
            bool validado = true;
            string strError = "";
            if (txtUser.Text.Length > 100 || txtUser.Text == "")
            {
                lblNomUsuario.ForeColor = System.Drawing.Color.Red;
                strError += "- La longitud del nombre de usuario es incorrecta\n";
                validado = false;
            }
            if (txtPass1.Text.Length < 8 || txtPass1.Text == "")
            {
                label2.ForeColor = System.Drawing.Color.Red;
                strError += "- La contraseña debe ser mayor a 8 caracteres\n";
                validado = false;
            }
            if (txtPass1.Text != txtPass2.Text)
            {
                label3.ForeColor = System.Drawing.Color.Red;
                strError += "- Las contraseñas ingresadas no coinciden\n";
                validado = false;
            }
           if (!validarRol(Convert.ToInt32(cmbRol.SelectedValue)))
            {
                label4.ForeColor = System.Drawing.Color.Red;
                strError += "- El Rol elegido esta inhabilitado\n";
                validado = false;
            }

            if (!validado) Support.mostrarError(strError);
            return validado;

        }
        private bool nombreDuplicado(string nombreUsuario)
        {
            bool duplicado = false;
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select  *
											from LOSGROSOS_RELOADED.Usuario
											where nombreUsuario=@usuario", dbcon);

            cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 100);
            cmd.Parameters["@usuario"].Value = nombreUsuario;
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
            if (dt.Rows.Count > 0) duplicado = true;
            dbcon.Close();
            return duplicado;


        }
        private bool validarRol(int rol)
        {
            bool validado = true;
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select inhabilitado
                                            from LOSGROSOS_RELOADED.Rol
                                            where idRol= @rol", dbcon);

            cmd.Parameters.Add("@rol", SqlDbType.Int, 18);
            cmd.Parameters["@rol"].Value = rol;
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
            if (dt.Rows[0]["inhabilitado"].ToString() == "1") validado = false;
            dbcon.Close();
            return validado;
        }


    }
    }

