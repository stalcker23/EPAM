using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            Console.WriteLine("Введена длина N ");
            N = int.Parse(Console.ReadLine());
            for (int i = 1; i < N+1; i++)
            {
                for (int j = 0; j < N-i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i*2-1; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();

            }
        }
    }
}
