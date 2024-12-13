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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{
    public partial class PerfilDueño : FIdiomaActualizable,IObservador
    {
        Dueño dueñoActivo;
        public PerfilDueño()
        {
            InitializeComponent();
            bitacora = new Bitacora_();
            bllBitaacora = new BitacoraBLL();
            bllUsuario = new BLLUsuario();
            bllDueño = new BLLDueño();
            bllIdiomas = new BLLIdiomas();
            usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            dueñoActivo = bllDueño.LeerDueño(usuario.ID);
            MostrarDatos(usuario, dueñoActivo);
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
            Notificar(this);
        }
        Bitacora_ bitacora;
        BitacoraBLL bllBitaacora;
        BLLUsuario bllUsuario;
        BLLDueño bllDueño;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;
        Usuario usuario;
        System.Drawing.Image imagen;


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

        public void MostrarDatos(Usuario usuario, Dueño dueño)
        {
            tbNombreDeUsuario.Text = usuario.NombreDeUsuario;
            tbMail.Text = usuario.Mail;
            tbNombre.Text = dueño.Nombre;
            tbApellido.Text = dueño.Apellido;
            tbResidencia.Text = dueño.Residencia;
            tableLayoutPanelFotoDePerfil.Controls.Clear();
            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            if (usuario.Foto != null)
            {
                using (MemoryStream ms = new MemoryStream(usuario.Foto))
                {
                    pictureBox.Image = System.Drawing.Image.FromStream(ms);
                }   
            }
            else
            {
                pictureBox.Image = Resources.UsuarioGenerico;
            } 
            tableLayoutPanelFotoDePerfil.Controls.Add(pictureBox);
        }
        public void ActualizarDatos(Usuario usuarioModificar)
        {
            try
            {
                usuarioModificar.Clave = Seguridad.Encriptar(tbContraseña.Text);
                usuarioModificar.Mail = tbMail.Text;
                usuarioModificar.DV = bllUsuario.CalcularDigitoVerificadorHorizontal(usuarioModificar);
                dueñoActivo.Nombre = tbNombre.Text;
                dueñoActivo.Apellido = tbApellido.Text;
                dueñoActivo.Residencia = tbResidencia.Text;
                if (imagen != null)
                {
                    usuarioModificar.Foto = ConvertirImagenABytes(imagen);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public byte[] ConvertirImagenABytes(System.Drawing.Image Imagen)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Imagen.Save(ms, Imagen.RawFormat);
                return ms.ToArray();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ManejoErrores.ValidarClave(tbContraseña.Text) || !ManejoErrores.ValidarMail(tbMail.Text) || !ManejoErrores.ValidarDireccion(tbResidencia.Text))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, tbNombreDeUsuario.Text, "Los datos ingresados no tienen el formato correcto.");
                    bllBitaacora.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                    return;
                }
                Usuario usuarioModificar = Sesion.ObtenerSesion().ObtenerUsuario();
                ActualizarDatos(usuarioModificar);
                if (bllUsuario.ActualizarUsuario(usuarioModificar, 1) && bllDueño.ModificarDueño(dueñoActivo, usuarioModificar.ID))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.INFO, tbNombreDeUsuario.Text, "El usuario se modificó con exito.");
                    bllBitaacora.Add(bitacora);
                    MostrarDatos(usuarioModificar, dueñoActivo);
                    MessageBox.Show(bitacora.Mensaje);
                }
                else
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, tbNombreDeUsuario.Text, "El usuario que intenta modificar no existe");
                    bllBitaacora.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = false;
                    openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg,*.jpeg)|*.png;*.jpg;*.jpeg";
                    openFileDialog.Title = "Seleccione una imagen";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string file in openFileDialog.FileNames)
                        {
                            System.Drawing.Image img = System.Drawing.Image.FromFile(file);
                            imagen = img;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PerfilDueño_Load(object sender, EventArgs e)
        {

        }

        private void btnBajaCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if(dueñoActivo.listaDeViviendas.Count > 0)
                {
                    throw new Exception("No se puede dar de baja la cuenta teniendo casas publicadas");
                }
                if (bllUsuario.BajaUsuario(usuario))
                {
                    MessageBox.Show("Cuenta dada de baja exitosamente!!");
                    System.Windows.Forms.Application.Restart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
