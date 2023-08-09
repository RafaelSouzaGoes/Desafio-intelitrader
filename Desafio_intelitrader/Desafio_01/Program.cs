using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;


/*
 * Crie uma aplicação que recebe dois arquivos e gera um terceiro arquivo 
 * contendo as linhas contidas nos 2 arquivos recebidos 
 * (a interseção)
 */



namespace Desafio_01
{
    public class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("======================================================================================================");
            Console.WriteLine("Seja bem vindo ao aplicativo!!");
            Console.WriteLine("Informe os dados a serem processados!!");

            do
            {

                Console.WriteLine("\n======================================================================================================");

                Console.WriteLine("Insira o caminho do primeiro arquivo");
                string arquivo1 = Console.ReadLine().Trim('"');
                Console.WriteLine("======================================================================================================");

                Console.WriteLine("Insira o caminho do Segundo arquivo");
                string arquivo2 = Console.ReadLine().Trim('"');
                Console.WriteLine("======================================================================================================");

                List<string> ListaArquivo1 = LerArquivo(arquivo1);
                List<string> ListaArquivo2 = LerArquivo(arquivo2);

                List<string> intersecao = FazerIntersecao(ListaArquivo1, ListaArquivo2);


                Console.WriteLine("\nLista intersecao");

                int i = 1;
                foreach (string str in intersecao)
                {
                    Console.WriteLine($"{i}:  {str}");
                    i++;
                }

                Console.WriteLine("\n ");

                string diretorioBase = AppDomain.CurrentDomain.BaseDirectory;

                string arquivoTxt = Path.Combine(diretorioBase, "Lista-intersecao.txt");

                SalvarIntersecaoTxt(intersecao, arquivoTxt);



                Console.WriteLine("\n======================================================================================================");

                Console.WriteLine("Deseja fazer uma nova análise? (S / N)");

            } while (Console.ReadLine().ToLower() == "s");


            Console.WriteLine("======================================================================================================");
            Console.WriteLine("Finalizando Programa!");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Obrigado! Até logo!");
            Console.WriteLine("======================================================================================================");

        }

        // Método para ler o conteúdo de um arquivo e retornar uma lista de strings
        // contendo as linhas do arquivo.

        private static List<string> LerArquivo(string? arquivo)
        {
            List<string> lista = new List<string>();

            try
            {
                lista = new List<string>(File.ReadAllLines(arquivo));
            }
            catch (FileNotFoundException)
            {

                Console.WriteLine($"Arquivo não Encontrado no caminho '{arquivo}'");
            }
            return lista;
        }

        // Método para realizar a interseção entre duas listas de strings.

        private static List<string> FazerIntersecao(List<string> listaArquivo1, List<string> listaArquivo2)
        {
           
            HashSet<string> Lista1 = new HashSet<string>(listaArquivo1);
            HashSet<string> Lista2 = new HashSet<string>(listaArquivo2);

            Lista1.IntersectWith(Lista2);

            return new List<string>(Lista1);

        }

        // Método para salvar a lista de strings em um arquivo de texto.
        private static void SalvarIntersecaoTxt(List<string> intersecao, string arquivoTxt)
        {
            try
            {
                File.WriteAllLines(arquivoTxt, intersecao);
                Console.WriteLine($"Arquivo Txt com a interseção salvo em '{arquivoTxt}'");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao Salvar Arquivo TXT: {ex.Message}");
            }
        }

       /* private static void SalvarIntersecaoJson(List<string> intersecao, string arquivoJson)
        {
            try
            {

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(intersecao, options);
                File.WriteAllLines(arquivoJson, intersecao);
                Console.WriteLine($"Arquivo Json com a interseção salvo em '{arquivoJson}'");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao Salvar Arquivo Json: {ex.Message}");
            }
        }
       */
    
    }

}