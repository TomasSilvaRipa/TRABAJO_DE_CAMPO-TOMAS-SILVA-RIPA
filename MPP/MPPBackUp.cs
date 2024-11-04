using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPBackUp
    {
        public MPPBackUp()
        {
            acceso = new Acceso();
        }
        Acceso acceso;

        public bool BackUp(int op,string filepath)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Opcion",1),
                new SqlParameter("@DatabaseName","TPGrupal"),
                new SqlParameter("@FilePath",filepath)
            };
            return acceso.EscribirBackupRestore("BackUpYRestore",parameters);
        }

        public bool Restore(int op, string filepath)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Opcion",2),
                new SqlParameter("@DatabaseName","TPGrupal"),
                new SqlParameter("@FilePath",filepath)
            };
            return acceso.EscribirBackupRestore("BackUpYRestore", parameters);
        }
    }
}
