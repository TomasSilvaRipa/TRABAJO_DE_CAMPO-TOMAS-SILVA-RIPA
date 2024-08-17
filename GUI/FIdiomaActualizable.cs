using BLL;
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
    public partial class FIdiomaActualizable : Form
    {
        public FIdiomaActualizable()
        {
            InitializeComponent();
        }

        private void FIdiomaActualizable_Load(object sender, EventArgs e)
        {

        }

        public void actualizarIdioma()
        {


            var dict = Sesion.ObtenerSesion().Traduccion;

            foreach (Control c in this.Controls)
            {
                if (c.Tag == null)
                {
                    continue;
                }
                if (dict.ContainsKey(c.Tag.ToString()))
                {
                    if (dict[c.Tag.ToString()] != "")
                    {
                        c.Text = dict[c.Tag.ToString()];
                    }

                }
            }

        }
    }
}
