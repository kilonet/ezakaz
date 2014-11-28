using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Domain.Dto
{
    [Serializable]
    public class OrderItemDto
    {
        public int N;
        public int OrderItemId;


        public OrderItemDto(int n, int orderItemId)
        {
            N = n;
            OrderItemId = orderItemId;
        }
    }
}
