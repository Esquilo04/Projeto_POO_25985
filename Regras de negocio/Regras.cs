using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using Objetos;
using Projeto_POO_25985;


namespace Regras_de_negocio
{
    public class Regras
    {
        /// <summary>
        /// Instâncias dos principais objetos do sistema
        /// </summary>
        private Clientes clientes;
        private Alojamentos alojamentos;
        private Reservas reservas;
        private Check_Ins check_Ins;
        private Io io;

        /// <summary>
        /// Construtor padrão que inicializa os objetos principais do sistema.
        /// </summary>
        public Regras()
        {
            clientes = new Clientes();
            alojamentos = new Alojamentos();
            reservas = new Reservas();
            check_Ins = new Check_Ins();
            io = new Io();
        }

        /// <summary>
        /// Menu Gestor
        /// </summary>
        /// <returns></returns>
        public int MenuGestor()
        {
            int opcaogestor;
            io.MenuGestor(out opcaogestor);
            return opcaogestor;
        }


        #region Cliente

        /// <summary>
        /// Adiciona um cliente à lista
        /// </summary>
        /// <returns></returns>
        public bool AdicionarCliente()
        {
            int nif, tel;
            string nome, morada;
            io.AdicionarCliente(out nome, out nif, out morada, out tel);
            int id = clientes.ObterProximoIdDisponivel();
            
            
            Cliente c = new Cliente(id, nome, nif, morada, tel);
            if (id > 0)
            {
                if (!clientes.VerificarIdExistente(id))
                {
                    clientes.AdicionarCliente(c);
                    return true;
                }
                else
                {
                    Console.WriteLine("Id já existente");
                }
            }
            else
            {
                Console.WriteLine("Id inferior a 0");
            }
            return false;
        }

        /// <summary>
        /// Mostra os dados de um cliente pelo seu id
        /// </summary>
        /// <returns></returns>
        public Cliente MostrarDadosClientePorId()
        {
            int id;
            io.ObterIdCliente(out id);

            Cliente clienteEncontrado = clientes.MostrarClientePorId(id);

            if (clienteEncontrado == null)
            {
                Console.WriteLine("Cliente não encontrado.");
            }

            return clienteEncontrado;
        }

        /// <summary>
        /// Mostra todos os clientes na consola
        /// </summary>
        public void MostrarClientes()
        {
            Console.WriteLine("\nDados dos clientes:");
            clientes.MostrarClientes();
        }

        /// <summary>
        /// Guarda os dados dos clientes em um ficheiro de texto
        /// </summary>
        /// <param name="d">Variavel para o nome do ficheiro</param>
        public void GuardarClientes(string d)
        {
            clientes.GuardarClientes(d);
        }

        /// <summary>
        /// LÊ os dados dos clientes de um ficheiro de texto
        /// </summary>
        /// <param name="d">Variavel para o nome do ficheiro</param>
        public void LerClientes(string d)
        {
            clientes.LerClientes(d);
        }

        /// <summary>
        /// Apaga determinado cliente pelo seu id
        /// </summary>
        /// <returns></returns>
        public bool ApagarClientePorId()
        {
            int id;
            io.ObterIdCliente(out id);

            Cliente clienteEncontrado = clientes.ObterClientePorId(id);

            if (clienteEncontrado != null)
            {
                clientes.RemoverCliente(clienteEncontrado);
                return true;
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
                return false;
            }
        }

        /// <summary>
        /// Menu dos clientes
        /// </summary>
        /// <returns></returns>
        public int MenuClientes()
        {
            int opcao;
            io.MenuClientes(out opcao);
            return opcao;
        }

        /// <summary>
        /// Altera determinado dado de um cliente
        /// </summary>
        public void AlterarDadosClientes()
        {
            int id, dado;
            io.ObterIdCliente(out id);
            io.AlterarDadoCliente(out dado);
            clientes.AlterarDadoCliente(dado, id);
        }
        #endregion



        #region Alojamento

        /// <summary>
        /// Adiciona um alojamento à lista
        /// </summary>
        /// <returns></returns>
        public bool AdicionarAlojamento()
        {
            int numeroQuartos, classificacao, disponibilidade, valorNoite;
            string morada;
            io.AdicionarAlojamento(out morada, out numeroQuartos, out classificacao, out disponibilidade, out valorNoite);
            int id = alojamentos.ObterProximoIdAlojamentoDisponivel();


            Alojamento a = new Alojamento(id, morada, numeroQuartos, classificacao, disponibilidade, valorNoite);
            if (id > 0)
            {
                if (!alojamentos.VerificarIdAlojamentoExistente(id))
                {
                    alojamentos.AdicionarAlojamento(a);
                    return true;
                }
                else
                {
                    Console.WriteLine("Id já existente");
                }
            }
            else
            {
                Console.WriteLine("Id inferior a 0");
            }
            return false;
        }

