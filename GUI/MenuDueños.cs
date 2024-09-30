using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MenuDueños : Form
    {
        public MenuDueños()
        {
            InitializeComponent();
        }
        
        private void btnAgregarPropiedad_Click(object sender, EventArgs e)
        {
            RegistrarPropiedades registrarPropiedades = new RegistrarPropiedades();
            registrarPropiedades.Show();
        }

        private void btnVerCatalogo_Click(object sender, EventArgs e)
        {
            CatalogoPropiedadesDueño CPD = new CatalogoPropiedadesDueño();
            CPD.Show();
        }

        private void MenuDueños_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
