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
    public partial class PerfilCliente : FIdiomaActualizable,IObservador
    {
        Cliente clienteActivo;
        public PerfilCliente()
        {
            InitializeComponent();
            bitacora = new Bitacora_();
            bllBitacora = new BitacoraBLL();
            bllCliente = new BLLCliente();
            bllUsuario = new BLLUsuario();
            bllIdiomas = new BLLIdiomas();
            usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            clienteActivo = bllCliente.LeerCliente(usuario.ID,1);
            MostrarDatos(usuario,clienteActivo);
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
        }
        Bitacora_ bitacora;
        BitacoraBLL bllBitacora;
        BLLUsuario bllUsuario;
        BLLCliente bllCliente;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;
        Usuario usuario;
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

        public void MostrarDatos(Usuario usuario,Cliente cliente)
        {
            tbNombreDeUsuario.Text = usuario.NombreDeUsuario;
            tbMail.Text = usuario.Mail;
            tbNombre.Text = cliente.Nombre;
            tbApellido.Text = cliente.Apellido;
            dateTimePickerFN.Value = cliente.FechaNacimiento;
            if(usuario.Foto != null)
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
                clienteActivo.Nombre = tbNombre.Text;
                clienteActivo.Apellido = tbApellido.Text;
                clienteActivo.FechaNacimiento = dateTimePickerFN.Value;
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
                if ( !ManejoErrores.ValidarClave(tbContraseña.Text) || !ManejoErrores.ValidarMail(tbMail.Text))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, tbNombreDeUsuario.Text, "Los datos ingresados no tienen el formato correcto.");
                    bllBitacora.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                    return;
                }
                Usuario usuarioModificar = Sesion.ObtenerSesion().ObtenerUsuario();
                ActualizarDatos(usuarioModificar);
                if (bllUsuario.ActualizarUsuario(usuarioModificar, 1) && bllCliente.ModificarCliente(clienteActivo,usuarioModificar.ID))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.INFO, tbNombreDeUsuario.Text, "El usuario se modificó con exito.");
                    bllBitacora.Add(bitacora);
                    MostrarDatos(usuarioModificar, clienteActivo);
                    MessageBox.Show(bitacora.Mensaje);
                }
                else
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, tbNombreDeUsuario.Text, "El usuario que intenta modificar no existe");
                    bllBitacora.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBajaCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.BajaUsuario(usuario.NombreDeUsuario))
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
