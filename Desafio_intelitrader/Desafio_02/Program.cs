using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_02
{
    public class Program
    {

        static void Main(string[] args)
        {
            /*
             * Crie uma aplicação capaz de realizar multiplicação de 
             * números com mais de 22 caracteres (bigInt)
             * */
            Console.WriteLine("Bem vindo a calculadora de multiplicação de numeros grandes!");
            bool continueCalculing = true;

            // Loop para permitir múltiplas operações

            while (continueCalculing)
            {

                try
                {

                    Console.WriteLine("Digite o primeiro número:");
                    string input1 = Console.ReadLine();

                    Console.WriteLine("Digite o segundo número:");
                    string input2 = Console.ReadLine();

                    // Verificar se os números são válidos usando BigInteger.TryParse
                    if (BigInteger.TryParse(input1, out BigInteger num1) &&
                        BigInteger.TryParse(input2, out BigInteger num2))
                    {

                        BigInteger result = Multiplication(num1, num2);

                        Console.WriteLine($"Resultado: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Entrada Invalida");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Ocorreu o erro: '{ex.Message}'");
                }

                Console.WriteLine("======================================================================================================");
                Console.WriteLine();
                Console.WriteLine("Deseja realizar outra multiplicação? (S / N)");
                string resposta = Console.ReadLine();
                continueCalculing = (resposta.ToLower() == "s");


            }

            Console.WriteLine("======================================================================================================");
            Console.WriteLine("Finalizando Programa!");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Obrigado! Até logo!");
            Console.WriteLine("======================================================================================================");

        }

        // Método para realizar a multiplicação de BigIntegers
        static BigInteger Multiplication(BigInteger a, BigInteger b)
        {

            return a * b;

        }

    }
}
