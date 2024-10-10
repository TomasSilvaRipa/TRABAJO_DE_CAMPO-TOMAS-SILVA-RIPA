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
            
        }
        MPPTrato mppTrato;
        MPPDueño mppDueño;
        MPPPropiedad mppPropiedad;
        public bool AltaTrato(Trato trato)
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Dueño dueño = mppDueño.LeerDueño(usuario.ID);
            trato.ID_Dueño = dueño.ID;
            return mppTrato.AltaTrato(trato);
        }
    }
}
