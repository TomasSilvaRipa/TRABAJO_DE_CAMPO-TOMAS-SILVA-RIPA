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
    public partial class IngresosDueño : Form
    {
        public IngresosDueño()
        {
            InitializeComponent();
            bllCuota = new BLLCuota();
            MostrarCuotas();
            MostrarIngresosTotales();
        }
        BLLCuota bllCuota;

        public void MostrarCuotas()
        {
            dataGridViewCuotas.DataSource = null;
            dataGridViewCuotas.DataSource = bllCuota.LeerCuotasXDueño();
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
    }
}
