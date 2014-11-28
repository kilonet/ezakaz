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
using EZakaz.Server.Core.Services;

namespace EZakaz.Web.UI
{
    public partial class Test : AbstractPage<TestPresenter>, IView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override string PageTitle
        {
            get { return "Тестовые данные"; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Presenter.GenerateTestData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Presenter.MarkOrdersRead();
        }

		protected void Button3_Click(object sender, EventArgs e)
		{
			Presenter.GenerateNonActiveUser();
		}
    }
}
