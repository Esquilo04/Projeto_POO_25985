/*
 * Classe responsavel por desenvolver funções relacionadas com alojamentos
 * Nuno Oliveira
 * a25985@alunos.ipca.pt
 * 19-12-2023
 * POO-ESI
 * **/
using Dados;
using Objetos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Alojamentos : IAlojamento
    {
        #region ESTADOS

        private List<Alojamento> alojamentos;

        /// <summary>
        /// Construtor padrão que inicializa a lista de alojamentos.
        /// </summary>
        public Alojamentos()
        {
            alojamentos = new List<Alojamento>(); // Inicializa a lista de alojamento no construtor
        }

        #endregion

        #region PROPRIEDADES

        public List<Alojamento> ALOJAMENTOS
        {
            get { return alojamentos; }
            set { alojamentos = value; }
        }


        #endregion

        #region OUTROSMETODOS

        /// <summary>
        /// Adiciona um novo alojamento à lista.
        /// </summary>
        /// <param name="a">Variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool AdicionarAlojamento(Alojamento a)
        {
            alojamentos.Add(a);
            return true;
        }

        /// <summary>
        /// Mostra todos os alojamentos na lista, se existirem.
        /// </summary>
        public void MostrarAlojamentos()
        {
            if (alojamentos.Count == 0)
            {
                Console.WriteLine("Nenhum alojamento foi adicionado ainda.");
                return;
            }

            foreach (Alojamento alojamento in alojamentos)
            {
                Console.WriteLine(alojamento.ToString());
            }
        }

        /// <summary>
        /// Mostra um alojamento com um determinado ID, se existir.
        /// </summary>
        /// <param name="id">id do alojamento</param>
        /// <returns></returns>
        public Alojamento MostrarAlojamentoPorId(int id)
        {
            foreach (Alojamento alojamento in ALOJAMENTOS)
            {
                if (alojamento.IdAlojamento == id)
                {
                    Console.WriteLine("Dados do Alojamento:");
                    Console.WriteLine(alojamento.ToString());
                    return alojamento;
                }
            }

            return null;
        }

        /// <summary>
        /// Verifica se um ID de alojamento existe na lista.
        /// </summary>
        /// <param name="id">id do alojamento</param>
        /// <returns></returns>
        public bool VerificarIdAlojamentoExistente(int id)
        {
            foreach (Alojamento alojamento in alojamentos)
            {
                if (alojamento.IdAlojamento == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica se um ID de alojamento existe na lista e tem disponibilidade.
        /// </summary>
        /// <param name="id">id do alojamento</param>
        /// <returns></returns>
        public bool VerificarAlojamentoDisponivel(int id)
        {
            foreach (Alojamento alojamento in alojamentos)
            {
                if (alojamento.IdAlojamento == id)
                {
                    if(alojamento.Disponibilidade == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Guarda os alojamentos num ficheiro de texto.
        /// </summary>
        /// <param name="a">Variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarAlojamentos(string a)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(a))
                {
                    foreach (var alojamentos in alojamentos)
                    {
                        writer.WriteLine($"{alojamentos.IdAlojamento}#{alojamentos.MoradaAlojamento}#{alojamentos.NumeroQuartos}#{alojamentos.ClassificacaoAlojamento}#{alojamentos.Disponibilidade}#{alojamentos.ValorNoite}");
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
        /// Lê os dados dos alojamentos de um ficheiro.
        /// </summary>
        /// <param name="a">Variavel para o nome do ficheiro</param>
        /// <returns></returns>

        public bool LerAlojamentos(string a)
        {
            try
            {
                using (StreamReader sr = File.OpenText(a))
                {
                    string linha = sr.ReadLine();
                    while (linha != null)
                    {
                        string[] sdados = linha.Split('#');
                        int id = int.Parse(sdados[0]);
                        string morada = sdados[1];
                        int numeroQuartos = int.Parse(sdados[2]);
                        int classificacao = int.Parse(sdados[3]);
                        int disponibilidade = int.Parse(sdados[4]);
                        int valorNoite = int.Parse(sdados[5]);


                        Alojamento alojamento = new Alojamento(id, morada, numeroQuartos, classificacao, disponibilidade, valorNoite);

                        alojamentos.Add(alojamento);

                        linha = sr.ReadLine();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler alojamentos: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Remove determinado alojamento da lista.
        /// </summary>
        /// <param name="alojamento">lista dos alojamentos</param>
        public void RemoverAlojamento(Alojamento alojamento)
        {
            if (alojamentos.Contains(alojamento))
            {
                alojamentos.Remove(alojamento);
                Console.WriteLine("Alojamento removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Alojamento não encontrado na lista.");
            }
        }

        /// <summary>
        /// Obtem determinado alojamento atraves do seu id.
        /// </summary>
        /// <param name="id">id do alojamento</param>
        /// <returns></returns>
        public Alojamento ObterAlojamentoPorId(int id)
        {
            foreach (Alojamento alojamento in alojamentos)
            {
                if (alojamento.IdAlojamento == id)
                {
                    return alojamento;
                }
            }
            return null;
        }

        /// <summary>
        /// Verifica o próximo id disponivel.
        /// </summary>
        public int ObterProximoIdAlojamentoDisponivel()
        {
            List<int> idsExistentes = new List<int>();

            foreach (Alojamento alojamento in alojamentos)
            {
                idsExistentes.Add(alojamento.IdAlojamento);
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
        /// Obtem o valor de cada noite do alojamento atraves do seu id.
        /// </summary>
        /// <param name="id">id do alojamento</param>
        /// <returns></returns>
        public int ObterValorNoitePorId(int id)
        {
            foreach (Alojamento alojamento in alojamentos)
            {
                if (alojamento.IdAlojamento == id)
                {
                    return alojamento.ValorNoite;
                }
            }
            return -1;
        }

        /// <summary>
        /// Altera determinado dado do alojamento atraves do seu id e de uma opcao.
        /// </summary>
        /// <param name="opcao">opcao da pergunta</param>
        /// <param name="id">id do alojamento</param>
        /// <returns></returns>
        public bool AlterarDadoAlojamento(int opcao, int id)
        {
            foreach (Alojamento alojamento in alojamentos)
            {
                if (alojamento.IdAlojamento == id)
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Qual a nova morada?");
                            string morada = Console.ReadLine();
                            alojamento.MoradaAlojamento = morada;
                            break;
                        case 2:
                            Console.WriteLine("Qual o novo numero de quartos");
                            int numeroQuartos = int.Parse(Console.ReadLine());
                            alojamento.NumeroQuartos = numeroQuartos;
                            break;
                        case 3:
                            Console.WriteLine("Qual a nova classificacao?");
                            int classificacao = int.Parse(Console.ReadLine());
                            alojamento.ClassificacaoAlojamento = classificacao;
                            break;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Altera a disponibilidade do alojamento (0  passa para 1, e vice versa)
        /// </summary>
        /// <param name="id">id do alojamento</param>
        /// <returns></returns>        
        public bool AlterarDisponibilidadeAlojamento(int id)
        {
            foreach (Alojamento alojamento in alojamentos)
            {
                if (alojamento.IdAlojamento == id)
                {
                    if (alojamento.Disponibilidade == 1)
                    {
                        alojamento.Disponibilidade = 0;
                        Console.WriteLine("Disponibilidade do alojamento alterada para: Disponivel");
                    }
                    else if (alojamento.Disponibilidade == 0)
                    {
                        alojamento.Disponibilidade = 1;
                        Console.WriteLine("Disponibilidade do alojamento alterada para: Indisponivel");
                    }
                    else
                    {
                        Console.WriteLine("Algo está errado pois o regime deveria ser 0 ou 1.");
                    }
                    return true; 
                }
            }
            Console.WriteLine("Alojamento não encontrado.");
            return false; 
        }

        /// <summary>
        /// Mostra os alojamentos disponiveis (se a sua variavel disponibilidade for 0).
        /// </summary>
        public List<Alojamento> MostrarAlojamentosDisponiveis()
        {
            List<Alojamento> alojamentosDisponiveis = new List<Alojamento>();

            foreach (Alojamento alojamento in ALOJAMENTOS)
            {
                if (alojamento.Disponibilidade == 0)
                {
                    alojamentosDisponiveis.Add(alojamento);
                }
            }

            return alojamentosDisponiveis;
        }
        #endregion
    }
}
