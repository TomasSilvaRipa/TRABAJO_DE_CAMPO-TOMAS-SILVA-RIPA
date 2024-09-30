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
    public partial class RegistrarPropiedades : Form
    {
        public RegistrarPropiedades()
        {
            InitializeComponent();
            bllPropiedad = new BLLPropiedad();
            imagenes = new List<System.Drawing.Image>();
            comboBoxPatio.DataSource = Enum.GetValues(typeof(Patio));
            comboBoxPileta.DataSource = Enum.GetValues(typeof(Pileta));
            comboBoxCochera.DataSource = Enum.GetValues(typeof(Cochera));
            comboBoxVivienda.DataSource = Enum.GetValues(typeof(Vivienda));
        }
        BLLPropiedad bllPropiedad;
        List<System.Drawing.Image> imagenes;
        Propiedad propiedadModificada;
        public RegistrarPropiedades(Propiedad propiedad)
        {
            InitializeComponent();
            bllPropiedad = new BLLPropiedad();
            imagenes = new List<System.Drawing.Image>();
            comboBoxPatio.DataSource = Enum.GetValues(typeof(Patio));
            comboBoxPileta.DataSource = Enum.GetValues(typeof(Pileta));
            comboBoxCochera.DataSource = Enum.GetValues(typeof(Cochera));
            comboBoxVivienda.DataSource = Enum.GetValues(typeof(Vivienda));
            propiedadModificada = propiedad;
            ActualizarControlesPorpiedadSeleccionada(propiedad);
            
        }
        private void RegistrarPropiedades_Load(object sender, EventArgs e)
        {

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
                    openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg)|*.png;*.jpg";
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

       

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ManejoErrores.ValidarDireccion(tbDireccion.Text))
                {
                    Propiedad propiedad = new Propiedad(comboBoxVivienda.Text,tbDireccion.Text,(int)numericUpDownAmbientes.Value,Convert.ToString(numericUpDownST.Value) + "m2", Convert.ToString(numericUpDownSC.Value)+"m2",(int)numericUpDownPisos.Value,(int)numericUpDownHabitaciones.Value,(int)numericUpDownBaños.Value,comboBoxCochera.Text,(int)numericUpDownAntiguedad.Value,comboBoxPatio.Text,comboBoxPileta.Text,numericUpDownValorDeCouta.Value);
                    if(numericUpDownST.Value >= numericUpDownSC.Value)
                    {
                        if (numericUpDownAmbientes.Value >= numericUpDownHabitaciones.Value)
                        {
                            if (imagenes.Count > 0)
                            {
                                if (bllPropiedad.AltaPropiedad(propiedad, ConvertirImagenesABytes(imagenes)))
                                {
                                    MessageBox.Show("Vivienda publicada exitosamente");
                                    imagenes.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo registrar la vivienda");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Seleccione al menos una imagen para la vivienda");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La cantidad de habitaciones no puede ser mayor que la cantidad de ambientes");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La superficie cubierta no puede ser mayor que la total");
                    }
                }
                else
                {
                    MessageBox.Show("Datos de dirección invalidos");
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
    }
}
