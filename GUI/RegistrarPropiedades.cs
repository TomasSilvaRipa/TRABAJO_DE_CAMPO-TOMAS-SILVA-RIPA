using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{
    public partial class RegistrarPropiedades : FIdiomaActualizable,IObservador
    {
        public RegistrarPropiedades(Menu menu)
        {
            InitializeComponent();
            bllPropiedad = new BLLPropiedad();
            bllIdiomas = new BLLIdiomas();
            imagenes = new List<System.Drawing.Image>();
            comboBoxPatio.DataSource = Enum.GetValues(typeof(Patio));
            comboBoxPileta.DataSource = Enum.GetValues(typeof(Pileta));
            comboBoxCochera.DataSource = Enum.GetValues(typeof(Cochera));
            comboBoxVivienda.DataSource = Enum.GetValues(typeof(Vivienda));
            btnPublicaPropiedad.Visible = true;
            btnModificar.Visible = false;
            menuActivo = menu;
            bllEtiquetas = new BLLEtiquetas();
            CargarEtiquetas();
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
            Notificar(this);
        }
        BLLPropiedad bllPropiedad;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;
        List<System.Drawing.Image> imagenes;
        Propiedad propiedadModificada;
        Menu menuActivo;
        BLLEtiquetas bllEtiquetas;
        List<Etiqueta> Etiquetas;
        

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

        public RegistrarPropiedades(Propiedad propiedad, Menu menu)
        {
            InitializeComponent();
            bllPropiedad = new BLLPropiedad();
            bllEtiquetas = new BLLEtiquetas();
            imagenes = new List<System.Drawing.Image>();
            comboBoxPatio.DataSource = Enum.GetValues(typeof(Patio));
            comboBoxPileta.DataSource = Enum.GetValues(typeof(Pileta));
            comboBoxCochera.DataSource = Enum.GetValues(typeof(Cochera));
            comboBoxVivienda.DataSource = Enum.GetValues(typeof(Vivienda));
            propiedadModificada = propiedad;
            menuActivo = menu;
            btnModificar.Visible = true;
            btnPublicaPropiedad.Visible = false;
            ActualizarControlesPorpiedadSeleccionada(propiedad);
            CargarEtiquetas();
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
            Notificar(this);
        }

        enum Patio
        {
            SI = 0,
            NO = 1
        }
        enum Cochera
        {
            SI = 0,
            NO = 1
        }
        enum Pileta
        {
            SI = 0,
            NO = 1
        }
        enum Vivienda
        {
            Casa = 0,
            Departamento = 1,
            Duplex = 3,
            Triplex = 4,
            Penthouse = 5
        }

        public void ActualizarControlesPorpiedadSeleccionada(Propiedad propiedad)
        {
            comboBoxVivienda.Text = propiedad.TipoDeVivienda;
            numericUpDownAmbientes.Value = propiedad.Ambientes;
            numericUpDownBaños.Value = propiedad.Baños;
            numericUpDownHabitaciones.Value = propiedad.Habitaciones;
            numericUpDownPisos.Value = propiedad.Pisos;
            tbDireccion.Text = propiedad.Direccion;
            numericUpDownValorDeCouta.Value = propiedad.ValorDeCouta;
            numericUpDownST.Value = Convert.ToInt32(propiedad.SuperficieTotal.Replace("m2", ""));
            numericUpDownSC.Value = Convert.ToInt32(propiedad.SuperficieCubierta.Replace("m2", ""));
            if (propiedad.Patio == true)
            {
                comboBoxPatio.SelectedItem = Patio.SI;
            }
            else
            {
                comboBoxPatio.SelectedItem = Patio.NO;
                comboBoxPileta.Visible = false;
                comboBoxPileta.SelectedItem = Pileta.NO;
            }
            if(propiedad.Pileta == true)
            {
                comboBoxPileta.SelectedItem = Pileta.SI;
            }
            else
            {
                comboBoxPileta.SelectedItem = Pileta.NO;
            }
            if(propiedad.Cochera == true)
            {
                comboBoxCochera.SelectedItem = Pileta.SI;
            }
            else
            {
                comboBoxCochera.SelectedItem = Pileta.NO; 
            }
        }

        public void CargarEtiquetas()
        {
            flowLayoutPanelEtiquetas.Controls.Clear();
            Etiquetas = bllEtiquetas.LeerEtiquetas();
            foreach(Etiqueta e in  Etiquetas)
            {
                CheckBox cb;
                cb = new CheckBox();
                cb.Text = e.Nombre;
                cb.Tag = "CE"+ e.Nombre;
                flowLayoutPanelEtiquetas.Controls.Add(cb);
            }
        }

        public bool ValidarCheckBox()
        {
            try
            {
                foreach(Control c in flowLayoutPanelEtiquetas.Controls)
                {
                    if(c is CheckBox)
                    {
                        CheckBox cb = (CheckBox)c;
                        if(cb.Checked == true)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<byte[]> ConvertirImagenesABytes(List<System.Drawing.Image> imagenes)
        {
            List<byte[]> listaDeImagenesEnBytes = new List<byte[]>();
            foreach (System.Drawing.Image imagen in imagenes)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imagen.Save(ms, imagen.RawFormat);
                    listaDeImagenesEnBytes.Add(ms.ToArray());
                }
            }
            return listaDeImagenesEnBytes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg,*.jpeg)|*.png;*.jpg;*.jpeg";
                    openFileDialog.Title = "Seleccione una o más imágenes";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string file in openFileDialog.FileNames)
                        {
                            System.Drawing.Image img = System.Drawing.Image.FromFile(file);
                            imagenes.Add(img);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<Etiqueta> ObtenerEtiquetasPorPropiedad()
        {
            try
            {
                List<Etiqueta> EtiquetasVivienda = new List<Etiqueta>();
                foreach (Etiqueta e in Etiquetas)
                {
                    foreach (Control c in flowLayoutPanelEtiquetas.Controls)
                    {
                        if (c is CheckBox)
                        {
                            CheckBox cb = (CheckBox)c;
                            if (cb.Checked)
                            {
                                string nombre = c.Tag.ToString().Substring("CE".Length);
                                if (nombre == e.Nombre)
                                {
                                    EtiquetasVivienda.Add(e);
                                }
                            }

                        }
                    }
                }
                return EtiquetasVivienda;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool Validaciones()
        {
            if (!ManejoErrores.ValidarDireccion(tbDireccion.Text))
            {
                MessageBox.Show("Datos de dirección invalidos");
                return false;
            }
            if (numericUpDownST.Value < numericUpDownSC.Value)
            {
                MessageBox.Show("La superficie cubierta no puede ser mayor que la total");
                return false;
            }
            else if(numericUpDownAmbientes.Value < numericUpDownHabitaciones.Value)
            {
                MessageBox.Show("La cantidad de habitaciones no puede ser mayor que la cantidad de ambientes");
                return false;
            }
            else if(imagenes.Count <= 0)
            {
                MessageBox.Show("Seleccione al menos una imagen para la vivienda");
                return false;
            }
            else if (!ValidarCheckBox())
            {
                MessageBox.Show("Seleccione al menos una etiqueta para su vivienda");
                return false;
            }
            else
            {
                return true;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones())
                {
                    Propiedad propiedad = new Propiedad(comboBoxVivienda.Text, tbDireccion.Text, (int)numericUpDownAmbientes.Value, Convert.ToString(numericUpDownST.Value) + "m2", Convert.ToString(numericUpDownSC.Value) + "m2", (int)numericUpDownPisos.Value, (int)numericUpDownHabitaciones.Value, (int)numericUpDownBaños.Value, comboBoxCochera.Text, (int)numericUpDownAntiguedad.Value, comboBoxPatio.Text, comboBoxPileta.Text, numericUpDownValorDeCouta.Value);
                    propiedad.Etiquetas = ObtenerEtiquetasPorPropiedad();
                    if (bllPropiedad.AltaPropiedad(propiedad, ConvertirImagenesABytes(imagenes)))
                    {
                        MessageBox.Show("Vivienda Publicada Exitosamente");
                        imagenes.Clear();
                        menuActivo.IdentificarCatalogo();
                        this.Close();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxPatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxPatio.Text == "NO")
            {
                comboBoxPileta.Text = "NO";
                comboBoxPileta.Visible = false;
                labelPileta.Visible = false;
            }
            else if(comboBoxPatio.Text == "SI")
            {
                labelPileta.Visible = true;
                comboBoxPileta.Visible = true;
            }
        }

        private void btnLimpiarImagenes_Click(object sender, EventArgs e)
        {
            imagenes.Clear();
            MessageBox.Show("Imagenes Deseleccionadas");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones())
                {
                    Propiedad propiedad = new Propiedad(comboBoxVivienda.Text, tbDireccion.Text, (int)numericUpDownAmbientes.Value, Convert.ToString(numericUpDownST.Value) + "m2", Convert.ToString(numericUpDownSC.Value) + "m2", (int)numericUpDownPisos.Value, (int)numericUpDownHabitaciones.Value, (int)numericUpDownBaños.Value, comboBoxCochera.Text, (int)numericUpDownAntiguedad.Value, comboBoxPatio.Text, comboBoxPileta.Text, numericUpDownValorDeCouta.Value);
                    propiedad.ID = propiedadModificada.ID;
                    propiedad.Etiquetas = ObtenerEtiquetasPorPropiedad();
                    if (bllPropiedad.ModificarPropiedad(propiedad, ConvertirImagenesABytes(imagenes)))
                    {
                        MessageBox.Show("Vivienda publicada exitosamente");
                        imagenes.Clear();
                        menuActivo.IdentificarCatalogo();
                        this.Close();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
