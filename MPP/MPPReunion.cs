using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPReunion
    {
        public MPPReunion()
        {
            acceso = new Acceso();
        }
        Acceso acceso;

        public bool SolicitarReunion(Propiedad propiedad,Cliente cliente,DateTime Fecha, string Disponibilidad)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Vivienda",propiedad.ID),
                new SqlParameter("@ID_Cliente",cliente.ID),
                new SqlParameter("@Fecha",Fecha),
                new SqlParameter("@Disponibilidad",Disponibilidad),
            };
            return acceso.Escribir("SolicitarReunion",parameters );
        }

        public List<Solicitud> LeerSolicitudesXVivienda(Propiedad propiedad)
        {
            List<Solicitud> solicitudes = new List<Solicitud>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Vivienda",propiedad.ID),
            };
            DataTable dt = acceso.Leer("LeerSolicitantesDeReunionXVivienda", parameters);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    Solicitud solicitud = new Solicitud();
                    solicitud.ID = (int)row["ID"];
                    solicitud.ID_Vivienda = (int)row["ID_Vivienda"];
                    solicitud.ID_Cliente = (int)row["ID_Cliente"];
                    solicitud.Fecha = Convert.ToDateTime(row["Fecha"]);
                    solicitud.Disponibilidad = row["Disponibilidad"].ToString();
                    solicitudes.Add(solicitud);
                }
                return solicitudes;
            }
            return null;
        }
    }
}
