using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.Entities
{
    public class Post
    {
        public int ID { get; set; }
        public string UserLogin { get; set; }      
        public string TopicTitle { get; set; }
        public DateTime CreateDate { get; set; }
        public string Text { get; set; }
       
    }
}
