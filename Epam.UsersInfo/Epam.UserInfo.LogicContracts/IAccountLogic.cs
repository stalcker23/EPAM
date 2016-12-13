using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.LogicContracts
{
    public interface IAccountLogic
    {
        void Add(Account account);

        bool CanRegister(string login);

        bool CanLogin(string login, string password);

        string GetUsersRole(string login);
        Account GetByID(int id);
        bool Contains(int id);
        bool ChangeRole(int id);

    }
}
