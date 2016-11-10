using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.ReGex.HtmlReplacer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string rx = @"<[^<>]+>";

            string text = "<2000-10-10> The the quick brown fox <sdfhd> fox jumped over the2000-10-12 lazy dog dog.";
            Console.WriteLine($"Old line:{text}");
            text = Regex.Replace(text, rx, "_");
            Console.WriteLine($"New line without tegs:{text}");
            Console.WriteLine(text);
        }
    }
}