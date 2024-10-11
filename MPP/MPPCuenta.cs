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
    public class MPPCuenta
    {
        public MPPCuenta()
        {
            acceso = new Acceso();
        }
        Acceso acceso;

        public bool AltaCuenta(Usuario usuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Usuario",usuario.ID),
            };
            return acceso.Escribir("AltaCuenta", parameters);
        }
    }
}
