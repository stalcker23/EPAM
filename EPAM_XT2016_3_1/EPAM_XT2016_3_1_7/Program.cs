using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_1_7
{
    class Program
    {
        public static Random rand = new Random();
        static void Main(string[] args)
        {
            int n = 10;
            int[] arrayForSort = Randomizer(n);
            Print(arrayForSort);
        }
        static int[] Randomizer(int n)
        {
            int[] arrayForSort = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                arrayForSort[i] = rand.Next(100);
            }
            return arrayForSort;
        }
        static void Print(int[] arrayForSort)
        {
            Console.WriteLine("Неотсортированный массив: " + string.Join(" ", arrayForSort));
            QuickSort(arrayForSort, 0, arrayForSort.Length - 1);
            Console.WriteLine("Отсортированный массив: " + string.Join(" ", arrayForSort));
            Console.WriteLine("Максимум: "+ Max(arrayForSort));
            Console.WriteLine("Минимум: " + Min(arrayForSort));
        }
        static int Max(int[] arrayforSort)
        {
            
            int max = 0;
            for (int i = 0; i < arrayforSort.Length; i++)
            {
                if (arrayforSort[i] > max)
                    max = arrayforSort[i];
            }

            return max;
                
        }
        static int Min(int[] arrayforSort)
        {

            int min = arrayforSort[0];
            for (int i = 0; i < arrayforSort.Length; i++)
            {
                if (arrayforSort[i] < min)
                    min = arrayforSort[i];
            }

            return min;

        }
        static void QuickSort(int[] arrayForSort, int l, int r)
        {
            int temp;
            int x = arrayForSort[l + (r - l) / 2];

            int i = l;
            int j = r;
            while (i <= j)
            {
                while (arrayForSort[i] < x) i++;
                while (arrayForSort[j] > x) j--;
                if (i <= j)
                {
                    temp = arrayForSort[i];
                    arrayForSort[i] = arrayForSort[j];
                    arrayForSort[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < r)
                QuickSort(arrayForSort, i, r);

            if (l < j)
                QuickSort(arrayForSort, l, j);
        }

    }
}

