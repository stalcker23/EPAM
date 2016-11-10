using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.Entities
{
    public class User
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; }
        public string Name { get; }

        public User(int id, string name, DateTime dateOfBirth)
        {
            this.Id = id;
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }

        public User(string name, DateTime dateOfBirth)
        {
            this.Id = 0;
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }

        public int Age
        {
            get
            {
                DateTime nowDate = DateTime.Today;
                int age = nowDate.Year - this.DateOfBirth.Year;
                if (this.DateOfBirth > nowDate.AddYears(-age)) age--;
                return age;
            }
        }
    }
}