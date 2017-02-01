using Epam.Forums.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.DalContracts
{
    public interface IPostDao
    {
        bool AddPost(Post post);
        bool EditPost(int id, string text);
        bool RemovePost(int id);

    }
}
