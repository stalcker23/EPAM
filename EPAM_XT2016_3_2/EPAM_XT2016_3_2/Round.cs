using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2
{
    public class Round
    {
        private double radius;
        private double x;
        private double y;
        public double CircleLength => 2 * Math.PI * this.radius;
        public double CircleSquare => Math.PI * Math.Pow(this.radius,2);
        public Round(double radius, double x, double y)
        {
            this.Radius = radius;
            this.X = x;
            this.Y = y;
        }
        public double X
        {
            get
            {
                return this.x;

            }
             set
            {
                this.x = value;
            }
        }
        public double Y
        {
            get
            {
                return this.y;

            }
             set
            {
                this.y = value;
            }
        }
        public double Radius
        {
            get
            {
                return this.radius;
            }
             set
            {
                if (value <= 0)
                    throw new ArgumentException("Radius Error");
                this.radius = value;
            }
        }

    }
}
