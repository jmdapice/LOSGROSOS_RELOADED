using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.RegistroConsumoCupon
{
    public partial class Consumo_BuscarProv : AbmProveedor.BuscaProv
    {
        RegistroConsumoCupon.RegistrarConsumo frmPadre = null;
        public Consumo_BuscarProv(RegistroConsumoCupon.RegistrarConsumo frm)
        {
            frmPadre = frm;
            InitializeComponent();
        }

    }
}
