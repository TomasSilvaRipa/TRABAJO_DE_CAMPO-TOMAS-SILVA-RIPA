using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLPropiedad
    {
        public BLLPropiedad()
        {
            mppPropiedad = new MPPPropiedad();
            mppDueño = new MPPDueño();
            mppCliente = new MPPCliente();
        }
        MPPPropiedad mppPropiedad;
        MPPDueño mppDueño;
        MPPCliente mppCliente;

        public bool AltaPropiedad(Propiedad propiedad, List<byte[]> imagenesEnBytes)
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Dueño dueño = mppDueño.LeerDueño(usuario.ID);
            if (mppPropiedad.AltaPropiedad(propiedad, dueño.ID, imagenesEnBytes))
            {
                Servicios.EmailSender.EnviarMail("Propiedad publicada", "Su propiedad con dirección " + propiedad.Direccion + " se ha publicado exitosamente", dueño.Mail);
                return true;
            }
            return false;
        }

        public bool ModificarPropiedad(Propiedad propiedad, List<byte[]> imagenesEnBytes)
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Dueño dueño = mppDueño.LeerDueño(usuario.ID);
            return mppPropiedad.ModificarPropiedad(propiedad, dueño.ID, imagenesEnBytes);
        }

        public bool BajaPropiedad(Propiedad propiedad)
        {
            if (mppPropiedad.BajaPropiedad(propiedad))
            {
                Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
                Servicios.EmailSender.EnviarMail("Publicación dada de baja", "Hola " + usuario.NombreDeUsuario + " se ha dado de baja la vivienda con dirección " + propiedad.Direccion + " exitosamente!", usuario.Mail);
                return true;
            }
            return false;
        }

        public List<Propiedad> LeerPropiedades(int opcion)
        {
            if (opcion == 2 || opcion == 3)
            {
                return mppPropiedad.LeerPropiedades(opcion, 0);
            }
            else
            {
                Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
                if (opcion == 0)
                {
                    Dueño dueño = mppDueño.LeerDueño(usuario.ID);
                    return mppPropiedad.LeerPropiedadesDeDueño(dueño.ID);
                }
                else if (opcion == 1)
                {
                    Cliente cliente = mppCliente.LeerCliente(usuario.ID, 1);
                    return mppPropiedad.LeerPropiedades(opcion, cliente.ID);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Propiedad> LeerPropiedadesDeDueño()
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Dueño dueño = mppDueño.LeerDueño(usuario.ID);
            return mppPropiedad.LeerPropiedadesDeDueño(dueño.ID);
        }

        public bool ComprobarViviendaBajoGestion(Propiedad propiedad)
        {
            return mppPropiedad.ComprobarViviendaBabjoGestion(propiedad);
        }

        public bool ComprobarAlquileres()
        {
            return mppPropiedad.ComprobarAlquileres();
        }

    }
}
