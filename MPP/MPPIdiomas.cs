using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace MPP
{
    public class MPPIdiomas
    {
        public void AltaTraduccion(DataTable tablaEditada, string idioma)
        {
            Acceso ad = new Acceso();

            string valores = "";

            foreach (DataRow row in tablaEditada.Rows)
            {

                string traduccion = row["Traduccion"].ToString();
                traduccion = traduccion.TrimStart(); 
                traduccion = traduccion.TrimEnd(); 

                valores += row["ID"].ToString() + "," + traduccion + ";";
            }

            ad.Escribir("AgregarIdioma", new List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("@NombreIdioma", idioma), new System.Data.SqlClient.SqlParameter("@Traducciones", valores) });
        }

        public void BajaTraduccion(int idTraduccion)
        {
            Acceso ad = new Acceso();
            ad.Escribir("EliminarIdioma", new List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("@IdIdioma", idTraduccion) });
        }

        public void ModificarTraduccion(DataTable tablaTraduccionEditable, int idIdioma)
        {
            Acceso ad = new Acceso();

            string valores = "";

            foreach (DataRow row in tablaTraduccionEditable.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row["Traduccion"].ToString().Trim()))
                {
                    string traduccion = row["Traduccion"].ToString().Trim().Replace(",", "").Replace(";", "");

                    valores += row["Codigo"].ToString() + "," + traduccion + ";";
                }
            }

            if (!string.IsNullOrEmpty(valores))
            {
                ad.Escribir("UpdateIdioma", new List<System.Data.SqlClient.SqlParameter>()
                {
                    new System.Data.SqlClient.SqlParameter("@IdIdioma", idIdioma),
                    new System.Data.SqlClient.SqlParameter("@Traducciones", valores)
                });
            }
            else
            {
                throw new Exception("No hay cambios en las traducciones.");
            }
        }

        public DataTable ObtenerIdiomas()
        {
            try
            {
                Acceso ad = new Acceso();
                return ad.Leer("LeerIdiomas");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerPalabras()
        {
            try
            {
                Acceso ad = new Acceso();
                return ad.Leer("LeerPalabras");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ObtenerTraduccion(int idioma) {
            try
            {
                Acceso ad = new Acceso();

                return ad.Leer("LeerTraduccion", new List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("@IdIdioma", idioma) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
