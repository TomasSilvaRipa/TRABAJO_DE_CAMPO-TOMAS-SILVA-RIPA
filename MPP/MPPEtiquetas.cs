using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;
using System.Data;
namespace MPP
{
    public class MPPEtiquetas
    {
        public MPPEtiquetas()
        {
            acceso = new Acceso();
        }
        Acceso acceso;

        public List<Etiqueta> LeerEtiquetas()
        {
            List<Etiqueta> Etiquetas = new List<Etiqueta>();
            DataTable dt = acceso.Leer("LeerEtiquetas");
            if(dt.Rows.Count > 0 )
            {
                foreach(DataRow row in dt.Rows )
                {
                    Etiqueta e = new Etiqueta();
                    e.ID = (int)row["ID"];
                    e.Nombre = row["Nombre"].ToString();
                    Etiquetas.Add(e);
                }
                return Etiquetas;
            }
            return null;
        }
    }
}
