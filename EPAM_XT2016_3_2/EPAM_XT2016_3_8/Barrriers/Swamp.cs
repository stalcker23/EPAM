using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_8
{
    internal class Swamp : Barrier
    {
        public override double X { get; set; }
        public override double Y { get; set; }

        public Swamp(double x, double y)
        {
        }

        public override void Effects()
        {
            throw new NotImplementedException();
        }

        public override double SpeedChanger()
        {
            throw new NotImplementedException();
        }
    }
}