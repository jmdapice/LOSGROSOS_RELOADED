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
    public partial class ModCliente : Form
    {
        public ModCliente()
        {
            InitializeComponent();
        }

        public void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtApe.Clear();
            this.txtDni.Clear();
            this.txtMail.Clear();
            this.txtNomb.Clear();
            dgvClientes.DataSource = null;
            dgvClientes.Columns.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvClientes.Columns.Clear();


            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd;
           


            if (this.txtDni.Text == "")
            {

                cmd = new SqlCommand(@"Select cli.nombre as 'Nombre',cli.apellido as 'Apellido',
                                             cli.dni as 'DNI', cli.mail as 'Email', cli.direccion as 'Direccion',
                                             cli.tel as 'Telefono', cli.codPostal as 'CP', cli.fechaNac as 'Fecha Nacimiento',
                                             RTRIM(c.nombre) as 'Ciudad', u.nombreUsuario as 'Usuario', cli.idCli as 'id',cli.inhabilitado as 'inhabilitado'
                                             from LOSGROSOS_RELOADED.Clientes cli, LOSGROSOS_RELOADED.Ciudad c,
                                             LOSGROSOS_RELOADED.Usuario u
                                             where cli.nombre like '%'+@criterio1+'%'
                                             and cli.apellido like '%'+@criterio2+'%'
                                             and cli.mail like '%'+@criterio4+'%'
                                             and cli.idCiudad = c.idCiudad
                                             and cli.idUsuario = u.idUsuario", dbcon);
            }
            else
            {
                cmd = new SqlCommand(@"Select cli.nombre as 'Nombre',cli.apellido as 'Apellido',
                                             cli.dni as 'DNI', cli.mail as 'Email', cli.direccion as 'Direccion',
                                             cli.tel as 'Telefono', cli.codPostal as 'CP', cli.fechaNac as 'Fecha Nacimiento',
                                             RTRIM(c.nombre) as 'Ciudad', u.nombreUsuario as 'Usuario', cli.idCli as 'id'',cli.inhabilitado as 'inhabilitado'
                                             from LOSGROSOS_RELOADED.Clientes cli, LOSGROSOS_RELOADED.Ciudad c,
                                             LOSGROSOS_RELOADED.Usuario u
                                             where cli.nombre like '%'+@criterio1+'%'
                                             and cli.apellido like '%'+@criterio2+'%'
                                             and cli.dni = @criterio3
                                             and cli.mail like '%'+@criterio4+'%'
                                             and cli.idCiudad = c.idCiudad
                                             and cli.idUsuario = u.idUsuario", dbcon);
                cmd.Parameters.Add("@criterio3", SqlDbType.Int, 18);
                cmd.Parameters["@criterio3"].Value = Convert.ToInt32(this.txtDni.Text);
            }

            cmd.Parameters.Add("@criterio1", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@criterio2", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@criterio4", SqlDbType.VarChar, 255);

            cmd.Parameters["@criterio1"].Value = this.txtNomb.Text.ToString();
            cmd.Parameters["@criterio2"].Value = this.txtApe.Text.ToString();
            cmd.Parameters["@criterio4"].Value = this.txtMail.Text.ToString();




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

            dgvClientes.DataSource = dt;

            dgvClientes.Columns[10].Visible = false;
            dgvClientes.Columns[11].Visible = false;
           
        }


        public virtual void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            AbmCliente.ModCli frmModCli = new AbmCliente.ModCli(this);
            frmModCli.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



    }
}
