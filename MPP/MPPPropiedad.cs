using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPPropiedad
    {
        public MPPPropiedad()
        {
            acceso = new Acceso();
        }
        Acceso acceso;
        
        public bool AltaPropiedad(Propiedad propiedad,int id, List<byte[]> imagenesEnBytes)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Dueño",id),
                new SqlParameter("@TipoDeVivienda",propiedad.TipoDeVivienda),
                new SqlParameter("@Direccion",propiedad.Direccion),
                new SqlParameter("@Ambientes",propiedad.Ambientes),
                new SqlParameter("@SuperficieTotal",propiedad.SuperficieTotal),
                new SqlParameter("@SuperficieCubierta",propiedad.SuperficieCubierta),
                new SqlParameter("@Pisos",propiedad.Pisos),
                new SqlParameter("@Habitaciones",propiedad.Habitaciones),
                new SqlParameter("@Baños",propiedad.Baños),
                new SqlParameter("@Cochera",propiedad.Cochera),
                new SqlParameter("@Antiguedad",propiedad.Antiguedad),
                new SqlParameter("@Patio",propiedad.Patio),
                new SqlParameter("@Pileta",propiedad.Pileta),
                new SqlParameter("@ValorCuota",propiedad.ValorDeCouta),
            };

            if (acceso.Escribir("AltaVivienda", parameters) && SubirImagenesPorPropiedad(imagenesEnBytes,id,propiedad.Direccion) && SubirEtiquetasPorPropiedad(propiedad.Direccion,propiedad.Etiquetas))
            {
                return true;
            }
            return false;
        }

        public bool ModificarPropiedad(Propiedad propiedad, int id, List<byte[]> imagenesEnBytes)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID",propiedad.ID),
                new SqlParameter("@TipoDeVivienda",propiedad.TipoDeVivienda),
                new SqlParameter("@Direccion",propiedad.Direccion),
                new SqlParameter("@Ambientes",propiedad.Ambientes),
                new SqlParameter("@SuperficieTotal",propiedad.SuperficieTotal),
                new SqlParameter("@SuperficieCubierta",propiedad.SuperficieCubierta),
                new SqlParameter("@Pisos",propiedad.Pisos),
                new SqlParameter("@Habitaciones",propiedad.Habitaciones),
                new SqlParameter("@Baños",propiedad.Baños),
                new SqlParameter("@Cochera",propiedad.Cochera),
                new SqlParameter("@Antiguedad",propiedad.Antiguedad),
                new SqlParameter("@Patio",propiedad.Patio),
                new SqlParameter("@Pileta",propiedad.Pileta),
                new SqlParameter("@ValorCuota",propiedad.ValorDeCouta),
            };

            if (acceso.Escribir("ModificarVivienda", parameters) && BorrarImagenesVivienda(propiedad.ID,imagenesEnBytes,id,propiedad.Direccion) && SubirImagenesPorPropiedad(imagenesEnBytes, id, propiedad.Direccion) && BorrarEtiquetasPorPropiedad(propiedad.ID) && SubirEtiquetasPorPropiedad(propiedad.Direccion, propiedad.Etiquetas))
            {
                return true;
            }
            return false;
        }


        public bool BajaPropiedad(Propiedad propiedad)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Vivienda",propiedad.ID),
            };
            return acceso.Escribir("BajaVivienda", parameters);
            
        }

        public List<Propiedad> LeerPropiedades(int opcion, int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter Opcion = new SqlParameter("@Opcion", opcion);
            parameters.Add(Opcion);
            if(id != 0)
            {
                SqlParameter idCliente = new SqlParameter("@ID_Cliente", id);
                parameters.Add(idCliente);
            }
            else
            {
                SqlParameter idCliente = new SqlParameter("@ID_Cliente", DBNull.Value);
                parameters.Add(idCliente);
            }
            List<Propiedad> listaDeViviendas = new List<Propiedad>();
            DataTable dt = acceso.Leer("LeerViviendas",parameters);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Propiedad propiedad = new Propiedad();
                    propiedad.ID = (int)row["ID"];
                    propiedad.Ambientes = (int)row["Ambientes"];
                    propiedad.TipoDeVivienda = row["TipoDeVivienda"].ToString();
                    propiedad.Antiguedad = (int)row["Antiguedad"];
                    propiedad.Baños = (int)row["Baños"];
                    propiedad.Cochera = (bool)row["Cochera"];
                    propiedad.Patio = (bool)row["Patio"];
                    propiedad.Pisos = (int)row["Pisos"];
                    propiedad.Direccion = row["Direccion"].ToString();
                    propiedad.SuperficieCubierta = row["SuperficieCubierta"].ToString();
                    propiedad.SuperficieTotal = row["SuperficieTotal"].ToString();
                    propiedad.Pileta = (bool)row["Pileta"];
                    propiedad.Habitaciones = (int)row["Habitaciones"];
                    propiedad.ValorDeCouta = (decimal)row["ValorCuota"];
                    propiedad.Aqluilada = Convert.ToBoolean(row["Alquilada"]);
                    propiedad.Imagenes = LeerImagenesPorPropiedad(propiedad.ID);
                    propiedad.Etiquetas = LeerEtiquetasPorPropiedad(propiedad.ID);
                    listaDeViviendas.Add(propiedad);
                }
                return listaDeViviendas;    
            }
            return null;
        }

        public List<Propiedad> LeerPropiedadesDeDueño(int id)
        {
            List<Propiedad> listaPropiedades = new List<Propiedad>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter ID = new SqlParameter("@ID", id);
            parameters.Add(ID);
            DataTable dt = acceso.Leer("LeerViviendasDeDueño",parameters);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Propiedad propiedad = new Propiedad();
                    propiedad.ID = (int)row["ID"];
                    propiedad.Ambientes = (int)row["Ambientes"];
                    propiedad.TipoDeVivienda = row["TipoDeVivienda"].ToString();
                    propiedad.Antiguedad = (int)row["Antiguedad"];
                    propiedad.Baños = (int)row["Baños"];
                    propiedad.Cochera = (bool)row["Cochera"];
                    propiedad.Patio = (bool)row["Patio"];
                    propiedad.Pisos = (int)row["Pisos"];
                    propiedad.Direccion = row["Direccion"].ToString();
                    propiedad.SuperficieCubierta = row["SuperficieCubierta"].ToString();
                    propiedad.SuperficieTotal = row["SuperficieTotal"].ToString();
                    propiedad.Pileta = (bool)row["Pileta"];
                    propiedad.Habitaciones = (int)row["Habitaciones"];
                    propiedad.ValorDeCouta = (decimal)row["ValorCuota"];
                    propiedad.Aqluilada = Convert.ToBoolean(row["Alquilada"]);
                    propiedad.Imagenes = LeerImagenesPorPropiedad(propiedad.ID);
                    propiedad.Etiquetas = LeerEtiquetasPorPropiedad(propiedad.ID);
                    listaPropiedades.Add(propiedad);
                }
                return listaPropiedades;
            }
            return null;
        }

        public bool SubirImagenesPorPropiedad(List<byte[]> imagenesEnBytes, int ID_Dueño,string Direccion)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (byte[] imagen in imagenesEnBytes)
            {
                SqlParameter parametro = new SqlParameter("@Imagen", imagen);
                parameters.Add(parametro);
                SqlParameter dueño = new SqlParameter("@ID_Dueño", ID_Dueño);
                parameters.Add(dueño);
                SqlParameter direccion = new SqlParameter("@Direccion", Direccion);
                parameters.Add(direccion);
                acceso.Escribir("SubirFotosVivienda", parameters);
                parameters.Clear();
            }
            return true;
        }

        public bool BorrarImagenesVivienda(int ID_Vivienda, List<byte[]> imagenesEnBytes, int ID_Dueño, string Direccion)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter ID = new SqlParameter("@ID", ID_Vivienda);
            parameters.Add(ID);
            return acceso.Escribir("BorrarImagenesVivienda", parameters); 
        }


        public bool SubirEtiquetasPorPropiedad(string Direccion,List<Etiqueta> Etiquetas)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (Etiqueta e in Etiquetas)
            {
                SqlParameter ID = new SqlParameter("@Direccion", Direccion);
                parameters.Add(ID);
                SqlParameter ID_Etiqueta = new SqlParameter("@ID_Etiqueta", e.ID);
                parameters.Add((ID_Etiqueta));
                acceso.Escribir("SubirEtiquetaXVivienda",parameters);
                parameters.Clear();
            }
            return true;
        }

        public bool BorrarEtiquetasPorPropiedad(int ID_Vivienda)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter ID = new SqlParameter("@ID_Vivienda", ID_Vivienda);
            parameters.Add(ID);
            return acceso.Escribir("BorrarEtiquetasVivienda", parameters);
        }

        public List<byte[]> LeerImagenesPorPropiedad(int id)
        {
            List<byte[]> Imagenes = new List<byte[]>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter ID = new SqlParameter("@ID", id);
            parameters.Add(ID);
            DataTable dt = acceso.Leer("LeerImagenesPorVivienda", parameters);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    byte[] imagen = (byte[])row["Imagen"];
                    Imagenes.Add(imagen);
                }
                return Imagenes;
            }
            return null;
        }

        public List<Etiqueta> LeerEtiquetasPorPropiedad(int id)
        {
            List<Etiqueta> etiquetas = new List<Etiqueta>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Vivienda",id),
            };
            DataTable dt = acceso.Leer("LeerEtiquetasXVivienda", parameters);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    Etiqueta e = new Etiqueta();
                    e.ID = (int)row["ID"];
                    e.Nombre = row["Nombre"].ToString();
                    etiquetas.Add(e);
                }
                return etiquetas;
            }
            return null;
        }

        public bool ComprobarViviendaBabjoGestion(Propiedad propiedad)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("ID_Vivienda",propiedad.ID),
            };
            DataTable dt = acceso.Leer("ComprobarViviendaBajoGestion",parameters);
            if(dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ComprobarAlquileres()
        {
            return acceso.Escribir("ComprobarAlquileres");
        }

        
    }
}
