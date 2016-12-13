using Epam.UserInfo.Logic;
using Epam.UserInfo.LogicContracts;
using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersInfo.ConsoleUI
{
    internal class Program
    {
        private static IUserLogic userLogic;
        private static IAwardLogic awardLogic;
        private static readonly string dateFormat = "dd/MM/yyyy";

        static Program()
        {
            userLogic = new UserLogic();
            awardLogic = new AwardLogic();
        }

        private static User EnterUser()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (name == String.Empty || name == null)
                throw new ArgumentException("Name can't be null or empty", nameof(name));

            Console.Write("Enter date of birth (format - {0}): ", dateFormat);
            string dateOfBirth = Console.ReadLine();
            DateTime tempDate;
            if (DateTime.TryParseExact(dateOfBirth, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate))
            {
                return new User { Name = name, DateOfBirth = tempDate };
            }
            else
            {
                throw new ArgumentException("Date incorrect");
            }
        }

        private static void AddUser()
        {
            userLogic.Save(EnterUser());
            Console.Write("Press any button to continue...");
            Console.ReadLine();
        }

        private static void ShowUsers()
        {
            User[] users = userLogic.GetAll();
            Console.WriteLine("List of users:");
            foreach (var user in users)
            {
                Console.Write($"ID:{user.Id}; Name - {user.Name}; DateOfBirth - {user.DateOfBirth.Day}/{user.DateOfBirth.Month}/{user.DateOfBirth.Year}; Age - {user.Age};");
                Console.WriteLine();
            }
            Console.Write("Press any button to continue...");
            Console.ReadLine();
        }

        private static void DeleteUser()
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());
            userLogic.Delete(id);
            Console.Write("Press any button to continue...");
            Console.ReadLine();
        }

        private static void AddAwardToUser()
        {
            Console.Write("Enter users ID: ");
            int userID;
            int awardID;
            bool userParse = Int32.TryParse(Console.ReadLine(), out userID);
            if (!userParse)
                throw new ArgumentException("Users ID must be a number!");
            if (awardLogic.GetMaxId() > 0)
            {
                ShowAwards();
                Console.Write("Choose one ID from awards list: ");
                bool awardParse = Int32.TryParse(Console.ReadLine(), out awardID);
                if (!awardParse)
                    throw new ArgumentException("Awards ID must be a number!");
            }
            else
            {
                Console.WriteLine("Nope any awards.");
                Console.Write("Press any button to continue...");
                Console.ReadLine();
                return;
            }        
            userLogic.AddAwardToUser(userID, awardID);
            Console.Write("Press any button to continue...");
            Console.ReadLine();
        }

        private static void AddAward()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            if (title == String.Empty || title == null)
                throw new ArgumentException("Name can't be null or empty", nameof(title));
            awardLogic.Save(new Award { Title = title });
            Console.Write("Press any button to continue...");
            Console.ReadLine();
        }

        private static void ShowAwards()
        {
            Award[] awards = awardLogic.GetAll();
            Console.WriteLine("List of awards:");
            foreach (var award in awards)
            {
                Console.WriteLine($"ID:{award.Id}; Title - {award.Title}");
            }
        }

        private static void ShowUsersWithAwards()
        {
            User[] users = userLogic.GetAll();
            Console.WriteLine("List of users with awards:");
            foreach (var user in users)
            {
                Console.Write($"ID:{user.Id}; Name - {user.Name}; DateOfBirth - {user.DateOfBirth.Day}/{user.DateOfBirth.Month}/{user.DateOfBirth.Year}; Age - {user.Age}; Awards: ");
                foreach (var item in awardLogic.GetAwardsByIDs(userLogic.GetUserAwardsIDs(user.Id)))
                {
                    Console.Write("{0} ", item.Title);
                }
                
                Console.WriteLine();
            }
            Console.Write("Press any button to continue...");
            Console.ReadLine();
        }

        private static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("1. Add user");
                    Console.WriteLine("2. Remove user");
                    Console.WriteLine("3. Add user's award");
                    Console.WriteLine("4. Show list of users");
                    Console.WriteLine("5. Show users with awards");
                    Console.WriteLine("6. Add award");
                    Console.WriteLine("7. Show awards");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("--------------------------");

                    ConsoleKeyInfo entry = Console.ReadKey(intercept: true);
                    switch (entry.Key)
                    {
                        case ConsoleKey.D1:
                            AddUser();
                            Console.WriteLine("User saved.");
                            break;

                        case ConsoleKey.D2:
                            DeleteUser();
                            break;

                        case ConsoleKey.D3:
                            AddAwardToUser();
                            break;

                        case ConsoleKey.D4:
                            ShowUsers();
                            break;

                        case ConsoleKey.D5:
                            ShowUsersWithAwards();
                            break;
                        case ConsoleKey.D6:
                            AddAward();
                            break;
                        case ConsoleKey.D7:
                            ShowAwards();
                            Console.Write("Press any button to continue...");
                            Console.ReadLine();
                            break;

                        case ConsoleKey.D0:
                            return;

                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.Write("Press any button to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}