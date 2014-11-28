using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;

namespace EZakaz.Server.Core.Services
{
    public class OrderService
    {
        private IOrderDao orderDao = Repository.Default.Resolve<IOrderDao>();

        public bool UserCanViewOrder(Order order, User user)
        {
            return (user.IsAdmin && order.State != OrderState.Draft) || order.User.Equals(user);
        }

        internal void SendOrder(Order order)
        {
            order.State = OrderState.Sent;
            order.DateSent = DateTime.Now;
            orderDao.Save(order);
        }

        public void DeleteOrder(Order order)
        {
            orderDao.Delete(order);
        }

        public Stream ToStream(Order order)
        {
            StringBuilder sb = new StringBuilder("НомерСтроки;НаимТовара;Количество;Цена;Сумма;КодКлиента;КодТовара;КодСтрокПрихода;Дата;НаимКлиента;Примечание" + Environment.NewLine); 
            
            int n = 0;
            foreach (OrderItem item in order.Items)
            {
                sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}",
                    ++n,
                    item.Name,
                    item.N,
                    item.Price,
                    item.Price * item.N,
                    order.User.AccessId,
                    item.ProductId,
                    item.ReceiptId,
                    DateTime.Now.ToShortDateString(),
                    order.User.Name,
                    ""));
            }
            return new MemoryStream(Encoding.Default.GetBytes(sb.ToString()));
        }
    }
}
