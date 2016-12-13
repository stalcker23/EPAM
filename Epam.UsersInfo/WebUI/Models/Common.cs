using Epam.UserInfo.Logic;
using Epam.UserInfo.LogicContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Epam.UsersInfo.WebUI.Models
{
    public static class Common
    {
        private static IUserLogic userLogic = new UserLogic();

        private static IAwardLogic awardLogic = new AwardLogic();

        private static IAccountLogic accountLogic = new AccountLogic();

        private static string dateFormat = ConfigurationManager.AppSettings["DateFormat"];

        public static int ElementID { get; set; }

        public static IUserLogic UserBll
        {
            get
            {
                return userLogic;
            }
        }

        public static IAwardLogic AwardBll
        {
            get
            {
                return awardLogic;
            }
        }

        public static IAccountLogic AccountBll
        {
            get
            {
                return accountLogic;
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