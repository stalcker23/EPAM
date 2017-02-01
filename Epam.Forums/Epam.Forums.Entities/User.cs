using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsBanned { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public Photo Photo { get; set; }
       
    }
}
