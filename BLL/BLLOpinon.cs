using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLOpinon
    {
        public BLLOpinon()
        {
            mppOpinion = new MPPOpinion();
        }
        MPPOpinion mppOpinion;

        public bool AltaOpinion(Opinion opinion)
        {
            return mppOpinion.AltaOpinion(opinion);
        }

        public List<Opinion> LeerOpiniones(Usuario usuario, int opcion)
        {
            return mppOpinion.LeerOpiniones(usuario,opcion);
        }
    }
}
