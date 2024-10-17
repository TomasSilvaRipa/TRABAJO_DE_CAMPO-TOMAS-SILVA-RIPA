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
    public class MPPInmoviliaria
    {
        public MPPInmoviliaria()
        {
            acceso = new Acceso();
            mppPermisos = new MPPPermisos();
        }
        Acceso acceso;
        MPPPermisos mppPermisos;

        public bool AltaCuentaInmoviliaria(Inmoviliaria inmoviliaria)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Usuario",inmoviliaria.ID),
                new SqlParameter("Nombre",inmoviliaria.Nombre),
            };
            
            if (acceso.Escribir("AltaInmoviliario", parameters) && acceso.Escribir("AltaCuentaInmoviliaria"))
            {
                return mppPermisos.AgregarGrupoDePermisosAUsuario(43, inmoviliaria.NombreDeUsuario);
            }
            return false;
        }

        public bool ModificarCuentaInmoviliaria(Inmoviliaria inmoviliaria,int ID_usuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Usuario",ID_usuario),
                new SqlParameter("Nombre",inmoviliaria.Nombre),
            };
            return acceso.Escribir("ModificarInmoviliario", parameters);
        }

        public Inmoviliaria LeerCuentaInmoviliaria(Usuario usuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Usuario",usuario.ID),
            };
            DataTable dt = acceso.Leer("LeerCuentaInmoviliaria",parameters);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row  in dt.Rows)
                {
                    Inmoviliaria inmoviliaria = new Inmoviliaria();
                    inmoviliaria.ID = (int)row["ID"];
                    inmoviliaria.Nombre = row["Nombre"].ToString();
                    if (row["Foto"] != DBNull.Value)
                    {
                        inmoviliaria.Foto = (byte[])row["Foto"];
                    }
                    return inmoviliaria;
                }
                return null;
            }
            return null;
        }

        
    }
}
