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
    /// Classe que representa um cliente.
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Estado da classe Cliente
        /// </summary>
        #region Estado
        private int idCliente;          // ID do cliente
        private string nomeCliente;    // Nome do cliente
        private int nifCliente;        // NIF (Número de Identificação Fiscal) do cliente
        private string moradaCliente;  // Morada do cliente
        private int telemovelCliente;  // Número de telemóvel do cliente
        #endregion

        #region Comportamentos

        #region Construtores

        /// <summary>
        /// Construtor por Omissão
        /// </summary>
        public Cliente()
        {
            idCliente = 0;
            nomeCliente = "";
            nifCliente = 0;
            moradaCliente = "";
            telemovelCliente = 0;
        }

        /// <summary>
        /// Construtor com parâmetros para inicializar um Cliente com valores específicos.
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <param name="nome">Nome do cliente</param>
        /// <param name="nif">NIF do cliente</param>
        /// <param name="morada">Morada do cliente</param>
        /// <param name="tel">Número de telemóvel do cliente</param>

        public Cliente(int id, string nome, int nif, string morada, int tel)
        {
            this.idCliente = id;
            this.nomeCliente = nome;
            this.nifCliente = nif;
            this.moradaCliente = morada;
            this.telemovelCliente = tel;
        }
        #endregion


        #region Propriedades

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
        /// Propriedade para acessar e modificar o Nome do cliente.
        /// </summary>
        public string NomeCliente
        {
            get
            {
                return nomeCliente;
            }
            set
            {
                nomeCliente = value;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar o NIF do cliente.
        /// </summary>
        public int NifCliente
        {
            set
            {
                if (value > 0)
                    nifCliente = value;
            }
            get
            {
                return nifCliente;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar a morada do cliente.
        /// </summary>
        public string MoradaCliente
        {
            get
            {
                return moradaCliente;
            }
            set
            {
                moradaCliente = value;
            }
        }

        /// <summary>
        /// Propriedade para acessar e modificar o número de telmovel do cliente.
        /// </summary>
        public int TelemovelCliente
        {
            set
            {
                if (value > 0)
                    telemovelCliente = value;
            }
            get
            {
                return telemovelCliente;
            }
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Função que verifica se dois clientes são iguais com base nos seus atributos.
        /// </summary>
        public static bool operator ==(Cliente p1, Cliente p2)
        {
            if ((p1.idCliente == p2.idCliente) && (p1.nomeCliente == p2.nomeCliente) && (p1.nifCliente == p2.nifCliente) &&
                (p1.moradaCliente == p2.moradaCliente) && (p1.telemovelCliente == p2.telemovelCliente))
                return true;
            return false;
        }

        /// <summary>
        /// Função que verifica se dois clientes são diferentes com base nos seus atributos.
        /// </summary>
        public static bool operator !=(Cliente p1, Cliente p2)
        {
            if (p1 == p2)
                return false;
            return true;
        }
        #endregion

        #region Overrides

        /// <summary>
        /// Função que retorna uma representação textual do cliente.
        /// </summary>
        public override string ToString()
        {
            return String.Format("Id Cliente: {0} - Nome Cliente: {1} - Nif Cliente: {2} - Morada Cliente: {3} - Telemovel Cliente: {4}", idCliente.ToString(), nomeCliente, nifCliente.ToString(), moradaCliente, telemovelCliente.ToString());
        }

        /// <summary>
        /// Função que verifica se o objeto fornecido é igual ao Cliente.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Cliente)
            {
                Cliente p = (Cliente)obj;
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

