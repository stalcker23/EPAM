using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EPZM_XT2016_3_4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] mas = new string[] { "12", "1", "123", "1234", "12345" };

            var sorting = new SortingArray<string>(mas, Comparing);

            sorting.SortingEnded += Sorting_SortingEnded;
            sorting.StartInAnotherThread(mas, Comparing);
            sorting.StartInSameThread(mas, Comparing);
        }

        public static int Comparing(string x, string y)
        {
            if (x.Length < y.Length)
            {
                return 1;
            }

            if (x.Length > y.Length)
            {
                return -1;
            }

            for (int i = 0; i < y.Length; i++)
            {
                if (x[i] < y[i])
                    return 1;
                if (x[i] > y[i])
                    return -1;
            }
            return 0;
        }

        private static void Sorting_SortingEnded(object sender, SortingArray<string>.SortingEventArgs e)
        {
            Console.WriteLine($"Sorting ended. Sorting counter:{e.CountOfSorting}");
        }
    }
}