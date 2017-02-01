using Epam.Forums.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.LogicContracts
{
    public interface ITopicLogic
    {
        bool AddTopic(Topic topic);
        int CountOfPosts(int id);
        Topic GetTopicById(int id);
        IEnumerable<Post> GetPostsByTopicId(int id);
        bool EditTopic(int id, string title, string description);
        bool RemoveTopic(int id);
        IEnumerable<Topic> FindTopics(string forum, string author, string title);
        int GetForumIdByTopicId(int id);
        bool ModerateTopic(int id);
    }
}
