using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1classe;
using _2classe;

namespace Projeto_POO_25985
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente(1, "rafa", 123, "RUA DO CAEALHP", 92);

            cliente.ToString();
            Console.ReadKey();

        }
    }
}
