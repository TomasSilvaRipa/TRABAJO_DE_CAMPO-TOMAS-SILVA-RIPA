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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class GestionDePropiedades : FIdiomaActualizable,IObservador
    {
        public GestionDePropiedades(Closer closer)
        {
            InitializeComponent();
            bllPropiedad = new BLLPropiedad();
            bllCloser = new BLLCloser();
            bllIdiomas = new BLLIdiomas();
            GenerarCatalogoViviendasXCloser(closer);
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
            Notificar(this);
        }
        BLLPropiedad bllPropiedad;
        BLLCloser bllCloser;
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
        private void CatalogoDePropiedades_Load(object sender, EventArgs e)
        {

        }

        public void VerSolicitantesDeReunion(Propiedad propiedad)
        {
            GestionSolicitudesDeReunion gestionSolicitudesDeReunion = new GestionSolicitudesDeReunion(propiedad);
            gestionSolicitudesDeReunion.Show();
        }

        public void GenerarCatalogoViviendasXCloser(Closer closer)
        {
            List<Propiedad> listaDePropiedades = new List<Propiedad>();
            listaDePropiedades = bllCloser.LeerViviendasXCloser(closer);
            flowLayoutPanelPadre.Controls.Clear();
            if(listaDePropiedades != null)
            {
                foreach (Propiedad p in listaDePropiedades)
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
                        if (propiedad.Name != "Imagenes" && propiedad.Name != "ID" && propiedad.Name != "Aqluilada")
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

                    Button btnPostularse = new Button();
                    btnPostularse.Text = "Ver Solicitudes de Reunion";
                    btnPostularse.Tag = "FGPVerSolicitudesDeReunion";
                    btnPostularse.Width = 150;
                    btnPostularse.Location = new Point(10, labelPosY);
                    btnPostularse.Click += (s, e) => VerSolicitantesDeReunion(p);

                    gpadre.Controls.Add(flpImagenes);
                    gpadre.Controls.Add(gpDescripcion);
                    gpDescripcion.Controls.Add(btnPostularse);
                    flowLayoutPanelPadre.Controls.Add(gpadre);
                }
            }
            else
            {
                Label l = new Label();
                flowLayoutPanelPadre.Controls.Add(l);
                l.Text = "No tiene casas bajo gestión aún";
                l.Font = new Font("Microsoft Sans Serif", 8);
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Dock = DockStyle.None;
                
                l.Anchor = AnchorStyles.None;
            }
        }

        private void flowLayoutPanelPadre_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
