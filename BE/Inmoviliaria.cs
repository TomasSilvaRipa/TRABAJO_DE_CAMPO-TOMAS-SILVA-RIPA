using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Inmoviliaria:Usuario
    {
        public int ID_Usuario {  get; set; }
        public string Nombre { get; set; }
        
        public Inmoviliaria() { }
        public Inmoviliaria(Usuario usuario,string nombre)
        {
            NombreDeUsuario = usuario.NombreDeUsuario;
            Sector = usuario.Sector;
            Clave = usuario.Clave;
            DV = usuario.DV;
            Mail = usuario.Mail;
            Nombre = nombre;
        }
    }
}
