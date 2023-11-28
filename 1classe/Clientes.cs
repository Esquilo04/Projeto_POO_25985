using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2classe;

namespace _1classe
{
    public class Clientes
    {
        public static List<Cliente> clientes;
        public static bool InsereCliente(Cliente c)
        {
            if (clientes.Contains(c)) return false;
            clientes.Add(c);
            return true;
        }
    }
}
