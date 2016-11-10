using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_1_9
{
    class Program
    {
        public static Random rand = new Random();
        static void Main(string[] args)
        {
            int n = 10;
            int[] arrayForSum = Randomizer(n);
            Print(arrayForSum);
            Console.WriteLine("Сумма неотрицательных чисел: "+SumNonNegative(arrayForSum));  
        }
        static int SumNonNegative(int[] arrayForSum)
        {
            int sum = 0;
            for (int i = 0; i < arrayForSum.Length; i++)
            {
                if (arrayForSum[i] > 0)
                    sum += arrayForSum[i];
            }
            return sum;
        }
        static void Print(int[] arrayForSort)
        {
            Console.WriteLine("Массив: " + string.Join(" ", arrayForSort));
        }
        static int[] Randomizer(int n)
        {
            int[] arrayForSort = new int[n];
           
            for (int i = 0; i < n; i++)
            {
                arrayForSort[i] = rand.Next(-100,100);
            }
            return arrayForSort;
        }
    }
}
