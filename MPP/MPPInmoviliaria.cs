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

        
    }
}
