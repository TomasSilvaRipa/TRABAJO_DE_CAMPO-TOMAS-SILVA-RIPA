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
                if (ManejoErrores.ValidarClave(tbDireccion.Text))
                {
                    Propiedad propiedad = new Propiedad(comboBoxVivienda.Text,tbDireccion.Text,(int)numericUpDownAmbientes.Value,(int)numericUpDownST.Value,(int)numericUpDownSC.Value,(int)numericUpDownPisos.Value,(int)numericUpDownHabitaciones.Value,(int)numericUpDownBaños.Value,comboBoxCochera.Text,(int)numericUpDownAntiguedad.Value,comboBoxPatio.Text,comboBoxPileta.Text,numericUpDownValorDeCouta.Value);
                    if (bllPropiedad.AltaPropiedad(propiedad, ConvertirImagenesABytes(imagenes)))
                    {
                        MessageBox.Show("Vivienda publicada exitosamente");
                    }
                    imagenes.Clear();
                    
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
    }
}
