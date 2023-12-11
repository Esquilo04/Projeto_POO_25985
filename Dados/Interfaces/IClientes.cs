using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    internal interface IClientes
    {
        bool AdicionarCliente(Cliente c);

        void MostrarClientes();

        void MostrarClientePorId(int id);

        bool VerificarIdExistente(int id);

        bool GuardarClientes(string d);

        bool LerClientes(string d);

        void RemoverCliente(Cliente cliente);

        Cliente ObterClientePorId(int id);

        int ObterProximoIdDisponivel();

    }
}
