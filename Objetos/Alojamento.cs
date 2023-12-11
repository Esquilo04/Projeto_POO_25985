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
    /// Classe que representa um alojamento.
    /// </summary>
    public class Alojamento
    {
        /// <summary>
        /// Estado da classe Alojamento.
        /// </summary>
        #region Estado
        private int idAlojamento;               // ID do alojamento
        private string moradaAlojamento;        // Morada do alojamento
        private int numeroQuartos;              // Número de quartos no alojamento
        private int classificacaoAlojamento;    // Classificação do alojamento (1 a 5)
        private int disponibilidade;            // 0 ou 1. 0->disponivel    1->ocupado
        #endregion

        #region Comportamentos

        #region Construtores

        /// <summary>
        /// Construtor por Omissão que inicializa um Alojamento com valores padrão.
        /// </summary>
        public Alojamento()
        {
            idAlojamento = 0;
            moradaAlojamento = "";
            numeroQuartos = 0;
            classificacaoAlojamento = 0;
            disponibilidade = 0;
        }

        /// <summary>
        /// Construtor que permite criar um Alojamento com valores específicos.
        /// </summary>
        /// <param name="idAlojamento">ID do alojamento</param>
        /// <param name="moradaAlojamento">Morada do alojamento</param>
        /// <param name="numeroQuartos">Número de quartos</param>
        /// <param name="classificacaoAlojamento">Classificação do alojamento</param>
        /// <param name="disponibilidade">Disponibilidade do alojamento</param>
        public Alojamento(int idAlojamento, string moradaAlojamento, int numeroQuartos, int classificacaoAlojamento, int disponibilidade)
        {
            this.idAlojamento = idAlojamento;
            this.moradaAlojamento = moradaAlojamento;
            this.numeroQuartos = numeroQuartos;
            this.classificacaoAlojamento = classificacaoAlojamento;
            this.disponibilidade = disponibilidade;
        }

        #endregion

        #region Propriedades

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
        /// Propriedade para acessar e modificar a morada do alojamento.
        /// </summary>
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

        /// <summary>
        /// Propriedade para acessar e modificar o número de quartos do alojamento.
        /// </summary>
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

        /// <summary>
        /// Propriedade para acessar e modificar a classificação do alojamento.
        /// </summary>
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

        public int Disponibilidade
        {
            set
            {
                if (value == 0 || value == 1) // Aceitar apenas 0 ou 1
                    disponibilidade = value;
            }
            get
            {
                return disponibilidade;
            }
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Verifica se dois alojamentos são iguais com base nos seus atributos.
        /// </summary>
        public static bool operator ==(Alojamento p1, Alojamento p2)
        {
            if (ReferenceEquals(p1, null) && ReferenceEquals(p2, null))
            {
                return true;
            }
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            {
                return false;
            }
            return (p1.idAlojamento == p2.idAlojamento) && (p1.moradaAlojamento == p2.moradaAlojamento) && (p1.numeroQuartos == p2.numeroQuartos) && (p1.classificacaoAlojamento == p2.classificacaoAlojamento) && (p1.disponibilidade == p2.disponibilidade);
        }

        /// <summary>
        /// Verifica se dois alojamentos são diferentes com base nos seus atributos.
        /// </summary>
        public static bool operator !=(Alojamento p1, Alojamento p2)
        {
            return !(p1 == p2);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Retorna uma representação textual do objeto Alojamento.
        /// </summary>
        public override string ToString()
        {
            return String.Format("Id Alojamento: {0} - Morada Alojamento: {1} - Número Quartos: {2} - Classificação Alojamento: {3} - Disponibilidade: {4}", idAlojamento.ToString(), moradaAlojamento, numeroQuartos.ToString(), classificacaoAlojamento.ToString(), disponibilidade.ToString());
        }

        /// <summary>
        /// Verifica se o objeto fornecido é igual a este Alojamento.
        /// </summary>
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
