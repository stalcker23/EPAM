using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle;

            try
            {

                double a = 2;

                double b = 2;

                double c = 2.8;
                triangle = new Triangle(a,b,c);
                Console.WriteLine("Sides: {0}, {1}, {2}", triangle.A, triangle.B, triangle.C);
                
                Console.WriteLine("Length: {0:0.000}", triangle.Perimetr);
                Console.WriteLine("Square: {0:0.000}", triangle.Square);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
