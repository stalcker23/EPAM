using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_4_4
{
    public static class MyExtensions
    {
        public static byte Sum(this byte[] array)
        {
            byte sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static sbyte Sum(this sbyte[] array)
        {
            sbyte sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static short Sum(this short[] array)
        {
            short sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static ushort Sum(this ushort[] array)
        {
            ushort sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static int Sum(this int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static uint Sum(this uint[] array)
        {
            uint sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static long Sum(this long[] array)
        {
            long sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static ulong Sum(this ulong[] array)
        {
            ulong sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static decimal Sum(this decimal[] array)
        {
            decimal sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static float Sum(this float[] array)
        {
            float sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static double Sum(this double[] array)
        {
            double sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }
    }
}