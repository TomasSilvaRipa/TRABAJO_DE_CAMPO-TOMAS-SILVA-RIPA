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
        }
        MPPPropiedad mppPropiedad;
        MPPDueño mppDueño;
        
        public bool AltaPropiedad(Propiedad propiedad, List<byte[]> imagenesEnBytes)
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Dueño dueño = mppDueño.LeerDueño(usuario.ID);
            if (mppPropiedad.AltaPropiedad(propiedad, dueño.ID, imagenesEnBytes))
            {
                Servicios.EmailSender.EnviarMail("Propiedad publicada","Su propiedad con dirección " + propiedad.Direccion + " se ha publicado exitosamente",dueño.Mail);
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
                Servicios.EmailSender.EnviarMail("Publicación dada de baja", "Hola "+ usuario.NombreDeUsuario +" se ha dado de baja la vivienda con dirección " + propiedad.Direccion + " exitosamente!", usuario.Mail);
                return true;
            }
            return false;
        }

        public List<Propiedad> LeerPropiedades(int opcion)
        {
            if (opcion != 0) 
            {
                return mppPropiedad.LeerPropiedades(opcion);
            }
            else
            {
                Sesion sesion = Sesion.ObtenerSesion();
                Usuario usuario = sesion.ObtenerUsuario();
                Dueño dueño = mppDueño.LeerDueño(usuario.ID);
                return mppPropiedad.LeerPropiedadesDeDueño(dueño.ID);
            }
        }

        public List<Propiedad> LeerPropiedadesDeDueño()
        {
            Sesion sesion = Sesion.ObtenerSesion();
            Usuario usuario = sesion.ObtenerUsuario();
            Dueño dueño = mppDueño.LeerDueño(usuario.ID);
            return mppPropiedad.LeerPropiedadesDeDueño(dueño.ID);
        }

        public bool ComprobarViviendaBajoGestion(Propiedad propiedad)
        {
            return mppPropiedad.ComprobarViviendaBabjoGestion(propiedad);
        }

    }
}
