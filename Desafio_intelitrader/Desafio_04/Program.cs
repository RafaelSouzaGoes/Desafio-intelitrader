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

            Console.WriteLine("Bem-vindo ao codificador/decodificador Base64!");

            bool repetir = true;

            while (repetir)
            {

                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Codificar um arquivo para Base64");
                Console.WriteLine("2. Descodificar um arquivo de Base64");
                Console.WriteLine("3. Sair");
                Console.Write("Digite a opção escolhida: ");

                string resposta = Console.ReadLine();

                switch (resposta)
                {
                    case "1":
                        CodificarArquivo();
                        break;
                    case "2":
                        DescodificarArquivo();
                        break;
                    case "3":
                        finalizarArquivo();
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. por favor, tente novamente.");
                        break;
                }
            }
        }

        // Método que exibe a mensagem de finalização e aguarda 2 segundos antes de encerrar

        private static void finalizarArquivo()
        {
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("Finalizando Programa!");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Obrigado! Até logo!");
            Console.WriteLine("======================================================================================================");

        }

        // Método que codifica um arquivo para Base64

        static void CodificarArquivo()
        {

            try
            {

                Console.WriteLine("Insira o caminho do arquivo");
                string arquivo = Console.ReadLine();

                if (!File.Exists(arquivo))
                {
                    Console.WriteLine("Arquivo não encontrado. Verifique se o caminho esta correto.");
                    return;
                }

                byte[] textoAsByte = File.ReadAllBytes(arquivo);
                string resultado = Convert.ToBase64String(textoAsByte);

                Console.WriteLine("\nResultado do arquivo Codificado");
                Console.WriteLine(resultado);

                Console.WriteLine("Qual o nome do arquivo para salvar?");
                string nomeArquivo = Console.ReadLine();

                // Cria o arquivo de saída com a extensão ".txt" contendo o resultado em Base64

                string arquivoSaida = Path.ChangeExtension(nomeArquivo, ".txt");
                File.WriteAllText(arquivoSaida, resultado);

                Console.WriteLine("\nArquivo Base64 salvo em: " + arquivoSaida);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao codificar: '{ex.Message}'");
            }

        }

        // Método que decodifica um arquivo de Base64 para binário

        static void DescodificarArquivo()
        {
            Console.WriteLine("Insira o caminho do arquivo");
            string arquivo = Console.ReadLine();

            if (!File.Exists(arquivo))
            {
                Console.WriteLine("Arquivo não encontrado. Verifique se o caminho esta correto.");
                return;
            }


            try
            {
                string bytesAsTexto = File.ReadAllText(arquivo);
                byte[] resultado = Convert.FromBase64String(bytesAsTexto);

                Console.WriteLine("Qual o nome do arquivo para salvar?");
                string nomeArquivo = Console.ReadLine();

                // Cria o arquivo de saída com a extensão ".txt" contendo o resultado decodificado

                string arquivoSaida = Path.ChangeExtension(nomeArquivo, ".txt");
                File.WriteAllBytes(arquivoSaida, resultado);

                Console.WriteLine("\nArquivo Base64 salvo em: " + arquivoSaida);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao codificar: '{ex.Message}'");

            }
        }

    }
}
