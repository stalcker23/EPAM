using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 5;
            int max = 1000;
            int integers = PartProgress(a, max) + PartProgress(b, max) - PartProgress(a * b, max);
            Console.WriteLine("Сумма чисел до {0}, кратные {1} или {2}: {3}", max, a, b, integers);
        }
        public static int PartProgress(int first, int second)
        {
            
            return (first + second) * (second / first) / 2;
        }


    }
}