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
    public class MPPDueño
    {
        public MPPDueño() 
        {
            acceso = new Acceso();
            mppPermisos = new MPPPermisos();
        }
        Acceso acceso;
        MPPPermisos mppPermisos;

        public Dueño LeerDueño(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID",id),
            };
            DataTable dt = acceso.Leer("LeerDueño", parameters);
            if(dt.Rows.Count > 0)
            {
                Dueño dueño = new Dueño();
                foreach(DataRow row in dt.Rows)
                {
                    dueño.ID = (int)row["ID"];
                    dueño.Nombre = Convert.ToString(row["Nombre"]);
                    dueño.Apellido = Convert.ToString(row["Apellido"]);
                    dueño.Residencia = Convert.ToString(row["Residencia"]);
                    return dueño;
                }
            }
            return null;
        }


        public bool AltaDueño(Dueño dueño)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter id = new SqlParameter("@ID", dueño.ID);
            parameters.Add(id);
            SqlParameter nombre = new SqlParameter("@Nombre", dueño.Nombre);
            parameters.Add(nombre);
            SqlParameter apellido = new SqlParameter("@Apellido", dueño.Apellido);
            parameters.Add(apellido);
            SqlParameter residencia = new SqlParameter("@Residencia", dueño.Residencia);
            parameters.Add(residencia);
            if(acceso.Escribir("AltaDueño", parameters))
            {
                return mppPermisos.AgregarGrupoDePermisosAUsuario(28,dueño.NombreDeUsuario);
            }
            return false;
        }

        public bool AceptarCloserPostulado(Propiedad propiedad, Closer closer)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Vivienda",propiedad.ID),
                new SqlParameter("@ID_Closer",closer.ID)
            };
            return acceso.Escribir("AceptarPostulado",parameters);
            
        }
        public bool ModificarDueño(Dueño dueño, int ID_Usuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter id = new SqlParameter("@ID_Usuario", ID_Usuario);
            parameters.Add(id);
            SqlParameter nombre = new SqlParameter("@Nombre", dueño.Nombre);
            parameters.Add(nombre);
            SqlParameter apellido = new SqlParameter("@Apellido", dueño.Apellido);
            parameters.Add(apellido);
            SqlParameter residencia = new SqlParameter("@Residencia", dueño.Residencia);
            parameters.Add(residencia);
            return acceso.Escribir("ModificarDueño", parameters);
        }

    }
}
