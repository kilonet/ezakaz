using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EZakaz.Server.Core;
using EZakaz.Server.Core.Presenters;
using EZakaz.Server.Core.Views;
using EZakaz.Server.Core.Web;

namespace EZakaz.Web.UI
{
    public partial class Default : AbstractPage<MainPresenter>, IMainView
    {
        private IUserContext userContext = Repository.Default.Resolve<IUserContext>();

        protected void Page_Load(object sender, EventArgs e)
        {

            //Domain.User currentUser = userContext.CurentUser;
            //if (currentUser == null)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            //else if (currentUser.IsClient)
            //{
            //    Response.Redirect("~/Items.aspx");
            //}
            //else
            //{
            //    Response.Redirect("~/Orders.aspx");
            //}

        }

        protected override string PageTitle
        {
            get { return "Новости"; }
        }

        public string NewsContents
        {
            set { lblNews.Text = value; }
        }
    }
}