        /// <summary>
        /// Guarda os dados dos alojamentos em um ficheiro de texto
        /// </summary>
        /// <param name="a">Variavel para o nome do ficheiro</param>
        public void GuardarAlojamentos(string a)
        {
            alojamentos.GuardarAlojamentos(a);
        }

        /// <summary>
        /// LÊ os dados de um ficheiro de texto
        /// </summary>
        /// <param name="a">Variavel para o nome do ficheiro</param>
        public void LerAlojamentos(string a)
        {
            alojamentos.LerAlojamentos(a);
        }

        /// <summary>
        /// Mostra todos os alojamentos disponiveis
        /// </summary>
        public void MostrarAlojamentosDisponiveis()
        {
            List<Alojamento> alojamentosDisponiveis = alojamentos.MostrarAlojamentosDisponiveis();

            if (alojamentosDisponiveis.Count > 0)
            {
                Console.WriteLine("Alojamentos disponíveis:");
                foreach (Alojamento alojamento in alojamentosDisponiveis)
                {
                    Console.WriteLine(alojamento.ToString());
                }
            }
            else
            {
                Console.WriteLine("Não existe nenhum alojamento disponível.");
            }
        }

        /// <summary>
        /// Mostra os dados de determinado alojamento pelo seu id
        /// </summary>
        /// <returns></returns>
        public Alojamento MostrarDadosAlojamentoPorId()
        {
            int id;
            io.ObterIdAlojamento(out id);

            Alojamento alojamentoEncontrado = alojamentos.MostrarAlojamentoPorId(id);

            if (alojamentoEncontrado == null)
            {
                Console.WriteLine("Alojamento não encontrado.");
            }

            return alojamentoEncontrado;
        }

        /// <summary>
        /// Mostra todos os alojamentos
        /// </summary>
        public void MostrarAlojamentos()
        {
            Console.WriteLine("\nDados dos alojamentos:");
            alojamentos.MostrarAlojamentos();
        }

        /// <summary>
        /// Apaga determinado alojamento
        /// </summary>
        /// <returns></returns>
        public bool ApagarAlojamentoPorId()
        {
            int id;
            io.ObterIdAlojamento(out id);

            Alojamento alojamentoEncontrado = alojamentos.ObterAlojamentoPorId(id);

            if (alojamentoEncontrado != null)
            {
                alojamentos.RemoverAlojamento(alojamentoEncontrado);
                return true;
            }
            else
            {
                Console.WriteLine("Alojamento não encontrado.");
                return false;
            }
        }

        /// <summary>
        /// Menu dos alojamentos
        /// </summary>
        /// <returns></returns>
        public int MenuAlojamentos()
        {
            int opcao2;
            io.MenuAlojamentos(out opcao2);
            return opcao2;
        }

        /// <summary>
        /// Altera determinado dado de um alojamento
        /// </summary>
        public void AlterarDadosAlojamentos()
        {
            int id, dado;
            io.ObterIdAlojamento(out id);
            io.AlterarDadoAlojamento(out dado);
            alojamentos.AlterarDadoAlojamento(dado, id);
        }

        /// <summary>
        /// Altera a disponibilidade de um alojamento
        /// </summary>
        public void AlterarDisponibilidadeAlojamento()
        {
            int id;
            io.ObterIdAlojamento(out id);
            alojamentos.AlterarDisponibilidadeAlojamento(id);
        }

        #endregion


        #region Reserva

