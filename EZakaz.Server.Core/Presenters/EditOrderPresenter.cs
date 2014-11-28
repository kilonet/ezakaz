using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using EZakaz.Common;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Domain.Dto;
using EZakaz.Server.Core.Services;
using EZakaz.Server.Core.Views;
using EZakaz.Server.Core.Web;

namespace EZakaz.Server.Core.Presenters
{
    public class EditOrderPresenter : AbstractPresenter<IEditOrderView>
    {
        private IOrderDao orderDao = Repository.Default.Resolve<IOrderDao>();
        private IOrderItemDao orderItemDao = Repository.Default.Resolve<IOrderItemDao>();
        private OrderService orderService;
        private MailService mailService = Repository.Default.Resolve<MailService>();
      


    	

        public OrderService OrderService
        {
            set { orderService = value; }
        }

        public override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            View.IsAdminView = CurrentUser.IsAdmin;

            Order order = GetCurrentOrder();
            if (order != null)
            {
                View.OrderItems = new List<OrderItem>(order.Items);
                View.IsRead = order.IsRead;
                
                View.OrderCreatedDate = order.DateCreated;
                View.OrderSentDate = order.DateSent;
                
                View.IsBtnSaveVisible = View.IsBtnDeleteVisible = View.IsBtnSendVisible = !order.IsSent;
                View.Comment = order.Comment;
                return;   
            }
            
            HttpContext.Current.Response.Redirect("~/Orders.aspx");
        }

        public Order GetCurrentOrder()
        {
            if (Request.QueryString["id"] != null)
            {
                int orderId;
                if (int.TryParse(Request.QueryString["id"], out orderId))
                {
                    Order order = orderDao.FindById(orderId);
                    if (orderService.UserCanViewOrder(order, CurrentUser))
                        return order;
                }
            }
            return null;
        }

        public void SendOrder()
        {
            UpdateOrderFromView();
            orderService.SendOrder(GetCurrentOrder());
            mailService.NotifyAllAdmins(GetCurrentOrder());
            View.ShowSuccesMessage();
        }

        public void DeleteOrder()
        {
            orderService.DeleteOrder(GetCurrentOrder());
            Response.Redirect("~/Orders.aspx");
        }

        public void UpdateOrderFromView()
        {
            Order order = GetCurrentOrder();
            order.IsRead = View.OrderDto.IsRead;
            
            // если заказ уже отправлен то количество в строке заказа не может изменяться
            if (!order.IsSent)
            {
                order.Items.Clear();
                foreach (OrderItemDto orderItemDto in View.OrderDto.Items)
                {
                    OrderItem orderItem = orderItemDao.FindById(orderItemDto.OrderItemId);
                    orderItem.N = orderItemDto.N;
                    order.Items.Add(orderItem);
                }
                order.Comment = View.Comment;
            }
            
            orderDao.Save(order);
        }

        
    }
}
