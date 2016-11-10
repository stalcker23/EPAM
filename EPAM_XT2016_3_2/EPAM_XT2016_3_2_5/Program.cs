using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM_XT2016_3_2_3;
namespace EPAM_XT2016_3_2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            User user;
            Employee employee;
            try
            {
                string firstName = "asd";


                string lastName = "asd";


                string patronymic = "asd";


                DateTime dateOfBirth = DateTime.Parse("21.02.2000");

                
                string position = "as";

                DateTime dateOfEmployment = DateTime.Parse("21.11.2012");

                employee = new Employee(firstName, lastName, patronymic, dateOfBirth, position, dateOfEmployment);

                Console.WriteLine("First name: {0}", employee.FirstName);
                Console.WriteLine("Last name: {0}", employee.LastName);
                Console.WriteLine("Patronymic: {0}", employee.Patronymic);
                Console.WriteLine("Date of Birth: {0:d}", employee.DateOfBirth);
                Console.WriteLine("Age: {0}", employee.Age);
                Console.WriteLine("Stage: {0}",employee.Stage);
                Console.WriteLine("Position: {0}",employee.Position);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
