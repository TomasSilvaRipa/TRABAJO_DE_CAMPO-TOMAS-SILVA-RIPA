using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IObservador
    {
       void Notificar(Object Sender);
    }
}
