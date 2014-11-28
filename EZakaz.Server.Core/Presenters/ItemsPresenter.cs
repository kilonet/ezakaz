using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using EZakaz.Dao;
using EZakaz.DaoImpl;
using EZakaz.Domain;
using EZakaz.Domain.Dto;
using EZakaz.Server.Core.Services;
using EZakaz.Server.Core.Views;
using JAGregory.Controls;


namespace EZakaz.Server.Core.Presenters
{
    public class ItemsPresenter: AbstractPresenter<IItemsView>
    {
        private IItemDao itemDao;
        private ICategoryDao categoryDao;
        private IOrderDao orderDao;
        private OrderService orderService = Repository.Default.Resolve<OrderService>();
        private MailService mailService = Repository.Default.Resolve<MailService>();
        private IOrderItemDao orderItemDao;


        public IOrderItemDao OrderItemDao
        {
            set { orderItemDao = value; }
        }

        public IOrderDao OrderDao
        {
            set { orderDao = value; }
        }

        public ICategoryDao CategoryDao
        {
            set { categoryDao = value; }
        }

        public IItemDao ItemDao
        {
            set { itemDao = value; }
        }

        public override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            View.IsAdminView = !CurrentUser.IsClient;
        }

        public string CategoryName
        {
            get
            {
                int id;
                if (int.TryParse(HttpContext.Current.Request.QueryString["category"], out id))
                {
                    Category category = categoryDao.FindById(id);
                    return category == null ? "" : category.Name;
                }
                return "";
            }
        }

        public IEnumerable<Category> AllCat()
        {
            return categoryDao.FindAllSorted(SortDirection.Ascending, "Name");
        }

        public void FormNewOrder()
        {
            if (View.QuantityByItemId.Count == 0)
                return;
            Order order = new Order();
            order.User = CurrentUser;
            order.Comment = View.Comment;
            orderDao.Save(order);
            foreach (KeyValuePair<int, int> keyValuePair in View.QuantityByItemId)
            {
                if (keyValuePair.Value < 1) continue;
                Item item = itemDao.FindById(keyValuePair.Key);
                order.Items.Add(new OrderItem(keyValuePair.Value, item, CurrentUser.PriceType, order));
            }
            orderService.SendOrder(order);
            mailService.NotifyAllAdmins(order);
            Response.Redirect("~/EditOrder.aspx?id=" + order.Id);
        }

        public int AllItemsCount()
        {
            return itemDao.GetTotalRecordCount();
        }

        public IEnumerable<Item> AllItems(SortDirection sortDirection, string sortField)
        {
            //if (string.IsNullOrEmpty(sortField))
            //    return itemDao.FindAllSorted(sortDirection, "Name");
            //return itemDao.FindAllSorted(sortDirection, sortField);
            return itemDao.FindAll();
        }

        public Order GetCurrentOrder()
        {
            if (this.IdParameter != -1)
            {
                Order order = orderDao.FindById(IdParameter);
                if (orderService.UserCanViewOrder(order, CurrentUser))
                {
                    return order;
                }
            }
            return null;
        }

        //public void UpdateOrder()
        //{
        //    Order order = GetCurrentOrder();
        //    order.IsRead = View.OrderDto.IsRead;

        //    // если заказ уже отправлен то количество в строке заказа не может изменяться
        //    if (!order.IsSent)
        //    {
        //        order.Items.Clear();
        //        foreach (OrderItemDto orderItemDto in View.OrderDto.Items)
        //        {
        //            NullReferenceException here:
        //            OrderItem orderItem = orderItemDao.FindById(orderItemDto.OrderItemId);
        //            orderItem.N = orderItemDto.N;
        //            order.Items.Add(orderItem);
        //        }
        //        order.Comment = View.Comment;
        //    }

        //    orderDao.Save(order);
        //}
    }
}
