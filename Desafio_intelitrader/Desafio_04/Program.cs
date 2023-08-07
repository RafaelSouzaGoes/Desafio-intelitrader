using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_04
{
    public class Program
    {
        /*
         * Crie uma aplicação que codifica/decodifica
         * arquivos para Base64
         */
        static void Main(string[] args)
        {

            Console.WriteLine("Seja bem vindo ao aplicativo!!");

            Console.WriteLine("Digite 'e' para codificar ou 'd' para descodificar");
            string resposta = Console.ReadLine().ToLower();

            if (resposta.Equals("e", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Insira o caminho do arquivo");
                string arquivo = Console.ReadLine();
                CodificarArquivo(arquivo);
            }
            else if (resposta.Equals("d", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Insira o caminho do arquivo");
                string arquivo = Console.ReadLine();
                DescodificarArquivo(arquivo);
            }
            else
            {
                Console.WriteLine("Opção invalida.");
            }

        }


        static void CodificarArquivo(string? arquivo)
        {
            byte[] textoAsByte = File.ReadAllBytes(arquivo);
            string resultado = Convert.ToBase64String(textoAsByte);
           
            Console.WriteLine("\nResultado do arquivo Codificado");
            Console.WriteLine(resultado);

            Console.WriteLine("Qual o nome do arquivo para salvar?");
            string nomeArquivo = Console.ReadLine();

            string arquivoSaida = Path.ChangeExtension(nomeArquivo, ".txt");
            File.WriteAllText(arquivoSaida, resultado);

            Console.WriteLine("\nArquivo Base64 salvo em: " + arquivoSaida);

        }
        static void DescodificarArquivo(string? arquivo)
        {

            string bytesAsTexto = File.ReadAllText(arquivo);
            byte[] resultado = Convert.FromBase64String(bytesAsTexto);

            Console.WriteLine("Qual o nome do arquivo para salvar?");
            string nomeArquivo = Console.ReadLine();

            string arquivoSaida = Path.ChangeExtension(nomeArquivo,".txt");
            File.WriteAllBytes(arquivoSaida, resultado);

            Console.WriteLine("\nArquivo Base64 salvo em: " + arquivoSaida);
        }

    }
}
