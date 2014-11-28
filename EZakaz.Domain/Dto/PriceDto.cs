using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Domain.Dto
{
    public class PriceDto
    {
        private DateTime dateTime = DateTime.Now;
        private ItemDto[] items;
        private string[] categories;

        public DateTime DateTime
        {
            get { return dateTime; }
        }


        public PriceDto()
        {
        }

        public PriceDto(ItemDto[] items, string[] categories)
        {
            this.items = items;
            this.categories = categories;
        }

        public ItemDto[] Items
        {
            get { return items; }
            set { items = value; }
        }


        public string[] Categories
        {
            get { return categories; }
            set { categories = value; }
        }
    }
}
