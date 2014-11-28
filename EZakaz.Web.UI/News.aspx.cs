using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EZakaz.Server.Core;
using EZakaz.Server.Core.Presenters;
using EZakaz.Server.Core.Views;

namespace EZakaz.Web.UI
{
	public partial class News : AbstractPage<NewsPresenter>, INewsView
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnPublish_Click(object sender, EventArgs e)
		{
			lblNewsText.Text = Editor1.Content;
			Presenter.SaveNews();
		}

		protected override string PageTitle
		{
			get { return "Новости"; }
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Editor1.Visible = btnPublish.Visible = Presenter.CurrentUser.IsAdmin;
			
			if (!IsPostBack)
			{
				Editor1.Content = lblNewsText.Text = Presenter.LoadNews();
			}
		}

		public string NewsContent
		{
			get { return Editor1.Content; }
		}
	}
}
