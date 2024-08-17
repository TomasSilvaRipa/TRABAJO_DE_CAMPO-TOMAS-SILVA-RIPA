using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Servicios;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using BE;
using MPP;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Bienvenido! \n \n");

            string entrada = "";
            while (entrada != "q") 
            {
                Console.WriteLine("\nIngrese un comando \n");
                entrada = Console.ReadLine();
                try
                {
                    switch (entrada)
                    {
                        case "insertar usuario":
                            InsertarUsuario();
                            break;
                        case "leer usuarios":
                            LeerUsuarios();
                            break;
                        case "comprobar usuario":
                            ComprobarUsuario();
                            break;
                        case "test":
                            ProbarSesiones();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void LeerUsuarios2()
        {
            List<Usuario> listaUsuarios = MPPUsuario.LeerUsuarios();

            foreach (Usuario usuario in listaUsuarios)
            {
                Console.WriteLine(usuario.Nombre);
            }
        }

        static void LeerUsuarios()
        {
            Console.WriteLine("Usuarios en la tabla: \n");
            DataTable TablaUsuarios = Acceso.Leer("LeerUsuarios");

            foreach (DataRow Row in TablaUsuarios.Rows)
            {
                Console.WriteLine("Usuario: " + Row[0] + " Clave: " + Row[1]);
            }
        }
        static void ComprobarUsuario()
        {
            Console.WriteLine("Nombre del Usuario: \n");

            string nombre = Console.ReadLine();

            Console.WriteLine("Clave del Usuario: \n");

            string contra = Console.ReadLine();

            string ClaveEncriptada = Seguridad.Encriptar(contra);

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@usuario", nombre),
                new SqlParameter("@clave", ClaveEncriptada),
            };

            var salida = Acceso.Leer("BuscarUsuario", parameters);

            if (salida.Rows.Count > 0)
            {
                Console.WriteLine("Credenciales válidas");
            }
            else
            {
                Console.WriteLine("Credenciales no validas \n");
            }
        }
        static void InsertarUsuario()
        {
            Console.WriteLine("Nombre del nuevo Usuario: ");

            string nombre = Console.ReadLine();

            Console.WriteLine("Clave del nuevo Usuario: ");

            string contra = Console.ReadLine();

            Console.WriteLine("Sector del nuevo Usuario: ");

            string Sector= Console.ReadLine();

            string ClaveEncriptada = Seguridad.Encriptar(contra);

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@usuario", nombre),
                new SqlParameter("@clave", ClaveEncriptada),
                new SqlParameter("@sector", Sector)
            };

            Acceso.Escribir("InsertarUsuario", parameters);
        }


        static void ProbarSesiones()
        {
            Usuario usuario = new Usuario();

            Console.WriteLine("Se instanció un nuevo usuario");

            Console.WriteLine("Nombre del nuevo Usuario: ");

            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Clave del nuevo Usuario: ");

            usuario.Clave = Console.ReadLine();

            Sesion sesionIniciada = Sesion.ObtenerSesion();

            Console.WriteLine("Se creo una sesion");

            sesionIniciada.IniciarUsuario(usuario);

            Console.WriteLine("Se establecio el usuario");

            Console.WriteLine($"{usuario.Nombre} {usuario.Clave}");
        }
    }
}
