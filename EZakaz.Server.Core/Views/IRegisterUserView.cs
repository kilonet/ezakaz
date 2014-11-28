using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;
using Iesi.Collections.Generic;

namespace EZakaz.Server.Core.Views
{
	public interface IRegisterUserView: IView
	{
		string Login { get; }
		string Name { get; }
		string Password { get; }
		string EMail { get; }
		string Address { get; }
		string Phone { get;}
		string ContactName { get; }
		Role Role { get; }
	    void SetRegisterResult(bool success, string message);

	}
}
