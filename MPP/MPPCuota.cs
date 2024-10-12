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
    public class MPPCuota
    {
        public MPPCuota()
        {
            acceso = new Acceso();
        }
        Acceso acceso;

        public bool EmitirCuotas()
        {
            return acceso.Escribir("EmitirCuotas");
        }

        public List<Cuota> LeerCuotasXClientePendientes(Cliente cliente)
        {
            List<Cuota> cuotasPendientes = new List<Cuota>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Cliente",cliente.ID),
            };
            DataTable dt = acceso.Leer("LeerCuotasXCliente",parameters);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in  dt.Rows)
                {
                    if (Convert.ToInt32(row["Estado"]) == 0)
                    {
                        Cuota cuota = new Cuota();
                        cuota.ID = (int)row["ID"];
                        cuota.ID_Cliente = (int)row["ID_Cliente"];
                        cuota.ID_Vivienda = (int)row["ID_Vivienda"];
                        cuota.Monto = Convert.ToDecimal(row["Monto"]);
                        cuota.FechaDeEmision = Convert.ToDateTime(row["FechaDeEmision"]);
                        cuota.FechaDeVencimiento = Convert.ToDateTime(row["FechaDeVencimiento"]);
                        cuotasPendientes.Add(cuota);
                    }
                    
                }
                return cuotasPendientes;
            }
            return null;
        }

        public List<Cuota> LeerCuotasXClientePagas(Cliente cliente)
        {
            List<Cuota> cuotasPagas = new List<Cuota>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Cliente",cliente.ID),
            };
            DataTable dt = acceso.Leer("LeerCuotasXCliente", parameters);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["Estado"]) == 1)
                    {
                        Cuota cuota = new Cuota();
                        cuota.ID = (int)row["ID"];
                        cuota.ID_Cliente = (int)row["ID_Cliente"];
                        cuota.ID_Vivienda = (int)row["ID_Vivienda"];
                        cuota.Monto = Convert.ToDecimal(row["Monto"]);
                        cuota.FechaDeEmision = Convert.ToDateTime(row["FechaDeEmision"]);
                        cuota.FechaDeVencimiento = Convert.ToDateTime(row["FechaDeVencimiento"]);
                        cuotasPagas.Add(cuota);
                    }

                }
                return cuotasPagas;
            }
            return null;
        }

        public bool PagarCuota(Cuota cuota,int idCloser,decimal montoCloser)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Cuota",cuota.ID),
                new SqlParameter("@ID_Closer",idCloser),
                new SqlParameter("@ID_Cliente",cuota.ID_Cliente),
                new SqlParameter("@ID_Vivienda",cuota.ID_Vivienda),
                new SqlParameter("@MontoCloser",montoCloser),
                new SqlParameter("@MontoDueño",cuota.Monto)
            };
            return acceso.Escribir("PagarCuota", parameters);
        }
    }
}
