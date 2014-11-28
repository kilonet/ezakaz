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
using EZakaz.Domain.Dto;
using EZakaz.Server.Core;
using EZakaz.Server.Core.Presenters;
using EZakaz.Server.Core.Views;

namespace EZakaz.Web.UI
{
    public partial class ItemsAll1 : AbstractPage<ItemsPresenter>, IItemsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            gvItems.Attributes["class"] = "grid";
            gvItems.DataSource = Presenter.AllItems();
            gvItems.DataBind();

            IList<Category> categories = Presenter.AllCat();
            foreach (Category category in categories)
            {
                ddlCat.Items.Add(new ListItem(category.Name, category.Number.ToString()));
            }

            ddlCat.Attributes["onchange"] =
                string.Format("showCat($('{0}').options[$('{0}').selectedIndex].value, $('txtSearch').value)", ddlCat.ClientID);
        }

        public int CategoryId
        {
            get { throw new NotImplementedException(); }
        }

        public List<int> OrderItemIds
        {
            get { throw new NotImplementedException(); }
        }

        protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["id"] = ((Item) e.Row.DataItem).Category.Number.ToString();

                ((HiddenField) e.Row.FindControl("hfItemId")).Value = 
                    ((Item) e.Row.DataItem).Id.ToString();

                e.Row.Cells[0].Attributes["class"] = "tcell tcell-inner";
                e.Row.Cells[1].Attributes["class"] = "tcell tcell-inner";
                e.Row.Cells[2].Attributes["class"] = "tcell tcell-inner";
                e.Row.Cells[3].Attributes["class"] = "tcell tcell-inner";
                e.Row.Cells[4].Attributes["class"] = "tcell tcell-inner";
                e.Row.Cells[5].Attributes["class"] = "tcell tcell-inner";
                e.Row.Cells[6].Attributes["class"] = "tcell tcell-right";
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Attributes["class"] = "theader";
                e.Row.Cells[1].Attributes["class"] = "theader";
                e.Row.Cells[2].Attributes["class"] = "theader";
                e.Row.Cells[3].Attributes["class"] = "theader";
                e.Row.Cells[4].Attributes["class"] = "theader";
                e.Row.Cells[5].Attributes["class"] = "theader";
                e.Row.Cells[6].Attributes["class"] = "theader";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           Presenter.FormNewOrder();
        }


        public OrderDto OrderDto
        {
            get
            {
                List<OrderItemDto> items = new List<OrderItemDto>();
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
                        items.Add(new OrderItemDto(n, itemId));
                    }
                }
                return new OrderDto(items);
                
            }
        }
    }
}
