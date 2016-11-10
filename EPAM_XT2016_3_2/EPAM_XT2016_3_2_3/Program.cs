using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_3
{
    internal class Program
    {
        private static void Main(string[] args)

        {
            User user;
            try
            {
                string firstName = Console.ReadLine();

                string lastName = "asd";

                string patronymic = "asd";

                DateTime dateOfBirth = DateTime.Parse("21.02.2000");

                user = new User(firstName, lastName, patronymic, dateOfBirth);

                Console.WriteLine("First name: {0}", user.FirstName);
                Console.WriteLine("Last name: {0}", user.LastName);
                Console.WriteLine("Patronymic: {0}", user.Patronymic);
                Console.WriteLine("Date of Birth: {0:d}", user.DateOfBirth);
                Console.WriteLine("Age: {0}", user.Age);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}