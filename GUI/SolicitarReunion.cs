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
    public partial class SolicitarReunion : Form
    {

        public SolicitarReunion(Propiedad p)
        {
            InitializeComponent();
            propiedadSeleccionada = p;
        }
        Propiedad propiedadSeleccionada;

        private void SolicitarReunion_Load(object sender, EventArgs e)
        {

        }

        private void btnSolicitarReunion_Click(object sender, EventArgs e)
        {
            if (monthCalendarReunion.SelectionStart == monthCalendarReunion.SelectionEnd && richTextBoxDisponibilidad.Text != "")
            {

            }
        }
    }
}
