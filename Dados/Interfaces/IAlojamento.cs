using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2classe
{
    internal interface IAlojamento
    {
        bool AdicionarAlojamento(Alojamento a);

        void MostrarAlojamentos();

        Alojamento MostrarAlojamentoPorId(int id);

        bool VerificarIdAlojamentoExistente(int id);

        bool GuardarAlojamentos(string a);

        bool LerAlojamentos(string a);

        void RemoverAlojamento(Alojamento alojamento);

        Alojamento ObterAlojamentoPorId(int id);

        int ObterProximoIdAlojamentoDisponivel();


    }
}
