using Epam.UserInfo.DalContracts;
using Epam.UserInfo.FileDal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.Logic
{
    internal static class DaoProvider
    {
        static DaoProvider()
        {
            if (string.Compare(ConfigurationManager.AppSettings["DaoFormat"], "File") == 0)
            {
                UserDao = new FileUserDao();
                AwardDao = new FileAwardDao();
            }
        }

        public static IUserDao UserDao { get; }
        public static IAwardDao AwardDao { get; }
    }
}