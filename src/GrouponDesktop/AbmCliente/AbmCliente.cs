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
    public partial class AbmCliente : Form
    {
        public AbmCliente()
        {
            InitializeComponent();
        }

        private void AbmCliente_Load(object sender, EventArgs e)
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            dbcon.Open();
            SqlCommand cmd = new SqlCommand(@"Select nombre 
                                            from LOSGROSOS_RELOADED.Ciudad", dbcon);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.listBoxCiudades.Items.Add(dt.Rows[i]["nombre"].ToString());
                this.comboBox1.Items.Add(dt.Rows[i]["nombre"].ToString());
            }

            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.txtFecNac.Text = this.monthCalendar1.SelectionStart.Date.ToString();
            this.monthCalendar1.Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtApellido.Clear();
            this.txtDireccion.Clear();
            this.txtDni.Clear();
            this.txtFecNac.Clear();
            this.txtMail.Clear();
            this.txtNombre.Clear();
            this.txtCodPos.Clear();
            this.txtTel.Clear();
            this.listBoxCiuElegidas.Items.Clear();
            this.comboBox1.Items.Clear();
        }

        private void btnElegirCiudad_Click(object sender, EventArgs e)
        {
            this.listBoxCiuElegidas.Items.Add(this.listBoxCiudades.SelectedItem);
        }




    }
}
