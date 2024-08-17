using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Lifetime;
using System.Data;
using System.Data.Common;
using System.Configuration;
namespace DAL
{
    public class Acceso
    {
        public SqlConnection conn = new SqlConnection("Data Source=DESKTOP-CUKEVVE\\SQLEXPRESS;Initial Catalog=TPGrupal;Integrated Security=True;");
        public static string cadena = "Data Source=DESKTOP-CUKEVVE\\SQLEXPRESS;Initial Catalog=TPGrupal;Integrated Security=True;";
        public static SqlCommand cmd;
        public static SqlTransaction myTrans;


        public  DataTable Leer(string procedimiento, List<SqlParameter> parametros = null)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd = new SqlCommand(procedimiento, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                adapter = new SqlDataAdapter(cmd);
                if (parametros != null)
                {
                    foreach (SqlParameter param in parametros)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                adapter.Fill(dataTable);
            }
            catch (SqlException ex) { throw new Exception(ex.Message); }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { conn.Close(); }
            return dataTable;

        }

        public bool Escribir(string procedimiento, List<SqlParameter> parametros = null)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = "Data Source=DESKTOP-CUKEVVE\\SQLEXPRESS;Initial Catalog=TPGrupal;Integrated Security=True;";
                conn.Open();
            }
            try
            {
                myTrans = conn.BeginTransaction();
                cmd = new SqlCommand(procedimiento, conn, myTrans);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (SqlParameter param in parametros)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                int repsuesta = cmd.ExecuteNonQuery();
                myTrans.Commit();
                return true;
            }
            catch (SqlException) { myTrans.Rollback(); return false; }
            catch (Exception) { myTrans.Rollback(); return false; }
            finally { conn.Close(); }

        }

    }
}
