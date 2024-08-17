using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace MPP
{
    public class MPPPermisos
    {
        public MPPPermisos()
        {
            acceso = new Acceso();
        }
        Acceso acceso;

        public List<Permiso> LeerPermisos()
        {
            List<Permiso> listaPermisos = new List<Permiso>();
            DataTable t = acceso.Leer("LeerPermisos",null);
            if (t.Rows.Count > 0)
            {
                foreach(DataRow r in t.Rows)
                {
                    PermisoSimple p = new PermisoSimple();
                    p.ID = Convert.ToInt32(r["ID"]);
                    p.Nombre = r["Nombre"].ToString();
                    listaPermisos.Add(p);
                }
            }
            return listaPermisos;
        }

       public bool AgregarGrupo(GrupoDePermisos g)
       {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Nombre", g.Nombre),
            };
            return acceso.Escribir("CrearGrupoDePermisos",parameters);
       }

        public List<GrupoDePermisos> LeerGruposDePermisos()
        {
            List<GrupoDePermisos> listaGrupos = new List<GrupoDePermisos>();
            DataTable dt;
            dt = acceso.Leer("LeerGruposDePermisos", null);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow r in dt.Rows)
                {
                    GrupoDePermisos gp = new GrupoDePermisos();
                    gp.ID = Convert.ToInt32(r["ID"]);
                    gp.Nombre = r["Nombre"].ToString();
                    listaGrupos.Add(gp);
                }
                return listaGrupos;
            }
            return null;
        }

        public GrupoDePermisos BuscarPermisoPadre(int idP)
        {
            DataTable dt;
            List<SqlParameter> parameters = new List<SqlParameter>();
            GrupoDePermisos gp = new GrupoDePermisos();
            SqlParameter prmtr = new SqlParameter("@ID", idP);
            parameters.Add(prmtr);
            dt = acceso.Leer("LeerPermisos", parameters);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dtr in dt.Rows)
                {
                    gp.ID = Convert.ToInt32(dtr["ID"]);
                    gp.Nombre = dtr["Nombre"].ToString();
                    return gp;
                }
            }
            return null; 
        }

        public PermisoSimple BuscarPermisoHijo(int id)
        {
            DataTable dt;
            List<SqlParameter> parameters = new List<SqlParameter>();
            PermisoSimple p = new PermisoSimple();
            SqlParameter prmtr = new SqlParameter("@ID", id);
            parameters.Add(prmtr);
            dt = acceso.Leer("LeerPermisos", parameters);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dtr in dt.Rows)
                {
                    p.ID = Convert.ToInt32(dtr["ID"]);
                    p.Nombre = dtr["Nombre"].ToString();
                    return p;
                }
            }
            return null;
        }

        public bool IdentificarSiEsPadre(int id)
        {
            DataTable dt;
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@ID", id);
            parameters.Add(p);
            dt = acceso.Leer("LeerPermisos", parameters);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dtr in dt.Rows)
                {
                    if (Convert.ToInt32(dtr["EsPadre"]) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public List<Permiso> TraerHijos(int id)
        {
            DataTable dt;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<Permiso> listaPermisos = new List<Permiso>(); 
            SqlParameter p = new SqlParameter("@IDGrupo", id);
            parameters.Add(p);
            dt = acceso.Leer("LeerPermisosXGrupo", parameters);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dtr in dt.Rows)
                {
                    if (IdentificarSiEsPadre(Convert.ToInt32(dtr["ID_PermisoHijo"])))
                    {
                        GrupoDePermisos gp = BuscarPermisoPadre(Convert.ToInt32(dtr["ID_PermisoHijo"]));
                        List<Permiso> listaPH = new List<Permiso>();
                        listaPH = TraerHijos(Convert.ToInt32(dtr["ID_PermisoHijo"]));
                        foreach(Permiso lp in listaPH)
                        {
                            gp.AgregarPermiso(lp);
                        }
                        listaPermisos.Add(gp);
                    }
                    else
                    {
                        PermisoSimple pS = BuscarPermisoHijo(Convert.ToInt32(dtr["ID_PermisoHijo"]));
                        listaPermisos.Add(pS);
                    }
                }
            }
            return listaPermisos;
        }

        public List<Permiso> CargarPermisosTreeNode(int idGrupo)
        {
            List<Permiso> listaP = new List<Permiso>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@IDGrupo", idGrupo);
            parameters.Add(p);
            DataTable dt;
            GrupoDePermisos grupoPadre = BuscarPermisoPadre(idGrupo);
            listaP.Add(grupoPadre);
            dt = acceso.Leer("LeerPermisosXGrupo", parameters);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow r in dt.Rows)
                {
                    if (Convert.ToInt32(r["ID_PermisoPadre"]) != Convert.ToInt32(r["ID_PermisoHijo"]))
                    {
                        if (IdentificarSiEsPadre(Convert.ToInt32(r["ID_PermisoHijo"])))
                        {
                            GrupoDePermisos gp = BuscarPermisoPadre(Convert.ToInt32(r["ID_PermisoHijo"]));
                            gp.permisos = TraerHijos(gp.ID);
                            listaP.Add(gp);
                        }
                        else
                        {
                            PermisoSimple pS = new PermisoSimple();
                            pS = BuscarPermisoHijo(Convert.ToInt32(r["ID_PermisoHijo"]));
                            listaP.Add(pS);
                        }
                    }
                }
            }
            return listaP;
        }

        public bool CrearRelacionesDePermisos(int idPadre, int idHijo)
        {
            int donde = 0;
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
               new SqlParameter("@Donde",donde),
               new SqlParameter("@ID_PermisoPadre",idPadre),
               new SqlParameter("@ID_PermisoHijo",idHijo)
            };
            return acceso.Escribir("CrearOBorrarRelacionesDePermisos", parameters);
        }

        public bool BorrarPermisoDeGrupo(int idPadre, int idHijo)
        {
            int donde = 1;
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Donde",donde),
                new SqlParameter("@ID_PermisoPadre",idPadre),
                new SqlParameter("@ID_PermisoHijo",idHijo)
            };
            return acceso.Escribir("CrearOBorrarRelacionesDePermisos", parameters);
        }

        public bool AgregarGrupoDePermisosAUsuario(int idGrupo, string usuarioNombre)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_GrupoDePermisos",idGrupo),
                new SqlParameter("@Nombre",usuarioNombre)
            };
            return acceso.Escribir("AgregarGrupoDePermisosAUsuario",parameters);
        }

        public List<Permiso> LeerPermisosXUsuario(string nombre)
        {
            List<Permiso> listaPermisos = new List<Permiso>();
            GrupoDePermisos g = new GrupoDePermisos();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@NombreDeUsuario",nombre)
            };
            DataTable dt = new DataTable();
            dt = acceso.Leer("LeerPermisosXUsuario",parameters);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    g = BuscarPermisoPadre(Convert.ToInt32(r["ID_GrupoDePermisos"]));
                    g.permisos = TraerHijos(Convert.ToInt32(r["ID_GrupoDePermisos"]));
                    listaPermisos.Add(g);
                }
            }
            return listaPermisos;
        }

        public bool QuitarPermisos(string nombre,int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@NombreDeUsuario",nombre),
                new SqlParameter("@ID",id)
            };
            return acceso.Escribir("QuitarPermisosDeUsuario",parameters);
        }
        
    }
}
