using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Propiedad:Entidad
    {
        public string TipoDeVivienda { get; set; }
        public string Direccion { get; set; }
        public int Ambientes {  get; set; }
        public string SuperficieTotal { get; set; }
        public string SuperficieCubierta { get; set; }
        public int Pisos { get; set; }
        public int Habitaciones { get; set; }
        public int Baños {  get; set; }
        public bool Cochera { get; set; }
        public int Antiguedad { get; set; }
        public bool Patio {  get; set; }
        public bool Pileta {  get; set; }

        public bool Aqluilada { get; set; }
        public decimal ValorDeCouta { get; set; }

        public List<byte[]> Imagenes = new List<byte[]>();
        public List<Etiqueta> Etiquetas = new List<Etiqueta>();
        public Propiedad() { }
        public Propiedad(string tipoDeVivienda, string direccion, int ambientes, string superficieTotal, string superficieCubierta, int pisos, int habitaciones, int baños, string cochera, int antiguedad, string patio, string pileta, decimal valorDeCouta)
        {
            TipoDeVivienda = tipoDeVivienda;
            Direccion = direccion;
            Ambientes = ambientes;
            SuperficieTotal = superficieTotal;
            SuperficieCubierta = superficieCubierta;
            Pisos = pisos;
            Habitaciones = habitaciones;
            Baños = baños;
            if (cochera == "SI")
            {
                Cochera = true;
            }
            else
            {
                Cochera = false;
            }
            Antiguedad = antiguedad;
            if(patio == "SI")
            {
                Patio = true;
            }
            else
            {
                Patio = false;
            }
            if (pileta == "SI")
            {
                Pileta = true;
            }
            else
            {
                Pileta = false;
            }
            ValorDeCouta = valorDeCouta;
        }
    }
}
