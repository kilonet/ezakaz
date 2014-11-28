using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EZakaz.Domain;
using EZakaz.Domain.Dto;
using EZakaz.Server.Core;
using EZakaz.Server.Core.Presenters;
using EZakaz.Server.Core.Views;

namespace EZakaz.Web.UI
{
    public partial class ItemsAll1 : AbstractPage<ItemsPresenter>, IItemsView
    {


        protected override string PageTitle
        {
            get { return "Список товаров"; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //if (Presenter.GetCurrentOrder() != null)
            //{
            //    foreach (OrderItem orderItem in Presenter.GetCurrentOrder().Items)
            //    {
            //        productIdN.Add(orderItem.ProductId, orderItem.N);
            //    }
            //}

            gvItems.DataBind();
            for (int i = 0; i < gvItems.Rows.Count; i++)
            {
                TextBox currentInput = gvItems.Rows[i].FindControl("txtOrder") as TextBox;
                currentInput.Attributes["onkeypress"] = string.Format("return focusNext(this.form, '{0}', event)", currentInput.ClientID);
                currentInput.Attributes["onkeyup"] = string.Format("calcSumm();");

            }

            IEnumerable<Category> categories = Presenter.AllCat();
            ddlCat.Items.Add(new ListItem("Все категории", "-1"));
            foreach (Category category in categories)
            {
                ddlCat.Items.Add(new ListItem(category.Name, category.Id.ToString()));
            }

            ddlCat.Attributes["onchange"] = txtSearch.Attributes["onkeyup"] = 
                string.Format("showCat($('#{0}')[0].options[$('#{0}')[0].selectedIndex].value, $('#{1}')[0].value, '{2}')",
                ddlCat.ClientID, txtSearch.ClientID, gvItems.ClientID);
        }


        


        public bool IsAdminView
        {
            set
            {
                gvItems.Columns[3].Visible = !value;
                btnSubmit.Visible = !value;
                gvItems.Columns[7].Visible = value;
                gvItems.Columns[8].Visible = value;
                gvItems.Columns[9].Visible = value;
                gvItems.Columns[1].Visible = !value;
            }
        }

        protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["id"] = ((Item) e.Row.DataItem).Category.Id.ToString();

                ((HiddenField) e.Row.FindControl("hfItemId")).Value = 
                    ((Item) e.Row.DataItem).Id.ToString();
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {

            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           Presenter.FormNewOrder();
        }


        public Dictionary<int, int> QuantityByItemId
        {
            get
            {
                Dictionary<int, int> dictionary = new Dictionary<int, int>();
                foreach (GridViewRow row in gvItems.Rows)
                {
                    if (row.RowType != DataControlRowType.DataRow)
                        continue;
                    int itemId;
                    int n;
                    if (
                        int.TryParse(((HiddenField)row.FindControl("hfItemId")).Value, out itemId) &&
                        int.TryParse(((TextBox)row.FindControl("txtOrder")).Text, out n)
                        )
                    {
                        dictionary.Add(itemId, n);
                    }
                }
                return dictionary;
            }
        }

        public string Comment
        {
            get { return txtComment.Text; }
        }

        //public OrderDto OrderDto
        //{
        //    get
        //    {
        //        List<OrderItemDto> items = new List<OrderItemDto>();
        //        foreach (GridViewRow row in gvItems.Rows)
        //        {
        //            if (row.RowType != DataControlRowType.DataRow)
        //                continue;
        //            int itemId;
        //            int n;
        //            if (
        //                int.TryParse(((HiddenField)row.FindControl("hfItemId")).Value, out itemId) &&
        //                int.TryParse(((TextBox)row.FindControl("txtOrder")).Text, out n)
        //                )
        //            {
        //                items.Add(new OrderItemDto(n, itemId));
        //            }
        //        }
        //        return new OrderDto(false, items);
                
        //    }
        //}

            

        //public string Comment
        //{
        //    get { return txtComment.Text; }
        //    set { txtComment.Text = lblComment.Text = value; }
        //}

        protected void gvItems_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (Session["SortDirection"] != null)
            {
                if (Session["SortDirection"] == "ASC")
                {
                    Session["SortDirection"] = "DESC";
                }
                else
                {
                    Session["SortDirection"] = "ASC";
                }
            }
            else 
                Session["SortDirection"] = "ASC";

        }

        protected IEnumerable gvItems_PageDataRequest(object sender, JAGregory.Controls.DataRequestEventArgs e)
        {
            return Presenter.AllItems(e.SortDirection, e.SortField);
        }

        protected int gvItems_TotalRecordCountRequest(object sender, JAGregory.Controls.DataRequestEventArgs e)
        {
            return Presenter.AllItemsCount();
        }
    }
}
