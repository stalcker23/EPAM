using Epam.Forums.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.DalContracts
{
   public interface ITopicDao
    {
        bool AddTopic(Topic topic);
        int CountOfPosts(int id);
        Topic GetTopicById(int id);
        IEnumerable<Post> GetPostsByTopicId(int id);
        bool RemoveTopic(int id);
        bool EditTopic(int id, string title, string description);
        int GetForumIdByTopicId(int id);
        IEnumerable<Topic> FindTopics(string forum, string author, string title);
        bool ModerateTopic(int id);
    }
}
