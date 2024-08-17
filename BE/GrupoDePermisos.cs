using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GrupoDePermisos : Permiso
    {
        public GrupoDePermisos(string nombre)
        {
            Nombre = nombre;
        }

        public override void AgregarPermiso(Permiso p)
        {
            permisos.Add(p);
        }

        public GrupoDePermisos() { }
    }
}
