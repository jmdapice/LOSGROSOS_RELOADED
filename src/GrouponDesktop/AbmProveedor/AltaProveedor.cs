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
        public AltaProveedor(RegistroUsuario frmRegistro)
        {
            frmPaso1 = frmRegistro;
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validar Campos
            //Verificar si existen razonSocial o Cuit en la db
            //Hacer insert usando stored procedure
            //mostrar msgbox
            this.Close();
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
            cmd.CommandText=@"Select descripcion, idRubro
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
    }
}
