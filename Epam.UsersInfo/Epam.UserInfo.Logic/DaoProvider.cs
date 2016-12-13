using Epam.UserInfo.DalContracts;
using Epam.UserInfo.DBDal;
using Epam.UserInfo.FileDal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.Logic
{
    internal class DaoProvider
    {
        static DaoProvider()
        {
            if (ConfigurationManager.AppSettings["DaoMode"] == "File")
            {
                UserDao = new FileUserDao();
                AwardDao = new FileAwardDao();
            }
            if (ConfigurationManager.AppSettings["DaoMode"] == "DB")
            {
                UserDao = new DBUserDao();
                AwardDao = new DBAwardDao();
                AccountDao = new DBAccountDao();
            }
        }

        public static IUserDao UserDao { get; }
        public static IAwardDao AwardDao { get; }
        public static IAccountDao AccountDao { get; }
    }
}