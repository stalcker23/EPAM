using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_1_8
{
    class Program
    {
        public static Random rand = new Random();
        static void Main(string[] args)
        {
            int size = 2;
            int[,,] arrayForSort = new int[size,size,size];
            arrayForSort = Randomizer(arrayForSort);
            
            Console.WriteLine("До работы:\n");
            Print(arrayForSort);
            arrayForSort = ChangerNull(arrayForSort);
            
            Console.WriteLine("После работы:\n");
            Print(arrayForSort);
            
        }

        public static int[,,] Randomizer(int[,,] arrayForSort)
        {
            
            for (int i = 0; i < arrayForSort.GetLength(0); i++)
            {
                for (int j = 0; j < arrayForSort.GetLength(1); j++)
                {
                    for (int k = 0; k < arrayForSort.GetLength(2); k++)
                    {
                        arrayForSort[i, j, k] = rand.Next(-100, 100);
                    }
                }
            }
            return arrayForSort;
        }

        public static int[,,] ChangerNull(int[,,] arrayForSort)
        {
            for (int i = 0; i < arrayForSort.GetLength(0); i++)
            {
                for (int j = 0; j < arrayForSort.GetLength(1); j++)
                {
                    for (int k = 0; k < arrayForSort.GetLength(2); k++)
                    {
                        if (arrayForSort[i, j, k] < 0)
                        {
                            arrayForSort[i, j, k] = 0;
                        }
                    }
                }
            }
            return arrayForSort;
        }

        public static void Print(int[,,]arrayForSort)
        {
            for (int i = 0; i < arrayForSort.GetLength(0); i++)
            {
                for (int j = 0; j < arrayForSort.GetLength(1); j++)
                {
                    for (int k = 0; k < arrayForSort.GetLength(2); k++)
                    {
                        Console.Write(arrayForSort[i,j,k]+" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
