using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введена длина N");
            int N = int.Parse(Console.ReadLine());
            for (int i = 1; i < N+1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
                
            }
        }
    }
}
