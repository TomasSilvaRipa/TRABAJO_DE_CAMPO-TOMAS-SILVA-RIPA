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
    }
}
