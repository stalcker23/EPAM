using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Forums.DalContracts;
using Epam.Forums.DBDal;
namespace Epam.Forums.Logic
{
    internal class DaoProvider
    {
        static DaoProvider()
        {
            
            if (ConfigurationManager.AppSettings["DaoMode"] == "DB")
            {
                UserDao = new DBUserDao();
                ForumDao = new DBForumDao();
                TopicDao = new DBTopicDao();
                ImageDao = new DBImageDao();
                PostDao = new DBPostDao();
            }
        }

        public static IImageDao ImageDao { get; }
        public static IUserDao UserDao { get; }
        public static IForumDao ForumDao { get;}
        public static ITopicDao TopicDao { get;}
        public static IPostDao PostDao { get; }
    }
}
