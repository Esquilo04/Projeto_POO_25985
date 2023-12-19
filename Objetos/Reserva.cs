/*
 * Classe responsavel por operações de entrada/saída (I/O)
 * Nuno Oliveira
 * a25985@alunos.ipca.pt
 * 15-11-2023
 * POO-ESI
 * **/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Objetos
{
    /// <summary>
    /// Classe que representa uma reserva de hospedagem de um cliente.
    /// </summary>
    public class Reserva
    {
        #region Estado
        private int idReserva;           // ID da reserva
        private int numeroHospedes;      // Número de hóspedes na reserva
        private DateTime dataEntrada;    // Data de entrada na reserva
        private DateTime dataSaida;      // Data de saída da reserva
        private string regime;           // Regime da reserva (ex: meia-pensão, pensão completa, etc.)
        private int valor;               // Valor da estadia
        private int idAlojamentoReserva;
        #endregion

        #region Comportamentos

        #region Construtores

        /// <summary>
        /// Construtor por Omissão que inicializa uma Reserva com valores padrão.
        /// </summary>
        public Reserva()
        {
            idReserva = 0;
            numeroHospedes = 0;
            dataEntrada = DateTime.Now;
            dataSaida = DateTime.Now;
            regime = "";
            valor = 0;
            idAlojamentoReserva = 0;
        }

        /// <summary>
        /// Construtor que permite criar uma Reserva com valores específicos.
        /// </summary>
        /// <param name="idReserva">ID da reserva</param>
        /// <param name="numeroHospedes">Número de hóspedes</param>
        /// <param name="dataEntrada">Data de entrada</param>
        /// <param name="dataSaida">Data de saída</param>
        /// <param name="regime">Regime da estadia</param>
        /// <param name="valor">Valor da estadia</param>
        /// 
        public Reserva(int idReserva, int numeroHospedes, DateTime dataEntrada, DateTime dataSaida, string regime, int valor, int idAlojamentoReserva)
        {
            this.idReserva = idReserva;
            this.numeroHospedes = numeroHospedes;
            this.dataEntrada = dataEntrada;
            this.dataSaida = dataSaida;
            this.regime = regime;
            this.valor = valor;
            this.idAlojamentoReserva = idAlojamentoReserva;
        }

        #endregion

        #region Propriedades


        /// <summary>
        /// Propriedade para acessar e modificar o ID da reserva.
        /// </summary>
        public int IdReserva
        {
            get
            {
                return idReserva;
            }
            set
            {
                idReserva = value;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar o número de hóspedes na reserva.
        /// </summary>
        public int NumeroHospedes
        {
            get
            {
                return numeroHospedes;
            }
            set
            {
                numeroHospedes = value;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar a data de entrada na reserva.
        /// </summary>
        public DateTime DataEntrada
        {
            get
            {
                return dataEntrada;
            }
            set
            {
                dataEntrada = value;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar a data de saída da reserva.
        /// </summary>
        public DateTime DataSaida
        {
            get
            {
                return dataSaida;
            }
            set
            {
                dataSaida = value;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar o regime da estadia.
        /// </summary>
        public string Regime
        {
            get
            {
                return regime;
            }
            set
            {
                regime = value;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar o valor da estadia.
        /// </summary>
        public int Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar o ID do alojamento asociado à reserva.
        /// </summary>
        public int IdAlojamentoReserva
        {
            get
            {
                return idAlojamentoReserva;
            }
            set
            {
                idAlojamentoReserva = value;
            }
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Verifica se duas reservas são iguais com base nos seus atributos.
        /// </summary>
        public static bool operator ==(Reserva p1, Reserva p2)
        {
            if (ReferenceEquals(p1, null) && ReferenceEquals(p2, null))
            {
                return true;
            }

            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            {
                return false;
            }

            return p1.idReserva == p2.idReserva &&
                   p1.numeroHospedes == p2.numeroHospedes &&
                   p1.dataEntrada == p2.dataEntrada &&
                   p1.dataSaida == p2.dataSaida &&
                   p1.regime == p2.regime &&
                   p1.valor == p2.valor &&
                   p1.idAlojamentoReserva == p2.idAlojamentoReserva;
        }

        /// <summary>
        /// Verifica se duas reservas são diferentes com base nos seus atributos.
        /// </summary>
        public static bool operator !=(Reserva p1, Reserva p2)
        {
            return !(p1 == p2);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Retorna uma representação textual do objeto Reserva.
        /// </summary>
        public override string ToString()
        {
            return String.Format("Id Reserva: {0} - Número Hospedes: {1} - Data Entrada: {2} - Data Saída: {3} - Regime: {4} - Valor: {5} - Id do alojamento: {6}", idReserva.ToString(), numeroHospedes.ToString(), dataEntrada.ToString(), dataSaida.ToString(), regime, valor.ToString(), idAlojamentoReserva.ToString());
        }

        /// <summary>
        /// Verifica se o objeto fornecido é igual a esta Reserva.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Reserva)
            {
                Reserva p = (Reserva)obj;
                if (this == p)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #endregion
    }
}

