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
        }
        MPPTrato mppTrato;

        public bool AltaTrato(Trato trato)
        {
            return mppTrato.AltaTrato(trato);
        }
    }
}
