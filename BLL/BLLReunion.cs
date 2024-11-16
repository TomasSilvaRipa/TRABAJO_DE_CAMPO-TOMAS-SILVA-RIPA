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
            mppDueño = new MPPDueño();
            mppPropiedad = new MPPPropiedad();
        }
        MPPReunion mppReunion;
        MPPCliente mppCliente;
        MPPCloser mppCloser;
        MPPDueño mppDueño;
        MPPPropiedad mppPropiedad;
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
            Closer closer = mppCloser.LeerCloser(usuario.ID, 1);
            Reunion reunion = new Reunion(solicitud.ID_Vivienda, closer.ID ,solicitud.ID_Cliente, DateTime.Now);
            if (mppReunion.AceptarReunion(reunion))
            {
                Servicios.EmailSender.EnviarMail("Reunion Acetada", "Su solicitud para ver la vivienda a sido aceptada. Le estaremos mandando la dirección y horario de encuentro a la brevedad." , cliente.Mail);
                return true;
            }
            return false;
        }

        public bool RechazarReunion(Solicitud solicitud)
        {
            Cliente cliente = mppCliente.LeerCliente(solicitud.ID_Cliente, 2);
            if (mppReunion.RecharReunion(solicitud))
            {
                Servicios.EmailSender.EnviarMail("Reunion Rechazada", "Su solicitud para ver la vivienda a sido rechazada.", cliente.Mail);
                return true;
            }
            return false;
        }

        public List<Reunion> LeerReuniones()
        {
            Usuario usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            Dueño dueño = mppDueño.LeerDueño(usuario.ID);
            dueño.listaDeViviendas = mppPropiedad.LeerPropiedadesDeDueño(usuario.ID);
            return mppReunion.LeerReuniones(dueño);
        }

        public List<Reunion> LeerReunionPorCliente(Cliente cliente)
        {
            return mppReunion.LeerReunionesPorCliente(cliente);
        }

        public bool CancelarReunion(Reunion reunion)
        {
            return mppReunion.CancelarReunion(reunion);
        }
    }
}
