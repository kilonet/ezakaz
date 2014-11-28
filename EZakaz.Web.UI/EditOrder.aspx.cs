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
using EZakaz.Server.Core.Services;
using EZakaz.Server.Core.Views;

namespace EZakaz.Web.UI
{
    public partial class EditOrder : AbstractPage<EditOrderPresenter>, IEditOrderView
    {
        protected override string PageTitle
        {
            get { return "Редактирование заказа"; }
        }
        
        private bool isAdminView;
        private Dictionary<int, int> productIdN = new Dictionary<int, int>();
        

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            panClient.Visible = !Presenter.CurrentUser.IsClient;
            lblError.Visible = false;
            
            if (Presenter.GetCurrentOrder() != null)
            {
                foreach(OrderItem orderItem in Presenter.GetCurrentOrder().Items)
                {
                    productIdN.Add(orderItem.ProductId, orderItem.N);
                }

                HyperLink1.NavigateUrl = ResolveUrl(string.Format("~/User.aspx?id={0}", Presenter.GetCurrentOrder().User.Id));
                HyperLink1.Text = Presenter.GetCurrentOrder().User.Name;

                hlZakazCsv.NavigateUrl = ResolveUrl("~/Order.ashx?id=" + Presenter.GetCurrentOrder().Id);
                linkPrint.NavigateUrl = ResolveUrl("~/PrintOrder.aspx?id=" + Presenter.GetCurrentOrder().Id);
                linkPrint.Attributes["target"] = "_blank";
            }
            
        }

        public string GetN(Item item)
        {
            if (productIdN.ContainsKey(item.ProductId))
            {
                return productIdN[item.ProductId].ToString();
            }
            return "";            
        }

        public void ShowSuccesMessage()
        {
            lblSuccesMessage.Visible = true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            OrderPrice = Presenter.GetCurrentOrder().GetPrice();
            lblComment.Visible = Presenter.GetCurrentOrder().IsSent;
            txtComment.Visible = !Presenter.GetCurrentOrder().IsSent;
            hlZakazCsv.Visible = Presenter.CurrentUser.IsAdmin || Presenter.CurrentUser.IsStaff;
        }

        protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            HiddenField hf = (HiddenField) e.Row.FindControl("hfItemId");
            hf.Value = ((OrderItem) e.Row.DataItem).Id.ToString();
        }


        public string SaveButtonText
        {
            set { btnSave.Text = value; }
        }

        public IList<OrderItem> OrderItems
        {
            set
            {
                gvItems.DataSource = value;
                gvItems.DataBind();
                MakeMoveFocusOnEnter();
            }
        }

        private void MakeMoveFocusOnEnter()
        {
            for (int i = 0; i < gvItems.Rows.Count - 1; i++)
            {
                TextBox currentInput = gvItems.Rows[i].FindControl("txtOrder") as TextBox;
                TextBox nextInput = gvItems.Rows[i + 1].FindControl("txtOrder") as TextBox;
                currentInput.Attributes["onkeypress"] = string.Format("return focusNext(this.form, '{0}', event)", nextInput.ClientID);
            }
            TextBox lastInput = gvItems.Rows[gvItems.Rows.Count - 1].FindControl("txtOrder") as TextBox;
            lastInput.Attributes["onkeypress"] = string.Format("return focusNext(this.form, '{0}', event)", lastInput.ClientID);
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
                    int orderItemId;
                    int n;
                    if (
                        int.TryParse(((HiddenField)row.FindControl("hfItemId")).Value, out orderItemId) &&
                        int.TryParse(((TextBox)row.FindControl("txtOrder")).Text, out n)
                        )
                    {
                        items.Add(new OrderItemDto(n, orderItemId));
                    }
                    else 
                        items.Add(new OrderItemDto(-1, orderItemId));
                }
                return new OrderDto(chkRead.Checked, items);

            }
        }
        
        public string Comment
        {
            get { return txtComment.Text; }
            set { txtComment.Text = lblComment.Text = value; }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Presenter.UpdateOrderFromView();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Presenter.SendOrder();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Presenter.DeleteOrder();
        }


        public bool IsRead
        {
            set { chkRead.Checked = value; }
        }

        public bool IsBtnSaveVisible
        {
            set { btnSave.Visible = value; }
        }

        public bool IsBtnSendVisible
        {
            set { btnSend.Visible = value; }
        }

        public bool IsBtnDeleteVisible
        {
            set { btnDelete.Visible = value; }
        }


        public decimal OrderPrice
        {
            set 
            {
                gvItems.FooterRow.Cells[0].Text = string.Format("Сумма заказа: {0:C}", value);
            }
        }


        public DateTime? OrderSentDate
        {
            set
            {
                if (value.HasValue)
                {
                    lblDateSent.Text = string.Format("Дата отправки заказа: {0:D} {0:t}", value);
                }
                
            }
        }

        public DateTime OrderCreatedDate
        {
            set
            {
                lblDateCreated.Text = string.Format("Дата создания заказа: {0:D} {0:t}", value);
            }
        }

        public bool IsAdminView
        {
            get { return isAdminView; }
            set
            {
                isAdminView = value;
                btnDelete.Visible = btnSave.Visible = btnSend.Visible = !value;
                panRead.Visible = value;
                Domain.Order order = Presenter.GetCurrentOrder();
                if (order == null)
                {
                    //if (!Presenter.CurrentUser.IsClient)
                    //    throw new Exception("только клиенты могут делать заказы");
                    gvItems.Columns[1].Visible = true;
                    gvItems.Columns[2].Visible = false;
                }
                else 
                {
                    // txt
                    gvItems.Columns[1].Visible = !order.IsSent;
                    // lbl
                    gvItems.Columns[2].Visible = order.IsSent;
                }
            }
        }

        protected void gvItems_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int m = e.Row.Cells.Count;
                for (int i = m - 1; i >= 1; i+= -1)
                {
                    e.Row.Cells.RemoveAt(i);
                }
                e.Row.Cells[0].ColumnSpan = m;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region IEditOrderView Members


        public new IList<Item> Items
        {
            set 
            {
                gvItems.DataSource = value;
                gvItems.DataBind();
            }
        }

        #endregion
    }
}
