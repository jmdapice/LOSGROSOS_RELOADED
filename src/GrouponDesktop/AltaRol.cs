using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop
{
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select descripcion, idPermiso 
                                            from LOSGROSOS_RELOADED.Permiso", dbcon);

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

            this.lstFuncElegidas.DataSource = dt;
            this.lstFuncElegidas.DisplayMember = "descripcion";
            this.lstFuncElegidas.ValueMember = "idPermiso";
            
            


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
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
                int idNuevoRol = agregarNombreRol(dbcon);
                agregarFuncionesRol(dbcon, idNuevoRol);
                MessageBox.Show("El Nuevo Rol se ha cargado con exito");
                btnLimpiar_Click(this, e);
                dbcon.Close();
            }
        }

        private int agregarNombreRol(SqlConnection dbcon)
        {
            
            SqlCommand cmd = new SqlCommand(@"insert into LOSGROSOS_RELOADED.Rol (descripcion)
                                            values (@nombre)", dbcon);
                

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100);
            cmd.Parameters["@nombre"].Value = txtNombRol.Text.ToString();
            int idNuevoRol = 0;
            try
            {
                
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }
            cmd.CommandText = @"select idRol from LOSGROSOS_RELOADED.Rol where descripcion=@nombre";

            try
            {

                idNuevoRol = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }

            return idNuevoRol;
        }
        
        private void agregarFuncionesRol(SqlConnection dbcon,int idRolNuevo)
        {
            SqlCommand cmd = new SqlCommand(@"insert into LOSGROSOS_RELOADED.PermisoPorRol (idRol,idPermiso)
                                            values (@idRol,@idPermiso)", dbcon);
            cmd.Parameters.Add("@idRol", SqlDbType.Int, 18);
            cmd.Parameters["@idRol"].Value = idRolNuevo;
            cmd.Parameters.Add("@idPermiso", SqlDbType.Int, 18);
            
            foreach (DataRowView item in lstFuncElegidas.CheckedItems)
            {
                cmd.Parameters["@idPermiso"].Value = Convert.ToInt32(item["idPermiso"]);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombRol.Clear();

            //Limpiar checks
            foreach (int i in this.lstFuncElegidas.CheckedIndices)
            {
                this.lstFuncElegidas.SetItemCheckState(i, CheckState.Unchecked);
            }

 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validado()
        {
            string strError="";
            bool val=true;

            if (txtNombRol.Text.Length > 100 || txtNombRol.Text == "")
            {
                lblNomRol.ForeColor = System.Drawing.Color.Red;
                strError += "- La longitud del nombre de Rol es incorrecta\n";
                val = false;
            }
            if (lstFuncElegidas.CheckedItems.Count == 0)
            {
                lblFun.ForeColor = System.Drawing.Color.Red;
                strError += "- Debe seleccionar al menos una funcionalidad\n";
                val = false;
            }
            if (!val) Support.mostrarError(strError);
            return val;
            
        }

       
    }
}
