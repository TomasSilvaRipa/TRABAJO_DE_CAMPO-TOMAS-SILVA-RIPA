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
using static System.Collections.Specialized.BitVector32;

namespace GUI
{
    public partial class Registrarse : FIdiomaActualizable,IObservador
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
            labelResidencia.Visible = false;
            tbResicencia.Visible = false;
            Notificar(this);
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
            actualizarcbxIdiomas();
            
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

        public string ObtenerSector()
        {
            string sector = "";
            if (rbCliente.Checked)
            {
                sector = "Cliente";
                return sector;
            }
            else if (rbDueño.Checked)
            {
                sector = "Dueño";
                return sector;
            }
            else if (rbCloser.Checked)
            {
                sector = "Closer";
                return sector;
            }
            else
            {
                throw new Exception("Elija un tipo de cuenta para registrase");
            }
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

        private void btnRegistrase_Click(object sender, EventArgs e)
        {
            Bitacora_ bitacora;
            try
            {
                if (!ManejoErrores.ValidarNombre(txtUsuario.Text) || !ManejoErrores.ValidarClave(txtContra.Text) || !ManejoErrores.ValidarMail(txtMail.Text) || !ManejoErrores.ValidarNombre(tbNombre.Text) || !ManejoErrores.ValidarNombre(tbApellido.Text))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, "UsuarioNoExisteEnLaBase", "Los datos ingresados no tienen el formato correcto.");
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                    return;
                }
                else
                {
                    Usuario nuevoUsuario = new Usuario(txtUsuario.Text, ObtenerSector(), txtMail.Text);
                    nuevoUsuario.Clave = Seguridad.Encriptar(txtContra.Text);
                    nuevoUsuario.DV = bllusuario.CalcularDigitoVerificadorHorizontal(nuevoUsuario);
                    if (rbCliente.Checked)
                    {
                        Cliente clienteCreate = new Cliente(nuevoUsuario,tbNombre.Text, tbApellido.Text, false, dateTimePickerFN.Value);
                        
                        if (bllusuario.AltaUsuario(clienteCreate, txtContra.Text))
                        {
                            MessageBox.Show("Cliente: " + nuevoUsuario.NombreDeUsuario + "creado correctamente");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ha occurido un error");
                        }
                    }
                    else if (rbDueño.Checked)
                    {
                        Dueño dueño = new Dueño(nuevoUsuario,tbNombre.Text, tbApellido.Text, tbResicencia.Text);
                        if (ManejoErrores.ValidarClave(tbResicencia.Text))
                        {
                            if (bllusuario.AltaUsuario(dueño, txtContra.Text))
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
                    else if (rbCloser.Checked)
                    {
                        Closer closer = new Closer(nuevoUsuario,tbNombre.Text, tbApellido.Text, "Beginner", 0);
                        if (bllusuario.AltaUsuario(closer, txtContra.Text))
                        {
                            MessageBox.Show("Closer: " + nuevoUsuario.NombreDeUsuario + "creado correctamente");
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

        private void rbCliente_CheckedChanged(object sender, EventArgs e)
        {
            rbCloser.Checked = false;
            rbDueño.Checked = false;
            labelResidencia.Visible = false;
            tbResicencia.Visible = false;
        }

        private void rbDueño_CheckedChanged(object sender, EventArgs e)
        {
            rbCloser.Checked = false;
            rbCliente.Checked = false;
            labelResidencia.Visible = true;
            tbResicencia.Visible = true;
        }

        private void rbCloser_CheckedChanged(object sender, EventArgs e)
        {
            rbCliente.Checked = false;
            rbDueño.Checked = false;
            labelResidencia.Visible = false;
            tbResicencia.Visible = false;
        }

        private void cbxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sesion.ObtenerSesion().AgregarObservador(this);
            Sesion.ObtenerSesion().ActualizarDiccionario(Convert.ToInt32(tablaIdioma.Rows[cbxIdiomas.SelectedIndex][0]));
        }
    }
}
