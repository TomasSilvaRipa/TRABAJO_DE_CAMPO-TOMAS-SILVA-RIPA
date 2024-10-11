using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cuota:Entidad
    {
        public int ID_Vivienda { get; set; }
        public int ID_Cliente { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaDeEmision { get; set; }
        public DateTime FechaDeVencimiento { get; set; }

        public Cuota() { }

        public Cuota(int iD_Vivienda, int iD_Cliente, decimal monto, DateTime fechaDeEmision, DateTime fechaDeVencimiento)
        {
            ID_Vivienda = iD_Vivienda;
            ID_Cliente = iD_Cliente;
            Monto = monto;
            FechaDeEmision = fechaDeEmision;
            FechaDeVencimiento = fechaDeVencimiento;
        }
    }
}
