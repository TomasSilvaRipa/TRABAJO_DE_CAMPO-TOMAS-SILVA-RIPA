using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace GUI
{
    public partial class AdminUsuarios : FIdiomaActualizable, IObservador
    {
        List<Usuario> listaUsuarios = new List<Usuario>();
        string Usuario;
        public AdminUsuarios(string nombreUsuario)
        {
            InitializeComponent();
            bitacorabll = new BitacoraBLL();
            Usuario = nombreUsuario;
            bllusuario = new BLLUsuario();
            bllusuario.ValidadDigito(bllusuario.LeerUsuarios());
            bllusuario.ValidarDigitoVertical();
            LlenarGrilla();
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarIdioma();
        }
        BitacoraBLL bitacorabll;
        BLLUsuario bllusuario;

        #region FUNCIONES APARTE



        Usuario ObtenerUsuarioSeleccionado()
        {
            int indice = dgvUsuarios.SelectedRows[0].Index;

            if (indice <= listaUsuarios.Count())
            {
                return listaUsuarios[indice];
            }
            return null;
        }

        void LlenarGrilla()
        {
            listaUsuarios = bllusuario.LeerUsuarios();
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = listaUsuarios;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.Columns["Clave"].Visible = false;
            dgvUsuarios.Columns["DV"].Visible = false;
        }
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = ObtenerUsuarioSeleccionado().NombreDeUsuario.Trim();
            txtSector.Text = ObtenerUsuarioSeleccionado().Sector.Trim();
            txtMail.Text = ObtenerUsuarioSeleccionado().Mail.Trim();
        }

        #endregion

        #region FUNCIONES
        private void btnAlta_Click(object sender, EventArgs e)
        {
            Bitacora_ bitacora;
            try
            {
                if (!ManejoErrores.ValidarNombre(txtNombre.Text) || !ManejoErrores.ValidarClave(txtClave.Text) || !ManejoErrores.ValidarNombre(txtSector.Text) || !ManejoErrores.ValidarMail(txtMail.Text))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, Usuario, "Los datos ingresados no tienen el formato correcto.");
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                    return;
                }
                Usuario nuevoUsuario = new Usuario(txtNombre.Text, txtSector.Text,txtMail.Text);
                nuevoUsuario.Clave = Seguridad.Encriptar(txtClave.Text);
                nuevoUsuario.DV = bllusuario.CalcularDigitoVerificadorHorizontal(nuevoUsuario);
                if (bllusuario.AltaUsuario(nuevoUsuario, txtClave.Text))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.INFO,Usuario,"El usuario " + nuevoUsuario.NombreDeUsuario + " se creo correctamente.");
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                }
                else
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION,Usuario, "Un usuario con el nombre " + nuevoUsuario.NombreDeUsuario + "o con el Mail: " + txtMail.Text + "ya existe!");
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                    return;
                }
                LlenarGrilla();
            }
            catch(Exception ex)
            {
                bitacora = new Bitacora_(Bitacora_.BitacoraTipo.ERROR,Usuario, "No Se Pudo Dar De Alta al Usuario:" + ex.Message);
                bitacorabll.Add(bitacora);
                throw ex;
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            Bitacora_ bitacora;
            try
            {
                if (bllusuario.BajaUsuario(ObtenerUsuarioSeleccionado().NombreDeUsuario))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.INFO, Usuario,"El usuario " + ObtenerUsuarioSeleccionado().NombreDeUsuario.Trim() + " fue eliminado");
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                }
                else
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, Usuario, "El usuario que intenta eliminar no existe");
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                }

                LlenarGrilla();
            }
            catch(Exception ex)
            {
                bitacora = new Bitacora_(Bitacora_.BitacoraTipo.ERROR, Usuario,"Ha sucedido un Error:" + ex.Message );
                bitacorabll.Add(bitacora);
                throw ex;
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            Bitacora_ bitacora;
            try
            {
                if ( !ManejoErrores.ValidarNombre(txtSector.Text) || !ManejoErrores.ValidarClave(txtClave.Text) || !ManejoErrores.ValidarMail(txtMail.Text))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION,Usuario, "Los datos ingresados no tienen el formato correcto." );
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                    return;
                }
                Usuario usuarioModificar = ObtenerUsuarioSeleccionado();
                usuarioModificar.Sector = txtSector.Text;
                usuarioModificar.Clave = Seguridad.Encriptar(txtClave.Text);
                usuarioModificar.Mail = txtMail.Text;
                usuarioModificar.DV = bllusuario.CalcularDigitoVerificadorHorizontal(usuarioModificar);
                usuarioModificar.Clave = txtClave.Text;
                if (bllusuario.ActualizarUsuario(usuarioModificar,0))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.INFO,  Usuario, "El usuario se modificó con exito.");
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                }
                else
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION,Usuario, "El usuario que intenta modificar no existe" );
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                }
                LlenarGrilla();
            }
            catch(Exception ex)
            {
                bitacora = new Bitacora_(Bitacora_.BitacoraTipo.ERROR, Usuario,"Ha sucedido un error:" + ex.Message );
                bitacorabll.Add(bitacora);
                throw ex;
            }
        }
        #endregion

        private void AdminUsuarios_Load(object sender, EventArgs e)
        {
            btnAlta.Enabled = false;
            btnBaja.Enabled = false;
            btnMod.Enabled = false;
            ComprobarPermisos(Sesion.ObtenerSesion().listaDePermisos);
        }

        public void ComprobarPermisos(List<Permiso> lista)
        {
            foreach (Permiso p in lista)
            {
                foreach (Control c in this.Controls)
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

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Notificar(object Sender)
        {
         actualizarIdioma();
            
        }



        
    }
}
