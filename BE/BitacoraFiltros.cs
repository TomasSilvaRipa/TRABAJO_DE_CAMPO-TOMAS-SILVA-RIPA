using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BitacoraFiltros
    {
        #region PROPIEDADES
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public int Tipo { get; set; }

        #endregion

        #region CONSTRUCTORES

        public BitacoraFiltros() { }

        public BitacoraFiltros(DateTime desde,DateTime hasta,int tipo)
        {
            Desde = desde;
            Hasta = hasta;
            Tipo = tipo;
        }

        public BitacoraFiltros(DateTime desde, DateTime hasta)
        {
            Desde = desde;
            Hasta = hasta;
        }

        public BitacoraFiltros( int tipo)
        {
            Tipo = tipo;
        }
        #endregion
    }
}
