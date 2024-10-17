using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI
{
    public partial class FTraducciones : FIdiomaActualizable, IObservador, IObservable
    {
        DataTable tablaIdioma;
        DataTable tablaPalabras;
        DataTable tablaTraduccion;
        DataTable tablaTraduccionEditable;
        DataTable tablaNuevaTraduccion;
        public List<IObservador> Observadores { get; set; }

        BLLIdiomas bLLIdiomas = new BLLIdiomas();
        public FTraducciones()
        {
            InitializeComponent();
        }



        private void FTraducciones_Load(object sender, EventArgs e)
        {
            BLLIdiomas bLLIdiomas = new BLLIdiomas();
            actualizarTablaIdiomas();

            LlenarCbxIdiomas();
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarIdioma();

        }

        private void actualizarTablaIdiomas()
        {
            Sesion.ObtenerSesion().ActualizarIdiomas();
            tablaIdioma = Sesion.ObtenerSesion().tablaIdioma;
            tablaPalabras = bLLIdiomas.ObtenerPalabras();

        }





        private void LlenarCbxIdiomas()
        {
            cbxIdiomas.Items.Clear();
            cbxIdiomas.Items.Add("Nuevo");

            foreach (DataRow row in tablaIdioma.Rows)
            {
                cbxIdiomas.Items.Add(row[1]);
            }

            cbxIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxIdiomas.SelectedIndex = 0;

        }
        private void actualizarTablaTraducciones()
        {
            if (cbxIdiomas.SelectedIndex > 0)
            {
                tablaTraduccion = bLLIdiomas.ObtenerTraducciones(Convert.ToInt32(tablaIdioma.Rows[cbxIdiomas.SelectedIndex - 1][0]));
            }


        }

        private void cbxIdiomas_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            actualizarTablaTraducciones();
            dgvTraduccion.DataSource = null;
            if (tablaTraduccion != null && cbxIdiomas.SelectedIndex > 0)
            {
                tablaTraduccionEditable = GenerarTablaTraduccionEditable();

                dgvTraduccion.DataSource = tablaTraduccionEditable;


            }
            else
            {
                tablaNuevaTraduccion = tablaPalabras.Copy();
                tablaNuevaTraduccion.Columns.Add("Traduccion", typeof(string));
                dgvTraduccion.DataSource = tablaNuevaTraduccion;
            }

            dgvTraduccion.Columns[0].Visible = false;
            dgvTraduccion.Columns[0].ReadOnly = true;
            dgvTraduccion.Columns[1].ReadOnly = true;
            dgvTraduccion.AllowUserToAddRows = false;

        }
        //private DataTable GenerarTablaTraduccionEditable()
        //{
        //    var nuevoDataTable = new DataTable();
        //    nuevoDataTable.Columns.Add("Codigo", typeof(int));
        //    nuevoDataTable.Columns.Add("Palabra", typeof(string));
        //    nuevoDataTable.Columns.Add("Traduccion", typeof(string));

        //    var filasCoincidentes = from palabra in tablaPalabras.AsEnumerable()
        //                            join traduccion in tablaTraduccion.AsEnumerable()
        //                            on palabra.Field<int>(0) equals traduccion.Field<int>(1)
        //                            select new { Codigo = palabra.Field<int>(0), Palabra = palabra.Field<string>(1), Traduccion = traduccion.Field<string>(2) };

        //    foreach (var fila in filasCoincidentes)
        //    {
        //        nuevoDataTable.Rows.Add(fila.Codigo,fila.Palabra, fila.Traduccion);
        //    }

        //    return nuevoDataTable;
        //}

        private DataTable GenerarTablaTraduccionEditable()
        {
            var nuevoDataTable = new DataTable();
            nuevoDataTable.Columns.Add("Codigo", typeof(int));
            nuevoDataTable.Columns.Add("Palabra", typeof(string));
            nuevoDataTable.Columns.Add("Traduccion", typeof(string));

            // Hacer un left join para incluir todas las palabras
            var filasCoincidentes = from palabra in tablaPalabras.AsEnumerable()
                                    join traduccion in tablaTraduccion.AsEnumerable()
                                    on palabra.Field<int>(0) equals traduccion.Field<int>(1) into traduccionGroup
                                    from subtraduccion in traduccionGroup.DefaultIfEmpty()
                                    select new
                                    {
                                        Codigo = palabra.Field<int>(0),
                                        Palabra = palabra.Field<string>(1),
                                        Traduccion = subtraduccion == null ? string.Empty : subtraduccion.Field<string>(2)
                                    };

            foreach (var fila in filasCoincidentes)
            {
                nuevoDataTable.Rows.Add(fila.Codigo, fila.Palabra, fila.Traduccion);
            }

            return nuevoDataTable;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (cbxIdiomas.SelectedIndex == 0)
            {
                DataTable tablaEditada = (DataTable)dgvTraduccion.DataSource;
                foreach(DataRow row in tablaEditada.Rows)
                {
                    if(row[2].ToString().Trim() == "")
                    {

                    }
                    else
                    {
                        if (!Servicios.ManejoErrores.ValidarNombre(row[2].ToString().Trim()))
                        {
                            MessageBox.Show("Error en la traduccion de la palabra: " + row[1].ToString());
                            return;
                        }
                    }
                    
                }

                if(!Servicios.ManejoErrores.ValidarNombre(txtIdioma.Text.Trim()))
                {
                    MessageBox.Show("Error en el nombre del idioma");
                    return;
                }

                bLLIdiomas.AltaTraduccion(tablaEditada, txtIdioma.Text);
                actualizarTablaIdiomas();
                LlenarCbxIdiomas();
                Notificar();

                MessageBox.Show("Se cargó un nuevo idioma");
            }
        }
        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (cbxIdiomas.SelectedIndex > 0)
            {
                bLLIdiomas.BajaTraduccion(Convert.ToInt32(tablaIdioma.Rows[cbxIdiomas.SelectedIndex - 1][0]));
                actualizarTablaIdiomas();
                MessageBox.Show("Se eliminó el idioma: " + cbxIdiomas.SelectedItem.ToString());
                LlenarCbxIdiomas();
                Notificar();

            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (cbxIdiomas.SelectedIndex > 0)
            {
                tablaTraduccionEditable = (DataTable)dgvTraduccion.DataSource;

                foreach (DataRow row in tablaTraduccionEditable.Rows)
                {
                    if (row[2].ToString().Trim() == "")
                    {

                    }
                    else
                    {
                        if (!Servicios.ManejoErrores.ValidarNombre(row[2].ToString().Trim()))
                        {
                            MessageBox.Show("Error en la traduccion de la palabra: " + row[1].ToString());
                            return;
                        }
                    }
                     
                }
            }

            bLLIdiomas.ModificarTraduccion(tablaTraduccionEditable, Convert.ToInt32(tablaIdioma.Rows[cbxIdiomas.SelectedIndex - 1][0]));

            MessageBox.Show("Se modificó la traduccion del idioma: " + cbxIdiomas.SelectedItem.ToString());
        }

        public void Notificar(object Sender)
        {
           actualizarIdioma();
        }


        #region observable
        public void AgregarObservador(IObservador observador)
        {
            if (Observadores == null)
            {
                Observadores = new List<IObservador>();
            }
            Observadores.Add(observador);
        }

        public void QuitarObservador(IObservador observador)
        {
            if (Observadores == null)
            {
                Observadores = new List<IObservador>();
            }
            Observadores.Remove(observador);
        }

        public void Notificar()
        {
            if (Observadores != null)
            {
                foreach (IObservador observador in Observadores)
                {
                    observador.Notificar(this);
                }
            }

        }

        #endregion observable

    }
}
