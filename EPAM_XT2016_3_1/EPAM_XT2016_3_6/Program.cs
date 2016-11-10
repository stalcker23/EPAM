using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            
            LiteralStyle style = new LiteralStyle();
            while (true)
            {
               
                Console.WriteLine("Параметры надписи: " + style);

                Console.WriteLine("Введите: ");
                Console.WriteLine("      1:" + LiteralStyle.Bold);
                Console.WriteLine("      2:" + LiteralStyle.Italic);
                Console.WriteLine("      3:" + LiteralStyle.Underline);
                try
                {
                    string changes = Console.ReadLine();
                    switch (changes)
                    {
                        case "1":
                            style = style ^ LiteralStyle.Bold;
                            break;
                        case "2":
                            style = style ^ LiteralStyle.Italic;
                            break;
                        case "3":
                            style = style ^ LiteralStyle.Underline;
                            break;
                        default:
                            return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }
        [Flags]
        enum LiteralStyle
        {

            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
        }
    }
}
