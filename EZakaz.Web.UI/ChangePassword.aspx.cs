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
    public partial class WebForm1 : AbstractPage<ChangePasswordPresenter>, IChangePasswordView
    {
        protected override string PageTitle
        {
            get { return "Сменить пароль"; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Presenter.ChangePassword();
        }


        public string OldPassword
        {
            get { return txtOldPass.Text.Trim(); }
        }

        public string NewPassword
        {
            get { return txtNewPass.Text.Trim(); }
        }

        public void SetResult(string p)
        {
            lblResult.Text = p;
        }
    }
}
