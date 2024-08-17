using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora_ : Entidad
    {
        #region PROPIEDADES
        public DateTime Fecha { get; set; }
        public BitacoraTipo Tipo { get; set; }
        public string Usuario { get; set; }
        public string Mensaje { get; set; }

        public enum BitacoraTipo
        {
            INFO = 1,
            ERROR = 2,
            VALIDACION = 3
        }
        #endregion

        #region CONSTRUCTORES
        public Bitacora_() { }

        public Bitacora_(BitacoraTipo tipo, string usuario, string mensaje)
        {

            Fecha = DateTime.Now.Date;
            Tipo = tipo;
            Usuario = usuario;
            Mensaje = mensaje;
        }
        #endregion
    }
}
