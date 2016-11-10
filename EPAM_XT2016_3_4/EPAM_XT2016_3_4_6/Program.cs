using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_4_6
{
    internal class Program
    {
        private static Random rnd = new Random();

        private static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();

            int n = 1000;
            List<double> timeSpansMethod = new List<double>();
            List<double> timeSpansDelegate = new List<double>();
            List<double> timeSpansAnonimus = new List<double>();
            List<double> timeSpansLambda = new List<double>();
            List<double> timeSpansLINQ = new List<double>();

            for (int i = 0; i < n; i++)
            {
                int[] arrayForTest = new int[n];
                for (int j = 0; j < arrayForTest.Length; j++)
                {
                    arrayForTest[j] = rnd.Next(-10000, 10000);
                }

                stopWatch.Restart();
                IsPositiveNumber(arrayForTest);
                stopWatch.Stop();
                timeSpansMethod.Add(stopWatch.Elapsed.TotalMilliseconds);

                stopWatch.Restart();
                IsPositiveNumber(arrayForTest, Comparing);
                stopWatch.Stop();
                timeSpansDelegate.Add(stopWatch.Elapsed.TotalMilliseconds);

                stopWatch.Restart();
                IsPositiveNumber(arrayForTest, delegate (int item)
                {
                    return item > 0;
                });

                stopWatch.Stop();
                timeSpansAnonimus.Add(stopWatch.Elapsed.TotalMilliseconds);

                stopWatch.Restart();
                IsPositiveNumber(arrayForTest, item => item > 0);

                stopWatch.Stop();
                timeSpansLambda.Add(stopWatch.Elapsed.TotalMilliseconds);

                stopWatch.Restart();

                var countIsPositive = arrayForTest.Where(item => item > 0).Count();

                timeSpansLINQ.Add(stopWatch.Elapsed.TotalMilliseconds);
            }

            timeSpansMethod.Sort();
            timeSpansDelegate.Sort();
            timeSpansAnonimus.Sort();
            timeSpansLambda.Sort();
            timeSpansLINQ.Sort();

            Console.WriteLine($"Time = {timeSpansMethod[n / 2]}");
            Console.WriteLine($"Time = {timeSpansDelegate[n / 2]}");
            Console.WriteLine($"Time = {timeSpansAnonimus[n / 2]}");
            Console.WriteLine($"Time = {timeSpansLambda[n / 2]}");
            Console.WriteLine($"Time = {timeSpansLINQ[n / 2]}");
        }

        public static void IsPositiveNumber(int[] array)
        {
            int countIsPositive = 0;
            foreach (var item in array)
            {
                if (item > 0)
                {
                    countIsPositive++;
                }
            }
        }

        public static void IsPositiveNumber(int[] array, Func<int, bool> comparing)
        {
            if (comparing == null)
            {
                throw new ArgumentNullException();
            }
            int countIsPositive = 0;
            foreach (var item in array)
            {
                if (comparing(item))
                {
                    countIsPositive++;
                }
            }
        }

        public static bool Comparing(int item)
        {
            return item > 0;
        }
    }
}