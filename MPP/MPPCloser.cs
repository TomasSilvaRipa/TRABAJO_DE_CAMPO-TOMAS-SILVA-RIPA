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

        public bool Postularse(Closer closer, Propiedad propiedad)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Vivienda",propiedad.ID),
                new SqlParameter("@ID_Closer",closer.ID),
            };
            return acceso.Escribir("Postularse",parameters);
        }

        public bool ComprobarExistenciaPostulado(Closer closer, Propiedad propiedad)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Vivienda",propiedad.ID),
                new SqlParameter("@ID_Closer",closer.ID),
            };
            DataTable dt = acceso.Leer("ComprobarPostulacion", parameters);
            if(dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Closer LeerCloser(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID",ID),
            };
            DataTable dt = acceso.Leer("LeerCloser",parameters);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    Closer closer = new Closer();
                    closer.ID = (int)row["ID"];
                    closer.Nombre = row["Nombre"].ToString();
                    closer.Apellido = row["Apellido"].ToString();
                    closer.Clasificacion = row["Clasificacion"].ToString();
                    closer.TratosCerrados = (int)row["TratosCerrados"];
                    return closer;
                }
            }
            return null;
        }

        public List<Closer> LeerClosersPostulados(Propiedad propiedad)
        {
            List<Closer> closers = new List<Closer>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Vivienda",propiedad.ID),
            };
            DataTable dt = acceso.Leer("LeerClosersPostulados",parameters);
            if(dt.Rows.Count > 0 )
            {
                foreach (DataRow row in dt.Rows)
                {
                    int estado = Convert.ToInt32(row["Estado"]);
                    if (estado != 2)
                    {
                        Closer closer = new Closer();
                        closer.ID = (int)row["ID"];
                        closer.Nombre = row["Nombre"].ToString();
                        closer.Apellido = row["Apellido"].ToString();
                        closer.Clasificacion = row["Clasificacion"].ToString();
                        closer.TratosCerrados = (int)row["TratosCerrados"];
                        closers.Add(closer);
                    }
                    else
                    {
                        closers.Clear();
                        Closer closer = new Closer();
                        closer.ID = (int)row["ID"];
                        closer.Nombre = row["Nombre"].ToString();
                        closer.Apellido = row["Apellido"].ToString();
                        closer.Clasificacion = row["Clasificacion"].ToString();
                        closer.TratosCerrados = (int)row["TratosCerrados"];
                        closers.Add(closer);
                        return closers;
                    }
                }
                return closers;
            }
            return null;
        }
    }
}
