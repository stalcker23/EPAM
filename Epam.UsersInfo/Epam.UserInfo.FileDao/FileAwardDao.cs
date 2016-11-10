using Epam.UserInfo.DalContracts;
using Epam.UserInfo.Entities;
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
            return File.ReadAllLines(fileName).Select(s =>
                {
                    string[] partsAward = s.Split('|');
                    return new Award(int.Parse(partsAward[0]), partsAward[1]);
                });
        }

        public IEnumerable<Award> GetAwardsByIDs(int[] IDs)
        {
            var awards = File.ReadAllLines(fileName);
            return awards.Select(n => n.Split('|')).Select(item => new Award(int.Parse(item[0]), item[1]));
        }

        public Award GetById(int id)
        {
            return GetAll().FirstOrDefault(award => award.Id == id);
        }

        public bool Contains(int id)
        {
            return GetById(id) != null;
        }
    }
}