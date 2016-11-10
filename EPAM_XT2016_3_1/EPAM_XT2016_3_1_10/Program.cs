using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_1_10
{
    class Program
    {
        public static Random rand = new Random();
        static void Main(string[] args)
        {
            int size = 3;
            int[,] arrayForSum = new int[size, size];
            arrayForSum=Randomizer(arrayForSum);            
            Print(arrayForSum);
            Console.WriteLine("Сумма чисел с четными номерами: "+SumEven(arrayForSum)); 
            
        }

        public static int[,] Randomizer(int[,] arrayForSum)
        {
          
            for (int i = 0; i < arrayForSum.GetLength(0); i++)
            {
                for (int j = 0; j < arrayForSum.GetLength(1); j++)
                {
                    arrayForSum[i, j] = rand.Next(10);
                }
            }
            return arrayForSum;
        }

        public static int SumEven(int[,] arrayForSum)
        {
            int sum = 0;
            for (int i = 0; i < arrayForSum.GetLength(0); i++)
            {
                for (int j = i % 2; j < arrayForSum.GetLength(1); j+=2)
                {
                    sum+=arrayForSum[i, j];
                }
                
            }
            return sum;
        }

        public static void Print(int[,] arrayForSort)
        {
            for (int i = 0; i < arrayForSort.GetLength(0); i++)
            {
                for (int j = 0; j < arrayForSort.GetLength(1); j++)
                {
                   
                        Console.Write(arrayForSort[i, j] + " ");

                }
                Console.WriteLine();
            }
        }
    }
    }

