using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod1_Atividade1
{
    internal class Class1
    {
        public static void Main(string[] args)
        {
            // Leitura do arquivo de distâncias - Desktop

            string caminhoDistancia = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nomeArquivoDistancia = "matriz.txt";

            string caminhoArquivoDistancia = Path.Combine(caminhoDistancia, nomeArquivoDistancia);

            string[] linhasDistancia = System.IO.File.ReadAllLines(caminhoArquivoDistancia);


            // Número de cidades - tamanho da matriz

            int cidades = linhasDistancia.Length;


            // Adequação das Strings de distância para uma matriz int

            int[,] distancias = new int[cidades, cidades];
            for (int i = 0; i < cidades; i++)
            {
                string[] separador = linhasDistancia[i].Split(",");
                for (int j = 0; j < cidades; j++)
                {
                    Int32.TryParse(separador[j], out distancias[i, j]);
                }
            }


            // Leitura do arquivo do percuso - Desktop

            string caminhoPercurso = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nomeArquivoPercurso = "caminho.txt";

            string caminhoArquivoPercurso = Path.Combine(caminhoPercurso, nomeArquivoPercurso);

            string[] linhaPercurso = System.IO.File.ReadAllLines(caminhoArquivoPercurso);


            // Adequação da String do percurso para um vetor int

            string[] percursoString = linhaPercurso[0].Split(", ");
            int[] percurso = new int[percursoString.Length];

            for (int i = 0; i < percursoString.Length; i++)
            {
                Int32.TryParse(percursoString[i], out percurso[i]);
            }


            // Distância somada

            int soma = 0;
            for (int i = 0; i < percurso.Length - 1; i++)
            {
                soma += distancias[percurso[i] - 1, percurso[i + 1] - 1];
            }

            Console.WriteLine($"A distância percorrida pelo usuário é de {soma} km.");
        }
    }
}
