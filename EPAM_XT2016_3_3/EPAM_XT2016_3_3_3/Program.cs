using System;
using System.Collections.Generic;
using System.Threading;

namespace EPAM_XT2016_3_3_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine();
            int[] itemsCollection = new int[] { 1, 2, 3 };

            var array = new DynamicArray<int>(itemsCollection);
            array.Add(2);
            Console.WriteLine(array.Capacity);
            Console.WriteLine(array.Length);
        }
    }
}