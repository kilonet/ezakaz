using System;
using EZakaz.Domain;
using EZakaz.Server.Core;
using EZakaz.Server.Core.Presenters;
using EZakaz.Server.Core.Views;

namespace EZakaz.Web.UI
{
    public partial class User : AbstractPage<UserPresenter>, IUserView
    {
        protected override string PageTitle
        {
            get { return "Данные пользователя"; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int ClientId
        {
            get { return int.Parse(txtClientId.Text); }
        }

        public PriceType PriceType
        {
            get { return (PriceType) Convert.ToInt32(ddlPriceType.SelectedValue); }
        }

        public Role Role
        {
            get
            {
                return (Role)Convert.ToInt32(ddlRole.SelectedValue);
            }
        }

        public bool Active
        {
            get
            {
                return chkActive.Checked;
            }
        }

        public Domain.User CurrentUser
        {
            set
            {
                lblAdres.Text = value.Address;
                lblContact.Text = value.ContactName;
                lblEmail.Text = value.Email;
                lblLogin.Text = value.Login;
                lblname.Text = value.Name;
                chkActive.Checked = value.IsActive;
                txtClientId.Text = value.AccessId.ToString();

                ddlRole.Items.FindByText("Администратор").Selected = value.IsAdmin;
                ddlRole.Items.FindByText("Сотрудник").Selected = value.IsStaff;
                ddlRole.Items.FindByText("Клиент").Selected = value.IsClient;

                ddlPriceType.Items.FindByText("Цена 1").Selected = value.PriceType == PriceType.Price1;
                ddlPriceType.Items.FindByText("Цена 2").Selected = value.PriceType == PriceType.Price2;
                ddlPriceType.Items.FindByText("Цена 3").Selected = value.PriceType == PriceType.Price3;
            }
        }


        public bool IsAdminView
        {
            set
            {
                ddlRole.Visible = chkActive.Visible = value;
                btnSave.Visible = value;
            	panIsNew.Visible = Presenter.GetUserByIdParam().IsNew && value;
                panPriceType.Visible = value && Presenter.GetUserByIdParam().IsClient;
                panClientId.Visible = value;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Presenter.UpdateFromView();
        }

		protected void btnAccept_Click(object sender, EventArgs e)
		{
			Presenter.AcceptUser();
		}

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			Presenter.CancelUser();
		}

    }
}
