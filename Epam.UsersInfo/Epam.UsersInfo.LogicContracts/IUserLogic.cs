using Epam.UserInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.LogicContracts
{
    public interface IUserLogic
    {
        User Save(User user);

        User[] GetAll();

        bool Delete(int id);

        bool AddAwardToUser(int userID, int awardID);

        int[] GetUserAwardsIDs(int id);
    }
}