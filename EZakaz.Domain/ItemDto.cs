using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Domain.Dto
{
    public class ItemDto
    {
        public int Id;
        public string Name;
        public decimal Price;
        //public decimal Price2;
        //public decimal Price3;
        public int? Rest;
        public string Manufacter;
        public string Pack;
        public string Category;
        public DateTime? Date;
        //TODO ?
        public int? ReceiptId;
        public int ProductId;


        public ItemDto()
        {
        }

        public ItemDto(Item item, PriceType priceType)
        {
            Id = item.Id;
            Name = item.Name;
            Price = item.GetPrice(priceType);
            Rest = item.Rest;
            Manufacter = item.Manufacter;
            Pack = item.Pack;
            Category = item.Category.Name;
            Date = item.Date;
            ReceiptId = item.ReceiptId;
            ProductId = item.ProductId;
        }
    }
}
