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
    public class MPPPropiedad
    {
        public MPPPropiedad()
        {
            acceso = new Acceso();
        }
        Acceso acceso;
        
        public bool AltaPropiedad(Propiedad propiedad,int id, List<byte[]> imagenesEnBytes)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Dueño",id),
                new SqlParameter("@TipoDeVivienda",propiedad.TipoDeVivienda),
                new SqlParameter("@Direccion",propiedad.Direccion),
                new SqlParameter("@Ambientes",propiedad.Ambientes),
                new SqlParameter("@SuperficieTotal",propiedad.SuperficieTotal),
                new SqlParameter("@SuperficieCubierta",propiedad.SuperficieCubierta),
                new SqlParameter("@Pisos",propiedad.Pisos),
                new SqlParameter("@Habitaciones",propiedad.Habitaciones),
                new SqlParameter("@Baños",propiedad.Baños),
                new SqlParameter("@Cochera",propiedad.Cochera),
                new SqlParameter("@Antiguedad",propiedad.Antiguedad),
                new SqlParameter("@Patio",propiedad.Patio),
                new SqlParameter("@Pileta",propiedad.Pileta),
                new SqlParameter("@ValorCuota",propiedad.ValorDeCouta),
            };

            if (acceso.Escribir("AltaPropiedad", parameters))
            {
                parameters.Clear();
                
                foreach (byte[] imagen in imagenesEnBytes)
                {
                    SqlParameter parametro = new SqlParameter("@Imagen", imagen);
                    parameters.Add(parametro);
                    SqlParameter dueño = new SqlParameter("@ID_Dueño",id);
                    parameters.Add(dueño);
                    SqlParameter direccion = new SqlParameter("@Direccion", propiedad.Direccion);
                    parameters.Add(direccion);
                    acceso.Escribir("SubirFotosVivienda",parameters);
                    parameters.Clear(); 
                    
                }
                return true;
            }
            return true;
        }
    }
}
