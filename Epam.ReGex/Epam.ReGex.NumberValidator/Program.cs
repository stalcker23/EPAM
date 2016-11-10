using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.ReGex.NumberValidator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Regex commonDiggit = new Regex(@"(-|\+)?\d+(\.d+)?");
            Regex normalizeDiggit = new Regex(@"(-|\+)?\d+\.\d+e(-|\+)?\d+");

            string text = "20.3";

            MatchCollection matchesCommonDiggit = commonDiggit.Matches(text);
            MatchCollection matchesCormalizeDiggit = normalizeDiggit.Matches(text);

            if (matchesCormalizeDiggit.Count != 0)
            {
                Console.WriteLine($"{text} is normalized diggit");
            }
            else
            if (matchesCommonDiggit.Count != 0)
            {
                Console.WriteLine($"{text} is common diggit");
            }
            else
            {
                Console.WriteLine($"{text} isn't diggit");
            }
        }
    }
}