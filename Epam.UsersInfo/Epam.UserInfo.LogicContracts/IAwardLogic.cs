using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.LogicContracts
{
    public interface IAwardLogic
    {
        Award[] GetAll();

        Award[] GetAwardsByIDs(int[] IDs);

        Award GetByID(int id);

        bool Save(Award newAward);

        int GetMaxId();

        bool Delete(int id);

        bool Contains(int id);

        bool Update(int id, Award award);

        bool IsAwarded(int id);
    }
}