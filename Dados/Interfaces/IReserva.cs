/*
 * Classe responsavel em enunciar funções relacionadas às Reservas
 * Nuno Oliveira
 * a25985@alunos.ipca.pt
 * 19-12-2023
 * POO-ESI
 * **/
using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    internal interface IReserva
    {
        /// <summary>
        /// Obtém o próximo ID disponível para reserva.
        /// </summary>
        int ObterProximoIdReservaDisponivel();

        /// <summary>
        /// Adiciona uma nova reserva.
        /// </summary>
        bool AdicionarReserva(Reserva r);

        /// <summary>
        /// Calcula o valor total da reserva com base em determinados parâmetros.
        /// </summary>
        int CalcularValorDaReserva(int numeroHospedes, DateTime dataEntrada, DateTime dataSaida, string regime, int valorNoite);

        /// <summary>
        /// Mostra todas as reservas.
        /// </summary>
        void MostrarReservas();

        /// <summary>
        /// Guarda as reservas em um arquivo.
        /// </summary>
        bool GuardarReservas(string r);

        /// <summary>
        /// Lê as reservas de um arquivo.
        /// </summary>
        bool LerReservas(string r);

        /// <summary>
        /// Remove uma reserva.
        /// </summary>
        bool RemoverReserva(Reserva reserva);

        /// <summary>
        /// Obtém uma reserva com base no ID fornecido.
        /// </summary>
        Reserva ObterReservaPorId(int id);

        /// <summary>
        /// Mostra uma reserva com base no ID fornecido.
        /// </summary>
        Reserva MostrarReservaPorId(int id);

        /// <summary>
        /// Obtém o ID do alojamento com base no ID da reserva fornecido.
        /// </summary>
        int ObterIdAlojamento(int id);

        /// <summary>
        /// Altera um dado de uma reserva com base na opção, ID e valor da noite fornecidos.
        /// </summary>
        bool AlterarDadoReserva(int opcao, int id, int valorNoite);

        /// <summary>
        /// Verifica se o ID da reserva existe.
        /// </summary>
        bool VerificarIdReservaExistente(int id);
    }

}
