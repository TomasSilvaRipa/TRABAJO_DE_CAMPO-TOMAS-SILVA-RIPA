using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCuenta
    {
        public BLLCuenta()
        {
            mppCuenta = new MPPCuenta();
        }
        MPPCuenta mppCuenta;

        public decimal LeerSaldoDeCuenta()
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            return mppCuenta.LeerSaldoDeCuenta(usuario);
        }
    }
}
