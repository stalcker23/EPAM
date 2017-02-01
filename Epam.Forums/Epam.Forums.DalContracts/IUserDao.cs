using Epam.Forums.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.DalContracts
{
    public interface IUserDao
    {
        bool AddUser(User user);

        IEnumerable<User> GetAllUsers();

        User GetUserById(int id);
        User GetUserByLogin(string login);

        bool RemoveUser(int id);

        bool ContainsUser(int id);

        bool ChangeUserStatus(int id);

        bool UpdateUser(int id, User user);     

        bool CanRegisterUser(string login);

        bool CheckUser(string login, string password);

        string GetUserRole(string login);
       
        bool ChangeUserRole(int id);
        bool ChangePassword(string login, string currentPassword, string newPassword);
    }
}
