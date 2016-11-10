using Epam.UserInfo.DalContracts;
using Epam.UserInfo.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.FileDal
{
    public class FileUserDao : IUserDao
    {
        private static string dateParse = ConfigurationManager.AppSettings["dateFormat"];

        private readonly string fileName;
        private readonly string counterFileName;
        private readonly string usersAwardsList;

        public FileUserDao()
        {
            fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.txt");
            counterFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usersCounter.txt");
            usersAwardsList = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usersAwardsList.txt");
        }

        public bool Add(User user)
        {
            user.Id = GetMaxId() + 1;
            File.WriteAllText(counterFileName, user.Id.ToString());
            File.AppendAllLines(fileName, new[] { $"{user.Id}|{user.Name}|{user.DateOfBirth.ToString(dateParse)}" });
            return true;
        }

        public bool Delete(int id)
        {
            User user = GetById(id);
            if (user != null)
            {
                RewriteFile(id);
                return true;
            }
            return false;
        }

        private void RewriteFile(int id)
        {
            var users = GetAll().Where(user => user.Id != id);

            File.Create(fileName).Close();
            using (StreamWriter sw = File.AppendText(fileName))
            {
                try
                {
                    foreach (var user in users)
                    {
                        sw.WriteLine($"{user.Id}|{user.Name}|{user.DateOfBirth.ToString(dateParse)}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            return File.ReadAllLines(fileName).Select(s =>
            {
                string[] partsUser = s.Split('|');
                int id = int.Parse(partsUser[0]);
                string name = partsUser[1];
                DateTime dateOfBirth = DateTime.ParseExact(partsUser[2], dateParse, CultureInfo.CurrentCulture);
                return new User(id, name, dateOfBirth);
            });
        }

        public User GetById(int id)
        {
            return GetAll().First(user => user.Id == id);
        }

        public bool Contains(int id)
        {
            return GetById(id) != null;
        }

        public int[] GetUserAwardsIDs(int ID)
        {
            using (StreamReader reader = new StreamReader(usersAwardsList, Encoding.Default))
            {
                string temp;
                List<int> userAwardsIDs = new List<int>();
                while ((temp = reader.ReadLine()) != null)
                {
                    string[] parts = temp.Split('|');
                    if (parts[0] == ID.ToString())
                    {
                        foreach (var awardId in parts[1].Split(' '))
                        {
                            userAwardsIDs.Add(int.Parse(awardId));
                        }
                        return userAwardsIDs.ToArray();
                    }
                }
                return userAwardsIDs.ToArray();
            }
        }

        public bool AddUserAward(int userID, int awardID)
        {
            if (!File.Exists(usersAwardsList))
            {
                File.Create(usersAwardsList).Close();
                File.WriteAllLines(usersAwardsList, new[] { $"{userID}|{awardID}" });
            }
            else
            {
                var lines = File.ReadAllLines(usersAwardsList).ToArray();
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Split('|')[0] == userID.ToString())
                    {
                        foreach (var availableAwardsId in lines[i].Split('|')[1].Split(' '))
                        {
                            if (availableAwardsId == awardID.ToString())
                                throw new Exception("User already has this award");
                        }
                        lines[i] = $"{lines[i]} {awardID}";
                        File.WriteAllLines(usersAwardsList, lines.ToArray(), Encoding.Default);
                        return true;
                    }
                }
                File.AppendAllLines(usersAwardsList, new[] { $"{userID}|{awardID}" });
            }
            return true;
        }

        public int GetMaxId()
        {
            try
            {
                return int.Parse(File.ReadAllText(counterFileName, Encoding.Default));
            }
            catch
            {
                File.WriteAllText(counterFileName, "0");
                return 0;
            }
        }
    }
}