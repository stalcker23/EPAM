using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_1_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string lineForParse = Console.ReadLine();
            AverageLength(lineForParse);
            
        }

        private static void AverageLength(string lineForParse)
        {
            int punctuationCounter = 0;
            int lettersCounter = 0;
            int wordCounter = 0;  
            for (int i = 0; i < lineForParse.Length; i++)
            {
                if (char.IsPunctuation(lineForParse[i]) || char.IsWhiteSpace(lineForParse[i]))
                {
                    punctuationCounter ++;
                    lettersCounter = 0;
                }
                else
                {
                    if (lettersCounter == 0)
                    {
                        lettersCounter++;
                        wordCounter++;
                    }
                }
            }
            Console.WriteLine("Средняя длина слова: " + ((double)lineForParse.Length - punctuationCounter) / wordCounter);
        }
    }
}
