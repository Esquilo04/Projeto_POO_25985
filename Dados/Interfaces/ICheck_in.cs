/*
 * Classe responsavel em enunciar funções relacionadas aos Check_Ins
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
    internal interface ICheck_in
    {
        /// <summary>
        /// Obtém o próximo ID disponível para Check_In.
        /// </summary>
        int ObterProximoIdCheck_InDisponivel();

        /// <summary>
        /// Efetua um Check_In.
        /// </summary>
        bool EfetuarCheck_In(Check_In c);

        /// <summary>
        /// Remove um Check_In.
        /// </summary>
        bool RemoverCheck_In(Check_In c);

        /// <summary>
        /// Exibe todos os Check_Ins.
        /// </summary>
        void MostrarCheck_Ins();

        /// <summary>
        /// Obtém um Check_In com base no ID fornecido.
        /// </summary>
        Check_In ObterCheck_InPorId(int id);

        /// <summary>
        /// Guarda os Check_Ins em um arquivo.
        /// </summary>
        bool GuardarCheck_Ins(string c);

        /// <summary>
        /// Lê os Check_Ins de um arquivo.
        /// </summary>
        bool LerCheck_Ins(string c);

        /// <summary>
        /// Exibe os Check_Ins pendentes.
        /// </summary>
        void MostrarCheck_InsPendentes();

        /// <summary>
        /// Efetua um Check_Out com base no ID do Check_In fornecido.
        /// </summary>
        bool EfetuarCheck_Out(int idCheck_In);
    }

}
