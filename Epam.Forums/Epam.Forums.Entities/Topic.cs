using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.Entities
{
    public class Topic
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string UserLogin { get; set; }
        public string ForumName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? LockDate { get; set; }
        public bool IsPublic { get; set; }
        public Photo Photo { get; set; }

    }
}
