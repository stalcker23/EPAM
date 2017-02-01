using Epam.Forums.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Forums.Entities;
using Epam.Forums.DalContracts;
using Epam.Forums.Utils;

namespace Epam.Forums.Logic
{
    public class TopicLogic : ITopicLogic
    {
        private ITopicDao topicDao;

        public TopicLogic()
        {
            topicDao = DaoProvider.TopicDao;

        }

        public bool AddTopic(Topic topic)
        {
            try
            {
                return topicDao.AddTopic(topic);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public int CountOfPosts(int id)
        {
            try
            {
                return topicDao.CountOfPosts(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool EditTopic(int id, string title, string description)
        {
            try
            {
                return topicDao.EditTopic(id, title, description);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public IEnumerable<Topic> FindTopics(string forum, string author, string title)
        {
            try
            {
                return topicDao.FindTopics(forum, author, title);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public int GetForumIdByTopicId(int id)
        {
            try
            {
                return topicDao.GetForumIdByTopicId(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public IEnumerable<Post> GetPostsByTopicId(int id)
        {
            try
            {
                return topicDao.GetPostsByTopicId(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public Topic GetTopicById(int id)
        {
            try
            {
                return topicDao.GetTopicById(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool ModerateTopic(int id)
        {
            try
            {
                return topicDao.ModerateTopic(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool RemoveTopic(int id)
        {
            try
            {
                return topicDao.RemoveTopic(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }
    }
}
