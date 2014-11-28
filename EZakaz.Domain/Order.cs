using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain.Dto;
using Iesi.Collections.Generic;

namespace EZakaz.Domain
{
    public class Order: DomainObject<int>
    {
    	private User user;
    	private OrderState state = OrderState.Draft;
    	private DateTime dateCreated = DateTime.Now;
    	private DateTime? dateSent = null;
    	private string comment ="";
    	private ISet<OrderItem> items = new HashedSet<OrderItem>();
        private bool isRead = false;


        public virtual bool IsRead
        {
            get { return isRead; }
            set { isRead = value; }
        }

        public virtual User User
    	{
    		get { return user; }
    		set { user = value; }
    	}

		public virtual OrderState State
    	{
    		get { return state; }
    		set { state = value; }
    	}

		public virtual DateTime DateCreated
    	{
    		get { return dateCreated; }
    		set { dateCreated = value; }
    	}

		public virtual DateTime? DateSent
    	{
    		get { return dateSent; }
    		set { dateSent = value; }
    	}

		public virtual string Comment
    	{
    		get { return comment; }
    		set { comment = value; }
    	}

		public virtual ISet<OrderItem> Items
    	{
    		get { return items; }
    		set { items = value; }
    	}

        public virtual bool IsSent
        {
            get { return dateSent.HasValue; }
        }

        public virtual decimal GetPrice()
        {
            decimal price = 0;
            foreach (OrderItem orderItem in items)
            {
                price += orderItem.N*orderItem.Price;
            }
            return price;
        }

        //public override int GetHashCode()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
