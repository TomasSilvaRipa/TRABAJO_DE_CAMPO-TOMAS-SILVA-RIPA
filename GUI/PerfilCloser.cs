﻿using BE;
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
    public partial class PerfilCloser : Form
    {
        Closer closerActivo;
        public PerfilCloser()
        {
            Closer closerActivo;
            InitializeComponent();
            bitacora = new Bitacora_();
            bllBitaacora = new BitacoraBLL();
            bllCloser = new BLLCloser();
            bllUsuario = new BLLUsuario();
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            closerActivo = bllCloser.LeerCloser(usuario.ID);
            MostrarDatos(usuario, closerActivo);
        }
        Bitacora_ bitacora;
        BitacoraBLL bllBitaacora;
        BLLUsuario bllUsuario;
        BLLCloser bllCloser;
        Image imagen;


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

        public void ActualizarDatos()
        {
            closerActivo.Nombre = tbNombre.Text;
            closerActivo.Apellido = tbApellido.Text;
            closerActivo.Clasificacion = labelTratosCerrados.Text;
            closerActivo.TratosCerrados = Convert.ToInt32(labelTratosCerrados.Text);
        }

        public byte[] ConvertirImagenABytes(Image Imagen)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Imagen.Save(ms, Imagen.RawFormat);
                return ms.ToArray();
            }
        }

        private void PerfilCloser_Load(object sender, EventArgs e)
        {
            
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
                if (imagen != null)
                {
                    usuarioModificar.Foto = ConvertirImagenABytes(imagen);
                }
                ActualizarDatos();
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
