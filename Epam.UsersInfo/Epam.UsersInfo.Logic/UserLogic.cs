using Epam.UserInfo.DalContracts;
using Epam.UserInfo.Entities;
using Epam.UserInfo.LogicContracts;
using System;
using System.Linq;

namespace Epam.UserInfo.Logic
{
    public class UserLogic : IUserLogic
    {
        private IUserDao userDao;
        private IAwardDao awardDao;
        private IDBDao dbDao;

        public UserLogic()
        {
            userDao = DaoProvider.UserDao;
            awardDao = DaoProvider.AwardDao;
            dbDao = DaoProvider.DataBaseDao;
        }

        public bool Delete(int id)
        {
            if (!userDao.Delete(id))
            {
                throw new Exception();
            }
            return true;
        }

        public User[] GetAll()
        {
            return userDao.GetAll().ToArray();
        }

        public User Save(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new ArgumentException("User text cannot be null or whitespace", nameof(user.Name));
            }

            if (ValidateName(user.Name))
            {
                if (ValidateDateOfBirth(user.DateOfBirth))
                {
                    User newUser = new User(user.Name, user.DateOfBirth);
                    if (userDao.Add(newUser))
                    {
                        return newUser;
                    }
                    throw new Exception("Error on note saving");
                }
                else
                {
                    throw new Exception("Date of birth invalid");
                }
            }
            else
            {
                throw new Exception("Username invalid");
            }
        }

        public bool ValidateName(string name)
        {
            return (!string.IsNullOrEmpty(name));
        }

        public bool ValidateDateOfBirth(DateTime dateOfBirth)
        {
            if ((dateOfBirth > DateTime.Now) || ((DateTime.Now.Year - dateOfBirth.Year) > 150))
            {
                return false;
            }
            return true;
        }

        public bool AddAwardToUser(int userID, int awardID)
        {
            if (userID < 1 || awardID < 1)
            {
                throw new Exception("ID can't be less than 1");
            }
            if (!userDao.Contains(userID))
            {
                throw new Exception("Can't find user with such ID");
            }
            if (!awardDao.Contains(awardID))
            {
                throw new Exception("Can't find award with such ID");
            }
            if (userDao.AddUserAward(userID, awardID))
            {
                return true;
            }
            throw new Exception("on user's award saving");
        }

        public int[] GetUserAwardsIDs(int ID)
        {
            return userDao.GetUserAwardsIDs(ID);
        }
    }
}