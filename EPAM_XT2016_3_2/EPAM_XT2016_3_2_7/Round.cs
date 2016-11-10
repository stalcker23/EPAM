using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_7
{
    public class Round : Figure, IArea
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
                    throw new ArgumentException("Round Radius Error");
                this.radius = value;
            }
        }

        public Round(double radius, double x, double y)
        {
            this.X = x;
            this.Y = y;
            this.radius = radius;
        }

        public Round(double[] coordinates)
        {
            this.X = coordinates[0];
            this.Y = coordinates[1];
            this.Radius = coordinates[2];
        }

        public double Area()
        {
            return Math.PI * radius * radius;
        }

        public override double Length()
        {
            return 2 * Math.PI * radius;
        }

        public override string ShowInfo()
        {
            return $"Круг с радиусом {radius} и координатами [{X}, {Y}]";
        }
    }
}