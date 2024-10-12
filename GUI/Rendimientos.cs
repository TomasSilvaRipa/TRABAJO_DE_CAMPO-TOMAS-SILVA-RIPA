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
    public partial class Rendimientos : Form
    {
        public Rendimientos()
        {
            InitializeComponent();
            bllTrato = new BLLTrato();
            MostrarTratosRealizados();
            bllCuenta = new BLLCuenta();
            LeerSaldoDeCuenta();
            CargarEstadisticas();
        }
        BLLTrato bllTrato;
        BLLCuenta bllCuenta;

        public void MostrarTratosRealizados()
        {
            try
            {
                dataGridViewTratosCerrados.DataSource = null;
                dataGridViewTratosCerrados.DataSource = bllTrato.LeerTratosXCloser();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void LeerSaldoDeCuenta()
        {
            try
            {
                labelSaldoDeCuenta.Text = bllCuenta.LeerSaldoDeCuenta().ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CargarEstadisticas()
        {
            List<Trato> listaTratos = bllTrato.LeerTratosXCloser();

            Dictionary<int, int> tratosPorMes = new Dictionary<int, int>();

            for (int mes = 1; mes <= 12; mes++)
            {
                tratosPorMes[mes] = 0;
            }

            foreach (var trato in listaTratos)
            {
                int mes = trato.FechaDeInicio.Month;
                tratosPorMes[mes]++;
            }

            foreach (var mes in tratosPorMes.Keys)
            {
                chartTratosMensuales.Series["Tratos Cerrados"].Points.AddXY(mes, tratosPorMes[mes]);
            }
        }
    }
}
