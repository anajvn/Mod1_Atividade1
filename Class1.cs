using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod1_Atividade1
{
    internal class Class1
    {
        public static async Task Main(string[] args)
        {
            // Caminho do arquivo distâncias - Desktop
            string caminhoDistacias = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nomeArquivoDistancias = "matriz.txt";

            string caminhoArquivoDistancias = Path.Combine(caminhoDistacias, nomeArquivoDistancias);

            // Uso do Csv Helper para leitura das distâncias

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using var reader = new StreamReader(caminhoArquivoDistancias);
            using var csv = new CsvParser(reader, config);

            // Tamanho da matriz

            if (!csv.Read())
                return;

            int numLinhas = csv.Record.Length;

            // Entrada das distâncias

            int[,] distancias = new int[numLinhas, numLinhas];

            for (int i = 0; i < numLinhas; i++)
            {
                 string[] record = csv.Record;
                for (int j = 0; j < numLinhas; j++)
                {
                    Int32.TryParse(record[j], out distancias[i, j]);
                }
                csv.Read();
            }

            // Caminho do arquivo percurso - Desktop
            string caminhoPercurso = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nomeArquivoPercurso = "caminho.txt";

            string caminhoArquivoPercurso = Path.Combine(caminhoPercurso, nomeArquivoPercurso);

            // Uso do Csv Helper para leitura das distâncias

            var configP = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using var readerP = new StreamReader(caminhoArquivoPercurso);
            using var csvP = new CsvParser(readerP, config);

            // Tamanho da matriz

            if (!csvP.Read())
                return;
            string[] dadosPercurso = csvP.Record;
            int numColunas = dadosPercurso.Length;

            // Entrada das cidades percorridas

            int[] percursos = new int[numColunas];
            for (int i = 0; i < numColunas; i++)
            {
                
                Int32.TryParse(dadosPercurso[i], out percursos[i]);
            }

            // Distância somada

            int soma = 0;
            for (int i = 0; i < percursos.Length - 1; i++)
            {
                soma += distancias[percursos[i] - 1, percursos[i + 1] - 1];
            }

            Console.WriteLine($"A distância percorrida pelo usuário é de {soma} km.");
        }
    }
}
