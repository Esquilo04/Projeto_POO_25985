using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1classe;

namespace _2classe
{
    /// <summary>
    /// Classe que representa um registo de cliente associado a um alojamento.
    /// </summary>
    public class Registo
    {
        #region Estado
        private Cliente cliente;       // Cliente associado ao registo
        private Alojamento alojamento; // Alojamento associado ao registo
        #endregion

        #region Comportamentos

        #region Construtores

        /// <summary>
        /// Construtor por Omissão que inicializa um Registo com valores padrão.
        /// </summary>
        public Registo()
        {
            cliente = null;
            alojamento = null;
        }

        /// <summary>
        /// Construtor que permite criar um Registo com valores específicos.
        /// </summary>
        /// <param name="cliente">Cliente associado</param>
        /// <param name="alojamento">Alojamento associado</param>
        public Registo(Cliente cliente, Alojamento alojamento)
        {
            this.cliente = cliente;
            this.alojamento = alojamento;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade para acessar e modificar o Cliente associado ao registo.
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
        /// Propriedade para acessar e modificar o Alojamento associado ao registo.
        /// </summary>
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

        /// <summary>
        /// Verifica se dois registos são iguais com base nos clientes e alojamentos associados.
        /// </summary>
        public static bool operator ==(Registo p1, Registo p2)
        {
            if ((p1.cliente == p2.cliente) && (p1.alojamento == p2.alojamento))
                return true;
            return false;
        }

        /// <summary>
        /// Verifica se dois registos são diferentes com base nos clientes e alojamentos associados.
        /// </summary>
        public static bool operator !=(Registo p1, Registo p2)
        {
            if (p1 == p2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Retorna uma representação textual do objeto Registo.
        /// </summary>
        public override string ToString()
        {
            return String.Format("Id Cliente: {0} - Nome Cliente: {1} - Nif Cliente: {2} - Morada Cliente: {3} - Telemovel Cliente: {4}\n Id Alojamento: {0} - Morada Alojamento: {1} - Número Quartos: {2} - Classificação Alojamento: {3}",
                cliente.IdCliente.ToString(), cliente.NomeCliente, cliente.NifCliente.ToString(), cliente.MoradaCliente, cliente.TelemovelCliente.ToString(), alojamento.IdAlojamento.ToString(), alojamento.MoradaAlojamento, alojamento.NumeroQuartos.ToString(), alojamento.ClassificacaoAlojamento.ToString());
        }

        /// <summary>
        /// Verifica se o objeto fornecido é igual ao Registo.
        /// </summary>
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

