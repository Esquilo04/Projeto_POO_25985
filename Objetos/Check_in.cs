/*
 * Classe para descrever um Check_In
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
    /// Classe que representa um check-in de um cliente em um hotel.
    /// </summary>
    public class Check_In
    {
        /// <summary>
        /// Estado da classe Check-in.
        /// </summary>
        #region Estado

        private int idCheck_In;           // ID do check-in
        private int idCliente;            //id do cliente associado
        private int idReserva;            //id da reserva associada
        private int idAlojamento;         //id do alojamento associado
        private DateTime dataCheck_In;    // Data de entrada
        private DateTime dataCheck_Out;   // Data de saída
        private int estadia;              //0 -> ainda nao terminou   1-> ja terminou
        #endregion

        #region Comportamentos

        #region Construtores

        /// <summary>
        /// Construtor por Omissão que inicializa um Check-in com valores padrão.
        /// </summary>
        public Check_In()
        {
            idCheck_In = 0;
            idCliente = 0;
            idReserva = 0;
            idAlojamento = 0;
            dataCheck_In = DateTime.Now;
            dataCheck_Out = DateTime.Now;
            estadia = 0;
        }

        /// <summary>
        /// Construtor que permite criar um Check-in com valores específicos.
        /// </summary>
        /// <param name="idCheck_In">ID do check-in</param>
        /// <param name="idCliente">Cliente associado</param>
        /// <param name="dataCheckIn">Data de entrada</param>
        /// <param name="dataCheckOut">Data de saída</param>
        /// <param name="numeroQuarto">Número do quarto</param>
        public Check_In(int idCheck_In,  int idCliente, int idReserva, int idAlojamento, DateTime dataCheckIn, DateTime dataCheckOut, int estadia)
        {
            this.idCheck_In = idCheck_In;
            this.idCliente = idCliente;
            this.idReserva = idReserva;
            this.idAlojamento = idAlojamento;
            this.dataCheck_In = dataCheckIn;
            this.dataCheck_Out = dataCheckOut;
            this.estadia = estadia;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade para acessar e modificar o ID do check-in.
        /// </summary>
        public int IdCheck_In
        {
            set
            {
                if (value > 0)
                    idCheck_In = value;
            }
            get
            {
                return idCheck_In;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar o ID do cliente.
        /// </summary>
        public int IdCliente
        {
            set
            {
                if (value > 0)
                    idCliente = value;
            }
            get
            {
                return idCliente;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar o ID da reserva.
        /// </summary>
        public int IdReserva
        {
            set
            {
                if (value > 0)
                    idReserva = value;
            }
            get
            {
                return idReserva;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar o ID do alojamento.
        /// </summary>
        public int IdAlojamento
        {
            set
            {
                if (value > 0)
                    idAlojamento = value;
            }
            get
            {
                return idAlojamento;
            }
        }
        /// <summary>
        /// Propriedade para acessar e modificar a data de entrada do check-in.
        /// </summary>
        public DateTime DataCheck_In
        {
            get
            {
                return dataCheck_In;
            }
            set
            {
                dataCheck_In = value;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar a data de saída do check-in.
        /// </summary>
        public DateTime DataCheck_Out
        {
            get
            {
                return dataCheck_Out;
            }
            set
            {
                dataCheck_Out = value;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar o valor associado à estadia.
        /// </summary>
        public int Estadia
        {
            set
            {
                if (value == 0 || value == 1) // Aceitar apenas 0 ou 1
                    estadia = value;
            }
            get
            {
                return estadia;
            }
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Verifica se dois check-ins são iguais com base nos seus atributos.
        /// </summary>
        public static bool operator ==(Check_In p1, Check_In p2)
        {
            if (ReferenceEquals(p1, null) && ReferenceEquals(p2, null))
            {
                return true;
            }
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            {
                return false;
            }

            return (p1.idCheck_In == p2.idCheck_In) && (p1.idCliente == p2.idCliente) && (p1.idReserva == p2.idReserva) && (p1.idAlojamento == p2.idAlojamento) && (p1.dataCheck_In == p2.dataCheck_In) &&
                (p1.dataCheck_Out == p2.dataCheck_Out) && (p1.estadia == p2.estadia);
        }

        /// <summary>
        /// Verifica se dois check-ins são diferentes com base nos seus atributos.
        /// </summary>
        public static bool operator !=(Check_In p1, Check_In p2)
        {
            return !(p1 == p2);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Retorna uma representação textual do objeto Check-in.
        /// </summary>
        public override string ToString()
        {
            return String.Format("Id Check_In: {0} - Id Cliente: {1} - Id Reserva {2} - Id Alojamento {3} - Data Check-In: {4} - Data Check-Out: {5} - Estadia: {6}", idCheck_In.ToString(), idCliente.ToString(), idReserva.ToString(), idAlojamento.ToString(), dataCheck_In.ToString(), dataCheck_Out.ToString(), estadia.ToString());
        }

        /// <summary>
        /// Verifica se o objeto fornecido é igual ao Check-in.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Check_In)
            {
                Check_In p = (Check_In)obj;
                if (this == p)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #endregion
    }
}

