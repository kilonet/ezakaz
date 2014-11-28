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
    public partial class ItemDetails : AbstractPage<ItemDetailsPresenter>, IItemDetailsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override string PageTitle
        {
            get { return "Информация о товаре"; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblInfo.Text = string.Format("{0}", Presenter.GetItemInfo().ProductId);
        }
    }
}
