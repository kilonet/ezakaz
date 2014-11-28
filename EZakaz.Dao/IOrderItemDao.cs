using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;

namespace EZakaz.Dao
{
    public interface IOrderItemDao: IDao<OrderItem, int>
    {
        //IList<OrderItem> FindByOrder(Order order);
    }
}
