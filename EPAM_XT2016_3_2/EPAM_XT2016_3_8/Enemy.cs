using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_8
{
    public abstract class Enemy : IGameObject, IMove, ITarget
    {
        public abstract double X { get; set; }
        public abstract double Y { get; set; }

        public abstract void Effects();

        public abstract double SpeedChanger();

        public abstract double XChanger(double x);

        public abstract double YChanger(double y);
    }
}