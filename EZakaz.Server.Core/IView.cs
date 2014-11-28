using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Server.Core
{
	public interface IView
	{
		bool IsValid { get; }
		bool IsPostBack { get; }
	}
}
