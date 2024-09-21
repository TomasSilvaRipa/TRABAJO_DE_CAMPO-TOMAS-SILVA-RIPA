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
    public class MPPDueño
    {
        public MPPDueño() 
        {
            acceso = new Acceso();
        }
        Acceso acceso;

        public bool AltaDueño(Dueño dueño, Usuario usuario)
        {
            dueño.ID = usuario.ID;
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter id = new SqlParameter("@ID_Usuario", dueño.ID);
            parameters.Add(id);
            SqlParameter nombre = new SqlParameter("@Nombre", dueño.Nombre);
            parameters.Add(nombre);
            SqlParameter apellido = new SqlParameter("@Apellido", dueño.Apellido);
            parameters.Add(apellido);
            SqlParameter residencia = new SqlParameter("@Residencia", dueño.Residencia);
            parameters.Add(residencia);
            return acceso.Escribir("AltaDueño", parameters);
        }

    }
}
