/*
 * Classe responsavel por desenvolver funções relacionadas com Check_Ins
 * Nuno Oliveira
 * a25985@alunos.ipca.pt
 * 19-12-2023
 * POO-ESI
 * **/
using Objetos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Check_Ins : ICheck_in
    {
        #region ESTADOS

        private List<Check_In> check_Ins;

        /// <summary>
        /// Construtor padrão que inicializa a lista de Check_Ins.
        /// </summary>
        public Check_Ins()
        {
            check_Ins = new List<Check_In>();
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Obtem o próximo id disponivel.
        /// </summary>
        public int ObterProximoIdCheck_InDisponivel()
        {
            List<int> idsExistentes = new List<int>();

            foreach (Check_In check_In in check_Ins)
            {
                idsExistentes.Add(check_In.IdCheck_In);
            }

            idsExistentes.Sort();

            int proximoId = 1; // O menor ID possível é 1

            foreach (int idExistente in idsExistentes)
            {
                if (proximoId == idExistente)
                {
                    proximoId++;
                }
                else
                {
                    return proximoId;
                }
            }

            return proximoId; 
        }

        /// <summary>
        /// Efetua o Check_In
        /// </summary>
        /// <param name="c">Lista dos check ins</param>
        /// <returns></returns>
        public bool EfetuarCheck_In(Check_In c)
        {
            check_Ins.Add(c);
            return true;
        }

        /// Remove o Check_In
        /// </summary>
        /// <param name="c">Lista dos check ins</param>
        /// <returns></returns>
        public bool RemoverCheck_In(Check_In c)
        {
            if (check_Ins.Contains(c))
            {
                check_Ins.Remove(c);
                Console.WriteLine("Check_In removido com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Check_In não encontrada na lista.");
                return false;
            }
        }

        /// <summary>
        /// Mostra todos os check_ins na consola
        /// </summary>
        public void MostrarCheck_Ins()
        {
            if (check_Ins.Count == 0)
            {
                Console.WriteLine("Nenhum Check_in foi adicionado ainda.");
                return;
            }

            foreach (Check_In check_In in check_Ins)
            {
                Console.WriteLine(check_In.ToString());
            }
        }

        /// <summary>
        /// Obtem determinado check in pelo seu id
        /// </summary>
        /// <param name="id">id do checkin</param>
        /// <returns></returns>
        public Check_In ObterCheck_InPorId(int id)
        {
            foreach (Check_In check_In in check_Ins)
            {
                if (check_In.IdCheck_In == id)
                {
                    return check_In;
                }
            }
            return null;
        }

        /// <summary>
        /// Guarda os dados do check in em um ficheiro de texto
        /// </summary>
        /// <param name="c">Variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarCheck_Ins(string c)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(c))
                {
                    foreach (var check_Ins in check_Ins)
                    {
                        writer.WriteLine($"{check_Ins.IdCheck_In}#{check_Ins.IdCliente}#{check_Ins.IdReserva}#{check_Ins.IdAlojamento}#{check_Ins.DataCheck_In}#{check_Ins.DataCheck_Out}#{check_Ins.Estadia}");
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao gravar produtos: {e.Message}");
                return false;
            };
        }

        /// <summary>
        /// LÊ os dados do check in de um ficheiro de texto
        /// </summary>
        /// <param name="c">Variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerCheck_Ins(string c)
        {
            try
            {
                using (StreamReader sr = File.OpenText(c))
                {
                    string linha = sr.ReadLine();
                    while (linha != null)
                    {
                        string[] dados = linha.Split('#');
                        int idCheck_In = int.Parse(dados[0]);
                        int idCliente = int.Parse(dados[1]);
                        int idReserva = int.Parse(dados[2]);
                        int idAlojamento = int.Parse(dados[3]);
                        DateTime dataCheck_In = DateTime.ParseExact(dados[4], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime dataCheck_Out = DateTime.ParseExact(dados[5], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        int estadia = int.Parse(dados[6]);

                        Check_In check_In = new Check_In(idCheck_In, idCliente, idReserva, idAlojamento, dataCheck_In, dataCheck_Out, estadia);

                        check_Ins.Add(check_In);

                        linha = sr.ReadLine();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler reservas: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Mostra os check ins que ainda estão pendentes (que não fizeram check out)
        /// </summary>
        public void MostrarCheck_InsPendentes()
        {
            int aux=0;
            foreach (Check_In check_In in check_Ins)
            {
                if (check_In.Estadia == 0)
                {
                    Console.WriteLine(check_In.ToString());
                    aux++;
                }
            }

            if(aux==0)
            { 
                Console.WriteLine("Não existe nenhum Check_In pendente."); 

            }
            
        }

        /// <summary>
        /// Efetua check out
        /// </summary>
        /// <param name="idCheck_In">id do check in</param>
        /// <returns></returns>
        public bool EfetuarCheck_Out(int idCheck_In)
        {
            foreach (Check_In check_In in check_Ins)
            {
                if (check_In.IdCheck_In == idCheck_In)
                {
                    check_In.Estadia = 1;

                    check_In.DataCheck_Out = DateTime.Now;
                    return true;
                }
            }
            return false;
        }


        #endregion
    }

}
