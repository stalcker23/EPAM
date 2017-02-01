using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.Entities
{
    public class Forum
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserLogin { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
