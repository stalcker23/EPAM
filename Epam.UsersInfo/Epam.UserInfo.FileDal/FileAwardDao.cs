using Epam.UserInfo.DalContracts;
using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.FileDal
{
    public class FileAwardDao : IAwardDao
    {
        private readonly string fileName;
        private readonly string counterFileName;

        public FileAwardDao()
        {
            fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "awards.txt");
            counterFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "awardsCounter.txt");
        }

        public bool Add(Award award)
        {
            award.Id = GetMaxId() + 1;
            File.WriteAllText(counterFileName, award.Id.ToString());
            File.AppendAllLines(fileName, new[] { $"{award.Id}|{award.Title}" });
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

        public IEnumerable<Award> GetAll()
        {
            try
            {
                return File.ReadAllLines(fileName)
                    .Select(s => s.Split('|'))
                    .Select(parts => new Award
                    {
                        Id = int.Parse(parts[0]),
                        Title = parts[1],
                    });
            }
            catch
            {
                throw new InvalidOperationException("Create an award first");
            }
        }

        public IEnumerable<Award> GetAwardsByIDs(int[] IDs)
        {
            var awards = File.ReadAllLines(fileName);
            List<Award> suitableAwards = new List<Award>();

            foreach (var award in awards)
            {
                var parts = award.Split('|');
                if (IDs.Contains(int.Parse(parts[0])))
                {
                    suitableAwards.Add(new Award { Id = int.Parse(parts[0]), Title = parts[1] });
                }
            }

            return suitableAwards;
        }

        public Award GetById(int id)
        {
            return GetAll().FirstOrDefault(award => award.Id == id);
        }

        public bool Contains(int id)
        {
            return GetById(id) != null;
        }

        bool IAwardDao.Remove(int id)
        {
            throw new NotImplementedException();
        }

        Award IAwardDao.GetByID(int id)
        {
            throw new NotImplementedException();
        }

        bool IAwardDao.Update(int id, Award award)
        {
            throw new NotImplementedException();
        }

        bool IAwardDao.IsAwarded(int id)
        {
            throw new NotImplementedException();
        }
    }
}