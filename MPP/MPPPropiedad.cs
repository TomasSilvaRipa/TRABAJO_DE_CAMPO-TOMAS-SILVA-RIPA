using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

            if (acceso.Escribir("AltaVivienda", parameters))
            {
                parameters.Clear();
                
                foreach (byte[] imagen in imagenesEnBytes)
                {
                    SqlParameter parametro = new SqlParameter("@Imagen", imagen);
                    parameters.Add(parametro);
                    SqlParameter dueño = new SqlParameter("@ID_Dueño",id);
                    parameters.Add(dueño);
                    SqlParameter direccion = new SqlParameter("@Direccion", propiedad.Direccion);
                    parameters.Add(direccion);
                    acceso.Escribir("SubirFotosVivienda",parameters);
                    parameters.Clear(); 
                    
                }
                return true;
            }
            return true;
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

            if (acceso.Escribir("ModificarVivienda", parameters))
            {
                parameters.Clear();
                SqlParameter ID = new SqlParameter("@ID", propiedad.ID);
                parameters.Add(ID);
                if (acceso.Escribir("BorrarImagenesVivienda", parameters))
                {
                    parameters.Clear();
                    foreach (byte[] imagen in imagenesEnBytes)
                    {
                        SqlParameter parametro = new SqlParameter("@Imagen", imagen);
                        parameters.Add(parametro);
                        SqlParameter dueño = new SqlParameter("@ID_Dueño", id);
                        parameters.Add(dueño);
                        SqlParameter direccion = new SqlParameter("@Direccion", propiedad.Direccion);
                        parameters.Add(direccion);
                        acceso.Escribir("SubirFotosVivienda", parameters);
                        parameters.Clear();

                    }
                    return true;
                }
            }
            return false;
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
                    propiedad.Imagenes = LeerImagenesPorPropiedad(propiedad.ID);
                    listaPropiedades.Add(propiedad);
                }
                return listaPropiedades;
            }
            return null;
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
    }
}
