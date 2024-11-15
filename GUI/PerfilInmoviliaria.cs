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
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{
    public partial class PerfilInmoviliaria : FIdiomaActualizable,IObservador
    {
        public PerfilInmoviliaria()
        {
            InitializeComponent();
            bllInmoviliaria = new BLLInmoviliaria();
            bllUsuario = new BLLUsuario();
            bllBitacora = new BitacoraBLL();
            bllIdiomas = new BLLIdiomas();
            Notificar(this);
            usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            inmoviliariaActivo = bllInmoviliaria.LeerCuentaInmoviliaria(usuario);
            MostrarDatos(usuario,inmoviliariaActivo);
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
        }
       
        Usuario usuario;
        Inmoviliaria inmoviliariaActivo;
        BLLInmoviliaria bllInmoviliaria;
        BLLUsuario bllUsuario;
        Bitacora_ bitacora;
        BitacoraBLL bllBitacora;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;
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

        public void MostrarDatos(Usuario usuario, Inmoviliaria inmoviliaria)
        {
            tbNombreDeUsuario.Text = usuario.NombreDeUsuario;
            tbMail.Text = usuario.Mail;
            tbNombre.Text = inmoviliaria.Nombre; 
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
        public byte[] ConvertirImagenABytes(System.Drawing.Image Imagen)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Imagen.Save(ms, Imagen.RawFormat);
                return ms.ToArray();
            }
        }

        public void ActualizarDatos(Usuario usuarioModificar)
        {
            try
            {
                usuarioModificar.Clave = Seguridad.Encriptar(tbContraseña.Text);
                usuarioModificar.Mail = tbMail.Text;
                usuarioModificar.DV = bllUsuario.CalcularDigitoVerificadorHorizontal(usuarioModificar);
                inmoviliariaActivo.Nombre = tbNombre.Text;
                if (imagen != null)
                {
                    usuarioModificar.Foto = ConvertirImagenABytes(imagen);
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ManejoErrores.ValidarClave(tbContraseña.Text) || !ManejoErrores.ValidarMail(tbMail.Text))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, tbNombreDeUsuario.Text, "Los datos ingresados no tienen el formato correcto.");
                    bllBitacora.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                    return;
                }
                Usuario usuarioModificar = Sesion.ObtenerSesion().ObtenerUsuario();
                ActualizarDatos(usuarioModificar);
                if (bllUsuario.ActualizarUsuario(usuarioModificar, 1) && bllInmoviliaria.ModificarCuentaInmoviliario(inmoviliariaActivo, usuarioModificar.ID))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.INFO, tbNombreDeUsuario.Text, "El usuario se modificó con exito.");
                    bllBitacora.Add(bitacora);
                    MostrarDatos(usuarioModificar,(inmoviliariaActivo));
                    MessageBox.Show(bitacora.Mensaje);
                }
                else
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, tbNombreDeUsuario.Text, "El usuario que intenta modificar no existe");
                    bllBitacora.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PerfilInmoviliaria_Load(object sender, EventArgs e)
        {

        }
    }
}
