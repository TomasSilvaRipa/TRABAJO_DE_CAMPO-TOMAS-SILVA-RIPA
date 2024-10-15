using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLInmoviliaria
    {
        public BLLInmoviliaria()
        {
            mppInmoviliaria = new MPPInmoviliaria();
        }
        MPPInmoviliaria mppInmoviliaria;

        public bool ModificarCuentaInmoviliario(Inmoviliaria inmoviliaria, int id)
        {
            return mppInmoviliaria.ModificarCuentaInmoviliaria(inmoviliaria, id);
        }
    }
}
