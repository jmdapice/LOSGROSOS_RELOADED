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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            apagarMenues();
            SqlConnection dbcon = new SqlConnection(GrouponDesktop.Properties.Settings.Default["conStr"].ToString());
            SqlCommand cmd = new SqlCommand(@"Select idPermiso 
                                            from LOSGROSOS_RELOADED.PermisoPorRol 
                                            where idRol = @idRol ", dbcon);

            cmd.Parameters.Add("@idRol", SqlDbType.Int, 18);
            cmd.Parameters["@idRol"].Value = Support.idRol;
           

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

            foreach (DataRow fila in dt.Rows)
            {
                prenderMenu(Convert.ToInt32(fila["idPermiso"]));
            }


        }
        private void prenderMenu(int idPermiso) 
        {
            switch (idPermiso)
            {
                //ABM_ROL
                case 1:
                    this.gestionarRolesToolStripMenuItem.Visible = true;
                    break;
                //ABM_CLIENTE
                case 2:
                    this.clienteToolStripMenuItem.Visible = true;
                    this.agregarClienteToolStripMenuItem.Visible = true;
                    this.modificarClienteToolStripMenuItem.Visible = true;
                    this.eliminarClienteToolStripMenuItem1.Visible = true;
                    break;
                //ABM_PROV
                case 3:
                    this.proveedorToolStripMenuItem.Visible = true;
                    this.agregarProvToolStripMenuItem1.Visible = true;
                    this.modificarProvToolStripMenuItem.Visible = true;
                    this.eliminarProvToolStripMenuItem.Visible = true;
                    break;
                //CARGA_CREDITO
                case 4:
                    this.clienteToolStripMenuItem.Visible = true;
                    this.cargarCreditoToolStripMenuItem.Visible = true;
                    break;
                //COMPRAR_GIFTCARD
                case 5:
                    this.clienteToolStripMenuItem.Visible = true;
                    this.comprarGiftCardToolStripMenuItem.Visible = true;
                    break;
                //COMPRAR_CUPON
                case 6:
                    this.clienteToolStripMenuItem.Visible = true;
                    this.cuponClienteToolStripMenuItem.Visible = true;
                    this.comprarToolStripMenuItem.Visible = true;
                    break;
                //DEVOLVER_CUPON
                case 7:
                    this.clienteToolStripMenuItem.Visible = true;
                    this.cuponClienteToolStripMenuItem.Visible = true;
                    this.devolverToolStripMenuItem1.Visible = true;
                    break;
                //HISTORIAL_CUPON
                case 8:
                    this.clienteToolStripMenuItem.Visible = true;
                    this.cuponClienteToolStripMenuItem.Visible = true;
                    this.verHistorialDeComprasToolStripMenuItem.Visible = true;
                    break;
                //CREAR_CUPON
                case 9:
                    this.proveedorToolStripMenuItem.Visible = true;
                    this.cuponProvToolStripMenuItem.Visible = true;
                    this.nuevoToolStripMenuItem.Visible = true;
                    break;
                //REGISTRAR_CONSUMO
                case 10:
                    this.proveedorToolStripMenuItem.Visible = true;
                    this.cuponProvToolStripMenuItem.Visible = true;
                    this.registrarConsumoToolStripMenuItem.Visible = true;
                    break;
                //PuBLICAR_CUPOM
                case 11:
                    this.adminToolStripMenuItem.Visible = true;
                    this.publicarToolStripMenuItem.Visible = true;
                    break;
                //FACTURAR
                case 12:
                    this.adminToolStripMenuItem.Visible = true;
                    this.facturarToolStripMenuItem.Visible = true;
                    break;
                //LISTADO LACO
                case 13:
                    this.listadoEstadisticoToolStripMenuItem.Visible = true;
                    break;    
                //GESTION USUARIOS
                case 14:
                    this.adminToolStripMenuItem.Visible = true;
                    this.gestionarUsuariosToolStripMenuItem.Visible = true;
                    break;
                default:
                    Support.mostrarError("Su usuario no tiene funcionalidades asignadas");
                    break;
    

            }
        }
            private void apagarMenues()
            {
                    this.gestionarRolesToolStripMenuItem.Visible = false;
                    this.clienteToolStripMenuItem.Visible = false;
                    this.agregarClienteToolStripMenuItem.Visible = false;
                    this.modificarClienteToolStripMenuItem.Visible = false;
                    this.eliminarClienteToolStripMenuItem1.Visible = false;
                    this.proveedorToolStripMenuItem.Visible = false;
                    this.agregarProvToolStripMenuItem1.Visible = false;
                    this.modificarProvToolStripMenuItem.Visible = false;
                    this.eliminarProvToolStripMenuItem.Visible = false;
                    this.cargarCreditoToolStripMenuItem.Visible = false;
                    this.comprarGiftCardToolStripMenuItem.Visible = false;
                    this.cuponClienteToolStripMenuItem.Visible = false;
                    this.comprarToolStripMenuItem.Visible = false;
                    this.devolverToolStripMenuItem1.Visible = false;
                    this.verHistorialDeComprasToolStripMenuItem.Visible = false;
                    this.nuevoToolStripMenuItem.Visible = false;
                    this.registrarConsumoToolStripMenuItem.Visible = false;
                    this.adminToolStripMenuItem.Visible = false;
                    this.publicarToolStripMenuItem.Visible = false;
                    this.facturarToolStripMenuItem.Visible = false;
                    this.listadoEstadisticoToolStripMenuItem.Visible = false;
                    this.gestionarUsuariosToolStripMenuItem.Visible = false;
                
                
            }

            private void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
            {
                Application.Exit();
            }

            private void salirToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

            private void agregarRolToolStripMenuItem_Click(object sender, EventArgs e)
            {
                AltaRol frm = new AltaRol();
                frm.ShowDialog();
            }

            private void modificarRolToolStripMenuItem_Click(object sender, EventArgs e)
            {
                AbmRoles.ModRol frm = new AbmRoles.ModRol();
                frm.ShowDialog();
            }

            private void eliminarRolToolStripMenuItem_Click(object sender, EventArgs e)
            {
                AbmRoles.ElimRol frm = new AbmRoles.ElimRol();
                frm.ShowDialog();
            }

            private void modificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
            {
                AbmCliente.ModCliente frmMod = new AbmCliente.ModCliente();
                frmMod.ShowDialog();

            }

            private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
            {
                RegistroUsuario frmAlta = new RegistroUsuario(this);
                frmAlta.Text = "Alta Cliente";
                frmAlta.cmbRol.Visible = false;
                frmAlta.label4.Visible = false;
                frmAlta.ShowDialog();
            }

            private void eliminarClienteToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                AbmCliente.BajaCliente frmBaja = new AbmCliente.BajaCliente();
                frmBaja.ShowDialog();
            }

            private void cargarCreditoToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (Support.verificarCliente())
                {
                    CargaCredito.CargaCredito frm = new CargaCredito.CargaCredito();
                    frm.ShowDialog();
                }
            }

            private void comprarGiftCardToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (Support.verificarCliente())
                {
                    ComprarGiftCard.Giftcard frm = new ComprarGiftCard.Giftcard();
                    frm.ShowDialog();
                }
            }

            private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //juanca
            }
           

        }
    }

