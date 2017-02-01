using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.Entities
{
    public class Logger
    {
        public Type Class { get; set; }

        public string MethodName { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return $"Exception in method {this.MethodName} of {this.Class}. {this.Message}";
        }
    }
}

