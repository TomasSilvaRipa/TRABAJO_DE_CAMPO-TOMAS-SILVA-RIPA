using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Reunion: Entidad
    {
        public int ID_Vivienda { get; set; }
        public int ID_Closer {  get; set; }

        public int ID_Cliente { get; set; }
        public DateTime Fecha {  get; set; }

        public string Direccion {  get; set; } 

        public string NombreCloser { get; set; }

        public string Hora { get; set; }

        public Reunion() { }

        public Reunion( int iD_Vivienda, int iD_Closer, int iD_Cliente, DateTime fecha, string hora)
        {
            ID_Vivienda = iD_Vivienda;
            ID_Closer = iD_Closer;
            ID_Cliente = iD_Cliente;
            Fecha = fecha;
            Hora = hora;
        }

        
    }
}
