using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EZakaz.Server.Core.Services;

namespace EZakaz.Server.Core
{
    public abstract class AbstractPage<TPresenter> : Page, IView where TPresenter : IPresenter, new()
    {
        private TPresenter presenter;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presenter = Repository.Default.Resolve<TPresenter>();
            presenter.AttachView(this);
            Title = "Склад медицинских изделий и диетических продутов: " + PageTitle;
            if (Master == null) return;
            Label label = Master.FindControl("lblTitle") as Label;
            if (label != null) label.Text = PageTitle;

        }

        protected override void OnLoad(EventArgs e)
        {
            Page.Header.DataBind();
            //if (Master != null && Master.FindControl("Panel1") as Panel != null)
            //    (Master.FindControl("Panel1") as Panel).Visible = presenter.IsShowNews;
            //if (presenter.IsShowNews)
            //{
            //    if (Master != null && Master.FindControl("dialog") as HtmlContainerControl != null)
            //    {
            //        (Master.FindControl("dialog") as HtmlContainerControl).InnerHtml = NewsService.GetNewsContent();
            //        NewsService.SetShowNewsMode(false);
            //    }
            //}

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            presenter.OnPreRender(e);
        }

        public TPresenter Presenter
        {
            get { return presenter; }
        }

        protected abstract string PageTitle { get; }
    }
}
