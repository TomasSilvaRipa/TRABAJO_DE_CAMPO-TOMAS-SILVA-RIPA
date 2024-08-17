using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IObservable
    {
        List<IObservador> Observadores { get; set; }
        void AgregarObservador(IObservador observador);
        void QuitarObservador(IObservador observador);
        void Notificar();
    }
}
