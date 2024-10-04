using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCliente
    {
        public BLLCliente() 
        {
            mppCliente = new MPPCliente();
        }
        MPPCliente mppCliente;

        public Cliente LeerCliente(int id,int op)
        {
            return mppCliente.LeerCliente(id,2);
        }
    }
}
