using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BitacoraBLL
    {
        public BitacoraBLL() 
        {
            mppBitacora = new MPPBitacora();
        }
        MPPBitacora mppBitacora;

        public bool Add(Bitacora_ bitacora)
        {
            return mppBitacora.Add(bitacora);
        }

        public List<Bitacora_> LeerBitacora()
        {
            return mppBitacora.LeerBitacora();
        }

        public List<Bitacora_> FiltrarBitacora(BitacoraFiltros bf, int tipoDeBusqueda)
        {
            return mppBitacora.Filtrar(bf,tipoDeBusqueda);
        }
    }
}
