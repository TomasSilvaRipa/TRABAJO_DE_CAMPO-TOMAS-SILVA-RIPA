using BE;
using BLL;
using Servicios;
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
    public partial class Menu : FIdiomaActualizable,IObservador
    {
        public Menu(FLogin fLogin)
        {
            InitializeComponent();
            bitacora = new Bitacora_();
            bitacorabll = new BitacoraBLL();
            bllPropiedad = new BLLPropiedad();
            bllCloser = new BLLCloser();
            bllIdiomas = new BLLIdiomas();
            bllEtiquetas = new BLLEtiquetas();
            fl = fLogin;
            BuscarControles(this.Controls);
            OcultarBotonesDinamico();
            ComprobarPermisos(Sesion.ObtenerSesion().listaDePermisos);
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
            actualizarcbxIdiomas();
            MostrarControles();
            CargarEtiquetas();
            IdentificarCatalogo();

        }
        Bitacora_ bitacora;
        BitacoraBLL bitacorabll;
        FLogin fl;
        BLLPropiedad bllPropiedad;
        BLLCloser bllCloser;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;
        List<Propiedad> listaDePropiedades;
        BLLEtiquetas bllEtiquetas;
        bool IsLogOut = false;
        List<Etiqueta> Etiquetas;
        List<Propiedad> viviendasFiltradas;
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

        #region MULTI IDIOMA Y PERMISOS

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

        private void actualizarTablaIdiomas()
        {
            Sesion.ObtenerSesion().ActualizarIdiomas();
            tablaIdioma = Sesion.ObtenerSesion().tablaIdioma;

        }

        private void actualizarcbxIdiomas()
        {

            tablaIdioma = bllIdiomas.ObtenerIdiomas();
            foreach (DataRow row in tablaIdioma.Rows)
            {
                comboBoxIdiomas.Items.Add(row[1]);
            }
            comboBoxIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIdiomas.SelectedIndex = 0;
        }

        private void LlenarCbxIdiomas()
        {
            comboBoxIdiomas.Items.Clear();

            foreach (DataRow row in Sesion.ObtenerSesion().tablaIdioma.Rows)
            {
                comboBoxIdiomas.Items.Add(row[1]);
            }

            comboBoxIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public void Notificar(object Sender)
        {

            if (Sender is FTraducciones)
            {
                actualizarTablaIdiomas();
                LlenarCbxIdiomas();
            }
            else
            {
                actualizarIdioma();
            }

        }
        #endregion


        public void CargarEtiquetas()
        {
            flowLayoutPanelFiltro.Controls.Clear();
            Etiquetas = bllEtiquetas.LeerEtiquetas();
            foreach (Etiqueta e in Etiquetas)
            {
                CheckBox cb;
                cb = new CheckBox();
                cb.Text = e.Nombre;
                cb.Tag = "Formchb" + e.Nombre;
                cb.ForeColor = Color.White;
                flowLayoutPanelFiltro.Controls.Add(cb);
            }
        }

        public void MostrarControles()
        {
            Control[] botonesDueño = { btnAgregarPropiedad, btnVerReunionesDueño, btnIngresosDueño, btnCuentaDueño };
            Control[] botonesCloser = { btnRendimientoCloser, btnVerCasasGestionadasCloser, btnCuentaCloser };
            Control[] botonesCliente = { btnGestorDeReunionesCliente, btnPagosCliente, btnCuentaCliente };
            Control[] botonesInmobiliaria = { btnPerformanceInmoviliaria, btnCuentaInmoviliaria };

            ResetTableLayout();

            if (TodosHabilitados(botonesDueño))
            {
                ConfigurarFilasYColumnas(0, new float[] { 25, 25, 25, 25 }, botonesDueño);
            }
            else if (TodosHabilitados(botonesCloser))
            {
                ConfigurarFilasYColumnas(1, new float[] { 33, 0, 33, 33 }, botonesCloser);
            }
            else if (TodosHabilitados(botonesCliente))
            {
                ConfigurarFilasYColumnas(2, new float[] { 33, 0, 33, 33 }, botonesCliente);
            }
            else if (TodosHabilitados(botonesInmobiliaria))
            {
                ConfigurarFilasYColumnas(4, new float[] { 75, 0, 0, 25 }, botonesInmobiliaria);
            }

            tableLayoutPanelBarraMenuDinamica.Refresh();
        }

        private bool TodosHabilitados(Control[] botones)
        {
            return botones.All(boton => boton.Enabled);
        }

        private void ConfigurarFilasYColumnas(int filaVisible, float[] anchosColumnas, Control[] botones)
        {
            for (int i = 0; i < tableLayoutPanelBarraMenuDinamica.RowStyles.Count; i++)
            {
                tableLayoutPanelBarraMenuDinamica.RowStyles[i].Height = i == filaVisible ? 100 : 0;
            }

            for (int i = 0; i < anchosColumnas.Length; i++)
            {
                tableLayoutPanelBarraMenuDinamica.ColumnStyles[i].Width = anchosColumnas[i];
            }

            foreach (Control boton in botones)
            {
                boton.Size = new Size(140, 35);
            }
        }
        private void ResetTableLayout()
        {
            foreach (RowStyle row in tableLayoutPanelBarraMenuDinamica.RowStyles)
            {
                row.Height = 0;
            }
            foreach (ColumnStyle col in tableLayoutPanelBarraMenuDinamica.ColumnStyles)
            {
                col.Width = 0;
            }
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

        public void DarViviendaDeBaja(Propiedad propiedad)
        {
            try
            {
                if(propiedad.Aqluilada == false)
                {
                    if (bllPropiedad.BajaPropiedad(propiedad))
                    {
                        IdentificarCatalogo();
                        MessageBox.Show("Vivienda dada de baja exitosamente!!");
                    }
                }
                else
                {
                    MessageBox.Show("No se puede borrar una vivienda que esta siendo alquilada");
                }
                
            }
            catch(Exception ex)
            {

            }
        }

        public void GenerarCatalogo(int opcion)
        {
            listaDePropiedades = new List<Propiedad>();
            listaDePropiedades = bllPropiedad.LeerPropiedades(opcion);
            if (viviendasFiltradas != null && viviendasFiltradas.Count > 0)
            {
                listaDePropiedades = viviendasFiltradas;
            }
            flowLayoutPanelCatalogo.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelCatalogo.WrapContents = true;
            flowLayoutPanelCatalogo.Controls.Clear();
            flowLayoutPanelCatalogo.Padding = new Padding(50,0,0,0);
            if (listaDePropiedades != null && listaDePropiedades.Count > 0)
            {
                foreach (Propiedad p in listaDePropiedades)
                {
                    GroupBox gpadre = new GroupBox();
                    gpadre.Width = flowLayoutPanelCatalogo.Width - 130;
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
                            labelNombre.ForeColor = Color.White;

                            Label labelValor = new Label();
                            labelValor.Text = propiedad.GetValue(p)?.ToString();
                            labelValor.Location = new Point(130, labelPosY);
                            labelValor.AutoSize = true;
                            labelValor.ForeColor = Color.White;

                            gpDescripcion.Controls.Add(labelNombre);
                            gpDescripcion.Controls.Add(labelValor);

                            labelPosY += 30;
                        }
                    }

                    gpadre.Controls.Add(flpImagenes);
                    gpadre.Controls.Add(gpDescripcion);
                    GenerarBotones(opcion, labelPosY, p, gpDescripcion);
                    flowLayoutPanelCatalogo.Controls.Add(gpadre);
                }
            }
            else
            {
                Label Aviso = new Label();
                Aviso.Height = flowLayoutPanelCatalogo.Height -40;
                Aviso.Width = flowLayoutPanelCatalogo.Width -40;
                
                Aviso.ForeColor = Color.White;
                Aviso.Text = "No hay Casas Disponibles Por el Momentos";
                Aviso.TextAlign = ContentAlignment.MiddleCenter;
                Aviso.Dock = DockStyle.None;
                flowLayoutPanelCatalogo.Controls.Add(Aviso);
                Aviso.Anchor = AnchorStyles.None;
                
            }
        }



        public void IdentificarCatalogo()
        {
            try
            {
                int opcion = 0;
                if (Sesion.ObtenerSesion().ObtenerUsuario().Sector == "Dueño")
                {
                    GenerarCatalogo(opcion);
                }
                else if(Sesion.ObtenerSesion().ObtenerUsuario().Sector == "Cliente")
                {
                    opcion = 1;
                    GenerarCatalogo(opcion);
                }
                else if(Sesion.ObtenerSesion().ObtenerUsuario().Sector == "Closer")
                {
                    opcion = 2;
                    GenerarCatalogo(opcion);
                }
                else if(Sesion.ObtenerSesion().ObtenerUsuario().Sector == "Inmoviliaria")
                {
                    opcion = 3;
                    GenerarCatalogo(opcion);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GenerarBotones(int opcion,int labelPosY ,Propiedad p,Panel GroupBoxDescripcion)
        {
            if (opcion == 0)
            {
                Button btnModificar = new Button();
                btnModificar.Text = "Modificar Datos";
                btnModificar.Tag = "FMDModificarDatos";
                btnModificar.Width = 120;
                btnModificar.Location = new Point(10, labelPosY);
                btnModificar.Click += (s, e) => AbrirFormularioModificar(p);
                btnModificar.ForeColor = Color.White;
                labelPosY += 30;

                Button btnVerPostulados = new Button();
                btnVerPostulados.Text = "Ver Postulados";
                btnVerPostulados.Tag = "FMDVerPostulados";
                btnVerPostulados.Width = 120;
                btnVerPostulados.Location = new Point(10, labelPosY);
                btnVerPostulados.ForeColor = Color.White;
                labelPosY += 30;
                btnVerPostulados.Click += (s, e) => AbrirFormularioClosersPostulados(p);

                Button btnBaja = new Button();
                btnBaja.Text = "Dar de Baja";
                btnBaja.Tag = "FMDarDeBaja";
                btnBaja.Width = 120;
                btnBaja.Location = new Point(10, labelPosY);
                btnBaja.ForeColor = Color.White;
                labelPosY += 30;
                btnBaja.Click += (s, e) => DarViviendaDeBaja(p);

                GroupBoxDescripcion.Controls.Add(btnModificar);
                GroupBoxDescripcion.Controls.Add(btnVerPostulados);
                GroupBoxDescripcion.Controls.Add(btnBaja);
            }
            else if (opcion == 1)
            {
                Button btnSolicitarReunion = new Button();
                btnSolicitarReunion.Text = "Solicitar Reunion";
                btnSolicitarReunion.Tag = "FMCliSolicitarReunion";
                btnAgregarPropiedad.BackColor = Color.White;
                btnSolicitarReunion.Width = 120;
                btnSolicitarReunion.Location = new Point(10, labelPosY);
                btnSolicitarReunion.Click += (s, e) => AbrirFormularioSolicitarReunion(p);
                btnSolicitarReunion.ForeColor = Color.White;
                GroupBoxDescripcion.Controls.Add(btnSolicitarReunion);
            }
            else if (opcion == 2)
            {
                Button btnPostularse = new Button();
                btnPostularse.Text = "Postularse";
                btnPostularse.Tag = "FMCPostularse";
                btnPostularse.Width = 120;
                btnPostularse.Location = new Point(10, labelPosY);
                btnPostularse.Click += (s, e) => Postularse(p);
                btnPostularse.ForeColor = Color.White;
                GroupBoxDescripcion.Controls.Add(btnPostularse);
            }
            else if (opcion == 3)
            {
                Button btnBaja = new Button();
                btnBaja.Text = "Dar de Baja";
                btnBaja.Tag = "FMDarDeBaja";
                btnBaja.ForeColor = Color.White;
                btnBaja.Width = 120;
                btnBaja.Location = new Point(10, labelPosY);
                btnBaja.ForeColor = Color.White;
                btnBaja.Click += (s, e) => DarViviendaDeBaja(p);
                GroupBoxDescripcion.Controls.Add(btnBaja);
            }
        }

        #endregion


        #region LOGOUT Y CIERRE DE APP
        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(IsLogOut == false)
            {
                Application.Exit();
            }
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
                
                MessageBox.Show("Sesión Cerrada Exitosamente");
                fl.Show();
                fl.Limpiar();
                IsLogOut = true;
                this.Close();
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
        private void tableLayoutPanelBarraMenuDinamica_Paint(object sender, PaintEventArgs e){ }

        #region FUNCIONALIDADES DUEÑO
        private void btnAgregarPropiedad_Click(object sender, EventArgs e)
        {
            RegistrarPropiedades registrarPropiedades = new RegistrarPropiedades(this);
            registrarPropiedades.Show();
        }
        #endregion
        
        #region FORMS
        public void AbrirFormularioModificar(Propiedad propiedad)
        {
            RegistrarPropiedades registrarPropiedades = new RegistrarPropiedades(propiedad,this);
            registrarPropiedades.Show();
        }

        public void AbrirFormularioClosersPostulados(Propiedad p)
        {
            try
            {
                if(p.Aqluilada != true)
                {
                    ClosersPostulados closersPostulados = new ClosersPostulados(p);
                    closersPostulados.Show();
                }
                else
                {
                    MessageBox.Show("Su casa esta en alquiler ahora mismo");
                }
            }
            catch(Exception ex){}
        }

        public void AbrirFormularioSolicitarReunion(Propiedad propiedad)
        {
            try
            {
                SolicitarReunion solicitarReunion = new SolicitarReunion(propiedad);
                solicitarReunion.Show();
            }
            catch(Exception ex){  }
        }

        private void btnVerCasasGestionadasCloser_Click(object sender, EventArgs e)
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Closer closer = bllCloser.LeerCloser(usuario.ID,1);
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

        private void btnPerformanceEmpresa_Click(object sender, EventArgs e)
        {
            PerformanceInmoviliaria performanceInmoviliaria = new PerformanceInmoviliaria();
            performanceInmoviliaria.Show();
        }

        private void btnCuentaInmoviliaria_Click(object sender, EventArgs e)
        {
            PerfilInmoviliaria perfilInmoviliaria = new PerfilInmoviliaria();
            perfilInmoviliaria.Show();
        }

        private void buttonMenuDeGestion_Click(object sender, EventArgs e)
        {
            FMdi fMdi = new FMdi(fl,Sesion.ObtenerSesion().ObtenerUsuario().NombreDeUsuario);
            fMdi.Show();
        }

        private void comboBoxIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sesion.ObtenerSesion().AgregarObservador(this);
            Sesion.ObtenerSesion().ActualizarDiccionario(Convert.ToInt32(tablaIdioma.Rows[comboBoxIdiomas.SelectedIndex][0]));
        }


        private void btnGestorDeReunionesCliente_Click(object sender, EventArgs e)
        {
            VerReunionesCliente verReunionesCliente = new VerReunionesCliente();
            verReunionesCliente.Show();
        }

        private void flowLayoutPanelCatalogo_Paint(object sender, PaintEventArgs e){}

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if(listaDePropiedades != null && listaDePropiedades.Count > 0)
            {
                List<Propiedad> viviendasAFiltrar = listaDePropiedades;
                viviendasFiltradas = new List<Propiedad>();
                foreach(Control c in flowLayoutPanelFiltro.Controls)
                {
                    if(c is CheckBox)
                    {
                        CheckBox cb = (CheckBox)c;
                        if (cb.Checked)
                        {
                            string nombre = c.Tag.ToString().Substring("Formchb".Length);
                            foreach (Propiedad p in viviendasAFiltrar)
                            {
                                foreach (Etiqueta etiquetasP in p.Etiquetas)
                                {
                                    if (etiquetasP.Nombre == nombre)
                                    {
                                        viviendasFiltradas.Add(p);
                                        //cb.Checked = false;
                                    }
                                }
                            }
                        }
                    }
                    
                }
                IdentificarCatalogo();  
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if(viviendasFiltradas != null && viviendasFiltradas.Count > 0)
            {
                viviendasFiltradas = null;
                IdentificarCatalogo();
            }
        }
    }
}
