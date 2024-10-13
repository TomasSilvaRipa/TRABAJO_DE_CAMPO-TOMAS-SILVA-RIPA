using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Opinion:Entidad
    {
        public int ID_Usuario {  get; set; }
        public string Reseña { get; set; }
        public int Calificacion {  get; set; }

        public Opinion() { }

        public Opinion(int iD_Usuario, string reseña, int calificacion)
        {
            ID_Usuario = iD_Usuario;
            Reseña = reseña;
            Calificacion = calificacion;
        }
    }
}
