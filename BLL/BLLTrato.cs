using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLTrato
    {
        public BLLTrato()
        {
            mppTrato = new MPPTrato();
            mppDueño = new MPPDueño();
            mppCloser = new MPPCloser();
        }
        MPPTrato mppTrato;
        MPPDueño mppDueño;
        MPPPropiedad mppPropiedad;
        MPPCloser mppCloser;
        public bool AltaTrato(Trato trato)
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Dueño dueño = mppDueño.LeerDueño(usuario.ID);
            trato.ID_Dueño = dueño.ID;
            if (mppTrato.AltaTrato(trato))
            {
                Servicios.EmailSender.EnviarMail("Trato cerrado","El trato ha sido cerrado exitosamente. Ya puede pagar su primer cuota",usuario.Mail);
                return true;
            }
            return false;
        }

        public List<Trato> LeerTratosXCloser()
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Closer closer = mppCloser.LeerCloser(usuario.ID,1);
            return mppTrato.LeerTratosXCloser(closer);
        }

        public List<Trato> LeerTratos()
        {
            return mppTrato.LeerTratos();
        }

        
    }
}
