using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2classe;

namespace _1classe
{
    public class Check_in
    {
        #region Estado

        private int idCheckIn;
        private Cliente cliente;
        private DateTime dataCheckIn;
        private DateTime dataCheckOut;
        private int numeroQuarto;

        #endregion

        #region Comportamentos

        #region Construtores

        /// <summary>
        /// Construtor por Omissão
        /// </summary>
        public Check_in()
        {
            idCheckIn = 0;
            cliente = null;
            dataCheckIn = DateTime.Now;
            dataCheckOut = DateTime.Now;
            numeroQuarto = 0;
        }

        public Check_in(int id, Cliente cliente, DateTime dataCheckIn, DateTime dataCheckOut, int numeroQuarto)
        {
            this.idCheckIn = id;
            this.cliente = cliente;
            this.dataCheckIn = dataCheckIn;
            this.dataCheckOut = dataCheckOut;
            this.numeroQuarto = numeroQuarto;
        }

        #endregion

        #region Propriedades

        public int IdCheckIn
        {
            set
            {
                if (value > 0)
                    idCheckIn = value;
            }
            get
            {
                return idCheckIn;
            }
        }

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

        public DateTime DataCheckIn
        {
            get
            {
                return dataCheckIn;
            }
            set
            {
                dataCheckIn = value;
            }
        }

        public DateTime DataCheckOut
        {
            get
            {
                return dataCheckOut;
            }
            set
            {
                dataCheckOut = value;
            }
        }

        public int NumeroQuarto
        {
            get
            {
                return numeroQuarto;
            }
            set
            {
                numeroQuarto = value;
            }
        }

        #endregion

        #region Operadores

        public static bool operator ==(Check_in p1, Check_in p2)
        {
            if ((p1.idCheckIn == p2.idCheckIn) && (p1.cliente == p2.cliente) && (p1.dataCheckIn == p2.dataCheckIn) &&
                (p1.dataCheckOut == p2.dataCheckOut) && (p1.numeroQuarto == p2.numeroQuarto))
                return true;
            return false;
        }

        public static bool operator !=(Check_in p1, Check_in p2)
        {
            if (p1 == p2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return String.Format("Id Check-In: {0} - Cliente: {1} - Data Check-In: {2} - Data Check-Out: {3} - Número Quarto: {4}", idCheckIn.ToString(), cliente.NomeCliente, dataCheckIn.ToString(), dataCheckOut.ToString(), numeroQuarto.ToString());
        }

        public override bool Equals(object obj)
        {
            if (obj is Check_in)
            {
                Check_in p = (Check_in)obj;
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

