/*
 * Classe responsavel por desenvolver funções relacionadas com Clientes
 * Nuno Oliveira
 * a25985@alunos.ipca.pt
 * 19-12-2023
 * POO-ESI
 * **/
using Objetos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace Dados
{
    public class Clientes : ICliente
    {
        #region ESTADOS

        private List<Cliente> clientes;

        /// <summary>
        /// Inicializa a lista de clientes no construtor
        /// </summary>
        public Clientes()
        {
            clientes = new List<Cliente>();
        }

        #endregion

        #region PROPRIEDADES

        public List<Cliente> CLIENTES
        {
            get { return clientes; }
            set { clientes = value; }
        }


        #endregion

        #region OUTROSMETODOS

        /// <summary>
        /// Adiciona um cliente à lista
        /// </summary>
        /// <param name="c">lista dos clientes</param>
        /// <returns></returns>
        public bool AdicionarCliente(Cliente c)
        {
            clientes.Add(c);
            return true;
        }

        /// <summary>
        /// Mostra todos os clientes na consola
        /// </summary>
        public void MostrarClientes()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente foi adicionado ainda.");
                return;
            }

            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine(cliente.ToString());
            }
        }

        /// <summary>
        /// Mostra determinado cliente atraves do seu id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public Cliente MostrarClientePorId(int id)
        {
            foreach (Cliente cliente in CLIENTES)
            {
                if (cliente.IdCliente == id)
                {
                    Console.WriteLine("Dados do cliente:");
                    Console.WriteLine(cliente.ToString());
                    return cliente; 
                }
            }

            return null; 
        }

        /// <summary>
        /// Verifica se determinado id ja existe
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public bool VerificarIdExistente(int id)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.IdCliente == id)
                {
                    return true; // Retorna verdadeiro se o ID for encontrado na lista de clientes
                }
            }
            return false; // Retorna falso se o ID não for encontrado na lista de clientes
        }

        /// <summary>
        /// Guarda os dados dos clientes em um ficheiro e texto
        /// </summary>
        /// <param name="d">Variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarClientes(string d)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(d))
                {
                    foreach (var clientes in clientes)
                    {
                        writer.WriteLine($"{clientes.IdCliente}#{clientes.NomeCliente}#{clientes.NifCliente}#{clientes.MoradaCliente}#{clientes.TelemovelCliente}");
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao gravar produtos: {e.Message}");
                return false;
            };
        }

        /// <summary>
        /// LÊ os dados dos clientes de um ficheiro de texto
        /// </summary>
        /// <param name="d">Variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerClientes(string d)
        {
            try
            {
                using (StreamReader sr = File.OpenText(d))
                {
                    string linha = sr.ReadLine();
                    while (linha != null)
                    {
                        string[] sdados = linha.Split('#');
                        int id = int.Parse(sdados[0]);
                        string nome = sdados[1];
                        int nif = int.Parse(sdados[2]);
                        string morada = sdados[3];
                        int telemovel = int.Parse(sdados[4]);

                        Cliente cliente = new Cliente(id, nome, nif, morada, telemovel);

                        clientes.Add(cliente);

                        linha = sr.ReadLine();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler clientes: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Remove determinado cliente da lista
        /// </summary>
        /// <param name="cliente">lista dos clientes</param>
        /// <returns></returns>
        public bool RemoverCliente(Cliente cliente)
        {
            if (clientes.Contains(cliente))
            {
                clientes.Remove(cliente);
                Console.WriteLine("Cliente removido com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Cliente não encontrado na lista.");
                return false;
            }
        }

        /// <summary>
        /// Obtem determinado cliente atraves do seu id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public Cliente ObterClientePorId(int id)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.IdCliente == id)
                {
                    return cliente;
                }
            }
            return null; // Retorna null se não encontrar nenhum cliente com o ID especificado
        }

        /// <summary>
        /// Obtem o proximo id disponivel
        /// </summary>
        /// <returns></returns>
        public int ObterProximoIdDisponivel()
        {
            List<int> idsExistentes = new List<int>();

            // Percorre a lista de clientes para obter todos os IDs existentes
            foreach (Cliente cliente in clientes)
            {
                idsExistentes.Add(cliente.IdCliente);
            }

            // Ordena os IDs existentes em ordem crescente
            idsExistentes.Sort();

            // Verifica o próximo ID disponível
            int proximoId = 1; // O menor ID possível é 1

            foreach (int idExistente in idsExistentes)
            {
                // Se o próximo ID for igual ao ID existente, incrementa o próximo ID
                if (proximoId == idExistente)
                {
                    proximoId++;
                }
                else
                {
                    // Se encontrar um ID diferente, retorna o próximo ID disponível
                    return proximoId;
                }
            }

            return proximoId; // Se não houver IDs disponíveis entre os existentes, retorna o próximo número
        }

        /// <summary>
        /// Altera determinado dado de um cliente
        /// </summary>
        /// <param name="opcao">opcao que escolheu</param>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public bool AlterarDadoCliente(int opcao, int id)
        {
            foreach(Cliente cliente in clientes)
            {
                if(cliente.IdCliente == id)
                {
                    switch (opcao)
                    {
                        case 1: 
                            Console.WriteLine("Qual o novo nome?");
                            string nome = Console.ReadLine();
                            cliente.NomeCliente = nome;
                            break;
                        case 2:
                            Console.WriteLine("Qual o novo NIF");
                            int nif = int.Parse(Console.ReadLine());
                            cliente.NifCliente = nif;
                            break;
                        case 3:
                            Console.WriteLine("Qual a nova morada?");
                            string morada = Console.ReadLine();
                            cliente.MoradaCliente = morada;
                            break;
                        case 4:
                            Console.WriteLine("Qual o novo telemovel?");
                            int telemovel = int.Parse(Console.ReadLine());
                            cliente.TelemovelCliente = telemovel;
                            break;
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
