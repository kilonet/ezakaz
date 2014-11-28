using System;
using System.Collections.Generic;
using EZakaz.Domain;

namespace EZakaz.WebService.Dtos
{
    public class OrderDto
    {
        private int id;
        private DateTime dateSent;
        private string clientName;
        private int clientId;
        //private OrderItemDto[] orderItems;
        
        public DateTime DateSent
        {
            get { return dateSent; }
            set { dateSent = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }

        //public OrderItemDto[] OrderItems
        //{
        //    get { return orderItems; }
        //    set { orderItems = value; }
        //}


        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }

        public OrderDto()
        {
        }

        public OrderDto(Order order)
        {
            if (order.DateSent.HasValue)
                dateSent = order.DateSent.Value;
            clientName = order.User.Name;
            clientId = order.User.AccessId;
            id = order.Id;
            //List<OrderItemDto> dtosList = new List<OrderItemDto>(order.Items.Count);
            //foreach (OrderItem item in order.Items)
            //{
            //    dtosList.Add(new OrderItemDto(item, order.User));
            //}
            //orderItems = dtosList.ToArray();
        }
    }
}
