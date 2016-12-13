using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.LogicContracts
{
    public interface IUserLogic
    {
        User[] GetAll();

        User GetByID(int id);

        bool Save(User newUser);

        bool Delete(int id);

        bool AddAwardToUser(int userID, int awardID);

        int [] GetUserAwardsIDs(int id);

        bool Contains(int id);

        bool Update(int id, User user);

    }
}