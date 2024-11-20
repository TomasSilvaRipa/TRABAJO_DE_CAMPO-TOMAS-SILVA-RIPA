using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPTrato
    {
        public MPPTrato()
        {
            acceso = new Acceso();
        }
        Acceso acceso;

        public bool AltaTrato(Trato trato)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Cliente",trato.ID_Cliente),
                new SqlParameter("@ID_Dueño",trato.ID_Dueño),
                new SqlParameter("@ID_Closer",trato.ID_Closer),
                new SqlParameter("@ID_Vivienda",trato.ID_Vivienda),
                new SqlParameter("@FechaDeInicio",trato.FechaDeInicio),
                new SqlParameter("@FechaDeFinalizacion",trato.FechaDeFinalizacion),
            };
            if (acceso.Escribir("AltaTrato", parameters))
            {
                if (acceso.Escribir("EmitirCuotas"))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public Trato LeerTrato(Trato trato)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Cliente",trato.ID_Cliente),
                new SqlParameter("@ID_Vivienda",trato.ID_Vivienda)
            };
            DataTable dt = acceso.Leer("LeerTrato", parameters);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    Trato t = new Trato();
                    t.ID = (int)row["ID"];
                    t.ID_Cliente = (int)row["ID_Cliente"];
                    t.ID_Vivienda = (int)row["ID_Vivienda"];
                    t.ID_Dueño = (int)row["ID_Dueño"];
                    t.ID_Closer = (int)row["ID_Closer"];
                    t.FechaDeInicio = Convert.ToDateTime(row["FechaDeInicio"]);
                    t.FechaDeFinalizacion = Convert.ToDateTime(row["FechaDeFinalizacion"]);
                    return t;
                }
            }
            return null;
        }

        public List<Trato> LeerTratosXCloser(Closer closer)
        {
            List<Trato> listaDeTratos = new List<Trato>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Closer",closer.ID),
            };
            DataTable dt = acceso.Leer("LeerTratosXCloser",parameters);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Trato trato = new Trato();
                    trato.ID = (int)row["ID"];
                    trato.ID_Cliente = (int)row["ID_Cliente"];
                    trato.ID_Vivienda = (int)row["ID_Vivienda"];
                    trato.ID_Closer = (int)row["ID_Closer"];
                    trato.ID_Dueño = (int)row["ID_Dueño"];
                    trato.FechaDeInicio = Convert.ToDateTime(row["FechaDeInicio"]);
                    trato.FechaDeFinalizacion = Convert.ToDateTime(row["FechaDeFinalizacion"]);
                    listaDeTratos.Add(trato);
                }
                return listaDeTratos;
            }
            return null;
        }

        public List<Trato> LeerTratos()
        {
            List<Trato> listaDeTratos = new List<Trato>();
            DataTable dt = acceso.Leer("LeerTratos");
            if( dt.Rows.Count > 0 )
            {
                foreach(DataRow row in dt.Rows)
                {
                    Trato trato = new Trato();
                    trato.ID = (int)row["ID"];
                    trato.ID_Cliente = (int)row["ID_Cliente"];
                    trato.ID_Vivienda = (int)row["ID_Vivienda"];
                    trato.ID_Closer = (int)row["ID_Closer"];
                    trato.ID_Dueño = (int)row["ID_Dueño"];
                    trato.FechaDeInicio = Convert.ToDateTime(row["FechaDeInicio"]);
                    trato.FechaDeFinalizacion = Convert.ToDateTime(row["FechaDeFinalizacion"]);
                    listaDeTratos.Add(trato);
                }
                return listaDeTratos;
            }
            return null;
        }

    }
}
