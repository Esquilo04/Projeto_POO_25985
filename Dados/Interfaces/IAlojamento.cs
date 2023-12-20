/*
 * Interface responsável por definir métodos relacionados aos alojamentos
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
    internal interface IAlojamento
    {
        /// <summary>
        /// Adiciona um novo alojamento.
        /// </summary>
        bool AdicionarAlojamento(Alojamento a);

        /// <summary>
        /// Exibe todos os alojamentos.
        /// </summary>
        void MostrarAlojamentos();

        /// <summary>
        /// Retorna um alojamento com base no ID fornecido.
        /// </summary>
        Alojamento MostrarAlojamentoPorId(int id);

        /// <summary>
        /// Verifica se um ID de alojamento existe.
        /// </summary>
        bool VerificarIdAlojamentoExistente(int id);

        /// <summary>
        /// Verifica a disponibilidade de um alojamento com base no ID fornecido.
        /// </summary>
        bool VerificarAlojamentoDisponivel(int id);

        /// <summary>
        /// Salva os alojamentos em um arquivo.
        /// </summary>
        bool GuardarAlojamentos(string a);

        /// <summary>
        /// Lê os alojamentos de um arquivo.
        /// </summary>
        bool LerAlojamentos(string a);

        /// <summary>
        /// Remove um alojamento.
        /// </summary>
        void RemoverAlojamento(Alojamento alojamento);

        /// <summary>
        /// Obtém um alojamento com base no ID fornecido.
        /// </summary>
        Alojamento ObterAlojamentoPorId(int id);

        /// <summary>
        /// Obtém o próximo ID disponível para alojamento.
        /// </summary>
        int ObterProximoIdAlojamentoDisponivel();

        /// <summary>
        /// Obtém o valor da noite para um alojamento com base no ID fornecido.
        /// </summary>
        int ObterValorNoitePorId(int id);

        /// <summary>
        /// Altera um dado específico de um alojamento.
        /// </summary>
        bool AlterarDadoAlojamento(int opcao, int id);

        /// <summary>
        /// Altera a disponibilidade de um alojamento com base no ID fornecido.
        /// </summary>
        bool AlterarDisponibilidadeAlojamento(int id);

        /// <summary>
        /// Retorna uma lista de alojamentos disponíveis.
        /// </summary>
        List<Alojamento> MostrarAlojamentosDisponiveis();
    }
}
