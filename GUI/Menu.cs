using BE;
using BLL;
using System;
using System.Collections;
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
    public partial class Menu : Form
    {
        public Menu(FLogin fLogin)
        {
            InitializeComponent();
            bitacora = new Bitacora_();
            bitacorabll = new BitacoraBLL();
            bllPropiedad = new BLLPropiedad();
            bllCloser = new BLLCloser();
            fl = fLogin;
            BuscarControles(this.Controls);
            OcultarBotonesDinamico();
            ComprobarPermisos(Sesion.ObtenerSesion().listaDePermisos);
            MostrarControles();
            IdentificarCatalogo();
        }
        Bitacora_ bitacora;
        BitacoraBLL bitacorabll;
        FLogin fl;
        BLLPropiedad bllPropiedad;
        BLLCloser bllCloser;
        private void Menu_Load(object sender, EventArgs e)
        {

        }

        #region FUNCIONES EXTRA
        public void OcultarBotonesDinamico()
        {
            foreach (Control c in ListaControles)
            {

                if (c.Tag == null || c.Tag.ToString() == "")
                {
                    continue;
                }
                if (c.Tag.ToString() != null)
                {
                    c.Enabled = false; 
                    c.Visible = false;
                }
            } 
        }

        //public void OcultarBotones()
        //{
        //    btnAgregarPropiedad.Enabled = false;
        //    btnAgregarPropiedad.Visible = false;
        //    btnIngresosDueño.Enabled = false;
        //    btnIngresosDueño.Visible = false;
        //    btnVerReunionesDueño.Enabled = false;
        //    btnVerReunionesDueño.Visible = false;
        //    btnVerSolicitudesDeClosers.Enabled = false;
        //    btnVerSolicitudesDeClosers.Visible = false;
        //    btnCuentaDueño.Enabled = false;
        //    btnCuentaDueño.Visible = false;

        //    btnCuentaCloser.Enabled = false;
        //    btnCuentaCloser.Visible = false;
        //    btnVerCasasGestionadasCloser.Enabled = false;
        //    btnVerCasasGestionadasCloser.Visible = false;
        //    btnIngresosCloser.Enabled = false;
        //    btnIngresosCloser.Visible = false;
        //    btnRendimientoCloser.Enabled = false;
        //    btnRendimientoCloser.Visible = false;

        //    btnGestorDeReunionesCliente.Enabled = false;
        //    btnGestorDeReunionesCliente.Visible = false;
        //    btnPagosCliente.Enabled = false;
        //    btnPagosCliente.Visible = false;
        //    btnCuentaCliente.Enabled = false;
        //    btnCuentaCliente.Visible = false;

        //    btnPerformanceEmpresa.Enabled = false;
        //    btnPerformanceEmpresa.Visible = false;
        //    btnIngresosEmpresa.Enabled = false;
        //    btnIngresosEmpresa.Visible = false;
        //    btnCuentaEmpresa.Enabled = false;
        //    btnCuentaEmpresa.Visible = false;
        //}

        public void ComprobarPermisos(List<Permiso> lista)
        {
            foreach (Permiso p in lista)
            {
                
                foreach (Control c in ListaControles)
                {
                    
                    if (c.Tag == null)
                    {
                        continue;
                    }
                    if (c.Tag.ToString() == p.Nombre)
                    {
                        c.Enabled = true;
                        c.Visible = true;
                    }

                    if (p.permisos.Count > 0)
                    {
                        ComprobarPermisos(p.permisos);
                    }
                }
            }
        }

        List<Control> ListaControles = new List<Control>();
        public void BuscarControles(ICollection controles)
        {
            foreach (Control c in controles)
            {
                ListaControles.Add(c);
                if (c.HasChildren)
                {
                    BuscarControles(c.Controls);
                }
            }
        }

        public void MostrarControles()
        {
            if(btnAgregarPropiedad.Enabled == true && btnVerReunionesDueño.Enabled == true && btnIngresosDueño.Enabled == true && btnVerSolicitudesDeClosers.Enabled == true && btnCuentaDueño.Enabled == true)
            {
                tableLayoutPanelBarraMenuDinamica.RowStyles[0].Height = 100;
                tableLayoutPanelBarraMenuDinamica.RowStyles[1].Height = 0;
                tableLayoutPanelBarraMenuDinamica.RowStyles[2].Height = 0;
                tableLayoutPanelBarraMenuDinamica.RowStyles[3].Height = 0;

                tableLayoutPanelBarraMenuDinamica.ColumnStyles[1].Width = 25;
                tableLayoutPanelBarraMenuDinamica.ColumnStyles[0].Width = 25;
                tableLayoutPanelBarraMenuDinamica.ColumnStyles[2].Width = 25;
                tableLayoutPanelBarraMenuDinamica.ColumnStyles[3].Width = 0;
                tableLayoutPanelBarraMenuDinamica.ColumnStyles[4].Width = 25;

                btnAgregarPropiedad.Size = new Size(140,35);
                btnVerReunionesDueño.Size = new Size(164, 35);
                btnIngresosDueño.Size = new Size(160, 40);
                btnVerSolicitudesDeClosers.Size = new Size(140,35);
                btnCuentaDueño.Size = new Size(140,35);
            }
            else if(btnIngresosCloser.Enabled == true && btnRendimientoCloser.Enabled == true && btnCuentaCloser.Enabled == true && btnVerCasasGestionadasCloser.Enabled == true)
            {
                tableLayoutPanelBarraMenuDinamica.RowStyles[0].Height = 0;
                tableLayoutPanelBarraMenuDinamica.RowStyles[1].Height = 100;
                tableLayoutPanelBarraMenuDinamica.RowStyles[2].Height = 0;
                tableLayoutPanelBarraMenuDinamica.RowStyles[3].Height = 0;
                tableLayoutPanelBarraMenuDinamica.ColumnStyles[1].Width = 0;
                tableLayoutPanelBarraMenuDinamica.ColumnStyles[0].Width = 25;
                tableLayoutPanelBarraMenuDinamica.ColumnStyles[2].Width = 25;
                tableLayoutPanelBarraMenuDinamica.ColumnStyles[3].Width = 25;
                tableLayoutPanelBarraMenuDinamica.ColumnStyles[4].Width = 25;
                btnRendimientoCloser.Size = new Size(140, 35);
                btnVerCasasGestionadasCloser.Size = new Size(164, 35);
                btnIngresosCloser.Size = new Size(160, 40);
                btnCuentaCloser.Size = new Size(140, 35);
            }
            else if (btnGestorDeReunionesCliente.Enabled == true && btnPagosCliente.Enabled == true && btnCuentaCliente.Enabled == true)
            {
                tableLayoutPanelBarraMenuDinamica.RowStyles[0].Height = 0;
                tableLayoutPanelBarraMenuDinamica.RowStyles[1].Height = 0;
                tableLayoutPanelBarraMenuDinamica.RowStyles[2].Height = 100;
                tableLayoutPanelBarraMenuDinamica.RowStyles[3].Height = 0;
                
                btnGestorDeReunionesCliente.Size = new Size(140, 35);
                btnPagosCliente.Size = new Size(164, 35);
                btnCuentaCliente.Size = new Size(160, 40);
            }
            else if (btnPerformanceEmpresa.Enabled == true && btnIngresosEmpresa.Enabled == true && btnCuentaEmpresa.Enabled == true)
            {
                tableLayoutPanelBarraMenuDinamica.RowStyles[0].Height = 0;
                tableLayoutPanelBarraMenuDinamica.RowStyles[1].Height = 0;
                tableLayoutPanelBarraMenuDinamica.RowStyles[2].Height = 0;
                tableLayoutPanelBarraMenuDinamica.RowStyles[3].Height = 100;
                btnPerformanceEmpresa.Size = new Size(140, 35);
                btnIngresosEmpresa.Size = new Size(164, 35);
                btnCuentaEmpresa.Size = new Size(160, 40);
            }
            tableLayoutPanelBarraMenuDinamica.Refresh();
        }
        #endregion

        #region FUNCIONES PRINCIPALES

        
        public void Postularse(Propiedad propiedad)
        {
            try
            {
                if (bllCloser.Postularse(propiedad))
                {
                    MessageBox.Show("Postulacion Exitosa");
                }
                else
                {
                    MessageBox.Show("No se puedo postular");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GenerarCatalogoDueños()
        {
            List<Propiedad> listaDePropiedades = new List<Propiedad>();
            listaDePropiedades = bllPropiedad.LeerPropiedadesDeDueño();
            flowLayoutPanelCatalogo.Controls.Clear();
            flowLayoutPanelCatalogo.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelCatalogo.WrapContents = true;
            if(listaDePropiedades != null && listaDePropiedades.Count > 0)
            {
                foreach (Propiedad p in listaDePropiedades)
                {
                    GroupBox gpadre = new GroupBox();
                    gpadre.Width = flowLayoutPanelCatalogo.Width - 170;
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
                        if (propiedad.Name != "Imagenes" && propiedad.Name != "ID")
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
                    labelPosY += 30;

                    Button btnVerPostulados = new Button();
                    btnVerPostulados.Text = "Ver Postulados";
                    btnVerPostulados.Width = 120;
                    btnVerPostulados.Location = new Point(10, labelPosY);
                    labelPosY += 30;
                    btnVerPostulados.Click += (s, e) => AbrirFormularioClosersPostulados(p);

                    gpadre.Controls.Add(flpImagenes);
                    gpadre.Controls.Add(gpDescripcion);
                    gpDescripcion.Controls.Add(btnModificar);
                    gpDescripcion.Controls.Add(btnVerPostulados);
                    flowLayoutPanelCatalogo.Controls.Add(gpadre);
                }
            }
            
        }

        public void GenerarCatalogoClosers()
        {
            List<Propiedad> listaDePropiedades = new List<Propiedad>();
            listaDePropiedades = bllPropiedad.LeerPropiedades(2);
            flowLayoutPanelCatalogo.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelCatalogo.WrapContents = true;
            flowLayoutPanelCatalogo.Controls.Clear();
            foreach (Propiedad p in listaDePropiedades)
            {
                GroupBox gpadre = new GroupBox();
                gpadre.Width = flowLayoutPanelCatalogo.Width - 170;
                gpadre.Height = 300;
                gpadre.Margin = new Padding(20);

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
                    if (propiedad.Name != "Imagenes" && propiedad.Name != "ID")
                    {
                        Label labelNombre = new Label();
                        labelNombre.Text = propiedad.Name;
                        labelNombre.Tag = propiedad.Name;
                        labelNombre.Location = new Point(10, labelPosY);
                        labelNombre.AutoSize = true;

                        Label labelValor = new Label();
                        labelValor.Text = propiedad.GetValue(p)?.ToString();
                        labelValor.Location = new Point(130, labelPosY);
                        labelValor.AutoSize = true;

                        gpDescripcion.Controls.Add(labelNombre);
                        gpDescripcion.Controls.Add(labelValor);

                        labelPosY += 30;
                    }
                }

                Button btnPostularse = new Button();
                btnPostularse.Text = "Postularse";
                btnPostularse.Width = 120;
                btnPostularse.Location = new Point(10, labelPosY);
                btnPostularse.Click += (s, e) => Postularse(p);

                gpadre.Controls.Add(flpImagenes);
                gpadre.Controls.Add(gpDescripcion);
                gpDescripcion.Controls.Add(btnPostularse);
                flowLayoutPanelCatalogo.Controls.Add(gpadre);
            }
        }

        public void GenerarCatalogoClientes()
        {
            List<Propiedad> listaDePropiedades = new List<Propiedad>();
            listaDePropiedades = bllPropiedad.LeerPropiedades(1);
            flowLayoutPanelCatalogo.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelCatalogo.WrapContents = true;
            flowLayoutPanelCatalogo.Controls.Clear();
            foreach (Propiedad p in listaDePropiedades)
            {
                GroupBox gpadre = new GroupBox();
                gpadre.Width = flowLayoutPanelCatalogo.Width - 170;
                gpadre.Height = 300;
                gpadre.Margin = new Padding(20);

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
                    if (propiedad.Name != "Imagenes" && propiedad.Name != "ID")
                    {
                        Label labelNombre = new Label();
                        labelNombre.Text = propiedad.Name;
                        labelNombre.Tag = propiedad.Name;
                        labelNombre.Location = new Point(10, labelPosY);
                        labelNombre.AutoSize = true;

                        Label labelValor = new Label();
                        labelValor.Text = propiedad.GetValue(p)?.ToString();
                        labelValor.Location = new Point(130, labelPosY);
                        labelValor.AutoSize = true;

                        gpDescripcion.Controls.Add(labelNombre);
                        gpDescripcion.Controls.Add(labelValor);

                        labelPosY += 30;
                    }
                }

                Button btnSolicitarReunion = new Button();
                btnSolicitarReunion.Text = "Solicitar Reunion";
                btnAgregarPropiedad.BackColor = Color.White;
                btnSolicitarReunion.Width = 120;
                btnSolicitarReunion.Location = new Point(10, labelPosY);
                btnSolicitarReunion.Click += (s, e) => AbrirFormularioSolicitarReunion(p);

                gpadre.Controls.Add(flpImagenes);
                gpadre.Controls.Add(gpDescripcion);
                gpDescripcion.Controls.Add(btnSolicitarReunion);
                flowLayoutPanelCatalogo.Controls.Add(gpadre);
            }
        }


        public void IdentificarCatalogo()
        {
            try
            {
                if (Sesion.ObtenerSesion().ObtenerUsuario().Sector == "Dueño")
                {
                    GenerarCatalogoDueños();
                }
                else if(Sesion.ObtenerSesion().ObtenerUsuario().Sector == "Closer")
                {
                    GenerarCatalogoClosers();
                }
                else if(Sesion.ObtenerSesion().ObtenerUsuario().Sector == "Cliente")
                {
                    GenerarCatalogoClientes();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        #endregion


        #region LOGOUT Y CIERRE DE APP
        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        
        private void btnLogout_Click(object sender, EventArgs e)
        {
            bitacora.Fecha = DateTime.Now.Date;
            bitacora.Usuario = Sesion.ObtenerSesion().ObtenerUsuario().NombreDeUsuario;
            try
            {
                bitacora.Tipo = Bitacora_.BitacoraTipo.INFO;
                Sesion.Logout();
                bitacora.Mensaje = "Sesion Cerada Exitosamente";
                bitacorabll.Add(bitacora);
                this.Hide();
                MessageBox.Show("Sesión Cerrada Exitosamente");
                fl.Show();
                fl.Limpiar();
            }
            catch (Exception ex)
            {
                bitacora.Tipo = Bitacora_.BitacoraTipo.ERROR;
                bitacora.Mensaje = "No se Pudo Cerrar Sesion:" + ex.Message;
                bitacorabll.Add(bitacora);
                throw ex;
            }
        }
        #endregion
        private void tableLayoutPanelBarraMenuDinamica_Paint(object sender, PaintEventArgs e)
        {

        }

        #region FUNCIONALIDADES DUEÑO
        private void btnAgregarPropiedad_Click(object sender, EventArgs e)
        {
            RegistrarPropiedades registrarPropiedades = new RegistrarPropiedades();
            registrarPropiedades.Show();
        }
        #endregion
        private void btnVerSolicitudesDeClosers_Click(object sender, EventArgs e)
        {

        }
        #region FORMS
        public void AbrirFormularioModificar(Propiedad propiedad)
        {
            RegistrarPropiedades registrarPropiedades = new RegistrarPropiedades(propiedad);
            registrarPropiedades.Show();
        }

        public void AbrirFormularioClosersPostulados(Propiedad p)
        {
            try
            {
                ClosersPostulados closersPostulados = new ClosersPostulados(p);
                closersPostulados.Show();
            }
            catch(Exception ex)
            {
                
            }
        }

        public void AbrirFormularioSolicitarReunion(Propiedad propiedad)
        {
            try
            {
                SolicitarReunion solicitarReunion = new SolicitarReunion(propiedad);
                solicitarReunion.Show();
            }
            catch(Exception ex)
            {

            }
            
        }

        private void btnVerCasasGestionadasCloser_Click(object sender, EventArgs e)
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Closer closer = bllCloser.LeerCloser(usuario.ID);
            GestionDePropiedades gestionDePropiedades = new GestionDePropiedades(closer);
            gestionDePropiedades.Show();
        }

        private void btnVerReunionesDueño_Click(object sender, EventArgs e)
        {
            VerReuniones verReuniones = new VerReuniones();
            verReuniones.Show();
        }

        private void btnCuentaCliente_Click(object sender, EventArgs e)
        {
            PerfilCliente perfilCliente = new PerfilCliente();
            perfilCliente.Show();
        }

        private void btnCuentaDueño_Click(object sender, EventArgs e)
        {
            PerfilDueño perfilDueño = new PerfilDueño();
            perfilDueño.Show();
        }

        private void btnCuentaCloser_Click(object sender, EventArgs e)
        {
            PerfilCloser perfilCloser = new PerfilCloser();
            perfilCloser.Show();
        }
        #endregion

        private void btnPagosCliente_Click(object sender, EventArgs e)
        {
            Pagos pagos = new Pagos();
            pagos.Show();
        }

        private void btnIngresosDueño_Click(object sender, EventArgs e)
        {
            IngresosDueño ingresosDueño = new IngresosDueño();
            ingresosDueño.Show();
        }

        private void btnRendimientoCloser_Click(object sender, EventArgs e)
        {
            Rendimientos rendimientos = new Rendimientos();
            rendimientos.Show();
        }
    }
}
