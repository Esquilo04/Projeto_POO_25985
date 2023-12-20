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
        private Clientes clientes;
        private Alojamentos alojamentos;
        private Reservas reservas;
        private Check_Ins check_Ins;

        public Io()
        {
            clientes = new Clientes();
            alojamentos = new Alojamentos();
            reservas = new Reservas();
            check_Ins = new Check_Ins();
        }

        /// <summary>
        /// Region utilizada para operações de I/O relacionadas com Clientes.
        /// </summary>
        #region Cliente

        
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

        /// <summary>
        /// Obtem o id do cliente
        /// </summary>
        /// <param name="id">id do cliente</param>
        public void ObterIdCliente(out int id)
        {
            Console.WriteLine("Qual o ID do cliente?");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                id = int.Parse(Console.ReadLine());
            }
            
        }

        /// <summary>
        /// Altera determinado dado de um cliente
        /// </summary>
        /// <param name="dado">opcao escolhida</param>
        /// <returns></returns>
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

        /// <summary>
        /// Menu dos clientes
        /// </summary>
        /// <param name="opcao">opcao escolhida</param>
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



        #region Alojamento
        /// <summary>
        /// Região utilizada para operações de I/O relacionadas com Alojamentos.
        /// </summary>


        
        public void AdicionarAlojamento(out string morada, out int numeroQuartos, out int classificacao, out int disponibilidade, out int valorNoite)
        {
            Console.WriteLine("Qual a morada do alojamento?");
            morada = Console.ReadLine();

            Console.WriteLine("Quantos quartos tem o alojamento?");
            numeroQuartos = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual a classificacao do alojamento?");
            classificacao = int.Parse(Console.ReadLine());

            disponibilidade = 0;  //começa em 0 pois está disponivel

            Console.WriteLine("Qual o valor por noite do alojamento?");
            valorNoite = int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Obtem o id do alojamento
        /// </summary>
        /// <param name="id">id do alojamento</param>
        public void ObterIdAlojamento(out int id)
        {
            Console.WriteLine("Qual o ID do alojamento?");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                id = int.Parse(Console.ReadLine());
            }
        }

        /// <summary>
        /// Menu com os dados dos alojamentos
        /// </summary>
        /// <param name="opcao2">opcao escolhida</param>
        public void MenuAlojamentos(out int opcao2)
        {
            Console.WriteLine("\nO que deseja fazer?");
            Console.WriteLine("1 - Adicionar alojamento");
            Console.WriteLine("2 - Apagar alojamento");
            Console.WriteLine("3 - Mostrar todos os alojamentos");
            Console.WriteLine("4 - Mostrar determinado alojamento");
            Console.WriteLine("5 - Alterar determinado dado de determinado alojamento");
            Console.WriteLine("6 - Alterar disponibilidade de determinado alojamento");
            Console.WriteLine("7 - Mostrar alojamentos disponiveis");
            Console.WriteLine("0 - Sair");
            opcao2 = int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Altera dterminado de um alojamento
        /// </summary>
        /// <param name="dado">opcao escolhida</param>
        /// <returns></returns>
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

        /// <summary>
        /// Menu dos gestores com opcao para os outros menus
        /// </summary>
        /// <param name="opcaogestor">opcao escolhida</param>
        public void MenuGestor(out int opcaogestor)
        {
            Console.WriteLine("\nO que deseja fazer?");
            Console.WriteLine("1 - Gerir dados dos Clientes");
            Console.WriteLine("2 - Gerir dados dos Alojamentos");
            Console.WriteLine("3 - Gerir dados das Reservas");
            Console.WriteLine("4 - Gerir dados dos Check_Ins");
            Console.WriteLine("0 - Sair");
            opcaogestor = int.Parse(Console.ReadLine());
        }

        #endregion



        #region Reserva


        /// <summary>
        /// Converte o valor int para string
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Adiciona os dados de uma reserva
        /// </summary>
        /// <param name="numeroHospedes">numero de hospedes</param>
        /// <param name="dataEntrada">data de entrada</param>
        /// <param name="dataSaida">data de saida</param>
        /// <param name="regime">data de saida</param>
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

        /// <summary>
        /// Menu das reservas
        /// </summary>
        /// <param name="opcao3">opcao escolhida</param>
        public void MenuReservas(out int opcao3)
        {
            Console.WriteLine("\nO que deseja fazer?");
            Console.WriteLine("1 - Adicionar reserva");
            Console.WriteLine("2 - Apagar reserva");
            Console.WriteLine("3 - Mostrar todas as reservas");
            Console.WriteLine("4 - Mostrar determinada reserva");
            Console.WriteLine("5 - Alterar determinado dado de determinada reserva");
            Console.WriteLine("0 - Sair");
            opcao3 = int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Obtem o id de uma reserva
        /// </summary>
        /// <param name="id">id da reserva</param>
        public void ObterIdReserva(out int id)
        {
            Console.WriteLine("Qual o ID da reserva?");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                id = int.Parse(Console.ReadLine());
            }
        }

        /// <summary>
        /// Altera os dados de uma reserva
        /// </summary>
        /// <param name="dado">opcao escolhida</param>
        /// <returns></returns>
        public int AlterarDadoReserva(out int dado)
        {
            int aux = 0;
            bool entradaValida = false;

            while (!entradaValida)
            {
                Console.WriteLine("Qual o dado que deseja alterar?");
                Console.WriteLine("1 - Numero de hospedes da reserva.");
                Console.WriteLine("2 - Data de entrada.");
                Console.WriteLine("3 - Data de saida.");
                Console.WriteLine("4 - Regime da estadia.");
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
            return aux;
        }
        #endregion



        #region Check_In

        /// <summary>
        /// Menu do Check_in
        /// </summary>
        /// <param name="opcao4">opcao escolhida</param>
        public void MenuCheck_Ins(out int opcao4)
        {
            Console.WriteLine("\nO que deseja fazer?");
            Console.WriteLine("1 - Efetuar Check_In");
            Console.WriteLine("2 - Apagar Check_In");
            Console.WriteLine("3 - Mostrar todos os Check_Ins");
            Console.WriteLine("4 - Mostrar Check_Ins Pendentes");
            Console.WriteLine("5 - Efetuar Check_Out");
            Console.WriteLine("0 - Sair");
            opcao4 = int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Obtem o id do Check_In
        /// </summary>
        /// <param name="id">id do check in</param>
        public void ObterIdCheck_In(out int id)
        {
            Console.WriteLine("Qual o ID do Check_In?");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                id = int.Parse(Console.ReadLine());
            }
        }

        #endregion
    }
}
