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
    public class MPPInmoviliaria
    {
        public MPPInmoviliaria()
        {
            acceso = new Acceso();
        }
        Acceso acceso;

        public bool AltaCuentaInmoviliaria(Inmoviliaria inmoviliaria)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Usuario",inmoviliaria.ID),
                new SqlParameter("Nombre",inmoviliaria.Nombre),
            };
            return acceso.Escribir("AltaInmoviliario",parameters);
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
