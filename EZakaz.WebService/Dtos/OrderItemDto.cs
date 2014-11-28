using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EZakaz.Domain;

namespace EZakaz.WebService.Dtos
{
    public class OrderItemDto
    {
        private string name;
        private decimal price;
        private int? receiptId;
        private int productId;
        private int count;
        private int id;
        //private int clientId;
        //private string clientName;

        public OrderItemDto(OrderItem item)
        {
            name = item.Name;
            price = item.Price;
            receiptId = item.ReceiptId;
            productId = item.ProductId;
            count = item.N;
            id = item.Id;
        }

        public OrderItemDto()
        {
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int? ReceiptId
        {
            get { return receiptId; }
            set { receiptId = value; }
        }

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

    }
}
