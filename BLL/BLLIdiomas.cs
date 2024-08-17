using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;

namespace BLL
{
    public class BLLIdiomas
    {
        public void AltaTraduccion(DataTable tablaEditada, string Idioma)
        {
            MPPIdiomas mPPIdiomas = new MPPIdiomas();
            mPPIdiomas.AltaTraduccion(tablaEditada, Idioma);
        }

        public void BajaTraduccion(int IdTraduccion)
        {
            MPPIdiomas mPPIdiomas = new MPPIdiomas();
            mPPIdiomas.BajaTraduccion(IdTraduccion);
        }

        public void ModificarTraduccion(DataTable tablaTraduccionEditable, int IdIdioma)
        {
            MPPIdiomas mPPIdiomas = new MPPIdiomas();
            mPPIdiomas.ModificarTraduccion(tablaTraduccionEditable, IdIdioma);
        }

        public DataTable ObtenerIdiomas()
        {
            MPP.MPPIdiomas mppIdiomas = new MPP.MPPIdiomas();
            return mppIdiomas.ObtenerIdiomas();
        }


        public DataTable ObtenerPalabras()
        {
            MPP.MPPIdiomas mppIdiomas = new MPP.MPPIdiomas();
            return mppIdiomas.ObtenerPalabras();
        }
        
        public DataTable ObtenerTraducciones(int idioma)
        {
            MPP.MPPIdiomas mppIdiomas = new MPP.MPPIdiomas();
            return mppIdiomas.ObtenerTraduccion(idioma);
        }

        public Dictionary<string, string> ObtenerDiccionario(int idioma)
        {
            DataTable tablaTraduccion = ObtenerTraducciones(idioma);
            DataTable tablaPalabras = ObtenerPalabras();

            var filasCoincidentes = from palabra in tablaPalabras.AsEnumerable()
                                    join traduccion in tablaTraduccion.AsEnumerable()
                                    on palabra.Field<int>(0) equals traduccion.Field<int>(1)
                                    select new { Palabra = palabra.Field<string>(1), Traduccion = traduccion.Field<string>(2) };



            Dictionary<string, string> traducciones = new Dictionary<string, string>();
            foreach (var row in filasCoincidentes)
            {
                string palabra = row.Palabra.Trim();
                string traduccion = row.Traduccion.Trim();
                traducciones.Add(palabra, traduccion);
            }
            return traducciones;
        }
    }
}
