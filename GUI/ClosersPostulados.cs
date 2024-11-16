using BE;
using BLL;
using GUI.Properties;
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

namespace GUI
{
    public partial class ClosersPostulados : FIdiomaActualizable,IObservador
    {
        public ClosersPostulados(Propiedad p)
        {
            InitializeComponent();
            bllCloser = new BLLCloser();
            bllDueño = new BLLDueño();
            bllPropiedad = new BLLPropiedad();
            bllIdiomas = new BLLIdiomas();
            IdentificarCatalogo(p);
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
            Notificar(this);
        }
        BLLCloser bllCloser;
        BLLDueño bllDueño;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;
        BLLPropiedad bllPropiedad;
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

        public void Aceptar(Propiedad p, Closer c) 
        {
            try
            {
                if (bllDueño.AceptarCloserPostulado(p, c))
                {
                    IdentificarCatalogo(p);
                    MessageBox.Show("Closer" + c.Nombre + " " + c.Apellido + " Aceptado");   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Rechazar(Propiedad p, Closer c)
        {
            try
            {
                if (bllDueño.RechazarCloserPostulado(p,c))
                {
                    IdentificarCatalogo(p);
                    MessageBox.Show("Closer" + c.Nombre + " " + c.Apellido + " Rechazado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DarDeBaja(Propiedad propiedad,Closer closer)
        {
            try
            {
                if(bllDueño.DarDeBajaCloserACargo(propiedad, closer))
                {
                    GenerarCatalogoClosersPostulados(propiedad);
                    MessageBox.Show("Closer " + closer.Nombre +" dado de baja exitosamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void IdentificarCatalogo(Propiedad propiedad)
        {
            if (bllPropiedad.ComprobarViviendaBajoGestion(propiedad))
            {
                GenerarCatalogoCloserBajoGestion(propiedad);
            }
            else
            {
                GenerarCatalogoClosersPostulados(propiedad);
            }
        }
        public void GenerarCatalogoClosersPostulados(Propiedad propiedadSeleccionada)
        {
            try
            {
                List<Closer> closers = new List<Closer>();
                closers = bllCloser.LeerClosersPostulados(propiedadSeleccionada);
                flowLayoutPanelPadre.Controls.Clear();
                flowLayoutPanelPadre.FlowDirection = FlowDirection.LeftToRight;
                flowLayoutPanelPadre.WrapContents = true;
                if (closers != null)
                {
                    foreach (Closer c in closers)
                    {

                        GroupBox gpadre = new GroupBox();
                        gpadre.Width = flowLayoutPanelPadre.Width - 200;
                        gpadre.Height = 300;
                        gpadre.Margin = new Padding(10);

                        FlowLayoutPanel flpImagen = new FlowLayoutPanel();
                        flpImagen.Width = gpadre.Width / 2;
                        flpImagen.Height = gpadre.Height;
                        flpImagen.Dock = DockStyle.Left;
                        flpImagen.AutoScroll = true;

                        Panel gpDescripcion = new Panel();
                        gpDescripcion.Width = gpadre.Width / 2;
                        gpDescripcion.Height = gpadre.Height;
                        gpDescripcion.Dock = DockStyle.Right;
                        gpDescripcion.AutoScroll = true;

                        int labelPosY = 20;

                        foreach (PropertyInfo propiedad in c.GetType().GetProperties())
                        {
                            if (propiedad.Name != "Foto")
                            {
                                if (propiedad.Name != "ID_Usuario" && propiedad.Name != "NombreDeUsuario" && propiedad.Name != "DV" && propiedad.Name != "Clave" && propiedad.Name != "Sector" && propiedad.Name != "ID")
                                {
                                    Label labelNombre = new Label();
                                    labelNombre.Text = propiedad.Name;
                                    labelNombre.Tag = propiedad.Name;
                                    labelNombre.Location = new Point(10, labelPosY);
                                    labelNombre.AutoSize = true;
                                    labelNombre.Tag = "FP" + propiedad.Name;

                                    Label labelValor = new Label();
                                    labelValor.Text = propiedad.GetValue(c)?.ToString();
                                    labelValor.Location = new Point(130, labelPosY);
                                    labelValor.AutoSize = true;

                                    gpDescripcion.Controls.Add(labelNombre);
                                    gpDescripcion.Controls.Add(labelValor);

                                    labelPosY += 30;
                                }
                            }
                            else
                            {
                                PictureBox pictureBox = new PictureBox();
                                pictureBox.Width = flpImagen.Width;
                                pictureBox.Height = flpImagen.Height;
                                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                                if (propiedad.GetValue(c) != null)
                                {
                                    using (MemoryStream ms = new MemoryStream(c.Foto))
                                    {
                                        pictureBox.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    pictureBox.Image = Resources.UsuarioGenerico;
                                }
                                flpImagen.Controls.Add(pictureBox);
                            }
                        }

                        Button btnAceptar = new Button();
                        btnAceptar.Text = "Aceptar";
                        btnAceptar.Tag = "FCPAceptar";
                        btnAceptar.Width = 120;
                        btnAceptar.Location = new Point(10, labelPosY);
                        labelPosY += 30;
                        btnAceptar.Click += (s, e) => Aceptar(propiedadSeleccionada, c);

                        Button btnRechazar = new Button();
                        btnRechazar.Text = "Rechazar";
                        btnRechazar.Tag = "FCPRechazar";
                        btnRechazar.Width = 120;
                        btnRechazar.Location = new Point(10, labelPosY);
                        labelPosY += 30;
                        btnRechazar.Click += (s, e) => Rechazar(propiedadSeleccionada, c);

                        gpadre.Controls.Add(flpImagen);
                        gpadre.Controls.Add(gpDescripcion);
                        gpDescripcion.Controls.Add(btnAceptar);
                        gpDescripcion.Controls.Add(btnRechazar);
                        flowLayoutPanelPadre.Controls.Add(gpadre);
                    }
                }
                else
                {
                    throw new Exception("No hay Closers Postulados para esta vivienda");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        public void GenerarCatalogoCloserBajoGestion(Propiedad propiedadSeleccionada)
        {
            try
            {
                List<Closer> closers = new List<Closer>();
                closers = bllCloser.LeerClosersPostulados(propiedadSeleccionada);
                flowLayoutPanelPadre.Controls.Clear();
                flowLayoutPanelPadre.FlowDirection = FlowDirection.LeftToRight;
                flowLayoutPanelPadre.WrapContents = true;
                if (closers != null)
                {
                    if (closers.Count == 1)
                    {
                        foreach (Closer c in closers)
                        {

                            GroupBox gpadre = new GroupBox();
                            gpadre.Width = flowLayoutPanelPadre.Width - 200;
                            gpadre.Height = 300;
                            gpadre.Margin = new Padding(10);


                            FlowLayoutPanel flpImagen = new FlowLayoutPanel();
                            flpImagen.Width = gpadre.Width / 2;
                            flpImagen.Height = gpadre.Height;
                            flpImagen.Dock = DockStyle.Left;
                            flpImagen.AutoScroll = true;

                            Panel gpDescripcion = new Panel();
                            gpDescripcion.Width = gpadre.Width / 2;
                            gpDescripcion.Height = gpadre.Height;
                            gpDescripcion.Dock = DockStyle.Right;
                            gpDescripcion.AutoScroll = true;

                            int labelPosY = 20;

                            foreach (PropertyInfo propiedad in c.GetType().GetProperties())
                            {
                                if (propiedad.Name != "Foto")
                                {
                                    if (propiedad.Name != "NombreDeUsuario" && propiedad.Name != "DV" && propiedad.Name != "Clave" && propiedad.Name != "Sector" && propiedad.Name != "ID")
                                    {
                                        Label labelNombre = new Label();
                                        labelNombre.Text = propiedad.Name;
                                        labelNombre.Tag = propiedad.Name;
                                        labelNombre.Location = new Point(10, labelPosY);
                                        labelNombre.AutoSize = true;

                                        Label labelValor = new Label();
                                        labelValor.Text = propiedad.GetValue(c)?.ToString();
                                        labelValor.Location = new Point(130, labelPosY);
                                        labelValor.AutoSize = true;

                                        gpDescripcion.Controls.Add(labelNombre);
                                        gpDescripcion.Controls.Add(labelValor);

                                        labelPosY += 30;

                                    }
                                }
                                else
                                {
                                    PictureBox pictureBox = new PictureBox();
                                    pictureBox.Width = flpImagen.Width;
                                    pictureBox.Height = flpImagen.Height;
                                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                                    if (propiedad.GetValue(c) != null)
                                    {
                                        using (MemoryStream ms = new MemoryStream(c.Foto))
                                        {
                                            pictureBox.Image = Image.FromStream(ms);
                                        }
                                    }
                                    else
                                    {
                                        pictureBox.Image = Resources.UsuarioGenerico;
                                    }
                                    flpImagen.Controls.Add(pictureBox);
                                }
                            }
                            Button btnDarDeBaja = new Button();
                            btnDarDeBaja.Text = "Dar de Baja";
                            btnDarDeBaja.Tag = "FCPDarDeBaja";
                            btnDarDeBaja.Width = 120;
                            btnDarDeBaja.Location = new Point(10, labelPosY);
                            labelPosY += 30;
                            btnDarDeBaja.Click += (s, e) => DarDeBaja(propiedadSeleccionada, c);

                            gpadre.Controls.Add(flpImagen);
                            gpadre.Controls.Add(gpDescripcion);
                            gpDescripcion.Controls.Add(btnDarDeBaja);
                            flowLayoutPanelPadre.Controls.Add(gpadre);
                        }
                    }
                }
                else
                {
                    throw new Exception("No hay Closers Postulados para esta vivienda");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }

        }
    }
}
