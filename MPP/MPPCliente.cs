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
    public class MPPCliente
    {
        public MPPCliente()
        {
            acceso = new Acceso();
            mppUsuario = new MPPUsuario();
        }
        Acceso acceso;
        MPPUsuario mppUsuario;
        public bool AltaCliente(Cliente cliente)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter id = new SqlParameter("@ID", cliente.ID);
            parameters.Add(id);
            SqlParameter nombre = new SqlParameter("@Nombre",cliente.Nombre);
            parameters.Add(nombre);
            SqlParameter apellido = new SqlParameter("@Apellido", cliente.Apellido);
            parameters.Add(apellido);
            SqlParameter inquilino = new SqlParameter("@Inquilino", cliente.Inquilino);
            parameters.Add(inquilino);
            SqlParameter fechaNacimiento = new SqlParameter("@FechaNacimiento", cliente.FechaNacimiento);
            parameters.Add(fechaNacimiento);
            return acceso.Escribir("AltaCliente", parameters);
        }
    }
}
