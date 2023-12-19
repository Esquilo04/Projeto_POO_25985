using _2classe;
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
    public class Alojamentos
    {
        #region ESTADOS

        private List<Alojamento> alojamentos;

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

        public bool AdicionarAlojamento(Alojamento a)
        {
            alojamentos.Add(a);
            return true;
        }

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

        public int ObterProximoIdAlojamentoDisponivel()
        {
            List<int> idsExistentes = new List<int>();

            foreach (Alojamento alojamento in alojamentos)
            {
                idsExistentes.Add(alojamento.IdAlojamento);
            }

            // Ordena os IDs existentes em ordem crescente
            idsExistentes.Sort();

            // Verifica o próximo ID disponível
            int proximoId = 1; // O menor ID possível é 1

            foreach (int idExistente in idsExistentes)
            {
                // Se o próximo ID for igual ao ID existente, incrementa o próximo ID
                if (proximoId == idExistente)
                {
                    proximoId++;
                }
                else
                {
                    // Se encontrar um ID diferente, retorna o próximo ID disponível
                    return proximoId;
                }
            }

            return proximoId; // Se não houver IDs disponíveis entre os existentes, retorna o próximo número
        }

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
