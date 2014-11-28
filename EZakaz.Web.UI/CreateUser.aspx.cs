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

namespace EZakaz.Web.UI
{
    public partial class CreateUser : AbstractPage<CreateUserPresenter>, ICreateUserView
    {
        public string Password
        {
            get { return txtPassword.Text.Trim(); }
        }

        protected override string PageTitle
        {
            get { return "Добавить нового пользователя"; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            Domain.User createdUser = Presenter.CreateUser();
            if (createdUser != null)
            {
                panRegister.Visible = false;
                lblResult.Text = string.Format("Пользователь {0} (логин: {1}) был создан. На указаный почтовый ящик была отправлена информация о логине и пароле.", createdUser.Name, createdUser.Login);
            }
            else
            {
                panRegister.Visible = true;
                lblResult.Text = "Пользователь с таким именем уже существует";
            }
        }


        public string Login
        {
            get { return txtLogin.Text; }
        }

        public string Name
        {
            get { return txtName.Text; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
        }

        public string Adres
        {
            get { return txtAdres.Text; }
        }

        public string Phone
        {
            get { return txtPhone.Text; }
        }

        public string Contact
        {
            get { return txtContact.Text; }
        }

        public Role Role
        {
            get { return (Role) Convert.ToInt32(ddlRoles.SelectedValue); }
        }

        public PriceType PriceType
        {
            get { return (PriceType) Convert.ToInt32(ddlPriceType.SelectedValue); }
        }


        public int AccessId
        {
            get { return Convert.ToInt32(txtAccesId.Text.Trim());  }
        }
    }
}
