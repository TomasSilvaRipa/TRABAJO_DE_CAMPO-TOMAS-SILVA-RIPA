using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Dueño:Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Residencia { get; set; }

        public Dueño() { }

        public Dueño(Usuario usuario,string nombre, string apellido,string residencia)
        {
            NombreDeUsuario = usuario.NombreDeUsuario;
            Sector = usuario.Sector;
            Clave = usuario.Clave;
            DV = usuario.DV;
            Mail = usuario.Mail;
            Nombre = nombre;
            Apellido = apellido;
            Residencia = residencia;
        }
    }
}
