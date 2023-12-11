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
    public class Clientes
    {
        #region ESTADOS

        private List<Cliente> clientes;

        public Clientes()
        {
            clientes = new List<Cliente>(); // Inicializa a lista de clientes no construtor
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

        public bool AdicionarCliente(Cliente c)
        {
            clientes.Add(c);
            return true;
        }


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

        public Cliente MostrarClientePorId(int id)
        {
            foreach (Cliente cliente in CLIENTES)
            {
                if (cliente.IdCliente == id)
                {
                    Console.WriteLine("Dados do cliente:");
                    Console.WriteLine(cliente.ToString());
                    return cliente; // Retorna o cliente se o ID for encontrado
                }
            }

            return null; // Retorna null se o cliente com o ID especificado não for encontrado
        }

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

        public void RemoverCliente(Cliente cliente)
        {
            if (clientes.Contains(cliente))
            {
                clientes.Remove(cliente);
                Console.WriteLine("Cliente removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado na lista.");
            }
        }

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
