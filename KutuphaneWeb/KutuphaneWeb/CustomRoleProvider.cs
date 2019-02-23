using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using KutuphaneWeb.Models;

namespace KutuphaneWeb
{
    public class CustomRoleProvider : RoleProvider
    {
        KutuphaneDBContext ctx = new KutuphaneDBContext();
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public override string[] GetRolesForUser(string username)
        {
            Uye u = ctx.Uyes.FirstOrDefault(x => x.Email == username);
            if (u != null)
            {
                return u.Rol  == null ? new string[] { } : new string[] { u.Rol.Adi};
            }
            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
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
    }
}