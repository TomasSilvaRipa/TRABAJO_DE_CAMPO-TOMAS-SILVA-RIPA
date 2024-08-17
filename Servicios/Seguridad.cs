using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public static class Seguridad
    {
        public static string Encriptar(string cadena)
        {
            UnicodeEncoding UeCodigo = new UnicodeEncoding();
            byte[] ByteSourceText = UeCodigo.GetBytes(cadena);
            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
            byte[] ByteHash = Md5.ComputeHash(ByteSourceText);
            return Convert.ToBase64String(ByteHash);
        }

    }
}
