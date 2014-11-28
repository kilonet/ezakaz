using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;
using NHibernate.Criterion;
using Order=EZakaz.Domain.Order;

namespace EZakaz.DaoImpl
{
    public class OrderItemDao : AbstractNHibernateDao<OrderItem, int>, IOrderItemDao
    {
        public IList<OrderItem> FindByOrder(Order order)
        {
            return CreateCriteria()
                .Add(Expression.Eq("Order", order))
                .AddOrder(NHibernate.Criterion.Order.Asc("Name"))
                .List<OrderItem>();
            
        }
    }
}
