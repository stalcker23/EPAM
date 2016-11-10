using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.ReGex.DateExistance
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Regex rx = new Regex(@"(((0[1-9]|[12]\d)-(0[1-9]|1[0-2]))|(30-(0[13-9]|1[0-2]))|(31-0[13578]|1[02]))-\d{4}");

            string text = "10-10-2000The the quick brown fox  fox jumped over the2000-10-12 lazy dog dog.";

            MatchCollection matches = rx.Matches(text);

            Console.WriteLine($"{matches.Count} matches found in:{Environment.NewLine}{text}");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Founded date: {match}");
                Console.WriteLine(match);
            }
        }
    }
}