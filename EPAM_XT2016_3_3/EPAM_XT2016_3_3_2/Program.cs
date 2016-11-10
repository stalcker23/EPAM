using System;
using System.Collections.Generic;
using System.IO;

namespace EPAM_XT2016_3_3_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var words = new Dictionary<string, int>(new Parsing());
            Parser(words);
        }

        private static void Parser(Dictionary<string, int> words)
        {
            char[] separators = new char[] { ' ', '.' };
            using (StreamReader read = new StreamReader("file.txt"))
            {
                string[] fullText = read.ReadToEnd().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in fullText)
                {
                    if (words.ContainsKey(item))
                    {
                        words[item]++;
                    }
                    else
                    {
                        words.Add(item, 1);
                    }
                }

                WriteInfo(words, fullText);
            }
        }

        private static void WriteInfo(Dictionary<string, int> words, string[] fullText)
        {
            foreach (var item in words)
            {
                Console.WriteLine($"{item.Key}: {((double)item.Value / fullText.Length):P2}");
            }
        }
    }
}