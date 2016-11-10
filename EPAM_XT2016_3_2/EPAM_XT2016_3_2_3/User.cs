using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_3
{
    public class User
    {
        private string firstName;
        private string lastName;
        private string patronymic;
        private DateTime dateOfBirth;

        public User(string firstName, string lastName, string patronymic, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Patronymic = patronymic;
            this.DateOfBirth = dateOfBirth;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!char.IsLetter(value[i]))
                            throw new ArgumentException("Invalid first name");
                    }
                else throw new ArgumentException("Invalid first name");
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!char.IsLetter(value[i]))
                            throw new ArgumentException("Invalid last name");
                    }
                else
                    throw new ArgumentException("Invalid last name");
                lastName = value;
            }
        }

        public string Patronymic
        {
            get
            {
                return this.patronymic;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("Invalid patronymic");

                patronymic = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }
            set
            {
                if ((value > DateTime.Now) || ((DateTime.Now.Year - value.Year) > 150))
                {
                    throw new ArgumentException("Date of birth invalid");
                }
                this.dateOfBirth = value;
            }
        }

        public int Age
        {
            get
            {
                DateTime nowDate = DateTime.Today;
                int age = nowDate.Year - this.dateOfBirth.Year;
                if (this.dateOfBirth > nowDate.AddYears(-age)) age--;
                return age;
            }
        }
    }
}