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
    public partial class Login : AbstractPage<LoginPresenter>, ILoginView
    {
        protected override string PageTitle
        {
            get { return ""; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnLogin.Click += delegate
                                  {
                                      Presenter.Login();
                                  };
        }

        #region ILoginView Members

        public string Password
        {
            get { return txtPassword.Text; }
        }

        public string UserLogin
        {
            get { return txtLogin.Text; }
        }


        public void ShowFailureMessage()
        {
            panFailure.Visible = true;
        }

        #endregion

        protected void btnCreateAdmin_Click(object sender, EventArgs e)
        {
            Presenter.CreateAdmin();
        }
    }
}
