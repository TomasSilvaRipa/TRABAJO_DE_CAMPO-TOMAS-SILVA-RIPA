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
    public partial class GestionSolicitudesDeReunion : Form
    {
        public GestionSolicitudesDeReunion(Propiedad propiedad)
        {
            InitializeComponent();
            bllReunion = new BLLReunion();
            bllCliente = new BLLCliente();
            CargarDatagridSolicitantes(propiedad);
            propiedadSeleccionada = propiedad;
        }
        BLLReunion bllReunion;
        Propiedad propiedadSeleccionada;
        BLLCliente bllCliente;
        

        public void CargarDatagridSolicitantes(Propiedad propiedad)
        {
            dataGridViewSolicitudes.DataSource = null;
            dataGridViewSolicitudes.DataSource = bllReunion.LeerSolicitudesDeReunionXVivienda(propiedad);
        }

        public  void GenerarSolicitante() 
        {
            try
            {
                Solicitud solicitud = (Solicitud)dataGridViewSolicitudes.CurrentRow.DataBoundItem;
                Cliente cliente = bllCliente.LeerCliente(solicitud.ID_Cliente,2);
                tableLayoutPanelSolicitante.Controls.Clear();

                GroupBox gpadre = new GroupBox();
                gpadre.Width = tableLayoutPanelSolicitante.Width - 200;
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

                foreach (PropertyInfo propiedad in cliente.GetType().GetProperties())
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
                            labelValor.Text = propiedad.GetValue(cliente)?.ToString();
                            labelValor.Location = new Point(130, labelPosY);
                            labelValor.AutoSize = true;

                            gpDescripcion.Controls.Add(labelNombre);
                            gpDescripcion.Controls.Add(labelValor);

                            labelPosY += 30;
                        }
                    }
                    else
                    {
                        if (propiedad.GetValue(cliente) != null)
                        {
                            PictureBox pictureBox = new PictureBox();
                            pictureBox.Width = 100;
                            pictureBox.Height = 100;
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                            using (MemoryStream ms = new MemoryStream(cliente.Foto))
                            {
                                pictureBox.Image = Image.FromStream(ms);
                            }
                            flpImagen.Controls.Add(pictureBox);
                        }
                    }
                }
                Button btnAceptar = new Button();
                btnAceptar.Text = "Aceptar";
                btnAceptar.Width = 120;
                btnAceptar.Location = new Point(10, labelPosY);
                labelPosY += 30;
                //btnDarDeBaja.Click += (s, e) => Aceptar(propiedadSeleccionada, c);

                Button btnRechazar = new Button();
                btnRechazar.Text = "Rechazar";
                btnRechazar.Width = 120;
                btnRechazar.Location = new Point(10, labelPosY);
                labelPosY += 30;

                gpadre.Controls.Add(flpImagen);
                gpadre.Controls.Add(gpDescripcion);
                gpDescripcion.Controls.Add(btnAceptar);
                gpDescripcion.Controls.Add(btnRechazar);
                tableLayoutPanelSolicitante.Controls.Add(gpadre);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void dataGridViewSolicitudes_SelectionChanged(object sender, EventArgs e)
        {
            GenerarSolicitante();
        }
    }
}
