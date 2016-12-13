using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.DalContracts
{
    public interface IAwardDao
    {
        bool Add(Award award);

        IEnumerable<Award> GetAll();

        IEnumerable<Award> GetAwardsByIDs(int[] IDs);

        int GetMaxId();

        bool Contains(int id);

        bool Remove(int id);

        Award GetByID(int id);

        bool Update(int id, Award award);

        bool IsAwarded(int id);

    }
}