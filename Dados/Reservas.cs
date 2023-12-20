/*
 * Classe responsavel por desenvolver funções relacionadas com Reservas
 * Nuno Oliveira
 * a25985@alunos.ipca.pt
 * 19-12-2023
 * POO-ESI
 * **/
using Dados;
using Objetos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Reservas : IReserva
    {

        #region ESTADOS

        private List<Reserva> reservas;

        /// <summary>
        /// Inicializa a lista de reservas no construtor
        /// </summary>
        public Reservas()
        {
            reservas = new List<Reserva>(); 
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Obtem o proximo id disponivel
        /// </summary>
        /// <returns></returns>
        public int ObterProximoIdReservaDisponivel()
        {
            List<int> idsExistentes = new List<int>();

            // Percorre a lista de reservas para obter todos os IDs existentes
            foreach (Reserva reserva in reservas)
            {
                idsExistentes.Add(reserva.IdReserva);
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
        /// Adiciona uma reserva à lista
        /// </summary>
        /// <param name="r">lista de reservas</param>
        /// <returns></returns>
        public bool AdicionarReserva(Reserva r)
        {
            reservas.Add(r);
            return true;
        }

        /// <summary>
        /// Calcula o valor da estadia multiplicando as variaveis
        /// </summary>
        /// <param name="numeroHospedes">numero de hospedes</param>
        /// <param name="dataEntrada">data de entrada</param>
        /// <param name="dataSaida">data de saida</param>
        /// <param name="regime">regime da estadia (mp, pc, ti)</param>
        /// <param name="valorNoite">valor por noite</param>
        /// <returns></returns>
        public int CalcularValorDaReserva(int numeroHospedes, DateTime dataEntrada, DateTime dataSaida, string regime, int valorNoite)
        {
            // Calcula a diferença entre as datas de entrada e saída
            TimeSpan duracaoEstadia = dataSaida - dataEntrada;

            // Obtemos o número total de dias
            int numeroDias = (int)duracaoEstadia.TotalDays;
            int valor;

            int custoPorDia;
            if (regime == "mp")
            {
                custoPorDia = 2;
            }
            else if (regime == "pc")
            {
                custoPorDia = 4;
            }
            else if (regime == "ti")
            {
                custoPorDia = 6;
            }
            else
            {
                Console.WriteLine("Erro ao calcular valor da reserva");
                custoPorDia = 0;
            }

            // Calcula o valor total da reserva baseado no custo por dia, número de dias e numero de hospedes
            valor = numeroDias * custoPorDia * numeroHospedes * valorNoite;
            return valor;
        }

        /// <summary>
        /// Mostra todas as reservas na consola
        /// </summary>
        public void MostrarReservas()
        {
            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva foi adicionada ainda.");
                return;
            }

            foreach (Reserva reserva in reservas)
            {
                Console.WriteLine(reserva.ToString());
            }
        }

        /// <summary>
        /// Guarda as reservas em um ficheiro de texto
        /// </summary>
        /// <param name="r">variavel associada ao ficheiro de texto</param>
        /// <returns></returns>
        public bool GuardarReservas(string r)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(r))
                {
                    foreach (var reservas in reservas)
                    {
                        writer.WriteLine($"{reservas.IdReserva}#{reservas.NumeroHospedes}#{reservas.DataEntrada}#{reservas.DataSaida}#{reservas.Regime}#{reservas.Valor}#{reservas.IdAlojamentoReserva}");
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
        /// Lê os dados das reservas de um ficheiro de texto
        /// </summary>
        /// <param name="r">Variavel associada ao ficheiro de texto</param>
        /// <returns></returns>
        public bool LerReservas(string r)
        {
            try
            {
                using (StreamReader sr = File.OpenText(r))
                {
                    string linha = sr.ReadLine();
                    while (linha != null)
                    {
                        string[] dados = linha.Split('#');
                        int idReserva = int.Parse(dados[0]);
                        int numeroHospedes = int.Parse(dados[1]);
                        DateTime dataEntrada = DateTime.ParseExact(dados[2], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime dataSaida = DateTime.ParseExact(dados[3], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        string regime = dados[4];
                        int valor = int.Parse(dados[5]);
                        int idAlojamentoReserva = int.Parse(dados[6]);


                        Reserva reserva = new Reserva(idReserva, numeroHospedes, dataEntrada, dataSaida, regime, valor, idAlojamentoReserva);

                        reservas.Add(reserva);

                        linha = sr.ReadLine();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler reservas: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Remove determinada reserva da lista
        /// </summary>
        /// <param name="reserva">lista das reservas</param>
        /// <returns></returns>
        public bool RemoverReserva(Reserva reserva)
        {
            if (reservas.Contains(reserva))
            {
                reservas.Remove(reserva);
                return true;
                
            }
            else
            {
                Console.WriteLine("Reserva não encontrada na lista.");
                return false;
            }
        }

        /// <summary>
        /// Obtem determinada reserva pelo seu id
        /// </summary>
        /// <param name="id">id da reserva</param>
        /// <returns></returns>
        public Reserva ObterReservaPorId(int id)
        {
            foreach (Reserva reserva in reservas)
            {
                if (reserva.IdReserva == id)
                {
                    return reserva;
                }
            }
            return null;
        }

    /// <summary>
    /// Mostra dterminada reserva pelo seu id
    /// </summary>
    /// <param name="id">id da reserva</param>
    /// <returns></returns>
        public Reserva MostrarReservaPorId(int id)
        {
            foreach (Reserva reserva in reservas)
            {
                if (reserva.IdReserva == id)
                {
                    Console.WriteLine("Dados da Reserva:");
                    Console.WriteLine(reserva.ToString());
                    return reserva;
                }
            }

            return null;
        }

        /// <summary>
        /// Obtem o id de determinado alojamento
        /// </summary>
        /// <param name="id">id do alojamento</param>
        /// <returns></returns>
        public int ObterIdAlojamento(int id)
        {
            foreach(Reserva reserva in reservas)
            {
                if (reserva.IdReserva == id)
                {
                    return reserva.IdAlojamentoReserva;
                }
            }
            return 0;
        }

        /// <summary>
        /// Altera determinado dado de uma reserva
        /// </summary>
        /// <param name="opcao">opcao escolhida</param>
        /// <param name="id">id da reserva</param>
        /// <param name="valorNoite">valor por noite</param>
        /// <returns></returns>
        public bool AlterarDadoReserva(int opcao, int id, int valorNoite)
        {
            foreach (Reserva reserva in reservas)
            {
                if (reserva.IdReserva == id)
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Qual o numero de hospedes?");
                            int numeroHospedes = int.Parse(Console.ReadLine());
                            reserva.NumeroHospedes = numeroHospedes;
                            break;
                        case 2:
                            Console.WriteLine("Qual a nova data de entrada? (dd/mm/aaaa)");
                            DateTime dataEntrada = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            reserva.DataEntrada = dataEntrada;
                            break;
                        case 3:
                            Console.WriteLine("Qual a nova data de saida? (dd/mm/aaaa)");
                            DateTime dataSaida = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            reserva.DataSaida = dataSaida;
                            break;
                        case 4:
                            Console.WriteLine("Qual o novo regime? mp (meia pensao), pc (pensao completa), ti (tudo incluido)");
                            string regime = Console.ReadLine();
                            reserva.Regime = regime;
                            break;
                    }
                    reserva.Valor = CalcularValorDaReserva(reserva.NumeroHospedes, reserva.DataEntrada, reserva.DataSaida, reserva.Regime, valorNoite);
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica se determinado id ja existe
        /// </summary>
        /// <param name="id">id da reserva</param>
        /// <returns></returns>
        public bool VerificarIdReservaExistente(int id)
        {
            foreach (Reserva reserva in reservas)
            {
                if (reserva.IdReserva == id)
                {
                    return true;
                }
            }
            return false;
        }


        #endregion
    }
}
