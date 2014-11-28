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
    public partial class RecoverPassword : AbstractPage<RecoverPasswordPresenter>, IRecoverPasswordView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override string PageTitle
        {
            get { return "Восстановление пароля"; }
        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            Presenter.ResetPassword();
        }


        public string Email
        {
            get { return txtEmail.Text.Trim(); }
        }

        public string Login
        {
            get { return txtLogin.Text.Trim(); }
        }

        public void SetResult(string p)
        {
           lblResult.Text = p;
        }
    }
}
