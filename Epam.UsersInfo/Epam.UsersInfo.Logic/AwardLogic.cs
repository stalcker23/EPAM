using Epam.UserInfo.DalContracts;
using Epam.UserInfo.Entities;
using Epam.UserInfo.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.Logic
{
    public class AwardLogic : IAwardLogic
    {
        private IAwardDao awardDao;
        private IDBDao dbDao;

        public AwardLogic()
        {
            awardDao = DaoProvider.AwardDao;
        }

        public Award[] GetAll()
        {
            var awards = awardDao.GetAll().ToArray();
            if (awards.Length == 0)
            {
                throw new Exception("Nope any awards.");
            }
            return awards;
        }

        public int GetMaxId()
        {
            return awardDao.GetMaxId();
        }

        public Award[] GetAwardsByIDs(int[] IDs)
        {
            if (IDs.Length == 0)
            {
                Console.Write("None");
            }
            return awardDao.GetAwardsByIDs(IDs).ToArray();
        }

        public bool Contains(int id)
        {
            return awardDao.Contains(id);
        }

        public bool Save(string newAward)
        {
            if (newAward.Contains('|'))
            {
                throw new Exception("Award info can't contains symbol '|'");
            }

            Award award = new Award(newAward);

            if (awardDao.Add(award))
            {
                return true;
            }

            throw new InvalidOperationException("Error on award saving");
        }
    }
}