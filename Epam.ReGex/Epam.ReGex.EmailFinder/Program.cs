using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.ReGex.EmailFinder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Regex rx = new Regex(@"([^\W_]([\w-\.]*)[^\W_]|[^\W_])@[^\W_]+\.\w{2,6}");

            string text = "s@afss.fs.ru2000-10-10The the quick brown fox  s@afss.fs.rufox jumped over the2000-10-12 lazy dog dog.";

            MatchCollection matches = rx.Matches(text);

            Console.WriteLine($"{matches.Count} matches found in:{Environment.NewLine}{text}");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Founded e-mail: {match}");
            }
        }
    }
}