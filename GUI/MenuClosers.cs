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
    public partial class MenuClosers : Form
    {
        public MenuClosers()
        {
            InitializeComponent();
        }

        private void btnAbrirCatalogo_Click(object sender, EventArgs e)
        {
            CatalogoDePropiedades CDP = new CatalogoDePropiedades();
            CDP.Show();
        }

        private void MenuClosers_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
