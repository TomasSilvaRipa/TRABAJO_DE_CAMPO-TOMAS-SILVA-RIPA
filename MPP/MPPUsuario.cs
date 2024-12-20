﻿using DAL;
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
                        Usuario usuario = new Usuario();
                        usuario.ID = Convert.ToInt32(salida.Rows[0][0]);
                        usuario.NombreDeUsuario = salida.Rows[0][1].ToString().Trim();
                        usuario.Clave = salida.Rows[0][2].ToString().Trim();
                        usuario.Sector = salida.Rows[0][3].ToString().Trim();
                        usuario.DV = salida.Rows[0][5].ToString();
                        usuario.Mail = salida.Rows[0][6].ToString().Trim();
                        if (salida.Rows[0][7] != DBNull.Value && ((byte[])salida.Rows[0][7]).Length > 0)
                        {
                            usuario.Foto = (byte[])salida.Rows[0][7];
                        }
                        return usuario;
                }
                else
                {
                    return new Usuario();
                }
                
            } 
            else return new Usuario();
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
                new SqlParameter("@Fecha",fecha)
            };
            if(acceso.Escribir("InsertarUsuario", parameters))
            {
                Servicios.EmailSender.EnviarMail("Usuario creado!","Su usuario ha sido creado", nuevoUsuario.Mail);
                return true;
            }
            return false;
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
            SqlParameter fotoParam = new SqlParameter("@Foto", SqlDbType.VarBinary);

            if (usuario.Foto != null)
            {
                fotoParam.Value = usuario.Foto; // Si hay foto, la asignamos
            }
            else
            {
                fotoParam.Value = DBNull.Value; // Si no hay foto, asignamos DBNull.Value
            }
            if (opcion == 0)
            {
                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                new SqlParameter("@nombre", usuario.NombreDeUsuario),
                new SqlParameter("@sector", usuario.Sector),
                new SqlParameter("@clave", ClaveEncriptada),
                new SqlParameter("@DigitoVerificador",usuario.DV),
                new SqlParameter("@Mail",usuario.Mail),
                fotoParam,
                new SqlParameter("@Fecha",fecha)
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
                fotoParam,
                new SqlParameter("@Fecha",fecha)
                };
                return acceso.Escribir("UpdateUsuario", parameters);
            }
        }

        public bool ComprobarExistencia(Usuario usuario)
        {
            return (acceso.Leer("ComprobarExistenciaUsuario", new List<SqlParameter> { new SqlParameter("@Nombre", usuario.NombreDeUsuario), new SqlParameter("@Mail",usuario.Mail)})).Rows.Count>0;
        }


        public List<Usuario> LeerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            DataTable tablaUsuarios = acceso.Leer("LeerUsuarios");
            if(tablaUsuarios.Rows.Count > 0)
            {
                foreach(DataRow row in tablaUsuarios.Rows)
                {
                    if (Convert.ToInt32(row["Activo"]) != 0)
                    {
                        Usuario usuario = new Usuario();
                        usuario.ID = Convert.ToInt32(row[0]);
                        usuario.NombreDeUsuario = row[1].ToString().Trim();
                        usuario.Clave = row[2].ToString().Trim();
                        usuario.Sector = row[3].ToString().Trim();
                        usuario.DV = row[5].ToString();
                        usuario.Mail = row[6].ToString().Trim();
                        if (row["Foto"] != DBNull.Value && ((byte[])row["Foto"]).Length > 0) 
                        {
                            usuario.Foto = (byte[])row["Foto"];
                        }
                        usuarios.Add(usuario);
                    }
                }
               return usuarios;
            }
            return null;
        }

        public bool ComprobarExistenciaCuentaInmoviliaria()
        {
            DataTable dt = acceso.Leer("LeerUsuarios");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Sector"].ToString() == "Inmoviliaria")
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
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
