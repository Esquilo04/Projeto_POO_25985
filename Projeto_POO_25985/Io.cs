/*
 * Classe responsavel por operações de entrada/saída (I/O)
 * Nuno Oliveira
 * a25985@alunos.ipca.pt
 * 15-11-2023
 * POO-ESI
 * **/


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dados;
using Objetos;

namespace Projeto_POO_25985
{
    /// <summary>
    /// Classe responsável por operações de entrada/saída (I/O) para diferentes classes do sistema.
    /// </summary>
    public class Io
    {

        #region Cliente
        /// <summary>
        /// Region utilizada para operações de I/O relacionadas com Clientes.
        /// </summary>



        /// <summary>
        /// Adiciona um novo cliente.
        /// </summary>
        /// <param name="cliente">O cliente a ser adicionado</param>
        public void AdicionarCliente(out string nome, out int nif, out string morada, out int tel)
        {
            Console.WriteLine("Qual o nome do cliente?");
            nome = Console.ReadLine();

            Console.WriteLine("Qual o NIF do cliente?");
            nif = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual a morada do cliente?");
            morada = Console.ReadLine();

            Console.WriteLine("Qual o telemovel do cliente?");
            tel = int.Parse(Console.ReadLine());
        }

        public void ObterIdCliente(out int id)
        {
            Console.WriteLine("Qual o ID do cliente?");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                id = int.Parse(Console.ReadLine());
            }
            
        }


