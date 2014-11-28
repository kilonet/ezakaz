using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Domain.Dto
{
    [Serializable]
    public class OrderDto
    {
        public List<OrderItemDto> Items;
        public bool IsRead ;
        
        public OrderDto(bool isRead, List<OrderItemDto> items)
        {
            IsRead = isRead;
            Items = items;
        }
    }
}
