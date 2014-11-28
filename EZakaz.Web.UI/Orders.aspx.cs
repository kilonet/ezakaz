using System;
using System.Collections.Generic;
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
    public partial class Orders : AbstractPage<OrdersPresenter>, IOrdersView
    {
        private const int CLENT_NAME_COLUMN_INDEX = 0;
        private const int ORDER_STATE_COLUMN_INDEX = 3;
        private const int READ_COLUMN_INDEX = 5;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override string PageTitle
        {
            get { return "Список заказов"; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            gvOrders.TotalRecordCountRequest += delegate(object sender, JAGregory.Controls.DataRequestEventArgs args)
                                                    {
                                                        return Presenter.GetOrdersCount();
                                                    };
            gvOrders.PageDataRequest += delegate(object sender, JAGregory.Controls.DataRequestEventArgs args)
                                            {
                                                return Presenter.GetOrdersPaged(args.Start, args.Size, args.SortDirection, args.SortField);
                                            };
            //if (!IsPostBack)
                gvOrders.DataBind();

            gvOrders.Columns[READ_COLUMN_INDEX].Visible = Presenter.CurrentUser.IsAdmin || Presenter.CurrentUser.IsStaff;

        }


        public bool IsAdminView
        {
            set 
            {
                gvOrders.Columns[CLENT_NAME_COLUMN_INDEX].Visible = value;
                gvOrders.Columns[ORDER_STATE_COLUMN_INDEX].Visible = !value;
            }
        }

        protected string StatusToString(OrderState orderState)
        {
            if (orderState == OrderState.Draft)
                return "Не отправлен";
            return "Отправлен";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Presenter.DeleteOrders();
            gvOrders.DataBind();
        }

        public IEnumerable<int> SelectedOrdersIds
        {
            get
            {
                List<int> ids = new List<int>(gvOrders.Rows.Count - 1);
                foreach (GridViewRow row in gvOrders.Rows)
                {
                    if (row.RowType != DataControlRowType.DataRow)
                        continue;
                    CheckBox checkBox = row.FindControl("chkSelect") as CheckBox;
                    if (!checkBox.Checked) continue;
                    HiddenField hf = row.FindControl("hfOrderId") as HiddenField;
                    ids.Add(int.Parse(hf.Value));
                }
                return ids;
            }
        }

        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            HiddenField hf = e.Row.FindControl("hfOrderId") as HiddenField;
            hf.Value = (e.Row.DataItem as Domain.Order).Id.ToString();
        }
    }
}
