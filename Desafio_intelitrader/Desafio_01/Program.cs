using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


/*
 * Crie uma aplicação que recebe dois arquivos e gera um terceiro arquivo 
 * contendo as linhas contidas nos 2 arquivos recebidos 
 * (a interseção)
 * 
 */



namespace Desafio_01
{
    public class Program
    {

        static void Main(string[] args)
        {

            //Deseralizando

            Console.WriteLine("Seja bem vindo ao aplicativo!!");
            Console.WriteLine("Informe os dados a serem processados!!");

           
            Console.WriteLine("Insira o caminho do primeiro arquivo");
            string arquivo1 = Console.ReadLine();

            Console.WriteLine("Insira o caminho do Segundo arquivo");
            string arquivo2 = Console.ReadLine();

            List<string> ListaArquivo1 = new List<string>(File.ReadAllLines(arquivo1));
            List<string> ListaArquivo2 = new List<string>(File.ReadAllLines(arquivo2));

            List<string> intersecao = ListaArquivo1.Intersect(ListaArquivo2).ToList();

            /*
            Console.WriteLine("Lista 1");

            foreach (string str in ListaArquivo1) { Console.WriteLine(str); }


            Console.WriteLine("\nLista 2");

            foreach (string str in ListaArquivo2) { Console.WriteLine(str); }
            */

           
            Console.WriteLine("\nLista intersecao");

            foreach (string str in intersecao) {  Console.WriteLine(str); }

            Console.WriteLine("\n ");

            File.WriteAllLines("Lista-intersecao.txt", intersecao) ;
            Console.WriteLine("O Resultado da intersecao foi salva Lista-intersecao.txt");


        }
    }
}
