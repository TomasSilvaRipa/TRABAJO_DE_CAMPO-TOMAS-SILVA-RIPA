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
    public partial class Pagos : Form
    {
        BLLCliente bllCliente;
        Cliente clienteIniciado;
        public Pagos()
        {
            InitializeComponent();
            bllCuota = new BLLCuota();
            bllCliente = new BLLCliente();
            CargarCuotas();
            CargarPagos();
            
        }
        BLLCuota bllCuota;

        

        public void CargarCuotas()
        {
            dataGridViewCuotas.DataSource = null;
            dataGridViewCuotas.DataSource = bllCuota.LeerCuotasXClientePendientes();
        }

        public void CargarPagos()
        {
            dataGridViewHistorialPagos.DataSource = null;
            dataGridViewHistorialPagos.DataSource = bllCuota.LeerCuotasXClientePagas();
        }

        private void dataGridViewCuotas_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridViewCuotas.SelectedRows.Count == 1)
            {
                Cuota cuota = (Cuota)dataGridViewCuotas.CurrentRow.DataBoundItem;
                labelValor.Text = "$" + cuota.Monto.ToString();
                labelValor.ForeColor = Color.Red;
            }
        }

        private void btnPagarCuota_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridViewCuotas.SelectedRows.Count == 1)
                {
                    Cuota cuota = (Cuota)dataGridViewCuotas.CurrentRow.DataBoundItem;
                    if (bllCuota.PagarCuota(cuota))
                    {
                        labelValor.Text = "";
                        CargarCuotas();
                        CargarPagos();
                        MessageBox.Show("Pago Exitoso!!");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una couta a pagar");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
