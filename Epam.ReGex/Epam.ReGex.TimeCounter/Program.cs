using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.ReGex.TimeCounter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Regex rx = new Regex(@"([01][0-9]|2[0-3]):([0-5][0-9])");

            string text = "s@afss.fs.ru20:00-10:10The the quick brown fox  s@afss.fs.rufox jumped over the2000-10-12 lazy dog dog.";

            MatchCollection matches = rx.Matches(text);

            Console.WriteLine($"{matches.Count} date's matches found in:{Environment.NewLine}{text}");
        }
    }
}