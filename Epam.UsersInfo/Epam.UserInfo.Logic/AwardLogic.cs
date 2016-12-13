using Epam.UserInfo.DalContracts;
using Epam.UserInfo.LogicContracts;
using Epam.UsersInfo.Entities;
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

        public AwardLogic()
        {
            awardDao = DaoProvider.AwardDao;
        }

        public Award[] GetAll()
        {
            return awardDao.GetAll().ToArray();
        }

        public Award[] GetAwardsByIDs(int[] IDs)
        {
            if (IDs.Length==0)
            {
                Console.Write("None");
                return new Award[0];
            }

            return awardDao.GetAwardsByIDs(IDs).ToArray();
        }

        public Award GetByID(int ID)
        {
            return awardDao.GetByID(ID);
        }

        public int GetMaxId()
        {
            return awardDao.GetMaxId();
        }

        public bool Contains(int ID)
        {
            return awardDao.Contains(ID);
        }

        public bool Save(Award newAward)
        {
            if (newAward.Title.Contains('|'))
                throw new ArgumentException("Award info can't contains symbol '|'");

            if (awardDao.Add(newAward))
            {
                return true;
            }

            throw new InvalidOperationException("Error on award saving");
        }

        public bool Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID can't be less than 1");
            }

            if (!awardDao.Contains(id))
            {
                throw new ArgumentException("Can't find award with such ID");
            }
            return awardDao.Remove(id);
        }

        public bool Update(int id, Award award)
        {
            if (award.Title.Contains('|'))
            {
                throw new ArgumentException("Title can't contains symbol '|'");
            }

            return awardDao.Update(id, award);
        }

        public bool IsAwarded(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID can't be less than 1");
            }

            if (!awardDao.Contains(id))
            {
                throw new ArgumentException("Can't find award with such ID");
            }
            return awardDao.IsAwarded(id);
        }
    }
}