using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Domain
{
	public class Item: DomainObject<int>
	{
		private string name;
		private decimal price1;
		private decimal price2;
		private decimal price3;
		private int? rest;
		private string manufacter;
		private string pack;
		private Category category;
		private DateTime? date;
		//TODO ?
		private int? receiptId;
	    private int productId;

        public virtual ItemInfo ItemInfo { get; set; }

        public virtual decimal GetPrice(PriceType type)
        {
            if (type == PriceType.Price1)
                return price1;
            if (type == PriceType.Price2)
                return price2;
            return price3;
        }

		public virtual int ProductId
	    {
	        get { return productId; }
	        set { productId = value; }
	    }

	    public virtual string Name
		{
			get { return name; }
			set { name = value; }
		}

		public virtual decimal Price1
		{
			get { return price1; }
			set { price1 = value; }
		}

		public virtual decimal Price2
		{
			get { return price2; }
			set { price2 = value; }
		}

		public virtual decimal Price3
		{
			get { return price3; }
			set { price3 = value; }
		}

		public virtual int? Rest
		{
			get { return rest; }
			set { rest = value; }
		}

		public virtual string Manufacter
		{
			get { return manufacter; }
			set { manufacter = value; }
		}

		public virtual string Pack
		{
			get { return pack; }
			set { pack = value; }
		}

		public virtual Category Category
		{
			get { return category; }
			set { category = value; }
		}

		public virtual DateTime? Date
		{
			get { return date; }
			set { date = value; }
		}

		public virtual int? ReceiptId
		{
			get { return receiptId; }
			set { receiptId = value; }
		}

		// TODO
        public override int GetHashCode()
		{
            return productId;
		}
	}
}
