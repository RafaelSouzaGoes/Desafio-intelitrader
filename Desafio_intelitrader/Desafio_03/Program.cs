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

            Console.WriteLine("Seja bem vindo ao aplicativo!!");
            Console.WriteLine("Informe os dados a serem processados!!");


            Console.WriteLine("Insira o caminho do primeiro arquivo");
            string arquivo = Console.ReadLine();

            string texto = File.ReadAllText(arquivo).ToLower();

            Dictionary<char, int> contagem = new Dictionary<char, int>();

            foreach (char c in texto)
            {
                if (contagem.ContainsKey(c)) contagem[c]++;

                else contagem[c] = 1;
            }

            var ordemDecresente = contagem.OrderByDescending(x => x.Value).ToList();

            Console.WriteLine("\nRanking de caracteres:");

            foreach (var entry in ordemDecresente)
            {
                Console.WriteLine($"Caractere '{entry.Key}': {entry.Value} ocorrencias");
            }

        }
       
        
       
    }
}
