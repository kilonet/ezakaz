using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EZakaz.Server.Core;
using EZakaz.Server.Core.Presenters;
using EZakaz.Server.Core.Views;

namespace EZakaz.Web.UI
{
    public partial class PrintOrder : AbstractPage<PrintOrderPresenter>, IPrintOrderView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override string PageTitle
        {
            get { return "Печать заказа"; }
        }

        public Domain.Order Order
        {
            set
            {
                Repeater1.DataSource = value.Items;
                Repeater1.DataBind();

                lblDate.Text = string.Format("Заказ Покревскому Д. С. от {0:dd MMM yyyy}", value.DateCreated);
                lblSumm.Text = string.Format("Сумма {0:C}", value.GetPrice());
            }
        }
    }
}
