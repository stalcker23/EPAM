using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM_XT2016_3_2;
namespace EPAM_XT2016_3_2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Ring newRing = new Ring(1, 1, 3, 4);
                Console.WriteLine(newRing.InnerR);
                Console.WriteLine(newRing.OuterR);
                Console.WriteLine(newRing.RingSquare());
                Console.WriteLine(newRing.SumCircleLength());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
