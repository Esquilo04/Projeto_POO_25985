using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2classe;

namespace _1classe
{
    public class Cliente
    {
        #region Estado
        private int idCliente;
        private string nomeCliente;
        private int nifCliente;
        private string moradaCliente;
        private int telemovelCliente;


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

        public static bool operator ==(Cliente p1, Cliente p2)
        {
            if ((p1.idCliente == p2.idCliente) && (p1.nomeCliente == p2.nomeCliente) && (p1.nifCliente == p2.nifCliente) &&
                (p1.moradaCliente == p2.moradaCliente) && (p1.telemovelCliente == p2.telemovelCliente))
                return true;
            return false;
        }

        public static bool operator !=(Cliente p1, Cliente p2)
        {
            if (p1 == p2)
                return false;
            return true;
        }
        #endregion

        #region Overrides

        public override string ToString()
        {
            return String.Format("Id Cliente: {0} - Nome Cliente: {1} - Nif Cliente: {2} - Morada Cliente: {3} - Telemovel Cliente: {4}", idCliente.ToString(), nomeCliente, nifCliente.ToString(), moradaCliente, telemovelCliente.ToString());
        }

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

