using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.Entities
{
    public class Award
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Award(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public Award(string title)
        {
            this.Id = 0;
            this.Title = title;
        }
    }
}