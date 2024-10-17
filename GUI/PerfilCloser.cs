using BE;
using BLL;
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

namespace GUI
{
    public partial class PerfilCloser : FIdiomaActualizable,IObservador
    {
        Closer closerActivo;
        public PerfilCloser()
        {
            
            InitializeComponent();
            bitacora = new Bitacora_();
            bllBitaacora = new BitacoraBLL();
            bllCloser = new BLLCloser();
            bllUsuario = new BLLUsuario();
            bllIdiomas = new BLLIdiomas();
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            closerActivo = bllCloser.LeerCloser(usuario.ID);
            MostrarDatos(usuario, closerActivo);
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
        }
        Bitacora_ bitacora;
        BitacoraBLL bllBitaacora;
        BLLUsuario bllUsuario;
        BLLCloser bllCloser;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;
        Image imagen;


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

        public void MostrarDatos(Usuario usuario, Closer closer)
        {
            tbNombreDeUsuario.Text = usuario.NombreDeUsuario;
            tbMail.Text = usuario.Mail;
            tbNombre.Text = closer.Nombre;
            tbApellido.Text = closer.Apellido;
            labelClasificacion.Text = closer.Clasificacion;
            labelTratosCerrados.Text = closer.TratosCerrados.ToString();
            if (usuario.Foto != null)
            {
                tableLayoutPanelFotoDePerfil.Controls.Clear();
                PictureBox pictureBox = new PictureBox();
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                using (MemoryStream ms = new MemoryStream(usuario.Foto))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
                tableLayoutPanelFotoDePerfil.Controls.Add(pictureBox);
            }
        }

        public void ActualizarDatos(Usuario usuarioModificar)
        {
            try
            {
                usuarioModificar.Clave = Seguridad.Encriptar(tbContraseña.Text);
                usuarioModificar.Mail = tbMail.Text;
                usuarioModificar.DV = bllUsuario.CalcularDigitoVerificadorHorizontal(usuarioModificar);
                closerActivo.Nombre = tbNombre.Text;
                closerActivo.Apellido = tbApellido.Text;
                closerActivo.Clasificacion = labelTratosCerrados.Text;
                closerActivo.TratosCerrados = Convert.ToInt32(labelTratosCerrados.Text);
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

        public byte[] ConvertirImagenABytes(Image Imagen)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Imagen.Save(ms, Imagen.RawFormat);
                return ms.ToArray();
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
                    bllBitaacora.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                    return;
                }
                Usuario usuarioModificar = Sesion.ObtenerSesion().ObtenerUsuario();
                usuarioModificar.Clave = Seguridad.Encriptar(tbContraseña.Text);
                usuarioModificar.Mail = tbMail.Text;
                usuarioModificar.DV = bllUsuario.CalcularDigitoVerificadorHorizontal(usuarioModificar);
                
                ActualizarDatos(usuarioModificar);
                if (bllUsuario.ActualizarUsuario(usuarioModificar, 1) && bllCloser.ModificarCloser(closerActivo, usuarioModificar.ID))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.INFO, tbNombreDeUsuario.Text, "El usuario se modificó con exito.");
                    bllBitaacora.Add(bitacora);
                    MostrarDatos(usuarioModificar, closerActivo);
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
    }
}
