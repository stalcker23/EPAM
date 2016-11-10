using EPAM_XT2016_3_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_6
{
    internal class Ring
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

        public Ring(double x, double y, double innerR, double outerR)
        {
            if (innerR >= outerR)
            {
                throw new ArgumentException("Invalid inner radius");
            }
            this.X = x;
            this.Y = y;
            outerRound = new Round(outerR, x, y);
            innerRound = new Round(innerR, x, y);
        }

        public double SumCircleLength()
        {
            return innerRound.CircleLength + outerRound.CircleLength;
        }

        public double RingSquare()
        {
            return outerRound.CircleSquare - innerRound.CircleSquare;
        }
    }
}