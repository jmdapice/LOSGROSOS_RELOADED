using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.AbmRoles
{
    public partial class ModRol2 : Form
    {
        string nomRol = "";
        bool listaCambio = false;
        bool habilitado = false;
        ModRol frmPadre = null;
        public ModRol2(ModRol frm)
        {
            InitializeComponent();
            frmPadre = frm;
        }

        private void ModRol2_Load(object sender, EventArgs e)
        {
            nomRol = this.frmPadre.dgvRoles.SelectedRows[0].Cells[0].Value.ToString();
            txtNombRol.Text = nomRol;

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

            cmd.CommandText = @"Select a.descripcion, a.idPermiso ,c.inhabilitado
                                from LOSGROSOS_RELOADED.Permiso a, LOSGROSOS_RELOADED.PermisoPorRol b,LOSGROSOS_RELOADED.Rol c
                                where c.idRol=b.idRol
                                and a.idPermiso=b.idPermiso
                                and c.descripcion=@nomRol";
            cmd.Parameters.Add("@nomRol", SqlDbType.VarChar, 100);
            cmd.Parameters["@nomRol"].Value = nomRol;
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            try
            {
                da2.Fill(dt2);
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }

            if (dt2.Rows[0]["inhabilitado"].ToString() == "0")
            {
                checkBox1.Checked = true;
                habilitado = true;
            }
            
            foreach (DataRow fila in dt2.Rows)
            {

                for (int i = 0; i < lstFuncElegidas.Items.Count; i++)
                {
                    //Este casteo es muy ninja
                    if (fila["idPermiso"].Equals((lstFuncElegidas.Items[i] as DataRowView).Row["idPermiso"]))
                    {//Si la funcionalidad en la dataTable coincide con una de la lista, hay que checkearla
                        lstFuncElegidas.SetItemChecked(i, true);
                    }
                }


            }
            dbcon.Close();



        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.lblNomRol.ForeColor = System.Drawing.Color.Black;
            if (validado())
            {
                if (!nombreDuplicado(txtNombRol.Text.ToString()))
                {
                    if (!(habilitado && this.checkBox1.Checked))
                    {
                        //se toco el tilde de habilitado
                        actualizarHabilitado();
                    }
                    if (listaCambio)
                    {
                        //se tocaron las funcionalidades, hay que actualizar la db
                        actualizarFuncionalidades(lstFuncElegidas);
                    }
                    if (txtNombRol.Text != nomRol)
                    {
                        actualizarNombreRol();
                    }
                }
                else
                {
                    string strError = "El nombre de rol elegido ya existe, elija otro";
                    Support.mostrarError(strError);
                }
                this.Close();
            }
        }

        private void lstFuncElegidas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            listaCambio = true;
        }
        private void actualizarFuncionalidades(CheckedListBox lista)
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = dbcon.CreateCommand();
            dbcon.Open();
            SqlTransaction trans = dbcon.BeginTransaction("Trans");
            cmd.Connection = dbcon;
            cmd.Transaction = trans;
            cmd.Parameters.Add("@nomRol", SqlDbType.VarChar, 100);
            cmd.Parameters["@nomRol"].Value = nomRol;
            
           
            try
            {
                //Borro todos los permisos viejos
                cmd.CommandText = @"delete LOSGROSOS_RELOADED.PermisoPorRol from LOSGROSOS_RELOADED.PermisoPorRol a, LOSGROSOS_RELOADED.Rol b
                                    where b.descripcion=@nomRol
                                    and a.idRol=b.idRol";
                cmd.ExecuteNonQuery();
                               
                //Agrego los permisos nuevos
               
                cmd.Parameters.Add("@idPermiso", SqlDbType.Int, 18);
                cmd.CommandText = @"insert into LOSGROSOS_RELOADED.PermisoPorRol (idRol,idPermiso)
                                    select idRol,@idPermiso from LOSGROSOS_RELOADED.Rol 
                                    where descripcion=@nomRol";
                foreach (DataRowView item in lista.CheckedItems)
                {
                    cmd.Parameters["@idPermiso"].Value = Convert.ToInt32(item["idPermiso"]);
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
        private void actualizarNombreRol()
        {
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"update LOSGROSOS_RELOADED.Rol 
                                              set descripcion=@nuevoNomRol
                                              where descripcion=@nomRol", dbcon);
            cmd.Parameters.Add("@nuevoNomRol", SqlDbType.VarChar, 100);
            cmd.Parameters["@nuevoNomRol"].Value = txtNombRol.Text;
            cmd.Parameters.Add("@nomRol", SqlDbType.VarChar, 100);
            cmd.Parameters["@nomRol"].Value = nomRol;
            dbcon.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }
            dbcon.Close();

 
        }
        private void actualizarHabilitado()
        {
            string inhabilitado = "";
            if (checkBox1.Checked)
            {
                inhabilitado="0";
            }
            if(!checkBox1.Checked)
            {
                inhabilitado = "1";
            }
            
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"update LOSGROSOS_RELOADED.Rol 
                                              set inhabilitado=@inhab
                                              where descripcion=@nomRol", dbcon);
            cmd.Parameters.Add("@inhab", SqlDbType.Char, 1);
            cmd.Parameters["@inhab"].Value = inhabilitado;
            cmd.Parameters.Add("@nomRol", SqlDbType.VarChar, 100);
            cmd.Parameters["@nomRol"].Value = nomRol;
            dbcon.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Support.mostrarError(ex.Message);
            }
            dbcon.Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validado()
        {
            string strError = "";
            bool val = true;

            if (txtNombRol.Text.Length > 100 || txtNombRol.Text == "")
            {
                lblNomRol.ForeColor = System.Drawing.Color.Red;
                strError += "- La longitud del nombre de Rol es incorrecta\n";
                val = false;
            }
            

            if (!val) Support.mostrarError(strError);
            return val;
        }
        
        private bool nombreDuplicado(string nomRol)
        {
            bool duplicado = false;
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select  *
											from LOSGROSOS_RELOADED.Rol
											where descripcion=@nomRol
                                            and idRol!=@idRol", dbcon);

            cmd.Parameters.Add("@nomRol", SqlDbType.VarChar, 100);
            cmd.Parameters["@nomRol"].Value = nomRol;
            cmd.Parameters.Add("@idRol", SqlDbType.Int, 18);
            cmd.Parameters["@idRol"].Value = Convert.ToInt32(frmPadre.dgvRoles.CurrentRow.Cells["idRol"].Value);
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

    }
}
