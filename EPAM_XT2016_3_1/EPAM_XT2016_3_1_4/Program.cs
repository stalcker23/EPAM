using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            Console.WriteLine("Введите количество треугольников N: ");
            N = int.Parse(Console.ReadLine());
            for (int i = 1; i < N + 1; i++)
            {
                WriteTriangle(i, N);

            }
        }
        private static void WriteTriangle(int numberOfTriangle, int trianglesQuantity)
        {
            for (int lines = 1; lines < numberOfTriangle + 1; lines++)
            {
                for (int j = 0; j < trianglesQuantity - lines; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 1; j <= lines * 2 - 1; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
    }

