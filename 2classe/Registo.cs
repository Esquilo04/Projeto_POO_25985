using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1classe;

namespace _2classe
{
    public class Registo
    {
        #region Estado
        private Cliente cliente;
        private Alojamento alojamento;
        #endregion

        #region Comportamentos

        #region Construtores

        /// <summary>
        /// Construtor por Omissão
        /// </summary>
        public Registo()
        {
            cliente = null;
            alojamento = null;
        }

        public Registo(Cliente cliente, Alojamento alojamento)
        {
            this.cliente = cliente;
            this.alojamento = alojamento;
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

        public Alojamento Alojamento
        {
            get
            {
                return alojamento;
            }
            set
            {
                alojamento = value;
            }
        }

        #endregion

        #region Operadores

        public static bool operator ==(Registo p1, Registo p2)
        {
            if ((p1.cliente == p2.cliente) && (p1.alojamento == p2.alojamento))
                return true;
            return false;
        }

        public static bool operator !=(Registo p1, Registo p2)
        {
            if (p1 == p2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return String.Format("Id Cliente: {0} - Nome Cliente: {1} - Nif Cliente: {2} - Morada Cliente: {3} - Telemovel Cliente: {4}\n Id Alojamento: {0} - Morada Alojamento: {1} - Número Quartos: {2} - Classificação Alojamento: {3}",
                cliente.IdCliente.ToString(), cliente.NomeCliente, cliente.NifCliente.ToString(), cliente.MoradaCliente, cliente.TelemovelCliente.ToString(), alojamento.IdAlojamento.ToString(), alojamento.MoradaAlojamento, alojamento.NumeroQuartos.ToString(), alojamento.ClassificacaoAlojamento.ToString());
        }

        public override bool Equals(object obj)
        {
            if (obj is Registo)
            {
                Registo p = (Registo)obj;
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

