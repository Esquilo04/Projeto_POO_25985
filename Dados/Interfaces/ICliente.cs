/*
 * Classe responsavel em enunciar funções relacionadas aos Clientes
 * Nuno Oliveira
 * a25985@alunos.ipca.pt
 * 19-12-2023
 * POO-ESI
 * **/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    internal interface ICliente
    {
        /// <summary>
        /// Adiciona um novo cliente.
        /// </summary>
        bool AdicionarCliente(Cliente c);

        /// <summary>
        /// Mostra todos os clientes.
        /// </summary>
        void MostrarClientes();

        /// <summary>
        /// Mostra um cliente com base no ID fornecido.
        /// </summary>
        Cliente MostrarClientePorId(int id);

        /// <summary>
        /// Verifica se o ID do cliente existe.
        /// </summary>
        bool VerificarIdExistente(int id);

        /// <summary>
        /// Guarda os clientes em um arquivo.
        /// </summary>
        bool GuardarClientes(string d);

        /// <summary>
        /// Lê os clientes de um arquivo.
        /// </summary>
        bool LerClientes(string d);

        /// <summary>
        /// Remove um cliente.
        /// </summary>
        bool RemoverCliente(Cliente cliente);

        /// <summary>
        /// Obtém um cliente com base no ID fornecido.
        /// </summary>
        Cliente ObterClientePorId(int id);

        /// <summary>
        /// Obtém o próximo ID disponível para cliente.
        /// </summary>
        int ObterProximoIdDisponivel();

        /// <summary>
        /// Altera um dado de um cliente com base na opção e ID fornecidos.
        /// </summary>
        bool AlterarDadoCliente(int opcao, int id);
    }

}
