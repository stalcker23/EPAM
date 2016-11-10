using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_7
{
    internal class Rectangle : Figure, IArea
    {
        public Rectangle(double[] coordinates)
        {
            double x1 = coordinates[0];
            double y1 = coordinates[1];
            double x2 = coordinates[2];
            double y2 = coordinates[3];
            double x3 = coordinates[4];
            double y3 = coordinates[5];
            double x4 = coordinates[6];
            double y4 = coordinates[7];
            if (RectangleExist(x1, y1, x2, y2, x3, y3, x4, y4))
            {
                this.FirstSide = new Line(x1, x2, y1, y2);
                this.SecondSide = new Line(x2, x4, y2, y4);
            }
            else
                throw new ArgumentException("Rectangle fail");
        }

        public Line FirstSide { get; set; }

        public Line SecondSide { get; set; }

        public bool RectangleExist(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            return ((x1 - x3) == (x2 - x4) && ((y1 - y3) == (y2 - y4)));
        }

        public double Area()
        {
            return FirstSide.Length() * SecondSide.Length();
        }

        public override double Length()
        {
            return 2 * (FirstSide.Length() + SecondSide.Length());
        }

        public override string ShowInfo()
        {
            return $"Прямоугольник со сторонами {FirstSide.Length():0.000} и {SecondSide.Length():0.000}, площадью {this.Area():0.000} и радиусом {this.Length():0.000}";
        }
    }
}