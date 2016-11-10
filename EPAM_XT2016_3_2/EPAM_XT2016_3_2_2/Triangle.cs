using System;

namespace EPAM_XT2016_3_2_2
{
    internal class Triangle
    {
        private double firstSide;
        private double secondSide;
        private double thirdSide;

        public double Square
        {
            get
            {
                double semiP = Perimetr / 2;
                return Math.Sqrt(semiP * (semiP - firstSide) * (semiP - secondSide) * (semiP - thirdSide));
            }
        }

        public double Perimetr => this.firstSide + this.secondSide + this.thirdSide;

        public Triangle(double a, double b, double c)
        {
            if (TriangleNotExist(a, b, c))
            {
                throw new ArgumentException("Sides incorrect");
            }

            this.firstSide = a;
            this.secondSide = b;
            this.thirdSide = c;
        }

        public static bool TriangleNotExist(double a, double b, double c)
        {
            return ((a >= b + c) || (b >= a + c) || (c >= a + b));
        }

        public double A
        {
            get
            {
                return this.firstSide;
            }

            set
            {
                if (TriangleNotExist(value, secondSide, thirdSide))
                    throw new ArgumentException("side A Error");
                this.firstSide = value;
            }
        }

        public double B
        {
            get
            {
                return this.secondSide;
            }

            set
            {
                if (TriangleNotExist(firstSide, value, thirdSide))
                    throw new ArgumentException("side B Error");
                this.secondSide = value;
            }
        }

        public double C
        {
            get
            {
                return this.thirdSide;
            }

            set
            {
                if (TriangleNotExist(firstSide, secondSide, value))
                    throw new ArgumentException("side C Error");
                this.thirdSide = value;
            }
        }
    }
}