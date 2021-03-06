﻿using System;
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
            statusStrip1.Items[0].Text = "Fecha Actual: "+Support.fechaConfig().ToShortDateString();
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
                frmAlta.cmbRol.SelectedItem = "CLIENTE";
                frmAlta.ShowDialog();
            }

            private void eliminarClienteToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                AbmCliente.BajaCliente frmBaja = new AbmCliente.BajaCliente();
                frmBaja.ShowDialog();
            }

            private void cargarCreditoToolStripMenuItem_Click(object sender, EventArgs e)
            {
                CargaCredito.CargaCredito frm = new CargaCredito.CargaCredito();
                frm.ShowDialog();
            }

            private void comprarGiftCardToolStripMenuItem_Click(object sender, EventArgs e)
            {
               ComprarGiftCard.Giftcard frm = new ComprarGiftCard.Giftcard();
               frm.ShowDialog();
            }

            private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Login frm = new Login();
                frm.Show();
                this.Dispose();
            }

            private void comprarToolStripMenuItem_Click(object sender, EventArgs e)
            {

                ComprarCupon.ComprarCupon frm = new ComprarCupon.ComprarCupon();
                frm.ShowDialog();
            }

            private void devolverToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                PedirDevolucion.Devolucion frm = new PedirDevolucion.Devolucion();
                frm.ShowDialog();
            }

            private void verHistorialDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
            {
                HistorialCupones.historialCompras frm = new GrouponDesktop.HistorialCupones.historialCompras();
                frm.ShowDialog();
            }

            private void agregarProvToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                RegistroUsuario frmAlta = new RegistroUsuario(this);
                frmAlta.Text = "Alta Proveedor";
                frmAlta.cmbRol.Visible = false;
                frmAlta.label4.Visible = false;
                frmAlta.cmbRol.SelectedItem = "PROVEEDOR";
                frmAlta.ShowDialog();
                
            }

            private void modificarProvToolStripMenuItem_Click(object sender, EventArgs e)
            {
                AbmProveedor.BuscaProv frm = new AbmProveedor.BuscaProv();
                frm.ShowDialog();

            }

            private void registrarConsumoToolStripMenuItem_Click(object sender, EventArgs e)
            {

                RegistroConsumoCupon.RegistrarConsumo frm = new GrouponDesktop.RegistroConsumoCupon.RegistrarConsumo();
                frm.ShowDialog();

            }

            private void publicarToolStripMenuItem_Click(object sender, EventArgs e)
            {

                PublicarCupon.PublicarCupon frm = new GrouponDesktop.PublicarCupon.PublicarCupon();
                frm.ShowDialog();

            }

            private void eliminarProvToolStripMenuItem_Click(object sender, EventArgs e)
            {
                AbmProveedor.BajaProv frm = new AbmProveedor.BajaProv();
                frm.ShowDialog();
            }

            private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ArmarCupon.ArmarCupon frm = new ArmarCupon.ArmarCupon();
                frm.ShowDialog();
            }

            private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
            {
                FacturarProveedor.Facturar frm = new FacturarProveedor.Facturar();
                frm.ShowDialog();
            }

            private void listadoEstadisticoToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ListadoEstadistico.Listado frm = new ListadoEstadistico.Listado();
                frm.ShowDialog();
            }

            private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
            {

            }

            private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
            {

                GestionUsuarios.BuscUsuario_Mod frm = new GestionUsuarios.BuscUsuario_Mod();
                frm.ShowDialog();
            }

            private void cambiarContraseñaToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                GestionUsuarios.CambiarPass frm = new GestionUsuarios.CambiarPass();
                frm.ShowDialog();
            }

            private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                GestionUsuarios.AltaUsuario frm = new GestionUsuarios.AltaUsuario();
                frm.ShowDialog();

            }

            private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
            {
                GestionUsuarios.ElimUser frm = new GestionUsuarios.ElimUser();
                frm.ShowDialog();
            }
       
        }
    }

