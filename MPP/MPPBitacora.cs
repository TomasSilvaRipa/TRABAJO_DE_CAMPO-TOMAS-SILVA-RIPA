using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Eventing.Reader;

namespace MPP
{
    public class MPPBitacora
    {

        #region CONSTRUCTOR
        public MPPBitacora()
        {
            acceso = new Acceso();
        }
        Acceso acceso;
        #endregion

        #region FUNCIONES
        public bool Add(Bitacora_ bitacora)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Fecha",bitacora.Fecha),
                new SqlParameter("@Tipo",bitacora.Tipo),
                new SqlParameter("@Usuario",bitacora.Usuario),
                new SqlParameter("@Mensaje",bitacora.Mensaje)
            };
            return acceso.Escribir("AgregarBitacora", parameters);
        }

        public List<Bitacora_> LeerBitacora()
        {
            List<Bitacora_> lista = new List<Bitacora_>();
            DataTable tabla = acceso.Leer("LeerBitacora");
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow r in tabla.Rows)
                {
                    Bitacora_ b = new Bitacora_();
                    b.ID = Convert.ToInt32(r["ID"]);
                    b.Fecha = Convert.ToDateTime(r["Fecha"]);
                    b.Tipo = (Bitacora_.BitacoraTipo)(r["Tipo"]);
                    b.Usuario = r["Usuario"].ToString();
                    b.Mensaje = r["Mensaje"].ToString();
                    lista.Add(b);
                }
            }
            return lista;
        }

        public List<Bitacora_> Filtrar(BitacoraFiltros bf, int tipoDeBusqueda)
        {
            List<Bitacora_> lista = new List<Bitacora_>();
            DataTable dt = new DataTable();
            if (tipoDeBusqueda == 1)
            {
                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                new SqlParameter("@Desde", bf.Desde),
                new SqlParameter("@Hasta", bf.Hasta)
                };
                dt = acceso.Leer("FiltrarBitacoraPorFecha", parameters);
            }
            else if (tipoDeBusqueda == 2)
            {
                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Tipo",bf.Tipo)
                };
                dt = acceso.Leer("FiltrarPorTipo", parameters);
            }
            else if(tipoDeBusqueda == 3)
            {
                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                   new SqlParameter("@Desde", bf.Desde),
                   new SqlParameter("@Hasta", bf.Hasta),
                   new SqlParameter("@Tipo",bf.Tipo)
                };
                dt = acceso.Leer("FiltrarCombinado", parameters);
            }
            
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    Bitacora_ b = new Bitacora_();
                    b.ID = Convert.ToInt32(r["ID"]);
                    b.Fecha = Convert.ToDateTime(r["Fecha"]);
                    b.Tipo = (Bitacora_.BitacoraTipo)(r["Tipo"]);
                    b.Usuario = r["Usuario"].ToString();
                    b.Mensaje = r["Mensaje"].ToString();
                    lista.Add(b);
                }
            }
            return lista;
        }
        #endregion
    }
}
