using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Permiso:Entidad
    {
        public string Nombre {  get; set; }
        public List<Permiso> permisos =  new List<Permiso>();
        public override string ToString()
        {
            return Nombre;
        }

        public abstract void AgregarPermiso(Permiso p); 
    }
}
