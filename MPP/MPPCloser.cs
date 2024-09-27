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
    public class MPPCloser
    {
        public MPPCloser()
        {
            acceso = new Acceso();
        }
        Acceso acceso;

        public bool AltaCloser(Closer closer)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter id = new SqlParameter("@ID", closer.ID);
            parameters.Add(id);
            SqlParameter nombre = new SqlParameter("@Nombre", closer.Nombre);
            parameters.Add(nombre);
            SqlParameter apellido = new SqlParameter("@Apellido", closer.Apellido);
            parameters.Add(apellido);
            SqlParameter inquilino = new SqlParameter("@Clasificacion", closer.Clasificacion);
            parameters.Add(inquilino);
            SqlParameter fechaNacimiento = new SqlParameter("@TratosCerrados", closer.TratosCerrados);
            parameters.Add(fechaNacimiento);
            return acceso.Escribir("AltaCloser", parameters);
        }
    }
}
