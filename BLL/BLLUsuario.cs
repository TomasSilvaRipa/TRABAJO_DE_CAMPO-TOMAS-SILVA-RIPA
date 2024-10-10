using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Servicios;
namespace BLL
{
    public class BLLUsuario
    {
        #region CONSTRUCTOR
        public BLLUsuario()
        {
            mppusuario = new MPPUsuario();
            mppCliente = new MPPCliente();
            mppDueño = new MPPDueño();
            mppCloser = new MPPCloser();
        }
        MPPUsuario mppusuario;
        MPPCliente mppCliente;
        MPPCloser mppCloser;
        MPPDueño mppDueño;
        #endregion

        #region FUNCIONES
        public Usuario ObtenerUsuario(Usuario usuarioEntrante)
        {
            string claveEncriptada = Servicios.Seguridad.Encriptar(usuarioEntrante.Clave);
            Usuario usuarioBD = mppusuario.BuscarUsuario(usuarioEntrante.NombreDeUsuario);
            if (usuarioBD.Clave == claveEncriptada)
            {
                return usuarioBD;
            }
            else
            {
                return null;
            }
        }
        public List<Usuario> LeerUsuarios()
        {
            return mppusuario.LeerUsuarios();
        }

        //Alta de Cliente(Inquilino), Dueño o Closer  
        public bool AltaCDC(Usuario usuario)
        {
            Usuario usarioBD = mppusuario.BuscarUsuario(usuario.NombreDeUsuario);
            usuario.ID = usarioBD.ID;

            if(usuario is Cliente)
            {
                Cliente cliente = (Cliente)usuario;
                return mppCliente.AltaCliente(cliente);
            }

            else if(usuario is Dueño)
            {
                Dueño dueño = (Dueño)usuario;
                return mppDueño.AltaDueño(dueño);
            }
            else if(usuario is Closer)
            {
                Closer closer = (Closer)usuario;
                return mppCloser.AltaCloser(closer);
            }
            else
            {
                return false;
            }
        }


        public bool AltaUsuario(Usuario nuevoUsuario, string clave)
        {
            try
            {
                if (mppusuario.ComprobarExistencia(nuevoUsuario.NombreDeUsuario))
                {
                    throw new Exception("El que se esta intentando crear ya existe");
                }
                if (mppusuario.InsertarUsuario(nuevoUsuario, clave))
                {
                    string DV = mppusuario.LeerDigitoVerificadorVertical("Usuarios");
                    if (DV != null)
                    {
                        if (mppusuario.GestionarDigitoVerificadorVertical("Usuarios", 1, mppusuario.ObtenerDigitoVerificadorVertical()))
                        {
                            return AltaCDC(nuevoUsuario);
                        }
                        return false;
                    }
                    else
                    {
                        return mppusuario.GestionarDigitoVerificadorVertical("Usuarios", 0, mppusuario.ObtenerDigitoVerificadorVertical());
                    }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex; 
            }
            
        }

        public bool BajaUsuario(string Nombre)
        {
            if (!mppusuario.ComprobarExistencia(Nombre))
            {
                return false;
            }
            else
            {
                if (mppusuario.RemoverUsuario(Nombre))
                {
                    string DV = mppusuario.LeerDigitoVerificadorVertical("Usuarios");
                    if (DV != null)
                    {
                        return mppusuario.GestionarDigitoVerificadorVertical("Usuarios", 1, mppusuario.ObtenerDigitoVerificadorVertical());
                    }
                    else
                    {
                        return mppusuario.GestionarDigitoVerificadorVertical("Usuarios", 0, mppusuario.ObtenerDigitoVerificadorVertical());
                    }
                }
                else
                {
                    return false;
                }
                
            }
        }

        public bool ActualizarUsuario(Usuario usuario, int opcion)
        {
            if (!mppusuario.ComprobarExistencia(usuario.NombreDeUsuario))
            {
                return false;
            }
            else
            {
                if (mppusuario.ActualizarUsuario(usuario, opcion))
                {
                    string DV = mppusuario.LeerDigitoVerificadorVertical("Usuarios");
                    if (DV != null)
                    {
                        
                        return mppusuario.GestionarDigitoVerificadorVertical("Usuarios", 1, mppusuario.ObtenerDigitoVerificadorVertical());
                    }
                    else
                    {
                        return mppusuario.GestionarDigitoVerificadorVertical("Usuarios", 0, mppusuario.ObtenerDigitoVerificadorVertical());
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public string CalcularDigitoVerificadorHorizontal(IVerificableEntidad entidad)
        {
            return mppusuario.CalcularDigitoVerificadorHorizontal(entidad);
        }

        public bool ValidadDigito(List<Usuario> usuarios)
        {
            try
            {
                foreach(Usuario u in usuarios)
                {
                    string cadena = CalcularDigitoVerificadorHorizontal(u);
                    if(u.DV != cadena)
                    {
                        throw new Exception("Digito Verificador Horizontal Incongruente");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidarDigitoVertical()
        {
            try
            {
                string cadena = string.Empty;
                cadena = mppusuario.LeerDigitoVerificadorVertical("Usuarios");
                string DVV = mppusuario.ObtenerDigitoVerificadorVertical();
                if (cadena != DVV)
                {
                    throw new Exception("Digito Verificador Vertical Incongruente");
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<GestorDeUsuario> LeerHistoricoDeUsuario(string nombre)
        {
            return mppusuario.LeerHistoricoDeUsuario(nombre);
        }
        #endregion


    }
}
