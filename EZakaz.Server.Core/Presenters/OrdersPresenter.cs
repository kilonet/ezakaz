using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core.Views;
using EZakaz.Server.Core.Web;

namespace EZakaz.Server.Core.Presenters
{
    public class OrdersPresenter: AbstractPresenter<IOrdersView>
    {
        private IOrderDao orderDao;

        public int GetOrdersCount()
        {
			if (!CurrentUser.IsClient)
                return orderDao.GetAdminTotalRecordCount();
            return orderDao.UserOrdersCount(CurrentUser);
        }


        public IOrderDao OrderDao
        {
            set { orderDao = value; }
        }

        public IList<Order> GetOrdersPaged(int start, int size, SortDirection sortDirection, string sortField)
        {
			if (!CurrentUser.IsClient)
                return orderDao.FindAllAdminPaged(start, size, sortDirection, sortField);
            return orderDao.FindByUserPaged(CurrentUser, start, size, sortDirection, sortField);
        }

        public override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            View.IsAdminView = CurrentUser.IsAdmin || CurrentUser.IsStaff;
        }

        public int UnreadOrdersCount()
        {
            return orderDao.UnreadOrdersCount();
        }

        public void DeleteOrders()
        {
            foreach (int orderId in View.SelectedOrdersIds)
            {
                Order order = orderDao.FindById(orderId);
                if (order != null)
                {
                    orderDao.Delete(order);
                }
            }
        }
    }
}
