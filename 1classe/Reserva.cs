using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2classe;

namespace _1classe
{
    public class Reserva
    {
        #region Estado
        private Cliente cliente;
        private int idReserva;
        private int numeroHospedes;
        private DateTime dataEntrada;
        private DateTime dataSaida;
        private string regime;
        private int valor;
        #endregion

        #region Comportamentos

        #region Construtores

        /// <summary>
        /// Construtor por Omissão
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

        public static bool operator ==(Reserva p1, Reserva p2)
        {
            if ((p1.idReserva == p2.idReserva) && (p1.cliente == p2.cliente) && (p1.dataEntrada == p2.dataEntrada) &&
                (p1.dataSaida == p2.dataSaida) && (p1.numeroHospedes == p2.numeroHospedes) && (p1.regime == p2.regime) && (p1.valor == p2.valor))
                return true;
            return false;
        }

        public static bool operator !=(Reserva p1, Reserva p2)
        {
            if (p1 == p2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return String.Format("Id Reserva: {0} - Cliente: {1} - Número Hospedes: {2} - Data Entrada: {3} - Data Saída: {4} - Regime: {5} - Valor: {6}", idReserva.ToString(), cliente.NomeCliente, numeroHospedes.ToString(), dataEntrada.ToString(), dataSaida.ToString(), regime, valor.ToString());
        }

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

