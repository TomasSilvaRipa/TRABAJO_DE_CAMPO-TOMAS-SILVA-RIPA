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
    public partial class GestionSolicitudesDeReunion : FIdiomaActualizable,IObservador
    {
        public GestionSolicitudesDeReunion(Propiedad propiedad)
        {
            InitializeComponent();
            bllReunion = new BLLReunion();
            bllCliente = new BLLCliente();
            bllUsuario = new BLLUsuario();
            bllOpinion = new BLLOpinon();
            bllIdiomas = new BLLIdiomas();
            solicitudes = new List<Solicitud>();
            opiniones = new List<Opinion>();
            CargarDatagridSolicitantes(propiedad);
            propiedadSeleccionada = propiedad;
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
        }
        BLLReunion bllReunion;
        Propiedad propiedadSeleccionada;
        BLLCliente bllCliente;
        BLLUsuario bllUsuario;
        Solicitud solicitud;
        BLLOpinon bllOpinion;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;
        List<Solicitud> solicitudes;
        List<Opinion> opiniones;
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

        public void CargarDatagridSolicitantes(Propiedad propiedad)
        {
            dataGridViewSolicitudes.DataSource = null;
            solicitudes = bllReunion.LeerSolicitudesDeReunionXVivienda(propiedad);
            if(solicitudes != null && solicitudes.Count > 0)
            {
                dataGridViewSolicitudes.DataSource = solicitudes;
                dataGridViewSolicitudes.Columns["ID"].Visible = false;
                dataGridViewSolicitudes.Columns["ID_Cliente"].Visible = false;
                dataGridViewSolicitudes.Columns["ID_Vivienda"].Visible = false;
            }
            else
            {
                Label l = new Label();
                l.Text = "No Hay Reuniones por el Momento";
                flowLayoutPanelSolicitante.Controls.Add(l);
                l.Size = new Size(400, 200);
                l.Anchor = AnchorStyles.None;
            }
            
        }

        public void CargarOpiniones(Usuario usuario)
        {
            dataGridViewOpiniones.DataSource = null;
            opiniones = bllOpinion.LeerOpiniones(usuario, 2);
            if (opiniones != null && opiniones.Count > 0)
            {
                dataGridViewOpiniones.DataSource = opiniones;
                dataGridViewOpiniones.Columns["ID"].Visible = false;
                dataGridViewOpiniones.Columns["ID_Usuario"].Visible = false;
            }
        }


        public void GenerarSolicitante()
        {
            try
            {
                Solicitud solicitud = (Solicitud)dataGridViewSolicitudes.CurrentRow.DataBoundItem;
                Cliente cliente = bllCliente.LeerCliente(solicitud.ID_Cliente, 2);
                
                flowLayoutPanelSolicitante.Controls.Clear();
                flowLayoutPanelSolicitante.FlowDirection = FlowDirection.LeftToRight;
                flowLayoutPanelSolicitante.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom; 
                flowLayoutPanelSolicitante.WrapContents = true;

                GroupBox gpadre = new GroupBox();
                gpadre.Width = flowLayoutPanelSolicitante.Width;
                gpadre.Height = 300;
                gpadre.Margin = new Padding(10);

                
                TableLayoutPanel flpImagen = new TableLayoutPanel();
                flpImagen.Width = (gpadre.Width / 2); 
                flpImagen.Height = gpadre.Height;
                flpImagen.Dock = DockStyle.Left;
                flpImagen.AutoScroll = true;
               


                Panel gpDescripcion = new Panel();
                gpDescripcion.Width = gpadre.Width / 2;
                gpDescripcion.Height = gpadre.Height;
                gpDescripcion.Dock = DockStyle.Right;
                gpDescripcion.AutoScroll = true;

                int labelPosY = 20;
                int labelAncho = 100;  
                 

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
                            
                            Label labelValor = new Label();
                            labelValor.Text = propiedad.GetValue(cliente)?.ToString();
                            labelValor.Location = new Point(labelAncho + 20, labelPosY);
                            

                            if (propiedad.GetValue(cliente) is DateTime)
                            {
                                DateTime fn = Convert.ToDateTime(propiedad.GetValue(cliente)).Date;
                                labelValor.Text = fn.ToString("dd/MM/yyyy");
                            }

                            gpDescripcion.Controls.Add(labelNombre);
                            gpDescripcion.Controls.Add(labelValor);

                            labelPosY += 30;
                        }
                    }
                    else
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Width = flpImagen.Width - 30;
                        pictureBox.Height = flpImagen.Height - 30;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        if (propiedad.GetValue(cliente) != null)
                        {
                            
                            using (MemoryStream ms = new MemoryStream(cliente.Foto))
                            {
                                pictureBox.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pictureBox.Image = Resources.UsuarioGenerico;
                            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                        }
                        flpImagen.Controls.Add(pictureBox);
                    }
                }

                Button btnAceptar = new Button();
                btnAceptar.Text = "Aceptar";
                btnAceptar.Tag = "FGSRAceptar";
                btnAceptar.Width = 120;
                btnAceptar.Location = new Point(10, labelPosY);
                btnAceptar.Click += (s, e) => AceptarReunion(cliente,solicitud);
                labelPosY += 30;
                

                Button btnRechazar = new Button();
                btnRechazar.Text = "Rechazar";
                btnRechazar.Tag = "FGSRRechazar";
                btnRechazar.Width = 120;
                btnRechazar.Location = new Point(10, labelPosY);
                btnRechazar.Click += (s, e) => RechazarReunion(solicitud); 
                labelPosY += 30;

                gpadre.Controls.Add(flpImagen);
                gpadre.Controls.Add(gpDescripcion);
                gpDescripcion.Controls.Add(btnAceptar);
                gpDescripcion.Controls.Add(btnRechazar);
                flowLayoutPanelSolicitante.Controls.Add(gpadre);
                CargarOpiniones(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        public void AceptarReunion(Cliente cliente,Solicitud solicitud)
        {
            try
            {
                if (bllReunion.AceptarReunion(cliente, solicitud))
                {
                    flowLayoutPanelSolicitante.Controls.Clear();
                    CargarDatagridSolicitantes(propiedadSeleccionada);
                    MessageBox.Show("Solicitud Aceptada");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RechazarReunion(Solicitud solicitud)
        {
            try
            {
                if (bllReunion.RechazarReunion(solicitud))
                {
                    CargarDatagridSolicitantes(propiedadSeleccionada);
                    MessageBox.Show("Se rechazo la reunion con exito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridViewSolicitudes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSolicitudes.SelectedRows.Count == 1)
            {
                GenerarSolicitante();
                solicitud = (Solicitud)dataGridViewSolicitudes.CurrentRow.DataBoundItem;
            }
        }
    }
}
