using Epam.UserInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.DalContracts
{
    public interface IDBDao
    {
        IEnumerable<Award> GetAll();
    }
}