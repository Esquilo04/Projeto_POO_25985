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
using _1classe;
using _2classe;

namespace Projeto_POO_25985
{
    /// <summary>
    /// Classe responsável por operações de entrada/saída (I/O) para diferentes classes do sistema.
    /// </summary>
    public class Io
    {

        #region Cliente
        /// <summary>
        /// Region utilizada para operações de I/O relacionadas com Clientes.
        /// </summary>



        /// <summary>
        /// Adiciona um novo cliente.
        /// </summary>
        /// <param name="cliente">O cliente a ser adicionado</param>
        void adiconarCliente(Cliente cliente) { }

        #endregion



        #region Check_in
        /// <summary>
        /// Region utilizada para operações de I/O relacionadas com Check-in.
        /// </summary>
   


        /// <summary>
        /// Realiza o check-in de um cliente.
        /// </summary>
        /// <param name="check_in">O objeto Check_in associado ao check-in</param>
        void fazerCheck_in(Check_in check_in) { }

        #endregion



        #region Reserva
        /// <summary>
        /// Region utilizada para operações de I/O relacionadas com Reservas.
        /// </summary>



        /// <summary>
        /// Faz uma reserva de alojamento.
        /// </summary>
        /// <param name="reserva">O objeto Reserva associado à reserva</param>
        void fazerReserva(Reserva reserva) { }

        #endregion



        #region Consulta
        /// <summary>
        /// Region utilizada para operações de I/O relacionadas com Consultas de Dados de Clientes e Alojamentos.
        /// </summary>



        /// <summary>
        /// Consulta os dados de um cliente.
        /// </summary>
        /// <param name="cliente">O cliente cujos dados são consultados</param>
        void consultarDadosCliente(Cliente cliente) { }

        #endregion



        #region Registo
        /// <summary>
        /// Região utilizada para operações de I/O relacionadas com Registo de Alojamentos e Clientes.
        /// </summary>



        /// <summary>
        /// Regista um novo alojamento.
        /// </summary>
        void registarAlojamento(Alojamento alojamento) { }

        #endregion



        #region Alojamento
        /// <summary>
        /// Região utilizada para operações de I/O relacionadas com Alojamentos.
        /// </summary>



        /// <summary>
        /// Altera a morada de um alojamento.
        /// </summary>
        void alterarMoradaAlojamento(Alojamento alojamento) { }

        #endregion
    }
}
