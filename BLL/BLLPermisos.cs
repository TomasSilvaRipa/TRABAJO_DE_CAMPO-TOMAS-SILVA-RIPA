using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace BLL
{
    public class BLLPermisos
    {
        public BLLPermisos()
        {
            mppPermisos = new MPPPermisos();
        }
        MPPPermisos mppPermisos;

        public List<Permiso> LeerPermisos()
        {
            return mppPermisos.LeerPermisos();
        }

        public bool AgregarGrupo(GrupoDePermisos g)
        {
            return mppPermisos.AgregarGrupo(g);
        }
        public List<GrupoDePermisos> LeerGruposDePermisos()
        {
            return mppPermisos.LeerGruposDePermisos();
        }

        public List<Permiso> CargarPermisosTreeNode(int idGrupo)
        {
            return mppPermisos.CargarPermisosTreeNode(idGrupo);
        }

        public bool CrearRelacionesDePermisos(int idPadre, int idHijo)
        {
            return mppPermisos.CrearRelacionesDePermisos(idPadre,idHijo);
        }

        public bool IdentificarSiEsPadre(int idPermiso)
        {
            return mppPermisos.IdentificarSiEsPadre(idPermiso);
        }

        public bool BorrarPermisoDeGrupo(int idPadre,int idHijo)
        {
            return mppPermisos.BorrarPermisoDeGrupo(idPadre,idHijo);
        }

        public bool AgregarGrupoDePermisosAUsuario(int idGrupo, string usuarioNombre)
        {
            return mppPermisos.AgregarGrupoDePermisosAUsuario(idGrupo, usuarioNombre);
        }

        public List<Permiso> LeerPermisosXUsuario(string nombre)
        {
            return mppPermisos.LeerPermisosXUsuario(nombre);
        }

        public bool QuitarPermisosDeUsuario(string nombre,int id)
        {
            return mppPermisos.QuitarPermisos(nombre,id);
        }

        public List<Permiso> TraerGrupoDePermisos(int idPadre)
        {
            return mppPermisos.TraerHijos(idPadre);
        }
    }
}
