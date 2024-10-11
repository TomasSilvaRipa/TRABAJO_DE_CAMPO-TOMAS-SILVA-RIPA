using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            if(acceso.Escribir("AltaTrato",parameters) && acceso.Escribir("EmitirCuotas"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
