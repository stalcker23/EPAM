using Epam.UserInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.DalContracts
{
    public interface IUserDao
    {
        bool Add(User user);

        IEnumerable<User> GetAll();

        User GetById(int id);

        bool Delete(int id);

        int[] GetUserAwardsIDs(int iD);

        bool AddUserAward(int userID, int awardID);

        bool Contains(int id);
    }
}