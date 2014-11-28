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
using JAGregory.Controls;

namespace EZakaz.Web.UI
{
    public partial class Users : AbstractPage<UsersPresenter>, IUsersView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override string PageTitle
        {
            get { return "Список пользователей"; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            gvUsers.TotalRecordCountRequest += ((sender, args) => Presenter.GetUsersCount());
            gvUsers.PageDataRequest += ((sender, args) =>
                                        Presenter.GetUsersPaged(args.Start, args.Size, args.SortDirection,
                                                                args.SortField));
            if (!IsPostBack)
                gvUsers.DataBind();
        }

        protected void gvUsers_rowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            HiddenField hf = e.Row.FindControl("hdnBtnPostback") as HiddenField;
            LinkButton lbtn = e.Row.FindControl("lbtnDeleteUser") as LinkButton;
            HyperLink hyperLink = e.Row.FindControl("hlDeleteUser") as HyperLink;

            lbtn.OnClientClick = string.Format("confirmDelete('{0}','{1}'); return false;", hf.ClientID, (e.Row.DataItem as Domain.User).Name);
            lbtn.CommandArgument = (e.Row.DataItem as Domain.User).Id.ToString();
            hf.Value = ClientScript.GetPostBackEventReference(lbtn, "");
            hyperLink.Attributes["onclick"] = string.Format("confirmDelete('{0}','{1}'); return false;", hf.ClientID, (e.Row.DataItem as Domain.User).Name);
        }


        protected void deleteUserClick(object sender, CommandEventArgs e)
        {
            int userId = Convert.ToInt32(e.CommandArgument);
            Presenter.DeleteUser(userId);
        }
    }
}