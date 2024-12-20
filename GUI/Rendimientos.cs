﻿using BE;
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
    public partial class Rendimientos : FIdiomaActualizable,IObservador
    {
        public Rendimientos()
        {
            InitializeComponent();
            bllTrato = new BLLTrato();
            MostrarTratosRealizados();
            bllCuenta = new BLLCuenta();
            bllOpinion = new BLLOpinon();
            bllIdiomas = new BLLIdiomas();
            LeerSaldoDeCuenta();
            CargarEstadisticas();
            CargarOpiniones();
            CalcularCalificacionPromedio();
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
            Notificar(this);
        }
        BLLTrato bllTrato;
        BLLCuenta bllCuenta;
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

        public void MostrarTratosRealizados()
        {
            try
            {
                dataGridViewTratosCerrados.DataSource = null;
                List<Trato> tratos = bllTrato.LeerTratosXCloser();
                if (tratos != null && tratos.Count > 0) 
                {
                    dataGridViewTratosCerrados.DataSource = tratos;
                    dataGridViewTratosCerrados.Columns["ID_Cliente"].Visible = false;
                    dataGridViewTratosCerrados.Columns["ID_Closer"].Visible = false;
                    dataGridViewTratosCerrados.Columns["ID_Dueño"].Visible = false;
                    dataGridViewTratosCerrados.Columns["ID_Vivienda"].Visible = false;
                    dataGridViewTratosCerrados.Columns["ID"].Visible = false;
                    dataGridViewTratosCerrados.ForeColor = Color.Black;
                    dataGridViewTratosCerrados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                //dataGridViewTratosCerrados.Rows["ID_Cliente"].Visible = false;
                //dataGridViewTratosCerrados.Rows[1].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void CargarOpiniones()
        {
            try
            {
                dataGridViewOpiniones.DataSource = null;
                List<Opinion> opiniones = bllOpinion.LeerOpiniones(Sesion.ObtenerSesion().ObtenerUsuario(), 1);
                if (opiniones != null && opiniones.Count > 0) {
                    dataGridViewOpiniones.DataSource = opiniones;
                    dataGridViewOpiniones.Columns["ID"].Visible = false;
                    dataGridViewOpiniones.Columns["ID_Usuario"].Visible = false;
                    dataGridViewOpiniones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewOpiniones.ForeColor = Color.Black;
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CalcularCalificacionPromedio()
        {
            try
            {
                int promedio = 0;
                int cantidad = 0;
                foreach(DataGridViewRow row in dataGridViewOpiniones.Rows)
                {
                    Opinion opinion = (Opinion)row.DataBoundItem;
                    cantidad += 1;
                    promedio += opinion.Calificacion;
                }
                promedio = promedio/ cantidad;
                labelCalificacionPromedio.Text = promedio.ToString() + " Estrellas";
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
                labelSaldoDeCuenta.Text = "$" + bllCuenta.LeerSaldoDeCuenta().ToString();
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

        private void Rendimientos_Load(object sender, EventArgs e)
        {

        }
    }
}
