using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPOpinion
    {
        public MPPOpinion()
        {
            acceso = new Acceso();
        }
        Acceso acceso;

        public bool AltaOpinion(Opinion opinion)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Usuario",opinion.ID_Usuario),
                new SqlParameter("@Reseña",opinion.Reseña),
                new SqlParameter("@Calificacion",opinion.Calificacion),
            };
            return acceso.Escribir("AltaOpinion", parameters);
        }

        public List<Opinion> LeerOpiniones(Usuario usuario,int opcion)
        {
            List<Opinion> opiniones = new List<Opinion>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID",usuario.ID),
                new SqlParameter("@Opcion",opcion)
            };
            DataTable dt = acceso.Leer("LeerOpiniones",parameters);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in  dt.Rows)
                {
                    Opinion opinion = new Opinion();
                    opinion.ID = (int)row["ID"];
                    opinion.ID_Usuario = (int)row["ID_Usuario"];
                    opinion.Reseña = row["Reseña"].ToString();
                    opinion.Calificacion = (int)row["Calificacion"];
                    opiniones.Add(opinion);
                }
                return opiniones;
            }
            return null;
        }
    }
}
