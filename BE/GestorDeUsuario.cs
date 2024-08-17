using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GestorDeUsuario:Entidad
    {
        public string Nombre {  get; set; }
        public string Clave { get; set; }
        public string Sector { get; set; }
        public string DigitoVerificador { get; set; }

        public DateTime Fecha { get; set; }

        public GestorDeUsuario() { }
        public GestorDeUsuario(string nombre, string clave, string sector, string digitoVerificador, DateTime fecha)
        {
            Nombre = nombre;
            Clave = clave;
            Sector = sector;
            DigitoVerificador = digitoVerificador;
            Fecha = fecha;
        }
    }
}
