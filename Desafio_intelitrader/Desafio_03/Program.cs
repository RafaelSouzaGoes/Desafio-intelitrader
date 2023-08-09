using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_03
{
    public class Program
    {

        static void Main(string[] args)
        {
            /*
             * Crie uma aplicação que recebe um arquivo de texto e monta 
             * um ranking de quantidade dos caracteres contidos
             * 
             */

            Console.WriteLine("Bem-vindo ao Analisador de Caracteres!!");
            Console.WriteLine("Informe os dados a serem processados!!");



            do
            {

                // Solicita ao usuário o caminho do arquivo de texto a
                // ser analisado

                Console.WriteLine("Insira o caminho do primeiro arquivo");
                string arquivo = Console.ReadLine().Trim('"');


                try
                {
                    string texto = File.ReadAllText(arquivo).ToLower();
                    Dictionary<char, int> contagem = CountCharacter(texto);
                    PrintCharacterRanking(contagem);
                }
                catch (FileNotFoundException)
                {

                    Console.WriteLine("Arquivo não encontrado.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um error: '{ex.Message}'");
                }



                Console.WriteLine("======================================================================================================");
                Console.WriteLine();
                Console.WriteLine("Deseja fazer uma nova análise? (S / N)");

            } while (Console.ReadLine().ToLower() == "s");

            Console.WriteLine("======================================================================================================");
            Console.WriteLine("Finalizando Programa!");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Obrigado! Até logo!");
            Console.WriteLine("======================================================================================================");

        }

        // Função que conta a ocorrência de cada caractere no texto

        private static Dictionary<char, int> CountCharacter(string texto)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in texto)
            {
                if (c == '\n' || c == '\r') // Ignorar quebras de linha e retornos
                    continue;

                if (charCount.ContainsKey(c))
                    charCount[c]++;

                else charCount[c] = 1;
            }
            return charCount;

        }

        // Função que imprime o ranking de caracteres com base na quantidade de ocorrências

        private static void PrintCharacterRanking(Dictionary<char, int> contagem)
        {

            var sortedCharCount = contagem.OrderByDescending(x => x.Value);
            Console.WriteLine("\nRanking de caractere:");

            foreach (var c in sortedCharCount)
            {
                Console.WriteLine($"Caractere '{c.Key}': '{c.Value}' Repetições");
            }

        }
    }
}
