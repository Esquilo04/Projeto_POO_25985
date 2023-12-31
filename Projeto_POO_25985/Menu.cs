using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regras_de_negocio;

namespace Projeto_POO_25985
{
    internal class Menu
    {
        private Regras regras;
        public Menu()
        {
            regras = new Regras();
            String d = @"Clientes.txt";
            String a = @"Alojamentos.txt";
            String r = @"Reservas.txt";
            String c = @"Check_Ins.txt";

            regras.LerClientes(d);
            regras.LerAlojamentos(a);
            regras.LerReservas(r);
            regras.LerCheck_Ins(c);
            bool sair = false;
            
            while (!sair)
            {
                Console.Clear();
                int opcaogestor = regras.MenuGestor();

                switch (opcaogestor)
                {
                    case 0:
                        sair = true;
                        Console.WriteLine("Saindo...");
                        break;

                    case 1:
                        GerirMenuClientes(d);
                        break;

                    case 2:
                        GerirMenuAlojamentos(a);
                        break;

                    case 3:
                        GerirMenuReservas(r);
                        break;
                    case 4:
                        GerirMenuCheck_Ins(c);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

            public void GerirMenuClientes(string d)
            {
                int opcaoCliente = regras.MenuClientes();
                bool sair = false;

                while (!sair)
                {
                    Console.Clear();

                    switch (opcaoCliente)
                    {
                        case 0:
                            sair = true;
                            Console.WriteLine("Saindo do menu de clientes...");
                            break;

                        case 1:
                            regras.AdicionarCliente();
                            break;

                        case 2:
                            regras.ApagarClientePorId();
                            break;

                        case 3:
                            regras.MostrarClientes();
                            break;

                        case 4:
                            regras.MostrarDadosClientePorId();
                            break;
                        case 5:
                        regras.AlterarDadosClientes();
                            break;
                    default:
                            Console.Clear();
                            Console.WriteLine("Opção inválida!");
                            break;
                    }

                    if (!sair)
                    {
                        opcaoCliente = regras.MenuClientes();
                    }
                }

                regras.GuardarClientes(d);
            }

            public void GerirMenuAlojamentos(string a)
            {
                int opcaoAlojamento = regras.MenuAlojamentos();
                bool sair = false;

                while (!sair)
                {
                    Console.Clear();

                    switch (opcaoAlojamento)
                    {
                        case 0:
                            sair = true;
                            Console.WriteLine("Saindo do menu de alojamentos...");
                            break;

                        case 1:
                            regras.AdicionarAlojamento();
                            break;

                        case 2:
                            regras.ApagarAlojamentoPorId();
                            break;

                        case 3:
                            regras.MostrarAlojamentos();
                            break;

                        case 4:
                            regras.MostrarDadosAlojamentoPorId();
                            break;
                        case 5:
                            regras.AlterarDadosAlojamentos();
                            break;
                        case 6:
                            regras.AlterarDisponibilidadeAlojamento();
                            break;
                        case 7:
                            regras.MostrarAlojamentosDisponiveis();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opção inválida!");
                            break;
                    }

                    if (!sair)
                    {
                        opcaoAlojamento = regras.MenuAlojamentos();
                    }
                }

                regras.GuardarAlojamentos(a);
            }


        public void GerirMenuReservas(string r)
        {
            int opcaoReserva = regras.MenuReservas();
            bool sair = false;

            while (!sair)
            {
                Console.Clear();

                switch (opcaoReserva)
                {
                    case 0:
                        sair = true;
                        Console.WriteLine("Saindo do menu de reservas...");
                        break;

                    case 1:
                        regras.AdicionarReserva();
                        break;

                    case 2:
                        regras.ApagarReservaPorId();
                        break;

                    case 3:
                        regras.MostrarReservas();
                        break;

                    case 4:
                        regras.MostrarDadosReservaPorId();
                        break;
                    case 5:
                        regras.AlterarDadosReservas();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (!sair)
                {
                    opcaoReserva = regras.MenuReservas();
                }
            }
            regras.GuardarReservas(r);
        }


        public void GerirMenuCheck_Ins(string c)
        {
            int opcaoCheck_In = regras.MenuCheck_Ins();
            bool sair = false;

            while (!sair)
            {
                Console.Clear();

                switch (opcaoCheck_In)
                {
                    case 0:
                        sair = true;
                        Console.WriteLine("Saindo do menu de check_ins...");
                        break;

                    case 1:
                        regras.EfetuarCheck_In();
                        break;

                    case 2:
                        regras.ApagarCheck_InPorId();
                        break;

                    case 3:
                        regras.MostrarCheck_Ins();
                        break;

                    case 4:
                        regras.MostrarCheck_InsPendentes();
                        break;
                    case 5:
                        if(!regras.MostrarCheck_InsPendentes())
                        {
                            break;
                        }
                        regras.EfetuarCheck_Out();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (!sair)
                {
                    opcaoCheck_In = regras.MenuCheck_Ins();
                }
            }
            regras.GuardarCheck_Ins(c);
        }
    }
}