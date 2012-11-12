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
    public partial class BuscaProv : Form
    {
        public BuscaProv()
        {
            InitializeComponent();
        }

        public void btnLimpiar_Click(object sender, EventArgs e)
        { 
            this.txtMail.Clear();
            this.txtRazSoc.Clear();
            this.txtCuit.Clear();
            dgvProv.DataSource = null;
            dgvProv.Columns.Clear();
        }

        public void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvProv.Columns.Clear();


            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd;
            cmd = new SqlCommand(@"Select p.razonSocial as 'Razon Social', p.domicilio as 'Domicilio',
                                             RTRIM(c.nombre) as 'Ciudad', p.tel as 'Telefono', p.cuit as 'CUIT',
                                             r.descripcion as 'Rubro',p.mail as 'Mail',p.codPostal as 'CP',
                                             p.nombContacto as 'Contacto',u.nombreUsuario as 'Usuario',
                                             p.idProveedor as 'id', p.inhabilitado                    
                                             from LOSGROSOS_RELOADED.Proveedor p, LOSGROSOS_RELOADED.Ciudad c,
                                             LOSGROSOS_RELOADED.Usuario u,LOSGROSOS_RELOADED.Rubro r
                                             where p.idCiudad = c.idCiudad
                                             and p.idRubro = r.idRubro               
                                             and p.idUsuario = u.idUsuario
                                             and p.razonSocial like '%'+@criterio1+'%' ", dbcon);
                     

            cmd.Parameters.Add("@criterio1", SqlDbType.VarChar, 255);
            cmd.Parameters["@criterio1"].Value = this.txtRazSoc.Text;
            
            if (this.txtMail.Text != "")
            {
               cmd.CommandText += "and p.mail like '%'+@criterio2+'%' ";
               cmd.Parameters.Add("@criterio2", SqlDbType.VarChar,255);
               cmd.Parameters["@criterio2"].Value = this.txtMail.Text;

            }

            if (this.txtCuit.Text != "")
            {
                cmd.CommandText += "and p.cuit = @criterio3 ";
                cmd.Parameters.Add("@criterio3", SqlDbType.VarChar, 20);
                cmd.Parameters["@criterio3"].Value = this.txtCuit.Text;

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

            this.dgvProv.DataSource = dt;

            dgvProv.Columns["id"].Visible = false;
            dgvProv.Columns["inhabilitado"].Visible = false;
            dgvProv.Columns["Domicilio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           
        }

        public virtual void dgvProv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ModProv frm = new ModProv(this);
            frm.ShowDialog();
        }
        
    }
}
