using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario: IVerificableEntidad
    {
        [PropiedadVerificable]
        public string Nombre { get; set; }

        [PropiedadVerificable]
        public string Sector { get; set; }

        [PropiedadVerificable]
        public string Clave { get; set; } 
        
        public string DV {  get; set; }

        public List<Permiso> Permisos = new List<Permiso>();
        public Usuario() { }

        public Usuario(string nombre, string sector)
        {
            Nombre = nombre;
            Sector = sector;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
