using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace EZakaz.Server.Core.Services
{
	public static class NewsService
	{
		private static string PATH = HttpContext.Current.Request.MapPath("news.txt");
		public static int ContentLength { get; private set; }


		static NewsService()
		{
			ContentLength = GetNewsContent().Length;
		}


		public static string GetNewsContent()
		{
			return !File.Exists(PATH) ? "" : File.ReadAllText(PATH);
		}

		internal static void SaveNewsContent(string newsContent)
		{
			File.WriteAllText(PATH, newsContent);
			ContentLength = newsContent.Length;
		}


		internal static void SetShowNewsMode(bool p)
		{
			HttpContext.Current.Session["showNews"] = p;
		}

		private static bool IsShowNews()
		{
			if (ContentLength == 0) return false;
			if (HttpContext.Current.Session["showNews"] != null)
				return (bool) HttpContext.Current.Session["showNews"];
			return false;
		}
	}
}
