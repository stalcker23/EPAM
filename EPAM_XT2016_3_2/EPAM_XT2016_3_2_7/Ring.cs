using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_7
{
    public class Ring : Figure, IArea
    {
        private Round innerRound;
        private Round outerRound;

        public double X { get; set; }
        public double Y { get; set; }

        public double InnerR
        {
            get
            {
                return this.innerRound.Radius;
            }
            set
            {
                if (value < outerRound.Radius)
                    this.innerRound.Radius = value;
                else
                    throw new ArgumentException("Invalid inner radius");
            }
        }

        public double OuterR
        {
            get
            {
                return outerRound.Radius;
            }
            set
            {
                if (innerRound.Radius < value)
                    this.outerRound.Radius = value;
                else
                    throw new ArgumentException("Invalid outer radius");
            }
        }

        public Ring(double[] coordinates)
        {
            this.X = coordinates[0];
            this.Y = coordinates[1];
            double outerR = coordinates[3];
            double innerR = coordinates[2];
            if (innerR >= outerR)
            {
                throw new ArgumentException("Invalid inner radius");
            }
            outerRound = new Round(outerR, X, Y);
            innerRound = new Round(innerR, X, Y);
        }

        public override double Length()
        {
            return innerRound.Length() + outerRound.Length();
        }

        public double Area()
        {
            return outerRound.Area() - innerRound.Area();
        }

        public override string ShowInfo()
        {
            return $"Кольцо с радиусами {innerRound.Radius} и {outerRound.Radius} и координатами [{X}, {Y}]площадью {this.Area():0.000} и суммой радиусов {this.Length():0.000}";
        }
    }
}