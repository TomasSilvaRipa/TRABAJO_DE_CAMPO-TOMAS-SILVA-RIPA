using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public bool AceptarReunion(Reunion reunion)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Vivienda",reunion.ID_Vivienda),
                new SqlParameter("@ID_Cliente",reunion.ID_Cliente),
                new SqlParameter("@ID_Closer",reunion.ID_Closer),
                new SqlParameter("@Fecha",reunion.Fecha),
            };
            return acceso.Escribir("AceptarReunion", parameters);
        }

        public bool RecharReunion(Solicitud solicitud)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Solicitud",solicitud.ID),
            };
            return acceso.Escribir("RechazarReunion", parameters);
        }

        public List<Reunion> LeerReuniones(Dueño dueño)
        {
            List<Reunion> reuniones = new List<Reunion>();
            if(dueño.listaDeViviendas != null)
            {
                foreach (Propiedad propiedad in dueño.listaDeViviendas)
                {
                    List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@ID_Dueño",dueño.ID),
                    new SqlParameter("@ID_Vivienda",propiedad.ID)
                };
                    DataTable dt = acceso.Leer("LeerReuniones", parameters);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Reunion reunion = new Reunion();
                            reunion.ID = (int)row["ID"];
                            reunion.ID_Cliente = (int)row["ID_Cliente"];
                            reunion.ID_Vivienda = (int)row["ID_Vivienda"];
                            reunion.ID_Closer = (int)row["ID_Closer"];
                            reunion.Fecha = Convert.ToDateTime(row["Fecha"]);
                            reuniones.Add(reunion);
                        }
                    }
                }
                return reuniones;
            }
            return null;
        }
    }
}
