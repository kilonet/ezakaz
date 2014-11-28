using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using EZakaz.Dao;
using EZakaz.Domain;
using NHibernate;
using NHibernate.Criterion;
using Order=EZakaz.Domain.Order;
using NHibOrder = NHibernate.Criterion.Order;
namespace EZakaz.DaoImpl
{
    public class OrderDao : AbstractNHibernateDao<Order, int>, IOrderDao
    {
        public IList<Order> FindByUser(User user)
        {
            throw new NotImplementedException();
        }


        public IList<Order> FindAllAdmin()
        {
            return CreateCriteria()
                .Add(Expression.Eq("State", OrderState.Sent))
                .AddOrder(NHibOrder.Desc("DateSent"))
                .List<Order>();
        }

        public int GetAdminTotalRecordCount()
        {
            return CreateCriteria()
                .Add(Expression.Eq("State", OrderState.Sent))
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();
        }

        public IList<Order> FindAllAdminPaged(int start, int size, SortDirection sortDirection, string sortField)
        {
            if (string.IsNullOrEmpty(sortField))
            {
                sortDirection = SortDirection.Descending;
                sortField = "DateSent";
            }
                
            ICriteria criteria = CreateCriteria()
                .SetFirstResult(start)
                .SetMaxResults(size)
                .Add(Expression.Eq("State", OrderState.Sent))
                .CreateAlias("User", "user")
                .AddOrder(sortDirection == SortDirection.Ascending ? NHibOrder.Asc(sortField) : NHibOrder.Desc(sortField) );
            return criteria.List<Order>();

            
        }

        public IList<Order> FindByUserPaged(User user, int start, int size, SortDirection sortDirection, string sortField)
        {
            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "DateCreated";
                sortDirection = SortDirection.Descending;
            }
                
            return CreateCriteria()
                .Add(Expression.Eq("User", user))
                //.AddOrder(NHibernate.Criterion.Order.Desc("DateCreated"))
                .SetFirstResult(start)
                .SetMaxResults(size)
                .AddOrder(sortDirection == SortDirection.Ascending ? NHibOrder.Asc(sortField) : NHibOrder.Desc(sortField))
                .List<Order>();
        }

        public int UserOrdersCount(User user)
        {
            return CreateCriteria()
                .Add(Expression.Eq("User", user))
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();
        }


        public int UnreadOrdersCount()
        {
            return CreateCriteria()
                .Add(Expression.Eq("IsRead", false))
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();
        }
    }
}
