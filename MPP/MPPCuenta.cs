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

        public decimal LeerSaldoDeCuenta(Usuario usuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@ID_Usuario",usuario.ID),
            };
            DataTable dt = acceso.Leer("LeerSaldoDeCuenta",parameters);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in  dt.Rows)
                {
                    decimal saldo = Convert.ToDecimal(row["Saldo"]);
                    return saldo;
                }
            }
            return 0;
        }
    }
}
