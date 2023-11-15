using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1classe;

namespace _2classe
{
    public class Alojamento
    {
        #region Estado
        private int idAlojamento;
        private string moradaAlojamento;
        private int numeroQuartos;
        private int classificacaoAlojamento;
        #endregion

        #region Comportamentos

        #region Construtores

        /// <summary>
        /// Construtor por Omissão
        /// </summary>
        public Alojamento()
        {
            idAlojamento = 0;
            moradaAlojamento = "";
            numeroQuartos = 0;
            classificacaoAlojamento = 0;
        }

        /// <summary>
        /// Construtor por Parametros
        /// </summary>
        /// <param name="idAlojamento">Varivel que identifica o id do alojamento</param>
        /// <param name="moradaAlojamento"></param>
        /// <param name="numeroQuartos"></param>
        /// <param name="classificacaoAlojamento"></param>
        public Alojamento(int idAlojamento, string moradaAlojamento, int numeroQuartos, int classificacaoAlojamento)
        {
            this.idAlojamento = idAlojamento;
            this.moradaAlojamento = moradaAlojamento;
            this.numeroQuartos = numeroQuartos;
            this.classificacaoAlojamento = classificacaoAlojamento;
        }

        #endregion

        #region Propriedades

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

        public string MoradaAlojamento
        {
            set
            {
                moradaAlojamento = value;
            }
            get
            {
                return moradaAlojamento;
            }
        }

        public int NumeroQuartos
        {
            set
            {
                if (value > 0)
                    numeroQuartos = value;
            }
            get
            {
                return numeroQuartos;
            }
        }

        public int ClassificacaoAlojamento
        {
            set
            {
                if (value > 0 && value <= 5)
                    classificacaoAlojamento = value;
            }
            get
            {
                return classificacaoAlojamento;
            }
        }

        #endregion

        #region Operadores

        public static bool operator ==(Alojamento p1, Alojamento p2)
        {
            if ((p1.idAlojamento == p2.idAlojamento) && (p1.moradaAlojamento == p2.moradaAlojamento) && (p1.numeroQuartos == p2.numeroQuartos) && (p1.classificacaoAlojamento == p2.classificacaoAlojamento))
                return true;
            return false;
        }

        public static bool operator !=(Alojamento p1, Alojamento p2)
        {
            if (p1 == p2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return String.Format("Id Alojamento: {0} - Morada Alojamento: {1} - Número Quartos: {2} - Classificação Alojamento: {3}", idAlojamento.ToString(), moradaAlojamento, numeroQuartos.ToString(), classificacaoAlojamento.ToString());
        }

        public override bool Equals(object obj)
        {
            if (obj is Alojamento)
            {
                Alojamento p = (Alojamento)obj;
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
