using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2classe;

namespace _1classe
{
    /// <summary>
    /// Classe que representa uma reserva de hospedagem de um cliente.
    /// </summary>
    public class Reserva
    {
        #region Estado
        private Cliente cliente;          // Cliente associado à reserva
        private int idReserva;           // ID da reserva
        private int numeroHospedes;      // Número de hóspedes na reserva
        private DateTime dataEntrada;    // Data de entrada na reserva
        private DateTime dataSaida;      // Data de saída da reserva
        private string regime;           // Regime da reserva (ex: meia-pensão, pensão completa, etc.)
        private int valor;               // Valor da estadia
        #endregion

        #region Comportamentos

        #region Construtores

        /// <summary>
        /// Construtor por Omissão que inicializa uma Reserva com valores padrão.
        /// </summary>
        public Reserva()
        {
            cliente = null;
            idReserva = 0;
            numeroHospedes = 0;
            dataEntrada = DateTime.Now;
            dataSaida = DateTime.Now;
            regime = "";
            valor = 0;
        }

        /// <summary>
        /// Construtor que permite criar uma Reserva com valores específicos.
        /// </summary>
        /// <param name="cliente">Cliente associado</param>
        /// <param name="idReserva">ID da reserva</param>
        /// <param name="numeroHospedes">Número de hóspedes</param>
        /// <param name="dataEntrada">Data de entrada</param>
        /// <param name="dataSaida">Data de saída</param>
        /// <param name="regime">Regime da estadia</param>
        /// <param name="valor">Valor da estadia</param>
        public Reserva(Cliente cliente, int idReserva, int numeroHospedes, DateTime dataEntrada, DateTime dataSaida, string regime)
        {
            this.cliente = cliente;
            this.idReserva = idReserva;
            this.numeroHospedes = numeroHospedes;
            this.dataEntrada = dataEntrada;
            this.dataSaida = dataSaida;
            this.regime = regime;
            this.valor = valor;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade para acessar e modificar o Cliente associado à reserva.
        /// </summary>
        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
            }
        }

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

        #endregion

        #region Operadores

        /// <summary>
        /// Verifica se duas reservas são iguais com base nos seus atributos.
        /// </summary>
        public static bool operator ==(Reserva p1, Reserva p2)
        {
            if ((p1.idReserva == p2.idReserva) && (p1.cliente == p2.cliente) && (p1.dataEntrada == p2.dataEntrada) &&
                (p1.dataSaida == p2.dataSaida) && (p1.numeroHospedes == p2.numeroHospedes) && (p1.regime == p2.regime) && (p1.valor == p2.valor))
                return true;
            return false;
        }

        /// <summary>
        /// Verifica se duas reservas são diferentes com base nos seus atributos.
        /// </summary>
        public static bool operator !=(Reserva p1, Reserva p2)
        {
            if (p1 == p2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Retorna uma representação textual do objeto Reserva.
        /// </summary>
        public override string ToString()
        {
            return String.Format("Id Reserva: {0} - Cliente: {1} - Número Hospedes: {2} - Data Entrada: {3} - Data Saída: {4} - Regime: {5} - Valor: {6}", idReserva.ToString(), cliente.NomeCliente, numeroHospedes.ToString(), dataEntrada.ToString(), dataSaida.ToString(), regime, valor.ToString());
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

