using _2classe;
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
    public class Reservas
    {

        #region ESTADOS

        private List<Reserva> reservas;

        public Reservas()
        {
            reservas = new List<Reserva>(); // Inicializa a lista de reservas no construtor
        }

        #endregion

        #region PROPRIEDADES
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

        public bool AdicionarReserva(Reserva r)
        {
            reservas.Add(r);
            return true;
        }

        public void CalcularValorDaReserva(int numeroHospedes, DateTime dataEntrada, DateTime dataSaida, string regime, out int valor)
        {
            // Calcula a diferença entre as datas de entrada e saída
            TimeSpan duracaoEstadia = dataSaida - dataEntrada;

            // Obtemos o número total de dias
            int numeroDias = (int)duracaoEstadia.TotalDays;

            int custoPorDia;
            if (regime == "mp")
            {
                custoPorDia = 50;
            }
            else if (regime == "pc")
            {
                custoPorDia = 80;
            }
            else if (regime == "ti")
            {
                custoPorDia = 100;
            }
            else
            {
                Console.WriteLine("Erro ao calcular valor da reserva");
                custoPorDia = 0;
            }

            // Calcula o valor total da reserva baseado no custo por dia, número de dias e numero de hospedes
            valor = numeroDias * custoPorDia * numeroHospedes;
        }

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

        public bool GuardarReservas(string r)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(r))
                {
                    foreach (var reservas in reservas)
                    {
                        writer.WriteLine($"{reservas.IdReserva}#{reservas.NumeroHospedes}#{reservas.DataEntrada}#{reservas.DataSaida}#{reservas.Regime}#{reservas.Valor}");
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

                        Reserva reserva = new Reserva(idReserva, numeroHospedes, dataEntrada, dataSaida, regime, valor);

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

        public void RemoverReserva(Reserva reserva)
        {
            if (reservas.Contains(reserva))
            {
                reservas.Remove(reserva);
                Console.WriteLine("Reserva removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Reserva não encontrada na lista.");
            }
        }

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

        #endregion
    }
}
