using Epam.Forums.Logic;
using Epam.Forums.LogicContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Epam.Forums.WebUI.Models
{
    public static class Common
    {
        private static IUserLogic userLogic = new UserLogic();

        private static IForumLogic forumLogic = new ForumLogic();

        private static ITopicLogic topicLogic = new TopicLogic();

        private static IPostLogic postLogic = new PostLogic();
        private static IImageLogic imageLogic = new ImageLogic();

        private static string dateFormat = ConfigurationManager.AppSettings["DateFormat"];

        public static int ElementID { get; set; }

        public static IUserLogic UserBll
        {
            get
            {
                return userLogic;
            }
        }
        public static IImageLogic ImageBll
        {
            get
            {
                return imageLogic;
            }
        }
        public static IPostLogic PostBll
        {
            get
            {
                return postLogic;
            }
        }
        public static IForumLogic ForumBll
        {
            get
            {
                return forumLogic;
            }
        }

        public static ITopicLogic TopicBll
        {
            get
            {
                return topicLogic;
            }
        }
        public static string DateFormat
        {
            get
            {
                return dateFormat;
            }
        }

    }
}