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

namespace GUI
{
    public partial class IngresosDueño : FIdiomaActualizable, IObservador
    {
        public IngresosDueño()
        {
            InitializeComponent();
            bllCuota = new BLLCuota();
            bllOpinion = new BLLOpinon();
            bllIdiomas = new BLLIdiomas();
            MostrarCuotas();
            MostrarIngresosTotales();
            MostrarOpiniones();
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
        }
        BLLCuota bllCuota;
        BLLOpinon bllOpinion;
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

        public void MostrarCuotas()
        {
            dataGridViewCuotas.DataSource = null;
            dataGridViewCuotas.DataSource = bllCuota.LeerCuotasXDueño();
        }

        public void MostrarOpiniones()
        {
            dataGridViewOpiniones.DataSource = null;
            dataGridViewOpiniones.DataSource = bllOpinion.LeerOpiniones(Sesion.ObtenerSesion().ObtenerUsuario(),1);
        }
        public void MostrarIngresosTotales()
        {
            try
            {
                decimal IngresosTotales = 0;
                foreach (DataGridViewRow row in dataGridViewCuotas.Rows)
                {
                    Cuota cuota = (Cuota)row.DataBoundItem;
                    IngresosTotales += cuota.Monto;
                }
                labelIngresosTotales.Text = "";
                labelIngresosTotales.Text = "$" + IngresosTotales.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewCuotas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dataGridViewCuotas.SelectedRows.Count == 1)
                {
                    Cuota cuota = (Cuota)dataGridViewCuotas.CurrentRow.DataBoundItem;
                    labelIngresosPorCuota.Text = "";
                    labelIngresosPorCuota.Text = "$" + cuota.Monto.ToString();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void IngresosDueño_Load(object sender, EventArgs e)
        {

        }
    }
}
