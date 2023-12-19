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

        private Clientes clientes;
        private Alojamentos alojamentos;
        private Reservas reservas;
        private Check_Ins check_Ins;
        private Io io;

        public Regras()
        {
            clientes = new Clientes();
            alojamentos = new Alojamentos();
            reservas = new Reservas();
            check_Ins = new Check_Ins();
            io = new Io();
        }


        public int MenuGestor()
        {
            int opcaogestor;
            io.MenuGestor(out opcaogestor);
            return opcaogestor;
        }
        #region Cliente

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

        public void MostrarClientes()
        {
            Console.WriteLine("\nDados dos clientes:");
            clientes.MostrarClientes();
        }

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

        public void GuardarClientes(string d)
        {
            clientes.GuardarClientes(d);
        }

        public void LerClientes(string d)
        {
            clientes.LerClientes(d);
        }

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

        public int MenuClientes()
        {
            int opcao;
            io.MenuClientes(out opcao);
            return opcao;
        }

        public void AlterarDadosClientes()
        {
            int id, dado;
            io.ObterIdCliente(out id);
            io.AlterarDadoCliente(out dado);
            clientes.AlterarDadoCliente(dado, id);
        }
        #endregion



        #region Alojamento

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

        public void MostrarAlojamentos()
        {
            Console.WriteLine("\nDados dos alojamentos:");
            alojamentos.MostrarAlojamentos();
        }

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

        public void GuardarAlojamentos(string a)
        {
            alojamentos.GuardarAlojamentos(a);
        }

        public void LerAlojamentos(string a)
        {
            alojamentos.LerAlojamentos(a);
        }

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

        public int MenuAlojamentos()
        {
            int opcao2;
            io.MenuAlojamentos(out opcao2);
            return opcao2;
        }

        public void AlterarDadosAlojamentos()
        {
            int id, dado;
            io.ObterIdAlojamento(out id);
            io.AlterarDadoAlojamento(out dado);
            alojamentos.AlterarDadoAlojamento(dado, id);
        }

        public void AlterarDisponibilidadeAlojamento()
        {
            int id;
            io.ObterIdAlojamento(out id);
            alojamentos.AlterarDisponibilidadeAlojamento(id);
        }

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

        #endregion


        #region Reserva


        public bool AdicionarReserva()
        {
            int idReserva, numeroHospedes, valor, idAlojamentoReserva, valorNoite;
            DateTime dataEntrada, dataSaida;
            string regime;
            io.AdicionarReserva(out numeroHospedes, out dataEntrada, out dataSaida, out regime);
            MostrarAlojamentosDisponiveis();
            idAlojamentoReserva = int.Parse(Console.ReadLine());
            alojamentos.VerificarAlojamentoDisponivel(idAlojamentoReserva);
            valorNoite = alojamentos.ObterValorNoitePorId(idAlojamentoReserva);
            idReserva = reservas.ObterProximoIdReservaDisponivel();
            valor = reservas.CalcularValorDaReserva(numeroHospedes, dataEntrada, dataSaida, regime, valorNoite);
            

            Reserva r = new Reserva(idReserva, numeroHospedes, dataEntrada, dataSaida, regime, valor, idAlojamentoReserva);
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

        public void MostrarReservas()
        {
            Console.WriteLine("\nDados das reservas:");
            reservas.MostrarReservas();
        }

        public int MenuReservas()
        {
            int opcao3;
            io.MenuReservas(out opcao3);
            return opcao3;
        }

        public void GuardarReservas(string r)
        {
            reservas.GuardarReservas(r);
        }

        public void LerReservas(string r)
        {
            reservas.LerReservas(r);
        }

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
            MostrarClientes();
            Console.WriteLine("Qual o id do Cliente que deseja efetuar Check_In?");
            idCliente = int.Parse(Console.ReadLine());
            if(!clientes.VerificarIdExistente(idCliente))
            {
                Console.WriteLine("Id do cliente nao existe.");
                return false;
            }
            idAlojamento = reservas.ObterIdAlojamento(idReserva);
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

        public void MostrarCheck_Ins()
        {
            Console.WriteLine("\nDados dos Check_Ins:");
            check_Ins.MostrarCheck_Ins();
        }

        public void MostrarCheck_InsPendentes()
        {
            check_Ins.MostrarCheck_InsPendentes();
        }

        public void GuardarCheck_Ins(string c)
        {
            check_Ins.GuardarCheck_Ins(c);
        }

        public void LerCheck_Ins(string c)
        {
            check_Ins.LerCheck_Ins(c);
        }

        public int MenuCheck_Ins()
        {
            int opcao4;
            io.MenuCheck_Ins(out opcao4);
            return opcao4;
        }

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

        public void EfetuarCheck_Out()
        {
            int id;
            io.ObterIdCheck_In(out id);
            check_Ins.EfetuarCheck_Out(id);
        }

        #endregion
    }
}
