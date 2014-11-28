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
using EZakaz.Domain;
using EZakaz.Server.Core;
using EZakaz.Server.Core.Presenters;
using EZakaz.Server.Core.Views;
using Iesi.Collections.Generic;

namespace EZakaz.Web.UI
{
    public partial class Register : AbstractPage<RegisterUserPresenter>, IRegisterUserView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override string PageTitle
        {
            get { return "Регистрация"; }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			btnRegister.Click += delegate { Presenter.RegisterUser(); };
		}

		#region IRegisterUserView Members

        public void SetRegisterResult(bool success, string message)
        {
            RegistrationForm.Visible = !success;
            lblRegisterResult.Text = message;
        }

        public string Login
    	{
    		get { return txtLogin.Text; }
    	}

    	public string Name
    	{
			get { return txtName.Text; }
    	}

    	public string Password
    	{
			get { return txtPassword.Text; }
    	}

    	public string EMail
    	{
			get { return txtEMail.Text; }
    	}

    	public string Address
    	{
			get { return txtAddress.Text; }
    	}

    	public string Phone
    	{
			get { return txtPhone.Text; }
    	}

    	public string ContactName
    	{
			get { return txtContactName.Text; }
    	}

    	public Role Role
    	{
    		get
    		{
    		    return (Role)Convert.ToInt32(rblRoles.SelectedValue);
    		}
    	}

    	#endregion
    }
}
