using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_7
{
    internal class Line : Figure
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }

        public override double Length()
        {
            return Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2)); ;
        }

        public Line(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public Line(double[] coordinates)
        {
            X1 = coordinates[0];
            Y1 = coordinates[1];
            X2 = coordinates[2];
            Y2 = coordinates[3];
        }

        public override string ShowInfo()
        {
            return $"Линия с координатами вершин [{X1}, {Y1}], [{X2}, {Y2}] и длиной {this.Length():0.000}";
        }
    }
}