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
            mppTrato = new MPPTrato();
            mppCloser = new MPPCloser();
            mppPropiedad = new MPPPropiedad();
            mppDueño = new MPPDueño();
        }
        MPPCuota mppCuota;
        MPPCliente mppCliente;
        MPPTrato mppTrato;
        MPPCloser mppCloser;
        MPPPropiedad mppPropiedad;
        MPPDueño mppDueño;
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

        public bool PagarCuota(Cuota cuota)
        {
            try
            {
                Trato trato = new Trato();
                trato.ID_Vivienda = cuota.ID_Vivienda;
                trato.ID_Cliente = cuota.ID_Cliente;
                trato = mppTrato.LeerTrato(trato);
                Closer closer = mppCloser.LeerCloser(trato.ID_Closer, 2);
                decimal montoInmoviliaria = cuota.Monto * 0.10m;
                decimal montoCloser = cuota.Monto * (Convert.ToDecimal(closer.Comision.TrimEnd('%')) / 100);
                cuota.Monto = cuota.Monto - montoCloser - montoInmoviliaria; 
                return mppCuota.PagarCuota(cuota, trato.ID_Closer, montoCloser,montoInmoviliaria);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public List<Cuota> LeerCuotasXDueño()
        {
            try
            {
                Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
                Dueño dueño = mppDueño.LeerDueño(usuario.ID);
                dueño.listaDeViviendas = mppPropiedad.LeerPropiedadesDeDueño(dueño.ID);
                return mppCuota.LeerCoutasXDueño(dueño);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

    }
}
