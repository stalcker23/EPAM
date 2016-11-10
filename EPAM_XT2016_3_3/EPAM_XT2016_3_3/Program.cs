using System;
using System.Collections.Generic;

namespace EPAM_XT2016_3_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ////int currentIndex = 1;
            ////int currentCounter = 2;
            ////FoundCircle(ref currentIndex, ref currentCounter, N);

            int n = 9;
            var peoples = new Queue<int>(n);

            for (int i = 1; i <= n; i++)
            {
                peoples.Enqueue(i);
            }

            Console.WriteLine();
            FindCircleQueue(peoples);
        }

        private static void FindCircleQueue<T>(Queue<T> peoples)
        {
            int count = peoples.Count;
            int counter = 0;
            bool flag = false;
            do
            {
                var currentValue = peoples.Dequeue();
                Console.Write($"{currentValue} ");

                if ((!flag) && (count != 1))
                {
                    peoples.Enqueue(currentValue);
                }

                counter++;
                if (count < counter + 1)
                {
                    counter = 0;
                    count = peoples.Count;
                    Console.WriteLine();
                }

                flag = !flag;
            }
            while (peoples.Count != 0);
        }

        ////    private static void FoundCircle(ref int currentIndex, ref int currentCounter, int N)
        ////    {
        ////        bool[] peopleRound = new bool[N];
        ////        while (peopleRound.Contains(false))
        ////        {
        ////            if (currentIndex > peopleRound.Length - 1)
        ////            {
        ////                currentIndex = currentIndex % peopleRound.Length;
        ////                if (peopleRound[currentIndex]) currentIndex *= 2;
        ////                currentCounter *= 2;
        ////            }
        ////            else

        ////            {
        ////                peopleRound[currentIndex] = true;
        ////                Console.Write($"{currentIndex + 1} ");
        ////                currentIndex = currentIndex + currentCounter;
        ////            }
        ////        }
        ////    }
    }
}