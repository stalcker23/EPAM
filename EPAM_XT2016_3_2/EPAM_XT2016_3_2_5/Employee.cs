using EPAM_XT2016_3_2_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_5
{
    internal class Employee : User
    {
        private DateTime dateOfEmployment;
        private string position;

        public Employee(string FirstName, string LastName, string Patronymic, DateTime DateOfBirth, string position, DateTime dateOfEmployment) : base(FirstName, LastName, Patronymic, DateOfBirth)
        {
            DateOfEmployment = dateOfEmployment;
            Position = position;
        }

        public DateTime DateOfEmployment
        {
            get
            {
                return this.dateOfEmployment;
            }
            set
            {
                if ((value > DateTime.Now) || (((DateTime.Now.Year - value.Year) > 150) || DateTime.Now.Year < value.Year))
                {
                    throw new ArgumentException("Date of Employment invalid");
                }
                this.dateOfEmployment = value;
            }
        }

        public string Position
        {
            get

            {
                return this.position;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!char.IsLetter(value[i]))
                            throw new ArgumentException("Invalid position");
                    }
                else
                    throw new ArgumentException("Invalid position");
                this.position = value;
            }
        }

        public int YearsDif(DateTime someDate)
        {
            DateTime nowDate = DateTime.Today;
            int stage = nowDate.Year - someDate.Year;
            if (someDate > nowDate.AddYears(-stage)) stage--;
            return stage;
        }

        public int Stage
        {
            get
            {
                return YearsDif(this.DateOfEmployment);
            }
        }
    }
}