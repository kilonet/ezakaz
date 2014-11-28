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

namespace EZakaz.Web.UI
{
    public partial class Feedback : AbstractPage<FeedbackPresenter>, IFeedbackView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtMessage.Text = "";
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Presenter.SendMessage();
        }

        protected override string PageTitle
        {
            get { return "Обратная связь"; }
        }

        public string MessageText
        {
            get { return txtMessage.Text; }
        }

        public void ShowSuccesMessage()
        {
            lblSucces.Visible = true;
            txtMessage.Text = "";
        }
    }
}
