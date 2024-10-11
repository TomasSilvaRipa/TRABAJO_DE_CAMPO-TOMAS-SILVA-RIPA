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
using BE;
using System.Security.Cryptography.X509Certificates;

namespace GUI
{
    public partial class FLogin : Form, IObservador
    {
        BLLPermisos bllPermisos;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;
        BLLCuota bllCuota;
        public FLogin()
        {
            InitializeComponent();
            bllCuota = new BLLCuota();
            bllPermisos = new BLLPermisos();
            bitacorabll = new BitacoraBLL();
            bllusuario = new BLLUsuario();
            bllIdiomas = new BLLIdiomas();
            bllusuario.ValidadDigito(bllusuario.LeerUsuarios());
            bllusuario.ValidarDigitoVertical();
            actualizarcbxIdiomas();
            bllCuota.EmitirCuotas();
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

        #endregion

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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Bitacora_ bitacora;
            try
            {
                if (!ManejoErrores.ValidarNombre(txtUsuario.Text) || !ManejoErrores.ValidarClave(txtContra.Text))
                {
                    bitacora = new Bitacora_(Bitacora_.BitacoraTipo.VALIDACION, "UsuarioNoExisteEnLaBase", "Los datos ingresados no tienen el formato correcto.");
                    bitacorabll.Add(bitacora);
                    MessageBox.Show(bitacora.Mensaje);
                    return;
                }
                else
                {
                    Usuario usuarioEntrante = new Usuario()
                    {
                        NombreDeUsuario = txtUsuario.Text,
                        Clave = txtContra.Text,
                    };
                    if (bllusuario.ObtenerUsuario(usuarioEntrante) != null)
                    {
                        Usuario usuarioIniciar = bllusuario.ObtenerUsuario(usuarioEntrante);
                        usuarioIniciar.Permisos = bllPermisos.LeerPermisosXUsuario(usuarioIniciar.NombreDeUsuario);
                        Sesion.ObtenerSesion().IniciarUsuario(usuarioIniciar);
                        bitacora = new Bitacora_(Bitacora_.BitacoraTipo.INFO, usuarioIniciar.NombreDeUsuario, "Sesión Iniciada");
                        bitacorabll.Add(bitacora);
                        DataTable tablaTraduccion = bllIdiomas.ObtenerTraducciones(Convert.ToInt32(tablaIdioma.Rows[cbxIdiomas.SelectedIndex][0]));
                        Sesion.ObtenerSesion().Traduccion = bllIdiomas.ObtenerDiccionario(Convert.ToInt32(tablaIdioma.Rows[cbxIdiomas.SelectedIndex][0]));
                        if(usuarioIniciar.Sector == "Admin")
                        {
                            FMdi fMdi = new FMdi(this, usuarioIniciar.NombreDeUsuario);
                            fMdi.Show();
                        }
                        
                        Menu menu = new Menu(this);
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("El usuario no existe");
                    }
                }
            }
            catch (Exception ex)
            {
                bitacora = new Bitacora_(Bitacora_.BitacoraTipo.ERROR, "NULO", ex.Message);
                bitacorabll.Add(bitacora);
                MessageBox.Show(ex.Message);
            }
        }

        public void Notificar(object Sender)
        {
            var dict = Sesion.ObtenerSesion().Traduccion;

            this.label1.Text = dict["Flogin_Nombre"];
            this.label3.Text = dict["Flogin_Clave"];
        }

        private void cbxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {

                Sesion.ObtenerSesion().AgregarObservador(this);
                Sesion.ObtenerSesion().ActualizarDiccionario(Convert.ToInt32(tablaIdioma.Rows[cbxIdiomas.SelectedIndex][0]));

        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrase_Click(object sender, EventArgs e)
        {
            Registrarse registrase = new Registrarse();
            registrase.Show();
            
        }

    }
}
