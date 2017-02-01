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
    public class PostLogic : IPostLogic
    {
        private IPostDao postDao;

        public PostLogic()
        {
            postDao = DaoProvider.PostDao;

        }
        public bool AddPost(Post post)
        {
            try
            {

            return postDao.AddPost(post);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool EditPost(int id, string text)
        {
            try
            {
                return postDao.EditPost(id, text);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool RemovePost(int id)
        {
            try
            {
                return postDao.RemovePost(id);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }
    }
}
