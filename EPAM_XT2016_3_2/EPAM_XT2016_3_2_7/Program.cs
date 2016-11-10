using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_7
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                Figure[] figures = GetFigures();
                foreach (Figure figure in figures)
                {
                    Console.WriteLine(figure.ShowInfo());
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Figure[] GetFigures()
        {
            string[] stringToEnd = ReadFile().Split('\n');
            Figure[] figures = new Figure[stringToEnd.Length / 2];

            int i = 0, n = 0;

            while (i < stringToEnd.Length)
            {
                double[] coordinates = Array.ConvertAll(stringToEnd[i + 1].Split(' '), k => double.Parse(k));

                if (stringToEnd[i] == "rectangle\r")
                {
                    figures[n] = new Rectangle(coordinates);
                    n++;
                }
                if (stringToEnd[i] == "round\r")
                {
                    figures[n] = new Round(coordinates);
                    n++;
                }

                if (stringToEnd[i] == "ring\r")
                {
                    figures[n] = new Ring(coordinates);
                    n++;
                }
                if (stringToEnd[i] == "circle\r")

                {
                    figures[n] = new Circle(coordinates);
                    n++;
                }

                if (stringToEnd[i] == "line\r")
                {
                    figures[n] = new Line(coordinates);
                    n++;
                }
                i += 2;
            }
            return figures;
        }

        public static string ReadFile()
        {
            using (StreamReader fig = new StreamReader(@"file.txt"))
            {
                string stringToEnd = string.Empty;
                stringToEnd = fig.ReadToEnd();
                return stringToEnd;
            }
        }
    }
}