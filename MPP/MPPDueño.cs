using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPDueño
    {
        public MPPDueño() 
        {
            acceso = new Acceso();
            mppPermisos = new MPPPermisos();
            mppCuenta = new MPPCuenta();
            mppPropiedad = new MPPPropiedad();
        }
        Acceso acceso;
        MPPPermisos mppPermisos;
        MPPCuenta mppCuenta;
        MPPPropiedad mppPropiedad;
        public Dueño LeerDueño(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID",id),
            };
            DataTable dt = acceso.Leer("LeerDueño", parameters);
            if(dt.Rows.Count > 0)
            {
                Dueño dueño = new Dueño();
                foreach(DataRow row in dt.Rows)
                {
                    dueño.ID = (int)row["ID"];
                    dueño.Nombre = Convert.ToString(row["Nombre"]);
                    dueño.Apellido = Convert.ToString(row["Apellido"]);
                    dueño.Residencia = Convert.ToString(row["Residencia"]);
                    dueño.Mail = row["Mail"].ToString();
                    dueño.listaDeViviendas = mppPropiedad.LeerPropiedadesDeDueño(dueño.ID);
                    return dueño;
                }
            }
            return null;
        }


        public bool AltaDueño(Dueño dueño)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter id = new SqlParameter("@ID", dueño.ID);
            parameters.Add(id);
            SqlParameter nombre = new SqlParameter("@Nombre", dueño.Nombre);
            parameters.Add(nombre);
            SqlParameter apellido = new SqlParameter("@Apellido", dueño.Apellido);
            parameters.Add(apellido);
            SqlParameter residencia = new SqlParameter("@Residencia", dueño.Residencia);
            parameters.Add(residencia);
            if(acceso.Escribir("AltaDueño", parameters) && mppCuenta.AltaCuenta(dueño))
            {
                return mppPermisos.AgregarGrupoDePermisosAUsuario(28,dueño.NombreDeUsuario);
            }
            return false;
        }

        public bool AceptarCloserPostulado(Propiedad propiedad, Closer closer)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Vivienda",propiedad.ID),
                new SqlParameter("@ID_Closer",closer.ID)
            };
            if (acceso.Escribir("AceptarPostulado", parameters))
            {
                Servicios.EmailSender.EnviarMail("Postulación Aceptada", "Hola " + closer.Nombre + " " + closer.Apellido + " le informamos que ha sido aceptado para gestionar la vivienda con dirección " + propiedad.Direccion + " \n Saludos!!", closer.Mail);
                return true;
            }
            return false;
            
        }

        public bool RechazarCloserPostulado(Propiedad propiedad, Closer closer)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Vivienda",propiedad.ID),
                new SqlParameter("@ID_Closer",closer.ID)
            };
            if(acceso.Escribir("RechazarPostulado", parameters))
            {
                Servicios.EmailSender.EnviarMail("Postulación Rechazada", "Hola " + closer.Nombre + " " + closer.Apellido + " lamentamos informale que no ha sido aceptado para llevar la gestión de la vivienda con dirección " + propiedad.Direccion, closer.Mail);
                return true;
            }
            return false;
        }

        public bool DarDeBajaCloserACargo(Propiedad propiedad, Closer closer)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Vivienda",propiedad.ID),
                new SqlParameter("@ID_Closer",closer.ID),
            };
            if(acceso.Escribir("DarDeBajaCloserACargo", parameters))
            {
                Servicios.EmailSender.EnviarMail("Baja de Gestión","Hola " + closer.Nombre + " " + closer.Apellido + " lamentamos informale que se lo removido de la gestión de la vivienda con dirección " + propiedad.Direccion, closer.Mail);
                return true;
            }
            return false;
        }

        public bool ModificarDueño(Dueño dueño, int ID_Usuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter id = new SqlParameter("@ID_Usuario", ID_Usuario);
            parameters.Add(id);
            SqlParameter nombre = new SqlParameter("@Nombre", dueño.Nombre);
            parameters.Add(nombre);
            SqlParameter apellido = new SqlParameter("@Apellido", dueño.Apellido);
            parameters.Add(apellido);
            SqlParameter residencia = new SqlParameter("@Residencia", dueño.Residencia);
            parameters.Add(residencia);
            return acceso.Escribir("ModificarDueño", parameters);
        }

    }
}
