using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios;
using BLL;
using System.Web;
using System.Collections;

namespace GUI
{
    public partial class FMdi : FIdiomaActualizable, IObservador
    {
        AdminUsuarios adminUsuarios;
        FTraducciones ftraducciones;
        FLogin flogin;
        string nombreDeUsuario;
        List<Permiso> listaP;
        DataTable tablaIdioma;

        public FMdi(FLogin fl,string NombreDeSesion)
        {
            InitializeComponent();
            flogin = fl;
            bitacorabll = new BitacoraBLL();
            nombreDeUsuario = NombreDeSesion;
            adminUsuarios = new AdminUsuarios(nombreDeUsuario);
            ftraducciones = new FTraducciones();
            bitacora = new Bitacora_();
            listaP = Sesion.ObtenerSesion().listaDePermisos;
            labelGestionDePermisos.Enabled = false;
            labelGestionDePermisos.Visible = false;
            labelGU.Enabled = false;
            labelGU.Visible = false;
            labelBitacora.Enabled = false;
            labelBitacora.Visible = false;
            labelGestorDeCambios.Enabled = false;
            labelGestorDeCambios.Visible = false;
            labelTraducciones.Visible = false;
            labelTraducciones.Enabled = false;
            BuscarControles(this.Controls);
            ComprobarPermisos(Sesion.ObtenerSesion().listaDePermisos);

            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
            LlenarCbxIdiomas();

        }
        Bitacora_ bitacora;
        BitacoraBLL bitacorabll;

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void actualizarTablaIdiomas()
        {
            Sesion.ObtenerSesion().ActualizarIdiomas();
            tablaIdioma = Sesion.ObtenerSesion().tablaIdioma;

        }

        private void LlenarCbxIdiomas()
        {
            cbxIdiomas.Items.Clear();

            foreach (DataRow row in Sesion.ObtenerSesion().tablaIdioma.Rows)
            {
                cbxIdiomas.Items.Add(row[1]);
            }

            cbxIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;

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

        public void ComprobarPermisos(List<Permiso> lista)
        {
            foreach(Permiso p in lista)
            {
                foreach(Control c in ListaControles)
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

        private void FMdi_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = Sesion.ObtenerSesion().ObtenerUsuario().NombreDeUsuario;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            bitacora.Fecha = DateTime.Now.Date;
            try
            {
                Sesion.Logout();
                bitacora.Tipo = Bitacora_.BitacoraTipo.INFO;
                bitacora.Usuario = nombreDeUsuario;
                bitacora.Mensaje = "Sesion Cerada Exitosamente";
                bitacorabll.Add(bitacora);
                this.Hide();
                MessageBox.Show("Sesión Cerrada Exitosamente");
                flogin.Show();
                flogin.Limpiar();
            }
            catch (Exception ex) {
                bitacora.Tipo = Bitacora_.BitacoraTipo.ERROR;
                bitacora.Usuario = nombreDeUsuario;
                bitacora.Mensaje = "No se Pudo Cerrar Sesion:" + ex.Message;
                bitacorabll.Add(bitacora);
                throw ex;
            }
        }
        private void FMdi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void FMdi_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void adminUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitacora b = new Bitacora();
            b.Show();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Permisos p = new Permisos();
            p.Show();
        }

        private void GestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (adminUsuarios.IsDisposed)
            {
                adminUsuarios = new AdminUsuarios(nombreDeUsuario);
            }
            adminUsuarios.MdiParent = this;
            adminUsuarios.Show();
        }

        private void labelGU_Click(object sender, EventArgs e)
        {
            if (adminUsuarios.IsDisposed)
            {
                adminUsuarios = new AdminUsuarios(nombreDeUsuario);
            }
            adminUsuarios.MdiParent = this;
            adminUsuarios.Show();
        }

        private void labelBitacora_Click(object sender, EventArgs e)
        {
            Bitacora b = new Bitacora();
            b.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Permisos p = new Permisos();
            p.Show();
        }

        public void Notificar(object Sender)
        {

            if(Sender is FTraducciones)
            {
                actualizarTablaIdiomas();
                LlenarCbxIdiomas();
            }
            else
            {


                actualizarIdioma();
            }




        }


        private void cbxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sesion.ObtenerSesion().ActualizarDiccionario(Convert.ToInt32(tablaIdioma.Rows[cbxIdiomas.SelectedIndex][0]));
            Sesion.ObtenerSesion().ActualizarIdiomas();
        }

        private void labelTraducciones_Click(object sender, EventArgs e)
        {
            if(ftraducciones.IsDisposed)
            {
                ftraducciones = new FTraducciones();
            }
            ftraducciones.AgregarObservador(this);
            ftraducciones.MdiParent = this;
            ftraducciones.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            GestorDeCambios gestorDeCambios = new GestorDeCambios();
            gestorDeCambios.Show();
        }
    }
}
