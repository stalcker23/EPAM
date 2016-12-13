using Epam.UserInfo.DalContracts;
using Epam.UserInfo.LogicContracts;
using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.Logic
{
    public class UserLogic : IUserLogic
    {
        private IUserDao userDao;
        private IAwardDao awardDao;

        public UserLogic()
        {
            userDao = DaoProvider.UserDao;
            awardDao = DaoProvider.AwardDao;
        }

        public bool Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID can't be less than 1");
            }

            if (!userDao.Contains(id))
            {
                throw new ArgumentException("Can't find user with such ID");
            }
            return userDao.Remove(id);
        }

        public bool AddAwardToUser(int userID, int awardID)
        {
            if (userID < 1 || awardID < 1)
            {
                throw new ArgumentException("ID can't be less than 1");
            }
            if (!userDao.Contains(userID))
            {
                throw new ArgumentException("Can't find user with such ID");
            }
            if (!awardDao.Contains(awardID))
            {
                throw new ArgumentException("Can't find award with such ID");
            }
            if (userDao.AddUserAward(userID, awardID))
            {
                return true;
            }
            throw new InvalidOperationException("on user's award saving");
        }

        public int [] GetUserAwardsIDs(int ID)
        {
            return userDao.GetUserAwardsIDs(ID);
        }

        public User[] GetAll()
        {
            return userDao.GetAll().ToArray();
        }

        public bool Contains(int ID)
        {
            return userDao.Contains(ID);
        }

        public User GetByID(int ID)
        {
            return userDao.GetByID(ID);
        }

        public bool Update(int id, User user)
        {
            if (user.Name.Contains('|'))
            {
                throw new ArgumentException("User info can't contains symbol '|'");
            }

            if (user.DateOfBirth > DateTime.Today)
            {
                throw new ArgumentException("Date of Birth can't be above than current date");
            }

            if (user.Age > 150)
            {
                throw new ArgumentException("User's age cant' be above than 150 years");
            }
            return userDao.Update(id, user);
        }

        public bool Save(User newUser)
        {
            if (newUser.Name.Contains('|'))
            {
                throw new ArgumentException("User info can't contains symbol '|'");
            }

            if (newUser.DateOfBirth > DateTime.Today)
            {
                throw new ArgumentException("Date of Birth can't be above than current date");
            }

            if (newUser.Age > 150)
            {
                throw new ArgumentException("User's age cant' be above than 150 years");
            }

            if (userDao.Add(newUser))
            {
                return true;
            }
            throw new InvalidOperationException("Error on user saving");
        }

    }
}