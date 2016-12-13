using Epam.UserInfo.Logic;
using Epam.UserInfo.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Epam.UsersInfo.WebUI.Models
{
    public class MyRoleProvider : RoleProvider
    {
        private IAccountLogic accountLogic = new AccountLogic();
        public override bool IsUserInRole(string username, string roleName)
        {
            if (roleName == "Users")
            {
                return true;
            }
            if (roleName == "Admins")
            {
                return username.StartsWith("admin");
            }
            return false;
            //return (!accountLogic.CanRegister(username));
            //return (username.Equals("Admin") && roleName.Equals("Admin")) || roleName.Equals("User");
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] rolesForUsers;
            if (accountLogic.GetUsersRole(username).Equals("Admin"))
            {
                return rolesForUsers = new string[] { "Admin", "User" };
            }
            else if (accountLogic.GetUsersRole(username).Equals("User"))
            {
                return rolesForUsers = new string[] { "User" };
            }
            else
            {
                return rolesForUsers = new string[] { "Guest" };
            }
        }

        #region Not implemented
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}