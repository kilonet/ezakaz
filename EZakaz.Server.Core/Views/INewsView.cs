using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Server.Core.Views
{
	public interface INewsView: IView
	{
		string NewsContent { get; }
	}
}
