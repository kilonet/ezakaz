using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using EZakaz.Dao;
using EZakaz.DaoImpl;
using EZakaz.Domain;
using EZakaz.Domain.Dto;
using EZakaz.Server.Core;
using System.Collections.Generic;
using NHibernate;
using OrderDto=EZakaz.WebService.Dtos.OrderDto;
using OrderItemDto=EZakaz.WebService.Dtos.OrderItemDto;

namespace EZakaz.WebService
{
	/// <summary>
	/// Summary description for BaceWebService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
    [ScriptService]
	public class BaseWebService : System.Web.Services.WebService
	{
        IItemDao itemDao = Repository.Default.Resolve<IItemDao>();
	    private IOrderDao orderDao = Repository.Default.Resolve<IOrderDao>();
	    private IOrderItemDao orderItemDao = Repository.Default.Resolve<IOrderItemDao>();
	    private IUserDao userDao = Repository.Default.Resolve<IUserDao>();
	    private ICategoryDao categoryDao = Repository.Default.Resolve<ICategoryDao>();

        [WebMethod]
        public PriceDto GetPrice(string userName)
        {
            User user = userDao.FindByLogin(userName);
            IList<Item> items = itemDao.FindAll();
            ItemDto[] dtos = new ItemDto[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                dtos[i] = new ItemDto(items[i], user.PriceType);
            }
            List<string> catNames = new List<string>();
            foreach (Category category in categoryDao.FindAll())
            {
                catNames.Add(category.Name);
            }
            return new PriceDto(dtos, catNames.ToArray());
        }

        [WebMethod]
        public OrderDto[] GetOrdersList()
        {
            IList<Order> orders = orderDao.FindAllAdmin();
            List<OrderDto> dtos = new List<OrderDto>(orders.Count);
            foreach (Order order in orders)
            {
                dtos.Add(new OrderDto(order));
            }
            return dtos.ToArray();
        }

        [WebMethod]
        public OrderItemDto[] GetOrderItems(int orderId)
        {
            Order order = orderDao.FindById(orderId);
            List<OrderItem> items = new List<OrderItem>(order.Items);
            List<OrderItemDto> orderItemDtos = new List<OrderItemDto>(items.Count);
            foreach (OrderItem item in items)
            {
                orderItemDtos.Add(new OrderItemDto(item));
            }
            return orderItemDtos.ToArray();
        }

        [WebMethod]
        public void AddNewOrder(OrderItemDto[] items, string userName)
        {
            using (ISession session = NHibernateSessionManager.Instance.GetSession())
            {
                Order order = new Order();
                User user = userDao.FindByLogin(userName);
                order.User = user;
                orderDao.Save(order);
                foreach (OrderItemDto item in items)
                {
                    order.Items.Add(new OrderItem(item.Count, itemDao.FindById(item.Id), user.PriceType, order));
                }
                order.State = OrderState.Sent;
                order.DateSent = DateTime.Now;
                orderDao.Save(order);
                session.Flush();
            }
        }
	}
}
