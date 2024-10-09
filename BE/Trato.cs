using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Trato:Entidad
    {
        public int ID_Closer { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Dueño { get; set; }
        public int ID_Vivienda { get; set; }

        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeFinalizacion { get; set; }

        public Trato(int iD_Closer, int iD_Cliente, int iD_Dueño, int iD_Vivienda, DateTime fechaDeInicio, DateTime fechaDeFinalizacion)
        {
            ID_Closer = iD_Closer;
            ID_Cliente = iD_Cliente;
            ID_Dueño = iD_Dueño;
            ID_Vivienda = iD_Vivienda;
            FechaDeInicio = fechaDeInicio;
            FechaDeFinalizacion = fechaDeFinalizacion;
        }
        public Trato(int iD_Closer, int iD_Cliente, int iD_Vivienda, DateTime fechaDeInicio, DateTime fechaDeFinalizacion)
        {
            ID_Closer = iD_Closer;
            ID_Cliente = iD_Cliente;
            ID_Vivienda = iD_Vivienda;
            FechaDeInicio = fechaDeInicio;
            FechaDeFinalizacion = fechaDeFinalizacion;
        }
    }
}
