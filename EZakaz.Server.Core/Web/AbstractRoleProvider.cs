// Copyright (C) 2005 - 2007 American College of Radiology
//

using System;
using System.Web.Security;

namespace EZakaz.Server.Core.Web
{
	public abstract class AbstractRoleProvider : RoleProvider
	{
		///<summary>
		///Gets a value indicating whether the specified user is in the specified role for the configured applicationName.
		///</summary>
		///
		///<returns>
		///true if the specified user is in the specified role for the configured applicationName; otherwise, false.
		///</returns>
		///
		///<param name="username">The user name to search for.</param>
		///<param name="roleName">The role to search in.</param>
		public override bool IsUserInRole(string username, string roleName)
		{
			throw new NotImplementedException();
		}

		///<summary>
		///Gets a list of the roles that a specified user is in for the configured applicationName.
		///</summary>
		///
		///<returns>
		///A string array containing the names of all the roles that the specified user is in for the configured applicationName.
		///</returns>
		///
		///<param name="username">The user to return a list of roles for.</param>
		public override string[] GetRolesForUser(string username)
		{
			throw new NotImplementedException();
		}

		///<summary>
		///Adds a new role to the data source for the configured applicationName.
		///</summary>
		///
		///<param name="roleName">The name of the role to create.</param>
		public override void CreateRole(string roleName)
		{
			throw new NotImplementedException();
		}

		///<summary>
		///Removes a role from the data source for the configured applicationName.
		///</summary>
		///
		///<returns>
		///true if the role was successfully deleted; otherwise, false.
		///</returns>
		///
		///<param name="throwOnPopulatedRole">If true, throw an exception if roleName has one or more members and do not delete roleName.</param>
		///<param name="roleName">The name of the role to delete.</param>
		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new NotImplementedException();
		}

		///<summary>
		///Gets a value indicating whether the specified role name already exists in the role data source for the configured applicationName.
		///</summary>
		///
		///<returns>
		///true if the role name already exists in the data source for the configured applicationName; otherwise, false.
		///</returns>
		///
		///<param name="roleName">The name of the role to search for in the data source. </param>
		public override bool RoleExists(string roleName)
		{
			throw new NotImplementedException();
		}

		///<summary>
		///Adds the specified user names to the specified roles for the configured applicationName.
		///</summary>
		///
		///<param name="roleNames">A string array of the role names to add the specified user names to. </param>
		///<param name="usernames">A string array of user names to be added to the specified roles. </param>
		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		///<summary>
		///Removes the specified user names from the specified roles for the configured applicationName.
		///</summary>
		///
		///<param name="roleNames">A string array of role names to remove the specified user names from. </param>
		///<param name="usernames">A string array of user names to be removed from the specified roles. </param>
		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		///<summary>
		///Gets a list of users in the specified role for the configured applicationName.
		///</summary>
		///
		///<returns>
		///A string array containing the names of all the users who are members of the specified role for the configured applicationName.
		///</returns>
		///
		///<param name="roleName">The name of the role to get the list of users for. </param>
		public override string[] GetUsersInRole(string roleName)
		{
			throw new NotImplementedException();
		}

		///<summary>
		///Gets a list of all the roles for the configured applicationName.
		///</summary>
		///
		///<returns>
		///A string array containing the names of all the roles stored in the data source for the configured applicationName.
		///</returns>
		///
		public override string[] GetAllRoles()
		{
			throw new NotImplementedException();
		}

		///<summary>
		///Gets an array of user names in a role where the user name contains the specified user name to match.
		///</summary>
		///
		///<returns>
		///A string array containing the names of all the users where the user name matches usernameToMatch and the user is a member of the specified role.
		///</returns>
		///
		///<param name="usernameToMatch">The user name to search for.</param>
		///<param name="roleName">The role to search in.</param>
		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new NotImplementedException();
		}

		///<summary>
		///Gets or sets the name of the application to store and retrieve role information for.
		///</summary>
		///
		///<returns>
		///The name of the application to store and retrieve role information for.
		///</returns>
		///
		public override string ApplicationName
		{
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
	}
}