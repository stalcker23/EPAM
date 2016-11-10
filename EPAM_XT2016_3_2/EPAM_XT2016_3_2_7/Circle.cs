using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_7
{
    internal class Circle : Figure
    {
        private double radius;

        public double X { get; set; }
        public double Y { get; set; }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Circle Radius Error");
                this.radius = value;
            }
        }

        public Circle(double[] coordinates)
        {
            this.X = coordinates[0];
            this.Y = coordinates[1];
            this.Radius = coordinates[2];
        }

        public override double Length()
        {
            return 2 * Math.PI * radius;
        }

        public override string ShowInfo()
        {
            return $"Окружность с радиусом {radius} и координатами [{X}, {Y}] и длиной окружности {this.Length():0.000}";
        }
    }
}