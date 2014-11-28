using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.RichClient.localhost;

namespace EZakaz.RichClient.Model
{
    [Serializable]
    public class Order
    {
        private List<ItemDto> items;
        private DateTime date = DateTime.Now;
        private bool isSent = false;


        public Order(List<ItemDto> items)
        {
            this.items = items;
        }

        public List<ItemDto> Items
        {
            get { return items; }
            set { items = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public bool IsSent
        {
            get { return isSent; }
            set { isSent = value; }
        }
    }
}
