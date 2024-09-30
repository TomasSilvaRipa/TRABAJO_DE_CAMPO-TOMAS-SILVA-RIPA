using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class CatalogoPropiedadesDueño : Form
    {
        public CatalogoPropiedadesDueño()
        {
            InitializeComponent();
            bllPropiedad = new BLLPropiedad();
            GenerarCatalogo();
        }
        BLLPropiedad bllPropiedad;
        private void CatalogoPropiedadesDueño_Load(object sender, EventArgs e)
        {

        }

        public void AbrirFormularioModificar(Propiedad propiedad)
        {
            RegistrarPropiedades registrarPropiedades = new RegistrarPropiedades(propiedad);
            registrarPropiedades.Show();
        }

        public void GenerarCatalogo()
        {
            List<Propiedad> listaDePropiedades = new List<Propiedad>();
            listaDePropiedades = bllPropiedad.LeerPropiedadesDeDueño();
            flowLayoutPanelPadre.Controls.Clear();
            foreach (Propiedad p in  listaDePropiedades)
            {
                GroupBox gpadre = new GroupBox();
                gpadre.Width = flowLayoutPanelPadre.Width - 20; 
                gpadre.Height = 300;  
                gpadre.Margin = new Padding(10);

                FlowLayoutPanel flpImagenes = new FlowLayoutPanel();
                flpImagenes.Width = gpadre.Width / 2; 
                flpImagenes.Height = gpadre.Height; 
                flpImagenes.Dock = DockStyle.Left;
                flpImagenes.AutoScroll = true;

                Panel gpDescripcion = new Panel();
                gpDescripcion.Width = gpadre.Width / 2; 
                gpDescripcion.Height = gpadre.Height; 
                gpDescripcion.Dock = DockStyle.Right;
                gpDescripcion.AutoScroll = true;

                int labelPosY = 20;
                foreach (byte[] imgBytes in p.Imagenes) 
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Width = 100; 
                    pictureBox.Height = 100; 
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; 
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                    flpImagenes.Controls.Add(pictureBox);
                }

                foreach (PropertyInfo propiedad in p.GetType().GetProperties())
                {
                    if (propiedad.Name != "Imagenes")
                    {
                        Label labelNombre = new Label();
                        labelNombre.Text = propiedad.Name;
                        labelNombre.Tag = propiedad.Name;
                        labelNombre.Location = new Point(10, labelPosY);
                        labelNombre.AutoSize = true;

                        Label labelValor = new Label();
                        labelValor.Text = propiedad.GetValue(p)?.ToString();
                        labelValor.Location = new Point(150, labelPosY); 
                        labelValor.AutoSize = true;

                        gpDescripcion.Controls.Add(labelNombre);
                        gpDescripcion.Controls.Add(labelValor);

                        labelPosY += 30;
                    }
                }

                Button btnModificar = new Button();
                btnModificar.Text = "Modificar Datos";
                btnModificar.Width = 120;
                btnModificar.Location = new Point(10, labelPosY);
                btnModificar.Click += (s, e) => AbrirFormularioModificar(p);

                gpadre.Controls.Add(flpImagenes);
                gpadre.Controls.Add(gpDescripcion);
                gpDescripcion.Controls.Add(btnModificar);
                flowLayoutPanelPadre.Controls.Add(gpadre);
            }
        }

        private void flowLayoutPanelPadre_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
