using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_7
{
    public class Triangle : Figure, ISquareArea
    {
        private Line firstSide, secondSide, thirdSide;

        public Line FirstSide
        {
            get
            {
                return this.firstSide;
            }

            set
            {
                if (TriangleNotExist(firstSide.Length, secondSide.Length, thirdSide.Length))
                    throw new ArgumentException("Triangle side A Error");
                this.firstSide = value;
            }
        }

        public Line SecondSide
        {
            get
            {
                return this.secondSide;
            }

            set
            {
                if (TriangleNotExist(firstSide.Length, secondSide.Length, thirdSide.Length))
                    throw new ArgumentException("Triangle side B Error");
                this.secondSide = value;
            }
        }

        public Line ThirdSide
        {
            get
            {
                return this.thirdSide;
            }

            set
            {
                if (TriangleNotExist(firstSide.Length, secondSide.Length, thirdSide.Length))
                    throw new ArgumentException("Triangle side C Error");
                this.thirdSide = value;
            }
        }

        public Triangle(double[] coordinates)
        {
            double x1 = coordinates[0];
            double y1 = coordinates[1];
            double x2 = coordinates[2];
            double y2 = coordinates[3];
            double x3 = coordinates[4];
            double y3 = coordinates[5];
            Line a = new Line(x1, x2, y1, y2);
            Line b = new Line(x1, x3, y1, y3);
            Line c = new Line(x2, x3, y2, y3);
            if ((a.Length >= b.Length + c.Length) || (b.Length >= a.Length + c.Length) || (c.Length > a.Length + b.Length))
            {
                throw new ArgumentException("Triangle fail");
            }
            this.firstSide = a;
            this.secondSide = b;
            this.thirdSide = c;
        }

        public override double Perimetr() => this.firstSide.Length + this.secondSide.Length + this.thirdSide.Length;

        public static bool TriangleNotExist(double a, double b, double c)
        {
            return ((a >= b + c) || (b >= a + c) || (c >= a + b));
        }

        public override double Area()
        {
            double semiP = (this.firstSide.Length + this.secondSide.Length + this.thirdSide.Length) / 2;
            return Math.Sqrt(semiP * (semiP - firstSide.Length) * (semiP - secondSide.Length) * (semiP - thirdSide.Length));
        }

        public override string ShowInfo()
        {
            return $"Треугольник со сторонами  {firstSide.Length:0.000}, {secondSide.Length:0.000}, {thirdSide.Length:0.000}";
        }
    }
}