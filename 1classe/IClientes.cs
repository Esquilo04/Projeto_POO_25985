using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1classe
{
    internal interface IClientes
    {
        Cliente adicionarCliente(Cliente c, int id, string nome, int nif, string morada, int tel);
    }
}
