using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Closer:Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Clasificacion { get; set; }
        public int TratosCerrados { get; set; }

        public Closer() { }
        public Closer(Usuario usuario,string nombre,string apellido,string clasificacion, int tratosCerrados)
        {
            NombreDeUsuario = usuario.NombreDeUsuario;
            Sector = usuario.Sector;
            Clave = usuario.Clave;
            DV = usuario.DV;
            Mail = usuario.Mail;
            Nombre = nombre;
            Apellido = apellido;
            Clasificacion = clasificacion;
            TratosCerrados = tratosCerrados;
        }
    }
}
