using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;

namespace EZakaz.Server.Core.Views
{
	public interface INewOrderView: IView
	{
		IList<Category> Categories { set; }
	}
}
