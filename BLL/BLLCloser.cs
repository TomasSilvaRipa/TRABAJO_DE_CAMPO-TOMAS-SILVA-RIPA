using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCloser
    {
        public BLLCloser()
        {
            mppCloser = new MPPCloser();
        }
        MPPCloser mppCloser;

        public bool Postularse(Propiedad propiedad)
        {
            Sesion sesion = Sesion.ObtenerSesion();
            Usuario usuario = sesion.ObtenerUsuario();
            Closer closer = mppCloser.LeerCloser(usuario.ID);
            if (mppCloser.ComprobarExistenciaPostulado(closer, propiedad) == false)
            {
                return mppCloser.Postularse(closer, propiedad);
            }
            else
            {
                throw new Exception("Ya se ha postulado para gestionar esta vivienda");
            }

        }

        public List<Closer> LeerClosersPostulados(Propiedad propiedad)
        {
            return mppCloser.LeerClosersPostulados(propiedad);
        }

        public List<Propiedad> LeerViviendasXCloser(Closer closer)
        {
            return mppCloser.LeerPropiedadesXCloser(closer.ID);
        }

        public Closer LeerCloser(int ID)
        {
            return mppCloser.LeerCloser(ID);
        }
    }
}
