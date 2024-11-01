using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLEtiquetas
    {
        public BLLEtiquetas()
        {
            mppEtiquetas = new MPPEtiquetas();
        }
        MPPEtiquetas mppEtiquetas;

        public List<Etiqueta> LeerEtiquetas()
        {
            return mppEtiquetas.LeerEtiquetas();
        }
    }
}
