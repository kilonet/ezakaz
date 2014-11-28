using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Domain
{
    public class OrderItem: DomainObject<int>
	{
        private int n;
        private Order order;
        private int itemId;
        private string name;
        private decimal price;
        // for skald_be
        private int productId;
        private int? receiptId;


        public OrderItem()
        {
        }

        public OrderItem(int n, Item item, PriceType priceType, Order order)
        {
            this.n = n;

            name = item.Name;
            price = item.GetPrice(priceType);
            productId = item.ProductId;
            receiptId = item.ReceiptId;
            itemId = item.Id;
            this.order = order;
        }

        public virtual Order Order
        {
            get { return order; }
            set { order = value; }
        }

        //public virtual int ItemId
        //{
        //    get { return itemId; }
        //    set { itemId = value; }
        //}

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual decimal Price
        { 
            get { return price; }
            set { price = value; }
        }

        public virtual int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public virtual int? ReceiptId
        {
            get { return receiptId; }
            set { receiptId = value; }
        }

        //public virtual Order Order
        //{
        //    get { return order; }
        //    set { order = value; }
        //}

        public virtual int N
        {
            get { return n; }
            set { n = value; }
        }

        

        //public override int GetHashCode()
        //{
        //    throw new NotImplementedException();
        //}
	}
}
