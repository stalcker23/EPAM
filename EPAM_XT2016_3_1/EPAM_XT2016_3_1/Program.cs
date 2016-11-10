using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_1_1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;

            Console.WriteLine("Длина ребра a = ");
            a = int.Parse(Console.ReadLine());

            Console.WriteLine("Длина ребра b = ");
            b = int.Parse(Console.ReadLine());

            Rectangle rectangle = new Rectangle(a, b);
            if (rectangle.a < 0 || rectangle.b < 0)
            {
                Console.WriteLine("Ошибка длины ребра");
            }
            else
            {
                
                Console.WriteLine("Площадь прямоугольника = "+ rectangle.Square(a,b));
            }
        }
    }
}
