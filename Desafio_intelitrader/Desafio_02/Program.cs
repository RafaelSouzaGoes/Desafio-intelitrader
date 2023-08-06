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
             * 
             * */

            Console.WriteLine("Digite o primeiro número:");
            string input1 = Console.ReadLine();

            Console.WriteLine("Digite o segundo número:");
            string input2 = Console.ReadLine();

            if (BigInteger.TryParse(input1, out BigInteger num1) &&
                BigInteger.TryParse(input2, out BigInteger num2))
            {

                BigInteger result = Multiplication(num1, num2);

                Console.WriteLine($"Resultado {result}");
            }
            else
            {
                Console.WriteLine("Entrada Invalida");
            }


        }

        static BigInteger Multiplication(BigInteger a, BigInteger b)
        {

            return a * b;

        }

    }
}
