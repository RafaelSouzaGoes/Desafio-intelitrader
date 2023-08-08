using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_05
{

    /*
     * Crie uma aplicação que criptografa/descriptografa arquivos utilizando 
     * Cifra de César
     */

    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Cifra de César - Criptografar/Descriptografar Arquivos");
            do
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Criptografar um arquivo");
                Console.WriteLine("2. Descriptografar um arquivo");
                Console.WriteLine("3. Sair");
                Console.Write("Digite a opção escolhida: ");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            CriptografarArquivo();
                            break;
                        case 2:
                            DescriptografarArquivo();
                            break;
                        case 3:
                            finalizarArquivo();
                            return; // Sai do programa se a opção for 3 (Sair)
                        default:
                            Console.WriteLine("Opção inválida. Digite um valor válido.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Digite um valor válido.");
                }

                Console.WriteLine("Deseja fazer outra operação? (s/n)");
            } while (Console.ReadLine().ToLower() == "s");
            finalizarArquivo();

        }

        private static void CriptografarArquivo()
        {
            Console.WriteLine("Digite a frase que sera criptografada.");
            string frase = Console.ReadLine();

            Console.WriteLine("Digite a chave da cifra de César para a criptografia");
            int chave = int.Parse(Console.ReadLine());

            string fraseCriptografada = Criptografar(frase, chave);
            Console.WriteLine($"Frase criptografada: {fraseCriptografada}");
        }

        // Função que criptografa uma mensagem utilizando Cifra de César

        public static string Criptografar(string? frase, int chave)
        {
            char[] caracteres = frase.ToCharArray();

            for (int i = 0; i < caracteres.Length; i++)
            {
                char letra = caracteres[i];

                if (letra != ' ')
                {
                    int codigo = (int)letra + chave;

                    if (codigo > 90 && codigo < 97 || codigo > 122)
                        codigo -= 26;

                    caracteres[i] = (char)codigo;
                }
            }

            return new string(caracteres);
        }


        static void DescriptografarArquivo()
        {
            Console.WriteLine("Digite a frase criptografada:");
            string fraseCriptografada = Console.ReadLine();

            Console.WriteLine("Digite a chave da cifra de César para a descriptografia:");
            int chave = int.Parse(Console.ReadLine());

            string fraseDescriptografada = Descriptografar(fraseCriptografada, chave);
            Console.WriteLine($"Frase descriptografada: {fraseDescriptografada}");
        }

        // Função que descriptografa uma mensagem criptografada utilizando Cifra de César

        public static string Descriptografar(string mensagemCriptografada, int chave)
        {
            char[] caracteres = mensagemCriptografada.ToCharArray();

            for (int i = 0; i < caracteres.Length; i++)
            {
                char letra = caracteres[i];

                if (letra != ' ')
                {
                    int codigo = (int)letra - chave;

                    if (codigo < 65 || (codigo > 90 && codigo < 97))
                        codigo += 26;

                    caracteres[i] = (char)codigo;
                }
            }

            return new string(caracteres);
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
    }



}

