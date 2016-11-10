using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_8
{
    public abstract class Barrier : IGameObject, ITarget
    {
        public abstract double X { get; set; }
        public abstract double Y { get; set; }

        public abstract void Effects();

        public abstract double SpeedChanger();
    }
}