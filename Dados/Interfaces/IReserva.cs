using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1classe
{
    internal interface IReserva
    {

        int ObterProximoIdReservaDisponivel();

        bool AdicionarReserva(Reserva r);


    }
}
