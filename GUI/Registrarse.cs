using BE;
using BLL;
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

namespace GUI
{
    public partial class Registrarse : Form
    {
        BLLPermisos bllPermisos;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;
        public Registrarse()
        {
            InitializeComponent();
            bllPermisos = new BLLPermisos();
            bitacorabll = new BitacoraBLL();
            bllusuario = new BLLUsuario();
            bllIdiomas = new BLLIdiomas();
        }
        BitacoraBLL bitacorabll;
        BLLUsuario bllusuario;

        public delegate void IniciarMdi();
        public IniciarMdi iniciarMdi;

        #region FUNCIONES APARTE 
        public void Limpiar()
        {
            txtUsuario.Text = "";
            txtContra.Text = "";
        }

        private void actualizarcbxIdiomas()
        {

            tablaIdioma = bllIdiomas.ObtenerIdiomas();
            foreach (DataRow row in tablaIdioma.Rows)
            {
                cbxIdiomas.Items.Add(row[1]);
            }
            cbxIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxIdiomas.SelectedIndex = 0;
        }


        #endregion

        private void btnRegistrase_Click(object sender, EventArgs e)
        {
            Bitacora_ bitacora;
            try
            {
                if (!ManejoErrores.ValidarNombre(txtUsuario.Text) || !ManejoErrores.ValidarClave(txtContra.Text) || !ManejoErrores.ValidarMail(txtMail.Text))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, "UsuarioNoExisteEnLaBase", "Los datos ingresados no tienen el formato correcto.");
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                    return;
                }
                else
                {
                    string sector = "";
                    if (rbCliente.Checked)
                    {
                        sector = "Cliente";
                    }
                    else if (rbDueño.Checked)
                    {
                        sector = "Dueño";
                    }
                    else if (rbCloser.Checked)
                    {
                        sector = "Closer";
                    }
                    else
                    {
                        throw new Exception("Elija un tipo de cuenta para registrase");
                    }
                    Usuario nuevoUsuario = new Usuario(txtUsuario.Text, sector,txtMail.Text);
                    nuevoUsuario.Clave = Seguridad.Encriptar(txtContra.Text);
                    nuevoUsuario.DV = bllusuario.CalcularDigitoVerificadorHorizontal(nuevoUsuario);
                    if (bllusuario.AltaUsuario(nuevoUsuario, txtContra.Text))
                    {
                        bitacora = new Bitacora_(Bitacora_.BitacoraTipo.INFO, "sin ingresar", "El usuario " + nuevoUsuario.Nombre + " se creo correctamente.");
                        bitacorabll.Add(bitacora);
                        MessageBox.Show(bitacora.Mensaje);
                        Registrarse.ActiveForm.Close();
                    }
                    else
                    {
                        bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, "sin ingresar", "Un usuario con el nombre " + nuevoUsuario.Nombre + " ya existe!");
                        bitacorabll.Add(bitacora);
                        MessageBox.Show(bitacora.Mensaje);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                bitacora = new Bitacora_(Bitacora_.BitacoraTipo.ERROR, "sin ingresar", "No Se Pudo Dar De Alta al Usuario:" + ex.Message);
                bitacorabll.Add(bitacora);
                MessageBox.Show(ex.Message);
            }
        }

        private void Registrarse_Load(object sender, EventArgs e)
        {

        }
    }
}
