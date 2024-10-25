using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente:Usuario
    {
        public int ID_Usuario {  get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Inquilino { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Cliente() { }
        public Cliente(Usuario usuario,string nombre, string apellido, bool inqilino, DateTime fechaNacimiento) 
        {
            NombreDeUsuario = usuario.NombreDeUsuario;
            Sector = usuario.Sector;
            Clave = usuario.Clave;
            DV = usuario.DV;
            Mail = usuario.Mail;
            Nombre = nombre;
            Apellido = apellido;
            Inquilino = inqilino;
            FechaNacimiento = fechaNacimiento;
        }

        public Cliente(string nombre, string apellido, DateTime fechaNacimiento)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
        }

        public Cliente(Usuario usuario, string nombre, string apellido, DateTime fechaNacimiento)
        {
            NombreDeUsuario = usuario.NombreDeUsuario;
            Sector = usuario.Sector;
            Clave = usuario.Clave;
            DV = usuario.DV;
            Mail = usuario.Mail;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
        }
    }
}
