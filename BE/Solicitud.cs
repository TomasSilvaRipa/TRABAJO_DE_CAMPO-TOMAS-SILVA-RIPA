using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Solicitud:Entidad
    {
        
        public int ID_Vivienda { get; set; }
        
        public int ID_Cliente { get; set; }
        public DateTime Fecha { get; set; }

        public string Disponibilidad { get; set; }

        public Solicitud() { }

        public Solicitud(int iD_Vvienda, int iD_Cliente, DateTime fecha, string disponibilidad)
        {
            ID_Vivienda = iD_Vvienda;
            ID_Cliente = iD_Cliente;
            Fecha = fecha;
            Disponibilidad = disponibilidad;
        }
    }
}
