using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using EZakaz.Server.Core.Services;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
	public class NewsPresenter: AbstractPresenter<INewsView>
	{
		

		public string LoadNews()
		{
			return NewsService.GetNewsContent();
		}

		public void SaveNews()
		{
			NewsService.SaveNewsContent(View.NewsContent);
		}
	}
}
