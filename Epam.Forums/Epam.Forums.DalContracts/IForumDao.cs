using Epam.Forums.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.DalContracts
{
    public interface IForumDao
    {
        bool AddForum(Forum forum);
        Forum GetForumByName(string forumName);
        IEnumerable<Forum> GetAllForums();
        IEnumerable<Topic> GetTopicsByForumId(int id);

        Forum GetForumByID(int id);
        int CountOfTopics(int id);

        bool RemoveForum(int id);
        bool EditForum(int id, string name, string description);

        bool ContainsForum(int id);    
             

    }
}
