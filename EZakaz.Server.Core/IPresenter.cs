using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace EZakaz.Server.Core
{
	public interface IPresenter
	{
	    void AttachView(IView _view);
		void OnPreRender(EventArgs e);
	    HttpRequest Request { get; }
		//bool IsShowNews { get; }
	}
}
