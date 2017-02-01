using Epam.Forums.DalContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Forums.Entities;
using Epam.Forums.DBDal;
using Epam.Forums.LogicContracts;
using System.Net;
using Epam.Forums.Utils;
using log4net;

namespace Epam.Forums.Logic
{
    public class ForumLogic : IForumLogic
    {

        private IForumDao forumDao;     


        public ForumLogic()
        {
            forumDao = DaoProvider.ForumDao;

        }
        public void AddForum(Forum forum)

        {
            try
            {
                forumDao.AddForum(forum);

            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }


        public int CountOfTopics(int id)
        {
            try
            {
                return forumDao.CountOfTopics(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool EditForum(int id, string name, string description)
        {
            try
            {
                return forumDao.EditForum(id, name, description);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public IEnumerable<Forum> GetAllForums()
        {
            try
            {
                return forumDao.GetAllForums();
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public Forum GetForumByID(int id)
        {
            try
            {
                return forumDao.GetForumByID(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public Forum GetForumByName(string forumName)
        {
            try
            {
                return forumDao.GetForumByName(forumName);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public IEnumerable<Topic> GetTopicsByForumId(int id)
        {
            try
            {
                return forumDao.GetTopicsByForumId(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool RemoveForum(int id)
        {
            try
            {
                return forumDao.RemoveForum(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

     
    }
}
