    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_1_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringOne;
            string stringSecond;
            string stringForEnd = "";

            Console.WriteLine("Введи первую строку");
            stringOne = Console.ReadLine();

            Console.WriteLine("Введи вторую строку");
            stringSecond = Console.ReadLine();

            foreach (char charItem in stringOne)
                if (!stringSecond.Contains(charItem))
                    stringForEnd += charItem;
                else                
                    stringForEnd = stringForEnd + charItem + charItem;
                
            Console.WriteLine("Результат = {0}", stringForEnd);
            
        }
    }
}
