using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios;
using System.Data;
using BE;
using static System.Collections.Specialized.BitVector32;
using System.Diagnostics.Contracts;
using System.Data.SqlTypes;
using System.Reflection;

namespace MPP
{
    public class MPPUsuario
    {
        #region CONSTRUCTOR
        public MPPUsuario()
        {
            acceso = new Acceso();
        }
        Acceso acceso;
        #endregion

        #region FUNCIONES
        public Usuario BuscarUsuario(string nombre)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Usuario", nombre)
            };

            DataTable salida = acceso.Leer("BuscarUsuario", parameters);

            if (salida.Rows.Count > 0)
            {
                if (Convert.ToBoolean(salida.Rows[0][4]) == true)
                {
                    return new Usuario()
                    {
                        ID = Convert.ToInt32(salida.Rows[0][0]),
                        NombreDeUsuario = nombre,
                        Clave = salida.Rows[0][2].ToString().Trim(),
                        Sector = salida.Rows[0][3].ToString().Trim(),
                        DV = salida.Rows[0][5].ToString().Trim(),
                        Mail = salida.Rows[0][6].ToString().Trim()
                    };
                }
                else
                {
                    return new Usuario();
                }
                
            } else return new Usuario();
        }

        public bool InsertarUsuario(Usuario nuevoUsuario, string clave)
        {
            string ClaveEncriptada = Seguridad.Encriptar(clave);
            DateTime fecha = DateTime.Now;
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@usuario", nuevoUsuario.NombreDeUsuario),
                new SqlParameter("@clave", ClaveEncriptada),
                new SqlParameter("@sector", nuevoUsuario.Sector),
                new SqlParameter("@DigitoVerificador",nuevoUsuario.DV),
                new SqlParameter("@Mail",nuevoUsuario.Mail),
                new SqlParameter("Fecha",fecha)
            };
            return acceso.Escribir("InsertarUsuario", parameters);
        }

        public bool RemoverUsuario(string Nombre)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@nombre", Nombre)
            };
            return acceso.Escribir("DeleteUsuario", parameters);

        }

        public bool ActualizarUsuario(Usuario usuario,int opcion)
        {
            string ClaveEncriptada = Seguridad.Encriptar(usuario.Clave);
            DateTime fecha = DateTime.Now;
            if(opcion == 0)
            {
                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                new SqlParameter("@nombre", usuario.NombreDeUsuario),
                new SqlParameter("@sector", usuario.Sector),
                new SqlParameter("@clave", ClaveEncriptada),
                new SqlParameter("@DigitoVerificador",usuario.DV),
                new SqlParameter("@Mail",usuario.Mail),
                new SqlParameter("Fecha",fecha)
                };
                return acceso.Escribir("UpdateUsuario", parameters);
            }
            else
            {
                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                new SqlParameter("@nombre", usuario.NombreDeUsuario),
                new SqlParameter("@sector", usuario.Sector),
                new SqlParameter("@clave", usuario.Clave),
                new SqlParameter("@DigitoVerificador",usuario.DV),
                new SqlParameter("@Mail",usuario.Mail),
                new SqlParameter("Fecha",fecha)
                };
                return acceso.Escribir("UpdateUsuario", parameters);
            }
        }

        public bool ComprobarExistencia(string Nombre)
        {
            return (acceso.Leer("ComprobarExistenciaUsuario", new List<SqlParameter> { new SqlParameter("@nombre", Nombre)})).Rows.Count>0;
        }

        public List<Usuario> LeerUsuarios()
        {
            DataTable tablaUsuarios = acceso.Leer("LeerUsuarios");
            return (from Row in tablaUsuarios.AsEnumerable() where Convert.ToInt32(Row[4]) == 1
            select new Usuario
            {
                ID = Convert.ToInt32(Row[0]),
                NombreDeUsuario = Row[1].ToString().Trim(),
                Clave = Row[2].ToString().Trim(),
                Sector = Row[3].ToString().Trim(),
                DV = Row[5].ToString(),
                Mail = Row[6].ToString().Trim()
            }).ToList();
        }

        public string CalcularDigitoVerificadorHorizontal(IVerificableEntidad entidad)
        {
            Type t = entidad.GetType();
            string dvh = string.Empty;
            var props = t.GetProperties();

            foreach (var item in props)
            {
                var atributos = item.GetCustomAttributes();
                var verificable = atributos.FirstOrDefault(i => i.GetType().Equals(typeof(PropiedadVerificable)));
                if (verificable != null)
                {
                    if(item.GetValue(entidad) != null)
                    {
                        if(item.Name != "DV")
                        {
                           dvh += item.GetValue(entidad).ToString();
                        }
                    }
                }
            }
            return Seguridad.Encriptar(dvh);
        }

        public string ObtenerDigitoVerificadorVertical()
        {
            DataTable dt = acceso.Leer("LeerUsuarios", null);
            string DVV = string.Empty;
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    if (Convert.ToBoolean(row["Activo"]) == true)
                    {
                        DVV += row["DigitoVerificador"].ToString();
                    }
                }
                DVV = Servicios.Seguridad.Encriptar(DVV);
            }
            return DVV;
        }

        public List<GestorDeUsuario> LeerHistoricoDeUsuario(string nombre)
        {
            List<GestorDeUsuario> listaHistorico = new List<GestorDeUsuario>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Nombre",nombre)
            };
            DataTable dt = acceso.Leer("LeerGestorDeCambios",parameters);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    GestorDeUsuario historico = new GestorDeUsuario();
                    historico.ID = Convert.ToInt32(r["ID"]);
                    historico.Nombre = r["Nombre"].ToString();
                    historico.Clave = r["Clave"].ToString();
                    historico.Sector = r["Sector"].ToString();
                    historico.Mail = r["Mail"].ToString();
                    historico.DigitoVerificador = r["DigitoVerificador"].ToString();
                    historico.Fecha = Convert.ToDateTime(r["Fecha"]);
                    listaHistorico.Add(historico);
                }
                return listaHistorico;
            }
            return listaHistorico;
        }

        public string LeerDigitoVerificadorVertical(string NombreDeTabla)
        {
            string DV = string.Empty;
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Nombre",NombreDeTabla)
            };
            DataTable dt = acceso.Leer("LeerDigitoVerificadorVertical", parameters);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow r in dt.Rows)
                {
                    DV = r["DigitoVerificadorVertical"].ToString();
                }
                return DV;
            }
            return null;
        }

        public bool GestionarDigitoVerificadorVertical(string NombreDeTabla,int donde,string DV)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Donde",donde),
                new SqlParameter("@Nombre",NombreDeTabla),
                new SqlParameter("@DigitoVerificadorVertical",DV)
            };
            return acceso.Escribir("GestionarDigitoVerificadorVertical",parameters);
        }
        #endregion

    }
}
