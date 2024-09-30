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
            Sesion sesion = Sesion.ObtenerSesion();
            Usuario usuario = sesion.ObtenerUsuario();
            Dueño dueño = mppDueño.LeerDueño(usuario.ID);
            return mppPropiedad.AltaPropiedad(propiedad,dueño.ID,imagenesEnBytes);
        }

        public bool ModificarPropiedad(Propiedad propiedad, List<byte[]> imagenesEnBytes)
        {
            Sesion sesion = Sesion.ObtenerSesion();
            Usuario usuario = sesion.ObtenerUsuario();
            Dueño dueño = mppDueño.LeerDueño(usuario.ID);
            return mppPropiedad.AltaPropiedad(propiedad, dueño.ID, imagenesEnBytes);
        }

        public List<Propiedad> LeerPropiedadesDeDueño()
        {
            Sesion sesion = Sesion.ObtenerSesion();
            Usuario usuario = sesion.ObtenerUsuario();
            Dueño dueño = mppDueño.LeerDueño(usuario.ID);
            return mppPropiedad.LeerPropiedadesDeDueño(dueño.ID);
        }

    }
}
