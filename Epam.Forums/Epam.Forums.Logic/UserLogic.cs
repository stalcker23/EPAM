using Epam.Forums.DalContracts;
using Epam.Forums.Entities;
using Epam.Forums.LogicContracts;
using Epam.Forums.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.Logic
{
    public class UserLogic:IUserLogic
    {
        private IUserDao userDao;

        public UserLogic()
        {
            userDao = DaoProvider.UserDao;
            
        }
      
        public User[] GetAllUsers()
        {
            try
            {
                return userDao.GetAllUsers().ToArray();
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }
        public bool DeleteUser(int id)
        {
            if (!userDao.ContainsUser(id))
            {
                throw new ArgumentException("Can't find user with such ID");
            }
            return userDao.RemoveUser(id);
        }
        public bool ContainsUsers(int ID)
        {
            try
            {
                return userDao.ContainsUser(ID);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public User GetUserById(int ID)
        {
            try
            {
                return userDao.GetUserById(ID);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool UpdateUser(int id, User user)
        {
            try
            {
                if (user.Name.Contains('|'))
                {
                    throw new ArgumentException("User info can't contains symbol '|'");
                }

                return userDao.UpdateUser(id, user);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool SaveUser(User newUser)
        {
            try
            {
                if (newUser.Name.Contains('|'))
                {
                    throw new ArgumentException("User info can't contains symbol '|'");
                }

                if (userDao.AddUser(newUser))
                {
                    return true;
                }
                throw new InvalidOperationException("Error on user saving");
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }
        public void AddUser(User user)
        {
            try
            {
                user.Password = GetPasswordsHash(user.Password);
                userDao.AddUser(user);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool CanRegisterUser(string login)
        {
            try
            {
                return userDao.CanRegisterUser(login);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool ChangeUserStatus(int id)
        {
            try
            {
                return userDao.ChangeUserStatus(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        } 

        public bool CanLoginUser(string login, string password)
        {
            try
            {
                return userDao.CheckUser(login, GetPasswordsHash(password));
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public string GetUsersRole(string login)
        {
            try
            {
                return userDao.GetUserRole(login);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        private static string GetPasswordsHash(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
             

        public bool ChangeUserRole(int id)
        {
            try
            {
                return userDao.ChangeUserRole(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public User GetUserByLogin(string login)
        {
            try
            {
                return userDao.GetUserByLogin(login);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool ChangePassword(string login, string currentPassword, string newPassword)
        {
            try
            {
                return userDao.ChangePassword(login, GetPasswordsHash(currentPassword), GetPasswordsHash(newPassword));
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }
    }
}

