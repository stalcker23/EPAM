using Epam.UserInfo.DalContracts;
using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.FileDal
{
    public class FileUserDao : IUserDao
    {
        private const string DateFormat = "dd/MM/yyyy";
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
            string dob = String.Format("{0}/{1}/{2}", user.DateOfBirth.Day, user.DateOfBirth.Month, user.DateOfBirth.Year);
            File.AppendAllLines(fileName, new[] { $"{user.Id}|{user.Name}|{dob}" });

            return true;
        }

        public bool AddUserAward(int userID, int awardID)
        {
            if (!File.Exists(usersAwardsList))
            {
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
                                throw new ArgumentException("User already has this award");
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

        public IEnumerable<User> GetAll()
        {
            try
            {
                return File.ReadAllLines(fileName)
                    .Select(s => s.Split('|'))
                    .Select(parts => new User
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        DateOfBirth = DateTime.Parse(parts[2]),
                    });
            }
            catch
            {
                throw new InvalidOperationException("Create an user first");
            }
        }

        public int [] GetUserAwardsIDs(int ID)
        {
            if (!File.Exists(usersAwardsList))
            {
                File.Create(usersAwardsList).Close();
            }
            using (StreamReader reader = new StreamReader(usersAwardsList, System.Text.Encoding.Default))
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

        public User GetById(int id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }

        public bool Contains(int id)
        {
            return GetById(id) != null;
        }
        public bool Remove(int id)
        {
            var lines = File.ReadAllLines(fileName).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Split('|')[0] == id.ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines(fileName, lines.ToArray(), Encoding.Default);
            return true;
        }

        User IUserDao.GetByID(int id)
        {
            throw new NotImplementedException();
        }

        bool IUserDao.Update(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}