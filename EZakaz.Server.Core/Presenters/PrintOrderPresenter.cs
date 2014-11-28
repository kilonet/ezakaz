using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core.Services;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
    public class PrintOrderPresenter: AbstractPresenter<IPrintOrderView>
    {
        private IOrderDao orderDao = Repository.Default.Resolve<IOrderDao>();
        private OrderService orderService = Repository.Default.Resolve<OrderService>();

        public override void OnPreRender(EventArgs e)
        {
            if (GetCurrentOrder() != null)
                View.Order = GetCurrentOrder();
        }

        public Order GetCurrentOrder()
        {
            if (Request.QueryString["id"] != null)
            {
                int orderId;
                if (int.TryParse(Request.QueryString["id"], out orderId))
                {
                    Order currentOrder = orderDao.FindById(orderId);
                    if (orderService.UserCanViewOrder(currentOrder, CurrentUser))
                        return currentOrder;
                }
            }
            return null;
        }
    }
}
