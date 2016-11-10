using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_8
{
    public class Player : IGameObject, IMove
    {
        public double HealthPoints { get; set; }
        public double Points { get; set; }

        public Player(double x, double y, double health)
        {
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Speed { get; set; }

        public double XChanger(double x)
        {
            throw new NotImplementedException();
        }

        public double YChanger(double y)
        {
            throw new NotImplementedException();
        }

        public void TakeBonus(Bonus obj)
        {
        }

        public void TakeEnemy(Barrier obj)
        {
        }

        public void TakeBonusBarrier(Bonus obj)
        {
        }

        public void HealthAction()
        {
        }
    }
}