        public int AlterarDadoCliente(out int dado)
        {
            int aux = 0;
            bool entradaValida = false;

            while (!entradaValida)
            {
                Console.WriteLine("Qual o dado que deseja alterar?");
                Console.WriteLine("1 - Nome do cliente.");
                Console.WriteLine("2 - Nif do cliente.");
                Console.WriteLine("3 - Morada do cliente.");
                Console.WriteLine("4 - Telemovel do cliente.");
                aux = int.Parse(Console.ReadLine());

                if (aux >= 1 && aux <= 4)
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Introduza uma opção válida.");
                }
            }
            dado = aux;
            return aux; // Se necessário, você pode retornar o valor escolhido
        }

        public void MenuClientes(out int opcao)
        {
            Console.WriteLine("\nO que deseja fazer?");
            Console.WriteLine("1 - Adicionar cliente");
            Console.WriteLine("2 - Apagar cliente");
            Console.WriteLine("3 - Mostrar todos os clientes");
            Console.WriteLine("4 - Mostrar determinado cliente");
            Console.WriteLine("5 - Alterar determinado dado do cliente");
            Console.WriteLine("0 - Sair");
            opcao = int.Parse(Console.ReadLine());
        }

        #endregion



        #region Check_in
        /// <summary>
        /// Region utilizada para operações de I/O relacionadas com Check-in.
        /// </summary>



        /// <summary>
        /// Realiza o check-in de um cliente.
        /// </summary>
        /// <param name="check_in">O objeto Check_in associado ao check-in</param>
        void fazerCheck_in(Check_in check_in) { }

        #endregion



        #region Reserva
        /// <summary>
        /// Region utilizada para operações de I/O relacionadas com Reservas.
        /// </summary>



        /// <summary>
        /// Faz uma reserva de alojamento.
        /// </summary>
        /// <param name="reserva">O objeto Reserva associado à reserva</param>
        void fazerReserva(Reserva reserva) { }

        #endregion



        #region Consulta
        /// <summary>
        /// Region utilizada para operações de I/O relacionadas com Consultas de Dados de Clientes e Alojamentos.
        /// </summary>



        /// <summary>
        /// Consulta os dados de um cliente.
        /// </summary>
        /// <param name="cliente">O cliente cujos dados são consultados</param>
        void consultarDadosCliente(Cliente cliente) { }

        #endregion



        #region Registo
        /// <summary>
        /// Região utilizada para operações de I/O relacionadas com Registo de Alojamentos e Clientes.
        /// </summary>



        /// <summary>
        /// Regista um novo alojamento.
        /// </summary>
        void registarAlojamento(Alojamento alojamento) { }

        #endregion



        #region Alojamento
        /// <summary>
        /// Região utilizada para operações de I/O relacionadas com Alojamentos.
        /// </summary>


        public void AdicionarAlojamento(out string morada, out int numeroQuartos, out int classificacao, out int disponibilidade)
        {
            Console.WriteLine("Qual a morada do alojamento?");
            morada = Console.ReadLine();

            Console.WriteLine("Quantos quartos tem o alojamento?");
            numeroQuartos = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual a classificacao do alojamento?");
            classificacao = int.Parse(Console.ReadLine());

            disponibilidade = 0;  //começa em 0 pois está disponivel
        }

        public void ObterIdAlojamento(out int id)
        {
            Console.WriteLine("Qual o ID do alojamento?");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                id = int.Parse(Console.ReadLine());
            }
        }

        public void MenuAlojamentos(out int opcao2)
        {
            Console.WriteLine("\nO que deseja fazer?");
            Console.WriteLine("1 - Adicionar alojamento");
            Console.WriteLine("2 - Apagar alojamento");
            Console.WriteLine("3 - Mostrar todos os alojamentos");
            Console.WriteLine("4 - Mostrar determinado alojamento");
            Console.WriteLine("5 - Alterar determinado dado de determinado alojamento");
            Console.WriteLine("0 - Sair");
            opcao2 = int.Parse(Console.ReadLine());
        }

        public int AlterarDadoAlojamento(out int dado)
        {
            int aux = 0;
            bool entradaValida = false;

            while (!entradaValida)
            {
                Console.WriteLine("Qual o dado que deseja alterar?");
                Console.WriteLine("1 - Morada do alojamento.");
                Console.WriteLine("2 - Numero de quartos.");
                Console.WriteLine("3 - Classificacao do alojamento.");
                aux = int.Parse(Console.ReadLine());

                if (aux >= 1 && aux <= 3)
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Introduza uma opção válida.");
                }
            }
            dado = aux;
            return aux; // Se necessário, você pode retornar o valor escolhido
        }


        public void MenuGestor(out int opcaogestor)
        {
            Console.WriteLine("\nO que deseja fazer?");
            Console.WriteLine("1 - Gerir dados dos Clientes");
            Console.WriteLine("2 - Gerir dados dos Alojamentos");
            Console.WriteLine("3 - Gerir dados das Reservas");
            Console.WriteLine("0 - Sair");
            opcaogestor = int.Parse(Console.ReadLine());
        }

        #endregion


        #region Reserva

        public string ConverterRegime()
        {
            bool entradaValida = false;
            string regimeConvertido = "";

            while (!entradaValida)
            {
                Console.WriteLine("Qual o regime da reserva?");
                Console.WriteLine("1 - Meia Pensão.");
                Console.WriteLine("2 - Pensão Completa.");
                Console.WriteLine("3 - Tudo Incluído.");

                string opcaoRegime = Console.ReadLine();

                switch (opcaoRegime)
                {
                    case "1":
                        regimeConvertido = "mp";
                        entradaValida = true;
                        break;
                    case "2":
                        regimeConvertido = "pc";
                        entradaValida = true;
                        break;
                    case "3":
                        regimeConvertido = "ti";
                        entradaValida = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, selecione 1, 2 ou 3.");
                        break;
                }
            }
            return regimeConvertido;
        }

        public void AdicionarReserva(out int numeroHospedes, out DateTime dataEntrada, out DateTime dataSaida, out string regime)
        {

            Console.WriteLine("Quantos hóspedes na reserva?");
            numeroHospedes = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual a data de entrada (dd/mm/aaaa)?");
            dataEntrada = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("Qual a data de saída (dd/mm/aaaa)?");
            dataSaida = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            regime = ConverterRegime();

        }

        public void MenuReservas(out int opcao3)
        {
            Console.WriteLine("\nO que deseja fazer?");
            Console.WriteLine("1 - Adicionar reserva");
            Console.WriteLine("2 - Apagar reserva");
            Console.WriteLine("3 - Mostrar todas as reservas");
            Console.WriteLine("4 - Mostrar determinada reserva");
            Console.WriteLine("0 - Sair");
            opcao3 = int.Parse(Console.ReadLine());
        }

        public void ObterIdReserva(out int id)
        {
            Console.WriteLine("Qual o ID da reserva?");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                id = int.Parse(Console.ReadLine());
            }
        }
        #endregion
    }
}
