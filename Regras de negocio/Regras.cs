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
        private Io io;

        public Regras()
        {
            clientes = new Clientes();
            alojamentos = new Alojamentos();
            reservas = new Reservas();
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
            int numeroQuartos, classificacao, disponibilidade;
            string morada;
            io.AdicionarAlojamento(out morada, out numeroQuartos, out classificacao, out disponibilidade);
            int id = alojamentos.ObterProximoIdAlojamentoDisponivel();


            Alojamento a = new Alojamento(id, morada, numeroQuartos, classificacao, disponibilidade);
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
                Console.WriteLine("Cliente não encontrado.");
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
        #endregion


        #region Reserva


        public bool AdicionarReserva()
        {
            int id, numeroHospedes, valor;
            DateTime dataEntrada, dataSaida;
            string regime;
            io.AdicionarReserva(out numeroHospedes, out dataEntrada, out dataSaida, out regime);
            id = reservas.ObterProximoIdReservaDisponivel();
            reservas.CalcularValorDaReserva(numeroHospedes, dataEntrada, dataSaida, regime, out valor);
            

            Reserva r = new Reserva(id, numeroHospedes, dataEntrada, dataSaida, regime, valor);
            if (id > 0)
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
        #endregion
    }
}
