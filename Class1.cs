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
            bool flag;
            int cidades;

            Console.Write("Qual o número de cidades: ");
            do
            {
                flag = Int32.TryParse(Console.ReadLine(), out cidades);
                if (!flag || cidades <= 0)
                {
                    Console.Write("Entre com um número válido de cidades: ");
                    flag = false;
                }
            } while (!flag);

            // Entrada das distâncias
            int[,] distancias = new int[cidades, cidades];

            Console.WriteLine("\nEntre com as distâncias entre as cidades: ");
            for (int i = 0; i < cidades; i++)
            {
                for (int j = 0; j < cidades; j++)
                {
                    if (j == i)
                    {
                        distancias[i, j] = 0;
                        continue;
                    }
                    else if (j < i)
                    {
                        distancias[i, j] = distancias[j, i];
                        continue;
                    }

                    bool flag1;
                    Console.Write($"Entre com a distâcia entre as cidades {i + 1} e {j + 1}: ");
                    do
                    {
                        flag1 = Int32.TryParse(Console.ReadLine(), out distancias[i, j]);
                        if (!flag1 || distancias[i, j] < 0)
                        {
                            Console.Write("Entre com uma distância válida: ");
                            flag1 = false;
                        }
                    } while (!flag1);
                }
            }

            // Caminho a percorrer
            Console.WriteLine("Entre com o caminho a ser percorrido. Ex. 1, 2, 3, 2, 5, 1, 4");
            string[] caminhosString = Console.ReadLine().Split(", ");
            int[] caminhos = new int[caminhosString.Length];

            for (int i = 0; i < caminhosString.Length; i++)
            {
                Int32.TryParse(caminhosString[i], out caminhos[i]);
            }

            // Distância somada

            int soma = 0;
            for (int i = 0; i < caminhos.Length - 1; i++)
            {
                soma += distancias[caminhos[i] - 1, caminhos[i + 1] - 1];
            }

            Console.WriteLine($"A distância percorrida pelo usuário é de {soma} km.");
        }
    }
}
