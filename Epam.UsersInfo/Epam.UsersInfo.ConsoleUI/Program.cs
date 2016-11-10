using Epam.UserInfo.Entities;
using Epam.UserInfo.Logic;
using Epam.UserInfo.LogicContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.ConsoleUI
{
    internal class Program
    {
        private static string dateParse = ConfigurationManager.AppSettings["dateFormat"];
        private static IUserLogic userLogic;
        private static IAwardLogic awardLogic;

        static Program()
        {
            userLogic = new UserLogic();
            awardLogic = new AwardLogic();
        }

        private static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("1. Add user");
                    Console.WriteLine("2. Show users");
                    Console.WriteLine("3. Delete user");
                    Console.WriteLine("4. Add user's award");
                    Console.WriteLine("5. Show users with awards");
                    Console.WriteLine("6. Add award");
                    Console.WriteLine("7. Show awards");
                    Console.WriteLine("0. Exit");

                    var entry = Console.ReadKey(intercept: true);

                    switch (entry.Key)
                    {
                        case ConsoleKey.D1:
                            {
                                AddUser();
                                break;
                            }
                        case ConsoleKey.D2:
                            {
                                ShowUsers();
                                break;
                            }
                        case ConsoleKey.D3:
                            {
                                DeleteUser();
                                break;
                            }
                        case ConsoleKey.D4:
                            AddAwardToUser();
                            break;

                        case ConsoleKey.D5:
                            ShowUsersWithAwards();
                            break;

                        case ConsoleKey.D6:
                            AddAward();
                            break;

                        case ConsoleKey.D7:
                            ShowAwards();
                            Console.ReadLine();
                            break;

                        case ConsoleKey.D0:
                            {
                                return;
                            }
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.ReadLine();
                }
            }
        }

        private static void ShowUsers()
        {
            User[] users = userLogic.GetAll();
            foreach (var item in users)
            {
                Console.WriteLine($"{nameof(item.Id)}: {item.Id}");
                Console.WriteLine($"{nameof(item.Name)}: {item.Name}");
                Console.WriteLine($"{nameof(item.DateOfBirth)}: {item.DateOfBirth:d}");
                Console.WriteLine($"{nameof(item.Age)}: {item.Age}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private static void DeleteUser()
        {
            Console.WriteLine("Write ID's User");
            try
            {
                int id = int.Parse(Console.ReadLine());
                userLogic.Delete(id);
            }
            catch
            {
                throw new Exception("Invalid Id");
            }
            Console.ReadLine();
        }

        private static void AddUser()
        {
            Console.WriteLine("Enter the name:");
            string userText = Console.ReadLine();
            Console.WriteLine("Enter the date of birth:");
            string dateOfBirth = Console.ReadLine();
            try
            {
                var date = DateTime.ParseExact(dateOfBirth, dateParse, CultureInfo.CurrentCulture);
                User user = new User(userText, date);
                userLogic.Save(user);
            }
            catch
            {
                throw new Exception("Invalid date of birth");
            }
            Console.ReadLine();
        }

        private static void AddAwardToUser()
        {
            ShowAwards();
            int userID;
            int awardID;
            Console.Write("Enter users ID: ");
            bool userParse = int.TryParse(Console.ReadLine(), out userID);
            if (!userParse)
            {
                throw new ArgumentException("Users ID must be a number!");
            }

            Console.Write("Choose one ID from awards list: ");
            bool awardParse = int.TryParse(Console.ReadLine(), out awardID);
            if (!awardParse)
            {
                throw new ArgumentException("Awards ID must be a number!");
            }

            userLogic.AddAwardToUser(userID, awardID);
            Console.ReadLine();
        }

        private static void AddAward()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Name can't be null or empty", nameof(title));
            }
            awardLogic.Save(title);
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
                foreach (var item in users)
                {
                    Console.WriteLine($"{nameof(item.Id)}: {item.Id}");
                    Console.WriteLine($"{nameof(item.Name)}: {item.Name}");
                    Console.WriteLine($"{nameof(item.DateOfBirth)}: {item.DateOfBirth:d}");
                    Console.WriteLine($"{nameof(item.Age)}: {item.Age}");
                    Console.Write($"Award: ");
                }
                foreach (var item in awardLogic.GetAwardsByIDs(userLogic.GetUserAwardsIDs(user.Id)))
                {
                    Console.Write("{0} ", item.Title);
                }

                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}