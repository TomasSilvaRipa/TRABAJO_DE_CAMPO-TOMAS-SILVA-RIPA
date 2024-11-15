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
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
            bllCliente = new BLLCliente();
            bllCloser = new BLLCloser();
            bllDueño = new BLLDueño();
            bllInmoviliaria = new BLLInmoviliaria();
            bllusuario.ValidadDigito(bllusuario.LeerUsuarios());
            bllusuario.ValidarDigitoVertical();
            LlenarGrilla();
            Sesion.ObtenerSesion().AgregarObservador(this);
            BuscarControles(this.Controls);
            ComprobarPermisos(Sesion.ObtenerSesion().listaDePermisos);
            actualizarIdioma();
            comboBoxSector.DataSource = Enum.GetValues(typeof(Sector));
        }
        BitacoraBLL bitacorabll;
        BLLUsuario bllusuario;
        BLLCliente bllCliente;
        BLLCloser bllCloser;
        BLLDueño bllDueño;
        BLLInmoviliaria bllInmoviliaria;

        #region FUNCIONES APARTE

        public enum Sector
        {
            Cliente = 0,
            Closer = 2,
            Dueño = 3,
            Inmoviliaria = 4
        }


        Usuario ObtenerUsuarioSeleccionado()
        {
            int indice = dgvUsuarios.SelectedRows[0].Index;

            if (indice <= listaUsuarios.Count())
            {
                return listaUsuarios[indice];
            }
            return null;
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

        void LlenarGrilla()
        {
            listaUsuarios = bllusuario.LeerUsuarios();
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = listaUsuarios;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.Columns["ID"].Visible = false;
            dgvUsuarios.Columns["Clave"].Visible = false;
            dgvUsuarios.Columns["DV"].Visible = false;
            dgvUsuarios.Columns["Foto"].Visible = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreUsuario.Text = ObtenerUsuarioSeleccionado().NombreDeUsuario.Trim();
            comboBoxSector.Text = ObtenerUsuarioSeleccionado().Sector.Trim();
            txtMail.Text = ObtenerUsuarioSeleccionado().Mail.Trim();
        }

        #endregion

        #region FUNCIONES
        private void btnAlta_Click(object sender, EventArgs e)
        {
            Bitacora_ bitacora;
            try
            {
                if (!ManejoErrores.ValidarNombre(txtNombreUsuario.Text) || !ManejoErrores.ValidarClave(txtClave.Text) || !ManejoErrores.ValidarNombre(comboBoxSector.Text) || !ManejoErrores.ValidarMail(txtMail.Text) || !ManejoErrores.ValidarNombre(tbNombre.Text))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, Usuario, "Los datos ingresados no tienen el formato correcto.");
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                    return;
                }
                Usuario nuevoUsuario = new Usuario(txtNombreUsuario.Text, comboBoxSector.Text,txtMail.Text);
                nuevoUsuario.Clave = Seguridad.Encriptar(txtClave.Text);
                nuevoUsuario.DV = bllusuario.CalcularDigitoVerificadorHorizontal(nuevoUsuario);
                if (comboBoxSector.Text == "Cliente")
                {
                    Cliente clienteCreate = new Cliente(nuevoUsuario, tbNombre.Text, tbApellido.Text, false, dateTimePickerFN.Value);
                    if (ManejoErrores.ValidarNombre(tbApellido.Text) && bllusuario.AltaUsuario(clienteCreate, txtClave.Text))
                    {
                        MessageBox.Show("Cliente: " + nuevoUsuario.NombreDeUsuario + "creado correctamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha occurido un error");
                    }
                }
                else if (comboBoxSector.Text == "Dueño")
                {
                    Dueño dueño = new Dueño(nuevoUsuario, tbNombre.Text, tbApellido.Text, tbResicencia.Text);
                    if (ManejoErrores.ValidarNombre(tbApellido.Text) && ManejoErrores.ValidarClave(tbResicencia.Text))
                    {
                        if (bllusuario.AltaUsuario(dueño, txtClave.Text))
                        {
                            MessageBox.Show("Dueño: " + nuevoUsuario.NombreDeUsuario + " creado correctamente");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ha occurido un error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Datos en campo residencia invalidos");
                    }

                }
                else if (comboBoxSector.Text == "Closer")
                {
                    Closer closer = new Closer(nuevoUsuario, tbNombre.Text, tbApellido.Text, "Beginner", 0);
                    if (ManejoErrores.ValidarNombre(tbApellido.Text) && bllusuario.AltaUsuario(closer, txtClave.Text))
                    {
                        MessageBox.Show("Closer: " + nuevoUsuario.NombreDeUsuario + "creado correctamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha occurido un error");
                    }
                }
                else if(comboBoxSector.Text == "Inmoviliaria")
                {
                    Inmoviliaria inmoviliaria = new Inmoviliaria(nuevoUsuario,tbNombre.Text);
                    if (!bllusuario.ComprobarExistenciaCuentaEmpresa() && bllusuario.AltaUsuario(inmoviliaria, txtClave.Text))
                    {
                        MessageBox.Show("Usuario de Inmoviliaria: " + nuevoUsuario.NombreDeUsuario + "creada correctamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha occurido un error");
                    }
                }
                else
                {
                    throw new Exception("Elija un tipo de cuenta para registrase");
                }
            
                //if (bllusuario.AltaUsuario(nuevoUsuario, txtClave.Text))
                //{
                //    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.INFO,Usuario,"El usuario " + nuevoUsuario.NombreDeUsuario + " se creo correctamente.");
                //    bitacorabll.Add(bitacora);
                //    MessageBox.Show(bitacora.Mensaje);
                //}
                //else
                //{
                //    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION,Usuario, "Un usuario con el nombre " + nuevoUsuario.NombreDeUsuario + "o con el Mail: " + txtMail.Text + "ya existe!");
                //    bitacorabll.Add(bitacora);
                //    MessageBox.Show(bitacora.Mensaje);
                //    return;
                //}
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
                if (!ManejoErrores.ValidarClave(txtClave.Text) || !ManejoErrores.ValidarMail(txtMail.Text) || !ManejoErrores.ValidarNombre(tbNombre.Text))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION,Usuario, "Los datos ingresados no tienen el formato correcto." );
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                    return;
                }
                Usuario usuarioModificar = ObtenerUsuarioSeleccionado();
                //usuarioModificar.Sector = comboBoxSector.Text;
                usuarioModificar.Clave = Seguridad.Encriptar(txtClave.Text);
                usuarioModificar.Mail = txtMail.Text;
                usuarioModificar.DV = bllusuario.CalcularDigitoVerificadorHorizontal(usuarioModificar);
                usuarioModificar.Clave = txtClave.Text;
                if (usuarioModificar.Sector == "Cliente")
                {
                    Cliente clienteCreate = new Cliente(usuarioModificar, tbNombre.Text, tbApellido.Text, dateTimePickerFN.Value);
                    if (ManejoErrores.ValidarNombre(tbApellido.Text) && bllusuario.ActualizarUsuario(clienteCreate, 0) && bllCliente.ModificarCliente(clienteCreate,usuarioModificar.ID))
                    {
                        MessageBox.Show("Cliente: " + usuarioModificar.NombreDeUsuario + "creado correctamente");
                      
                    }
                    else
                    {
                        MessageBox.Show("Ha occurido un error");
                    }
                }
                else if (usuarioModificar.Sector == "Dueño")
                {
                    Dueño dueño = new Dueño(usuarioModificar, tbNombre.Text, tbApellido.Text, tbResicencia.Text);
                    if (ManejoErrores.ValidarNombre(tbApellido.Text) && ManejoErrores.ValidarClave(tbResicencia.Text))
                    {
                        if (bllusuario.ActualizarUsuario(dueño, 0) && bllDueño.ModificarDueño(dueño,usuarioModificar.ID))
                        {
                            MessageBox.Show("Dueño: " + usuarioModificar.NombreDeUsuario + " creado correctamente");
                            
                        }
                        else
                        {
                            MessageBox.Show("Ha occurido un error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Datos en campo residencia invalidos");
                    }

                }
                else if (usuarioModificar.Sector == "Closer")
                {
                    Closer closer = new Closer(usuarioModificar, tbNombre.Text, tbApellido.Text);
                    if (ManejoErrores.ValidarNombre(tbApellido.Text) && bllusuario.ActualizarUsuario(closer, 0) && bllCloser.ModificarCloser(closer,usuarioModificar.ID))
                    {
                        MessageBox.Show("Closer: " + usuarioModificar.NombreDeUsuario + "creado correctamente");
                       
                    }
                    else
                    {
                        MessageBox.Show("Ha occurido un error");
                    }
                }
                else if (usuarioModificar.Sector == "Inmoviliaria")
                {
                    Inmoviliaria inmoviliaria = new Inmoviliaria(usuarioModificar, tbNombre.Text);
                    if (bllusuario.ActualizarUsuario(inmoviliaria, 0) && bllInmoviliaria.ModificarCuentaInmoviliario(inmoviliaria,usuarioModificar.ID))
                    {
                        MessageBox.Show("Usuario de Inmoviliaria: " + usuarioModificar.NombreDeUsuario + "creada correctamente");
                        
                    }
                    else
                    {
                        MessageBox.Show("Ha occurido un error");
                    }
                }
                else
                {
                    throw new Exception("Elija un tipo de cuenta para registrase");
                }
                //if (bllusuario.ActualizarUsuario(usuarioModificar,0))
                //{

                //    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.INFO,  Usuario, "El usuario se modificó con exito.");
                //    bitacorabll.Add(bitacora);
                //    MessageBox.Show(bitacora.Mensaje);
                //}
                //else
                //{
                //    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION,Usuario, "El usuario que intenta modificar no existe" );
                //    bitacorabll.Add(bitacora);
                //    MessageBox.Show(bitacora.Mensaje);
                //}
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

        

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        public void Notificar(object Sender)
        {
          actualizarIdioma();
            
        }



        
    }
}
