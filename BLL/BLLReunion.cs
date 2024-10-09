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
            mppCloser = new MPPCloser();
        }
        MPPReunion mppReunion;
        MPPCliente mppCliente;
        MPPCloser mppCloser;
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

        public bool AceptarReunion(Cliente cliente,Solicitud solicitud)
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Closer closer = mppCloser.LeerCloser(usuario.ID);
            Reunion reunion = new Reunion(solicitud.ID_Vivienda, closer.ID ,solicitud.ID_Cliente, DateTime.Now);
            return mppReunion.AceptarReunion(reunion);
        }
    }
}
