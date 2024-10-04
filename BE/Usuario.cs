using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario: Entidad,IVerificableEntidad
    {
        [PropiedadVerificable]
        public string NombreDeUsuario { get; set; }

        [PropiedadVerificable]
        public string Sector { get; set; }

        [PropiedadVerificable]
        public string Clave { get; set; }

        [PropiedadVerificable]
        public string Mail { get; set; }

        public string DV {  get; set; }

        public List<Permiso> Permisos = new List<Permiso>();

        public byte[] Foto { get; set; }
        public Usuario() { }

        public Usuario(string nombre, string sector)
        {
            NombreDeUsuario = nombre;
            Sector = sector;
        }

        public Usuario(string nombre, string sector, string mail)
        {
            NombreDeUsuario = nombre;
            Sector = sector;
            Mail = mail;
        }

        //public Usuario(string nombre, string sector, string mail, byte[] foto)
        //{
        //    NombreDeUsuario = nombre;
        //    Sector = sector;
        //    Mail = mail;
        //    Foto = foto;
        //}

        public override string ToString()
        {
            return NombreDeUsuario;
        }
    }
}
