using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios;
using BE;
using System.Data;

namespace BLL
{
    public class Sesion : IObservable
    {
        #region PROPIEDADES
        private static Sesion sesionActual;

        Usuario usuario = null;
        public DataTable tablaIdioma { get; set; }
        public Dictionary<string, string> Traduccion { get; set; }

        public List<Permiso> listaDePermisos = new List<Permiso>();

        public List<IObservador> Observadores { get; set; }


        private Sesion() { }
        #endregion

        #region FUNCIONES
        public static Sesion ObtenerSesion()
        {
            // Si ya tenemos una sesion la devuelve.
            if (sesionActual != null)
            {
                return sesionActual;
            }

            // De lo contrario crea una y la vulve a iniciar.
            sesionActual = new Sesion();
            return sesionActual;
        }

        /// <summary>
        /// Obtiene el usuario actualmente Iniciado.
        /// </summary>
        /// <returns>Devuelve el Usuario actualmente iniciado, en caso de no haber uno, devuelve un usuario vacio.</returns>
        public Usuario ObtenerUsuario()
        {
            return (usuario != null) ? usuario : new Usuario();
        }

        /// <summary>
        /// Se establece un usuario como usuario inciado.
        /// </summary>
        /// <param name="UsuarioEntrada"> Instancia del usuario que ocuparía el puesto de usuario inciado.</param>
        public void IniciarUsuario(Usuario UsuarioEntrada)
        {
            if (usuario == null)
            {
                usuario = UsuarioEntrada;
                listaDePermisos = UsuarioEntrada.Permisos;
            }
            else
            {
                throw new Exception("Ya existe un usuario iniciado");
            }
        }

        public static void Logout()
        {
            try
            {
                sesionActual = null;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void ActualizarIdiomas()
        {
            BLLIdiomas bllIdiomas = new BLLIdiomas();
            tablaIdioma = bllIdiomas.ObtenerIdiomas();
     
        }
        public void NotificarActualizacionDeIdioma(int IdIdioma)
        {
            
        }



        public void ActualizarDiccionario(int IdIdioma){
            BLLIdiomas bllIdiomas = new BLLIdiomas();
            Traduccion = bllIdiomas.ObtenerDiccionario(IdIdioma);
            Notificar();
        }

        public void AgregarObservador(IObservador observador)
        {
            if(Observadores == null)
            {
                Observadores = new List<IObservador>();
            }
            Observadores.Add(observador);
        }

        public void QuitarObservador(IObservador observador)
        {
            if (Observadores == null)
            {
                Observadores = new List<IObservador>();
            }
            Observadores.Remove(observador);
        }

        public void Notificar()
        {
            if(Observadores != null)
            {
                foreach (IObservador observador in Observadores)
                {
                    observador.Notificar(this);
                }
            }

        }
        #endregion

    }
}
