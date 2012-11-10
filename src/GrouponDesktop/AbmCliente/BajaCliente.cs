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
    public partial class BajaCliente : Form
    {
        public BajaCliente()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
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
                                             c.nombre as 'Ciudad', u.nombreUsuario as 'Usuario', cli.idCli as 'id'
                                             from LOSGROSOS_RELOADED.Clientes cli, LOSGROSOS_RELOADED.Ciudad c,
                                             LOSGROSOS_RELOADED.Usuario u
                                             where cli.nombre like '%'+@criterio1+'%'
                                             and cli.apellido like '%'+@criterio2+'%'
                                             and cli.mail like '%'+@criterio4+'%'
                                             and cli.idCiudad = c.idCiudad
                                             and cli.idUsuario = u.idUsuario
                                             and cli.inhabilitado = '0'", dbcon);
            }
            else
            {
                cmd = new SqlCommand(@"Selectcli.nombre as 'Nombre',cli.apellido as 'Apellido',
                                             cli.dni as 'DNI', cli.mail as 'Email', cli.direccion as 'Direccion',
                                             cli.tel as 'Telefono', cli.codPostal as 'CP', cli.fechaNac as 'Fecha Nacimiento',
                                             c.nombre as 'Ciudad', u.nombreUsuario as 'Usuario', cli.idCli as 'id'
                                             from LOSGROSOS_RELOADED.Clientes cli, LOSGROSOS_RELOADED.Ciudad c,
                                             LOSGROSOS_RELOADED.Usuario u
                                             where nombre like '%'+@criterio1+'%'
                                             and apellido like '%'+@criterio2+'%'
                                             and dni = @criterio3
                                             and mail like '%'+@criterio4+'%'
                                             and cli.idCiudad = c.idCiudad
                                             and cli.idUsuario = u.idUsuario
                                             and cli.inhabilitado = '0'", dbcon);
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
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "btnEliminar";
            buttonColumn.HeaderText = "Eliminar";
            buttonColumn.Text = " ";
            dgvClientes.Columns["Ciudad"].Width = 95;
            dgvClientes.Columns.Insert(10, buttonColumn);
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show(this, "Esta seguro que desea eliminar este Cliente?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                inhabilitarCliente(Convert.ToInt32(dgvClientes.CurrentRow.Cells["id"].Value));
                this.btnLimpiar_Click(this,e);
            }
        }

        private void inhabilitarCliente(int idCli)
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"EXEC LOSGROSOS_RELOADED.P_HabilitacionCliente 
                                            @idCli,'1'", dbcon);
            cmd.Parameters.Add("@idCli", SqlDbType.VarChar, 100);
            cmd.Parameters["@idCli"].Value = idCli;
            try
            {
                dbcon.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }
        }
    }
}
