using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLDueño
    {
        public BLLDueño()
        {
            mppDueño = new MPPDueño();
        }
        MPPDueño mppDueño;
        public bool AceptarCloserPostulado(Propiedad propiedad, Closer closer)
        {
            return mppDueño.AceptarCloserPostulado(propiedad, closer);
        }

        public bool RechazarCloserPostulado(Propiedad propiedad, Closer closer)
        {
            return mppDueño.RechazarCloserPostulado(propiedad, closer);
        }

        public bool DarDeBajaCloserACargo(Propiedad propiedad,Closer closer)
        {
            return mppDueño.DarDeBajaCloserACargo(propiedad,closer);
        }

        public Dueño LeerDueño(int id)
        {
            return mppDueño.LeerDueño(id);
        }

        public bool ModificarDueño(Dueño dueño, int ID_Usuario)
        {
            return mppDueño.ModificarDueño(dueño,ID_Usuario);
        }
    }
}
