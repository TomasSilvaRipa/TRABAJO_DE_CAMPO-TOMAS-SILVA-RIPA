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
            Notificar(this);
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
                dataGridViewSolicitudes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewSolicitudes.ForeColor = Color.Black;
            }
            else
            {
                Label l = new Label();
                l.Text = "No Hay Reuniones por el Momento";
                flowLayoutPanelSolicitante.Controls.Add(l);
                l.Size = new Size(400, 200);
                l.Anchor = AnchorStyles.None;
                l.ForeColor = Color.White;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Font = new Font("Microsoft Sans Serif", 11);
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
                dataGridViewOpiniones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        public void GenerarSolicitante()
        {
            try
            {
                if (dataGridViewSolicitudes.SelectedRows.Count == 1)
                {
                    Solicitud solicitud = (Solicitud)dataGridViewSolicitudes.CurrentRow.DataBoundItem;
                    Cliente cliente = bllCliente.LeerCliente(solicitud.ID_Cliente, 2);

                    flowLayoutPanelSolicitante.Controls.Clear();
                    flowLayoutPanelSolicitante.FlowDirection = FlowDirection.LeftToRight;
                    flowLayoutPanelSolicitante.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
                    flowLayoutPanelSolicitante.WrapContents = true;
                    flowLayoutPanelSolicitante.ForeColor = Color.White;

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
                            if (propiedad.Name != "ID_Usuario" && propiedad.Name != "NombreDeUsuario" && propiedad.Name != "DV" && propiedad.Name != "Clave" && propiedad.Name != "Sector" && propiedad.Name != "ID" && propiedad.Name != "Inquilino")
                            {
                                Label labelNombre = new Label();
                                labelNombre.Text = propiedad.Name;
                                labelNombre.Tag = propiedad.Name;
                                labelNombre.Location = new Point(10, labelPosY);
                                labelNombre.Tag = "FP" + propiedad.Name;

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
                    ComboBox comboBoxHora = new ComboBox();
                    comboBoxHora.Items.AddRange(new object[] { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" });
                    comboBoxHora.SelectedIndex = 0;
                    comboBoxHora.DropDownStyle = ComboBoxStyle.DropDownList;
                    //comboBoxHora.Anchor = AnchorStyles.Top | AnchorStyles.Left; 
                    comboBoxHora.Location = new Point(10, labelPosY);
                    labelPosY += 30;

                    Button btnAceptar = new Button();
                    btnAceptar.Text = "Aceptar";
                    btnAceptar.Tag = "FGSRAceptar";
                    btnAceptar.Width = 120;
                    btnAceptar.Location = new Point(10, labelPosY);
                    btnAceptar.Click += (s, e) => AceptarReunion(cliente, solicitud,comboBoxHora.Text);
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
                    gpDescripcion.Controls.Add(comboBoxHora);
                    gpDescripcion.Controls.Add(btnRechazar);
                    flowLayoutPanelSolicitante.Controls.Add(gpadre);
                    CargarOpiniones(cliente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        public void AceptarReunion(Cliente cliente,Solicitud solicitud,string Hora)
        {
            try
            {
                if (bllReunion.AceptarReunion(cliente, solicitud,Hora))
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

        private void GestionSolicitudesDeReunion_MaximumSizeChanged(object sender, EventArgs e)
        {
        }

        private void GestionSolicitudesDeReunion_MinimumSizeChanged(object sender, EventArgs e)
        {
        }

        private void GestionSolicitudesDeReunion_SizeChanged(object sender, EventArgs e)
        {
        }

        private void GestionSolicitudesDeReunion_ResizeEnd(object sender, EventArgs e)
        {
            GenerarSolicitante();
        }

        private void GestionSolicitudesDeReunion_Resize(object sender, EventArgs e)
        {
            GenerarSolicitante();
        }
    }
}
