using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLBackUp
    {
        public BLLBackUp()
        {
            mppBackUp = new MPPBackUp();
        }
        MPPBackUp mppBackUp;

        public bool BackUp(int op,string filepath)
        {
            return mppBackUp.BackUp(op,filepath);
        }

        public bool Restore(int op,string filepath)
        {
            return mppBackUp.Restore(op,filepath);
        }

    }
}
