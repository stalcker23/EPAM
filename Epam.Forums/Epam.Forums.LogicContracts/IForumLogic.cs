using Epam.Forums.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.LogicContracts
{
    public interface IForumLogic
    {
        void AddForum(Forum forum);

        IEnumerable<Forum> GetAllForums();

        IEnumerable<Topic> GetTopicsByForumId(int id);

        Forum GetForumByID(int id);
        Forum GetForumByName(string forumName);
        bool RemoveForum(int id);

        bool EditForum(int id, string name, string description);
    
        int CountOfTopics(int id);
              
    }
}
