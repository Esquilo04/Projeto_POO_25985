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
using _2classe;

namespace _1classe
{
    /// <summary>
    /// Classe que representa um check-in de um cliente em um hotel.
    /// </summary>
    public class Check_in
    {
        /// <summary>
        /// Estado da classe Check-in.
        /// </summary>
        #region Estado

        private int idCheckIn;           // ID do check-in
        private Cliente cliente;         // Cliente associado ao check-in
        private DateTime dataCheckIn;    // Data de entrada
        private DateTime dataCheckOut;   // Data de saída
        private int numeroQuarto;        // Número do quarto associado ao check-in
        #endregion

        #region Comportamentos

        #region Construtores

        /// <summary>
        /// Construtor por Omissão que inicializa um Check-in com valores padrão.
        /// </summary>
        public Check_in()
        {
            idCheckIn = 0;
            cliente = null;
            dataCheckIn = DateTime.Now;
            dataCheckOut = DateTime.Now;
            numeroQuarto = 0;
        }

        /// <summary>
        /// Construtor que permite criar um Check-in com valores específicos.
        /// </summary>
        /// <param name="id">ID do check-in</param>
        /// <param name="cliente">Cliente associado</param>
        /// <param name="dataCheckIn">Data de entrada</param>
        /// <param name="dataCheckOut">Data de saída</param>
        /// <param name="numeroQuarto">Número do quarto</param>
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

        /// <summary>
        /// Propriedade para acessar e modificar o ID do check-in.
        /// </summary>
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

        /// <summary>
        /// Propriedade para acessar e modificar o Cliente associado ao check-in.
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
        /// Propriedade para acessar e modificar a data de entrada do check-in.
        /// </summary>
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

        /// <summary>
        /// Propriedade para acessar e modificar a data de saída do check-in.
        /// </summary>
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

        /// <summary>
        /// Propriedade para acessar e modificar o número do quarto associado ao check-in.
        /// </summary>
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

        /// <summary>
        /// Verifica se dois check-ins são iguais com base nos seus atributos.
        /// </summary>
        public static bool operator ==(Check_in p1, Check_in p2)
        {
            if ((p1.idCheckIn == p2.idCheckIn) && (p1.cliente == p2.cliente) && (p1.dataCheckIn == p2.dataCheckIn) &&
                (p1.dataCheckOut == p2.dataCheckOut) && (p1.numeroQuarto == p2.numeroQuarto))
                return true;
            return false;
        }

        /// <summary>
        /// Verifica se dois check-ins são diferentes com base nos seus atributos.
        /// </summary>
        public static bool operator !=(Check_in p1, Check_in p2)
        {
            if (p1 == p2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Retorna uma representação textual do objeto Check-in.
        /// </summary>
        public override string ToString()
        {
            return String.Format("Id Check-In: {0} - Cliente: {1} - Data Check-In: {2} - Data Check-Out: {3} - Número Quarto: {4}", idCheckIn.ToString(), cliente.NomeCliente, dataCheckIn.ToString(), dataCheckOut.ToString(), numeroQuarto.ToString());
        }

        /// <summary>
        /// Verifica se o objeto fornecido é igual ao Check-in.
        /// </summary>
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

