using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersInfo.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                DateTime dateNow = DateTime.Now;
                int age = dateNow.Year - this.DateOfBirth.Year;
                if (dateNow.Month < this.DateOfBirth.Month ||
                    (dateNow.Month == this.DateOfBirth.Month && dateNow.Day < this.DateOfBirth.Day)) age--;
                return age;
            }
        }
    }
}