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
    public class MPPCliente
    {
        public MPPCliente()
        {
            acceso = new Acceso();
            mppUsuario = new MPPUsuario();
            mppPermisos = new MPPPermisos();
        }
        Acceso acceso;
        MPPUsuario mppUsuario;
        MPPPermisos mppPermisos;
        public bool AltaCliente(Cliente cliente)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter id = new SqlParameter("@ID_Usuario", cliente.ID);
            parameters.Add(id);
            SqlParameter nombre = new SqlParameter("@Nombre",cliente.Nombre);
            parameters.Add(nombre);
            SqlParameter apellido = new SqlParameter("@Apellido", cliente.Apellido);
            parameters.Add(apellido);
            SqlParameter inquilino = new SqlParameter("@Inquilino", cliente.Inquilino);
            parameters.Add(inquilino);
            SqlParameter fechaNacimiento = new SqlParameter("@FechaNacimiento", cliente.FechaNacimiento);
            parameters.Add(fechaNacimiento);
            if(acceso.Escribir("AltaCliente", parameters))
            {
                return mppPermisos.AgregarGrupoDePermisosAUsuario(37,cliente.NombreDeUsuario); 
            }
            return false;
        }

        public bool ModificarCliente(Cliente cliente,int ID_Usuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter id_Usuario = new SqlParameter("@ID_Usuario", ID_Usuario);
            parameters.Add(id_Usuario);
            SqlParameter nombre = new SqlParameter("@Nombre", cliente.Nombre);
            parameters.Add(nombre);
            SqlParameter apellido = new SqlParameter("@Apellido", cliente.Apellido);
            parameters.Add(apellido);
            SqlParameter fechaNacimiento = new SqlParameter("@FechaNacimiento", cliente.FechaNacimiento);
            parameters.Add(fechaNacimiento);
            return acceso.Escribir("ModificarCliente", parameters);
        }

        public Cliente LeerCliente(int id,int op)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (op == 1)
            {
                SqlParameter ID = new SqlParameter("@ID", id);
                parameters.Add(ID);
                SqlParameter ID_Cliente = new SqlParameter("@ID_Cliente", DBNull.Value);
                parameters.Add(ID_Cliente);
            }
            else
            {
                SqlParameter ID = new SqlParameter("@ID", DBNull.Value);
                parameters.Add(ID);
                SqlParameter ID_Cliente = new SqlParameter("@ID_Cliente", id);
                parameters.Add(ID_Cliente);
            }
            DataTable dt = acceso.Leer("LeerCliente",parameters);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    Cliente cliente = new Cliente();
                    cliente.ID = (int)row["ID"];
                    cliente.Nombre = row["Nombre"].ToString();
                    cliente.Apellido = row["Apellido"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(row["FechaDeNacimiento"]);
                    if (row["Foto"] != DBNull.Value && ((byte[])row["Foto"]).Length > 0)
                    {
                        cliente.Foto = (byte[])row["Foto"];
                    }
                    return cliente;
                }
            }
            return null;
        }
    }
}
