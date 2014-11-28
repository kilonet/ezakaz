using System;
using EZakaz.Server.Core;
using EZakaz.Server.Core.Presenters;
using EZakaz.Server.Core.Views;

namespace EZakaz.Web.UI
{
	public partial class MyProfile : AbstractPage<MyProfilePresenter>, IMyProfileView
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected override string PageTitle
        {
            get { return "Мои данные"; }
        }

	    public string Login
	    {
            set { lblLogin.Text = value; }
	    }

	    public Domain.User DisplayedUser
	    {
	        set
	        {
	            lblLogin.Text = value.Login;
	            txtAdres.Text = value.Address;
	            txtContact.Text = value.ContactName;
	            txtEmail.Text = value.Email;
	            txtName.Text = value.Name;
	            txtPhone.Text = value.Phone;
	        }
	    }

	    public string Name
	    {
            get { return txtName.Text.Trim(); }
	    }

	    public string Email
	    {
            get { return txtEmail.Text.Trim(); }
	    }

	    public string Adres
	    {
            get { return txtAdres.Text.Trim(); }
	    }

	    public string Phone
	    {
            get { return txtPhone.Text.Trim(); }
	    }

	    public string Contact
	    {
            get { return txtContact.Text.Trim(); }
	    }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Presenter.UpdateFromView();
        }
	}
}
