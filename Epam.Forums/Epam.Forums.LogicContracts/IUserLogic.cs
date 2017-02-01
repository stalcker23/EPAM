using Epam.Forums.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.LogicContracts
{
    public interface IUserLogic
    {
        User[] GetAllUsers();

        User GetUserById(int id);
        void AddUser(User account);
        bool SaveUser(User newUser);
        bool DeleteUser(int id);
        bool ContainsUsers(int id);

        bool UpdateUser(int id, User user);

        bool CanRegisterUser(string login);

        bool ChangeUserStatus(int id);

        bool CanLoginUser(string login, string password);
        bool ChangePassword(string login, string currentPassword, string newPassword);

        string GetUsersRole(string login);

        User GetUserByLogin(string login);    
        bool ChangeUserRole(int id);
    }
}
