using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Round round;

            try
            {
                Console.WriteLine("Enter radius");
                double radius = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter x");
                double x = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter y");
                double y = double.Parse(Console.ReadLine());

                round = new Round(radius,x,y);
                Console.WriteLine("Radius: {0}, X: {1}, Y: {2}", round.Radius, round.X, round.Y);
                Console.WriteLine("Square: {0:0.000}", round.CircleSquare);
                Console.WriteLine("Length: {0:0.000}", round.CircleLength);
                
            }
            catch (Exception e)
            {              
                Console.WriteLine(e.Message);                
            }
            
            
        }
    }
}
