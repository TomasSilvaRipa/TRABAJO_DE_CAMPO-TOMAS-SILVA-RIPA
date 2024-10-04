using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Reunion: Entidad
    {
        public int ID_Dueño {  get; set; }
        public int ID_Vivienda { get; set; }
        public int ID_Closer {  get; set; }

        public int ID_Cliente { get; set; }
        public DateTime Fecha {  get; set; }

        public string Disponibilidad { get; set; }

        public Reunion() { }

        public Reunion(int iD_Dueño, int iD_Vvienda, int iD_Closer, int iD_Cliente, DateTime fecha, string disponibilidad)
        {
            ID_Dueño = iD_Dueño;
            ID_Vivienda = iD_Vvienda;
            ID_Closer = iD_Closer;
            ID_Cliente = iD_Cliente;
            Fecha = fecha;
            Disponibilidad = disponibilidad;
        }
    }
}
