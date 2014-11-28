using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using EZakaz.Dao;
using EZakaz.Domain;

namespace EZakaz.Server.Core.Web
{
	public class EZakazRoleProvider : RoleProvider
	{
		private IUserDao userDao = Repository.Default.Resolve<IUserDao>();

		public override string[] GetRolesForUser(string username)
		{
			return new string[] { userDao.FindByLogin(username).Role.ToString() };
		}

		public override void CreateRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new NotImplementedException();
		}

		public override bool RoleExists(string roleName)
		{
			try
			{
				ParseRoleName(roleName);
			}
			catch(ArgumentException)
			{
				return false;
			}
			return true;
		}

		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override string[] GetUsersInRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override string[] GetAllRoles()
		{
			return new string[] {Role.Admin.ToString(), Role.Client.ToString(), Role.Staff.ToString() };
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new NotImplementedException();
		}

		public override string ApplicationName
		{
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		public override bool IsUserInRole(string username, string roleName)
		{
			return userDao.FindByLogin(username).Role == ParseRoleName(roleName);
		}

		private Role ParseRoleName(string name)
		{
			if (name == "Admin") return Role.Admin;
			if (name == "Staff") return Role.Staff;
			if (name == "Client") return Role.Client;
			throw new ArgumentException("wrong role name");
		}

	}
}