        /// <summary>
        /// Exibe os dados de todos os alojamentos disponiveis para as datas introduzidas
        /// </summary>
        /// <param name="reservas">lista das reservas</param>
        /// <param name="alojamentos">lista dos alojamentos</param>
        /// <param name="dataEntrada">data de entrada</param>
        /// <param name="dataSaida">data de saida</param>
        public bool MostrarAlojamentosDisponiveis(Reservas reservas, Alojamentos alojamentos, DateTime dataEntrada, DateTime dataSaida)
        {
            List<int> alojamentosOcupados = reservas.ObterAlojamentosOcupados(dataEntrada, dataSaida);

            if (alojamentosOcupados.Count == alojamentos.ObterTodosIdsAlojamentos().Count)
            {
                Console.WriteLine("Não existem alojamentos disponíveis para as datas selecionadas.");
                return false;
            }

            Console.WriteLine("Alojamentos disponíveis para as datas fornecidas:");

            bool alojamentosEncontrados = false;

            foreach (int idAlojamento in alojamentos.ObterTodosIdsAlojamentos())
            {
                if (!alojamentosOcupados.Contains(idAlojamento))
                {
                    alojamentos.MostrarAlojamentoPorId(idAlojamento);
                    alojamentosEncontrados = true;
                }
            }

            if (!alojamentosEncontrados)
            {
                Console.WriteLine("Não foram encontrados alojamentos disponíveis para as datas fornecidas.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adicona uma reserva à lista
        /// </summary>
        /// <returns></returns>
        public bool AdicionarReserva()
        {
            int idReserva, numeroHospedes, valor, idAlojamentoReserva, valorNoite, idClienteReserva;
            DateTime dataEntrada, dataSaida;
            string regime;
            io.AdicionarReserva(out numeroHospedes, out dataEntrada, out dataSaida, out regime);
            if(!MostrarAlojamentosDisponiveis(reservas, alojamentos, dataEntrada, dataSaida))
            {
                return false;
            }

            Console.WriteLine("Qual o id do alojamento que gostaria de reservar?");
            idAlojamentoReserva = int.Parse(Console.ReadLine());
            if (!alojamentos.VerificarIdAlojamentoExistente(idAlojamentoReserva))
            {
                Console.WriteLine("Alojamento não existente.");
                return false;
            }

            //alojamentos.VerificarAlojamentoDisponivel(idAlojamentoReserva);
            MostrarClientes();
            Console.WriteLine("Qual o id do cliente que deseja efetuar a reserva?");
            idClienteReserva = int.Parse(Console.ReadLine());
            if(!clientes.VerificarIdExistente(idClienteReserva))
            {
                Console.WriteLine("Cliente não existente.");
                return false;
            }
            valorNoite = alojamentos.ObterValorNoitePorId(idAlojamentoReserva);
            idReserva = reservas.ObterProximoIdReservaDisponivel();
            valor = reservas.CalcularValorDaReserva(numeroHospedes, dataEntrada, dataSaida, regime, valorNoite);
            

            Reserva r = new Reserva(idReserva, numeroHospedes, dataEntrada, dataSaida, regime, valor, idAlojamentoReserva, idClienteReserva);
            if (idReserva > 0)
            {
                    reservas.AdicionarReserva(r);
                    return true;
            }
            else
            {
                Console.WriteLine("Id inferior a 0");
            }
            return false;
        }

        /// <summary>
        /// Mostra os dados de determinada reserva atraves do seu id
        /// </summary>
        /// <returns></returns>
        public Reserva MostrarDadosReservaPorId()
        {
            int id;
            io.ObterIdAlojamento(out id);

            Reserva reservaEncontrado = reservas.MostrarReservaPorId(id);

            if (reservaEncontrado == null)
            {
                Console.WriteLine("Reserva não encontrado.");
            }

            return reservaEncontrado;
        }

        /// <summary>
        /// Mostra todas as reservas na consola
        /// </summary>
        public void MostrarReservas()
        {
            Console.WriteLine("\nDados das reservas:");
            reservas.MostrarReservas();
        }

        /// <summary>
        /// Menu das reservas
        /// </summary>
        /// <returns></returns>
        public int MenuReservas()
        {
            int opcao3;
            io.MenuReservas(out opcao3);
            return opcao3;
        }

        /// <summary>
        /// Guarda os dados das reservas em um ficheiro de texto
        /// </summary>
        /// <param name="r">Variavel para o nome do ficheiro</param>
        public void GuardarReservas(string r)
        {
            reservas.GuardarReservas(r);
        }

        /// <summary>
        /// Lê os dados das reservas de um ficheiro de texto
        /// </summary>
        /// <param name="r">Variavel para o nome do ficheiro</param>
        public void LerReservas(string r)
        {
            reservas.LerReservas(r);
        }

        /// <summary>
        /// Apaga determinada reserva
        /// </summary>
        /// <returns></returns>
        public bool ApagarReservaPorId()
        {
            int id;
            io.ObterIdReserva(out id);

            Reserva reservaEncontrada = reservas.ObterReservaPorId(id);

            if (reservaEncontrada != null)
            {
                reservas.RemoverReserva(reservaEncontrada);
                Console.WriteLine("Reserva removido com sucesso!");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Apaga reserva pelo id sem o perguntar ao utilizador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ApagarReservaPorId2(int id)
        {
            Reserva reservaEncontrada = reservas.ObterReservaPorId(id);

            if (reservaEncontrada != null)
            {
                reservas.RemoverReserva(reservaEncontrada);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Altera determinado dado da reserva
        /// </summary>
        public void AlterarDadosReservas()
        {
            int idReserva, dado, idAlojamento, valorNoite;
            io.ObterIdReserva(out idReserva);
            io.AlterarDadoReserva(out dado);

            idAlojamento = reservas.ObterIdAlojamento(idReserva);
            valorNoite = alojamentos.ObterValorNoitePorId(idAlojamento);
            reservas.AlterarDadoReserva(dado, idReserva, valorNoite);
        }
        #endregion


        #region Check_In

        /// <summary>
        /// Efetua check in
        /// </summary>
        /// <returns></returns>
        public bool EfetuarCheck_In()
        {
            int idCheck_In, idCliente, idReserva, idAlojamento;
            DateTime dataCheck_In, dataCheck_Out=default;

            idCheck_In = check_Ins.ObterProximoIdCheck_InDisponivel();
            MostrarReservas();
            Console.WriteLine("Qual o id da reserva que deseja efetuar Check_In?");
            idReserva = int.Parse(Console.ReadLine());
            if (!reservas.VerificarIdReservaExistente(idReserva))
            {
                Console.WriteLine("Id da reserva nao existe.");
                return false;
            }
           
            idAlojamento = reservas.ObterIdAlojamento(idReserva);
            idCliente = reservas.ObterIdCliente(idReserva);

            ApagarReservaPorId2(idReserva);
            alojamentos.AlterarDisponibilidadeAlojamento(idAlojamento);
            dataCheck_In = DateTime.Now;

            Check_In c = new Check_In(idCheck_In, idCliente, idReserva, idAlojamento, dataCheck_In, dataCheck_Out, 0);

            if(idCheck_In > 0)
            {
                check_Ins.EfetuarCheck_In(c);
                return true;
            }
            else
            {
                Console.WriteLine("Id inferior a 0");
            }
            return false;
        }

        /// <summary>
        /// Mostra todos os check ins na consola
        /// </summary>
        public void MostrarCheck_Ins()
        {
            Console.WriteLine("\nDados dos Check_Ins:");
            check_Ins.MostrarCheck_Ins();
        }

        /// <summary>
        /// Mostra todos os check ins na consola pendentes
        /// </summary>
        public bool MostrarCheck_InsPendentes()
        {
            if(!check_Ins.MostrarCheck_InsPendentes())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Guarda todos os dados dos chekc ins em um ficheiro de texto
        /// </summary>
        /// <param name="c">Variavel para o nome do ficheiro</param>
        public void GuardarCheck_Ins(string c)
        {
            check_Ins.GuardarCheck_Ins(c);
        }

        /// <summary>
        /// Lê os dados de um ficheiro de texto
        /// </summary>
        /// <param name="c">Variavel para o nome do ficheiro</param>
        public void LerCheck_Ins(string c)
        {
            check_Ins.LerCheck_Ins(c);
        }

        /// <summary>
        /// Menu dos check ins
        /// </summary>
        /// <returns></returns>
        public int MenuCheck_Ins()
        {
            int opcao4;
            io.MenuCheck_Ins(out opcao4);
            return opcao4;
        }

        /// <summary>
        /// Apaga os dados de determinado check in pelo seu id
        /// </summary>
        /// <returns></returns>
        public bool ApagarCheck_InPorId()
        {
            int id;
            io.ObterIdCheck_In(out id);

            Check_In check_InEncontrado = check_Ins.ObterCheck_InPorId(id);

            if (check_InEncontrado != null)
            {
                check_Ins.RemoverCheck_In(check_InEncontrado);
                return true;
            }
            else
            {
                Console.WriteLine("Check_In não encontrado.");
                return false;
            }
        }

        /// <summary>
        /// Efetua o check out
        /// </summary>
        public bool EfetuarCheck_Out()
        {
            int idCheck_In, idAlojamento;
            io.ObterIdCheck_In(out idCheck_In);
            if(!check_Ins.EfetuarCheck_Out(idCheck_In))
            {
                return false;
            }
            idAlojamento = check_Ins.ObterIdAlojamento(idCheck_In);
            alojamentos.AlterarDisponibilidadeAlojamento(idAlojamento);
            return true;
        }

        #endregion
    }
}
