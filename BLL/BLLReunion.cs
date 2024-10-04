using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLReunion
    {
        public BLLReunion()
        {
            mppReunion = new MPPReunion();
            mppCliente = new MPPCliente();
        }
        MPPReunion mppReunion;
        MPPCliente mppCliente;
        public bool SolicitarReunion(Propiedad propiedad, DateTime Fecha, string Disponibilidad)
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Cliente cliente = mppCliente.LeerCliente(usuario.ID,1);
            return mppReunion.SolicitarReunion(propiedad,cliente,Fecha,Disponibilidad);
        }

        public List<Solicitud> LeerSolicitudesDeReunionXVivienda(Propiedad propiedad)
        {
            return mppReunion.LeerSolicitudesXVivienda(propiedad);
        }
    }
}
