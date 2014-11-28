using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core;
using EZakaz.Server.Core.Presenters;

namespace EZakaz.Web.UI
{
    public partial class ItemInfo : AbstractPage<DefaultPresenter>, IView
    {
        private IItemDao itemDao = Repository.Default.Resolve<IItemDao>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override string PageTitle
        {
            get { return "Информация о товаре: " + getCurrentItem().Name; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HyperLink1.NavigateUrl = ResolveUrl("~/uploads/" + getCurrentItem().ItemInfo.Image);
            Image1.ImageUrl = ResolveUrl("~/uploads/" + getCurrentItem().ItemInfo.SmallImage);
            Literal1.Text = getCurrentItem().ItemInfo.Description;

        }

        private Item getCurrentItem()
        {
            return itemDao.FindById(Presenter.IdParameter);
        }
    }
}
