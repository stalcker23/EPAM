using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_7
{
    public abstract class Figure : IFigure
    {
        public abstract string ShowInfo();

        public abstract double Length();
    }
}