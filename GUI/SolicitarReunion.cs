using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MaterialSkin.Controls;
namespace GUI
{
    public partial class SolicitarReunion : FIdiomaActualizable, IObservador
    {

        public SolicitarReunion(Propiedad p)
        {
            InitializeComponent();
            bllReunion = new BLLReunion();
            bllIdiomas = new BLLIdiomas();
            propiedadSeleccionada = p;
            ConfigurarCalendario();
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
            Notificar(this);
            comboBoxDesde.Items.AddRange(new object[] { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" });
            comboBoxHasta.Items.AddRange(new object[] { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" });
            comboBoxDesde.SelectedIndex = 0; 
            comboBoxHasta.SelectedIndex = 1;
        }
        Propiedad propiedadSeleccionada;
        BLLReunion bllReunion;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;

        private void actualizarTablaIdiomas()
        {
            Sesion.ObtenerSesion().ActualizarIdiomas();
            tablaIdioma = Sesion.ObtenerSesion().tablaIdioma;
        }

        public void Notificar(object Sender)
        {

            if (Sender is FTraducciones)
            {
                actualizarTablaIdiomas();
            }
            else
            {
                actualizarIdioma();
            }

        }

        public bool ValidarHora()
        {
            string horaDesdeStr = comboBoxDesde.SelectedItem.ToString();
            string horaHastaStr = comboBoxHasta.SelectedItem.ToString();

            DateTime horaDesde = DateTime.ParseExact(horaDesdeStr, "HH:mm", null);
            DateTime horaHasta = DateTime.ParseExact(horaHastaStr, "HH:mm", null);
           
            if (horaHasta <= horaDesde)
            {
                MessageBox.Show("La hora de 'Hasta' debe ser mayor que la hora de 'Desde'.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                
                int index = comboBoxDesde.SelectedIndex + 1; 
                if (index < comboBoxHasta.Items.Count)
                {
                    comboBoxHasta.SelectedIndex = index; 
                }
                return false;
            }
            return true;
        }




        public void ConfigurarCalendario()
        {
            monthCalendarReunion.MinDate = DateTime.Now;
        }

        private void btnSolicitarReunion_Click(object sender, EventArgs e)
        {
            try
            {
                if (monthCalendarReunion.SelectionStart >= DateTime.Now)
                {
                    if (monthCalendarReunion.SelectionStart.Date == monthCalendarReunion.SelectionEnd.Date && ValidarHora())
                    {
                        if (bllReunion.SolicitarReunion(propiedadSeleccionada, monthCalendarReunion.SelectionStart.Date, comboBoxDesde.Text +"-" + comboBoxHasta.Text+ "hs" ))
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
