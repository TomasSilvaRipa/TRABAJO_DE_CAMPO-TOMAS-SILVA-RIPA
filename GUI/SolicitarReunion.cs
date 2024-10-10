using BE;
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
    public partial class SolicitarReunion : Form
    {

        public SolicitarReunion(Propiedad p)
        {
            InitializeComponent();
            bllReunion = new BLLReunion();
            propiedadSeleccionada = p;
        }
        Propiedad propiedadSeleccionada;
        BLLReunion bllReunion;

        private void btnSolicitarReunion_Click(object sender, EventArgs e)
        {
            try
            {
                if (monthCalendarReunion.SelectionStart >= DateTime.Now)
                {
                    if (monthCalendarReunion.SelectionStart.Date == monthCalendarReunion.SelectionEnd.Date && richTextBoxDisponibilidad.Text != "")
                    {
                        if (bllReunion.SolicitarReunion(propiedadSeleccionada, monthCalendarReunion.SelectionStart.Date, richTextBoxDisponibilidad.Text))
                        {
                            MessageBox.Show("Solicitud Enviada");
                            
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Solo seleccione un dia para tener la reunion e indique su disponibilidad");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fecha aun disponible");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
