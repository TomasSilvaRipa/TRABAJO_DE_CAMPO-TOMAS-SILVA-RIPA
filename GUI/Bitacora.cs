using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios;
namespace GUI
{
    public partial class Bitacora : FIdiomaActualizable, IObservador
    {
        public Bitacora()
        {
            InitializeComponent();
            bitacorabll = new BitacoraBLL();
            LLenarGrillaBitacora();
            comboBoxTipo.DataSource = Enum.GetValues(typeof(Tipo));
            bf = new BitacoraFiltros();
            actualizarIdioma();
            Sesion.ObtenerSesion().AgregarObservador(this);
        }
        BitacoraBLL bitacorabll;
        BitacoraFiltros bf;

        #region FUNCIONES APARTE
        public enum Tipo
        {
            INFO = 1,
            ERROR = 2,
            VALIDACION = 3
        }
        public void LLenarGrillaBitacora()
        {
            dataGridViewBitacora.DataSource = null;
            dataGridViewBitacora.DataSource = bitacorabll.LeerBitacora();
        }

        #endregion




        private void Bitacora_Load(object sender, EventArgs e)
        {
            actualizarIdioma();
        }

        #region FILTRO

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonFecha.Checked)
                {
                    if(dateTimePickerDesde.Value.Date <= dateTimePickerHasta.Value.Date)
                    {
                        bf = new BitacoraFiltros(dateTimePickerDesde.Value.Date, dateTimePickerHasta.Value.Date);
                        dataGridViewBitacora.DataSource = bitacorabll.FiltrarBitacora(bf, 1);
                    }
                    else
                    {
                        MessageBox.Show("La fecha final no puede ser menor que la fecha de inicio");
                    }
                }
                else if (radioButtonTipo.Checked)
                {
                    bf = new BitacoraFiltros(Convert.ToInt32(comboBoxTipo.SelectedItem));
                    dataGridViewBitacora.DataSource = bitacorabll.FiltrarBitacora(bf, 2);
                }
                else if (radioButtonFYT.Checked)
                {
                    if ((dateTimePickerDesde.Value.Date <= dateTimePickerHasta.Value.Date))
                    {
                        bf = new BitacoraFiltros(dateTimePickerDesde.Value.Date, dateTimePickerHasta.Value.Date, Convert.ToInt32(comboBoxTipo.SelectedItem));
                        dataGridViewBitacora.DataSource = bitacorabll.FiltrarBitacora(bf, 3);
                    }
                    else
                    {
                        MessageBox.Show("La fecha final no puede ser menor que la fecha de inicio");
                    }
                }
                else
                {
                    throw new Exception("Seleccione un filtro para filtrar");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void Notificar(object Sender, string condicion = null)
        {
           actualizarIdioma();
        }
        #endregion

        private void dataGridViewBitacora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Notificar(object Sender)
        {
            actualizarIdioma();
        }
    }
}
