using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCuota
    {
        public BLLCuota()
        {
            mppCuota = new MPPCuota();
            mppCliente = new MPPCliente();
        }
        MPPCuota mppCuota;
        MPPCliente mppCliente;

        public bool EmitirCuotas()
        {
            return mppCuota.EmitirCuotas();
        }

        public List<Cuota> LeerCuotasXClientePendientes()
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Cliente cliente = mppCliente.LeerCliente(usuario.ID, 1);
            return mppCuota.LeerCuotasXClientePendientes(cliente);
        }

        public List<Cuota> LeerCuotasXClientePagas()
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Cliente cliente = mppCliente.LeerCliente(usuario.ID, 1);
            return mppCuota.LeerCuotasXClientePagas(cliente);
        }

    }
}
