using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Servicios
{
    public class ManejoErrores
    {
        public static bool ValidarNombre(string cadena)
        {
            return (!string.IsNullOrEmpty(cadena) && Regex.IsMatch(cadena, @"^[a-zA-Z ]{1,30}$"));
        }

        public static bool ValidarClave(string cadena)
        {
            return (!string.IsNullOrEmpty(cadena) && Regex.IsMatch(cadena, @"^[a-zA-Z0-9]{1,30}$"));
        }

        public static bool ValidarMail(string cadena)
        {
            return (!string.IsNullOrEmpty(cadena) && Regex.IsMatch(cadena, @"^[a-zA-Z0-9._%+-]+@(gmail\.com|hotmail\.com|yahoo\.com)$"));
        }
    }
}
