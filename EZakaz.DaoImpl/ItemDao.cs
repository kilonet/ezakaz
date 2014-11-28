using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;
using NHibernate.Criterion;
using Order=NHibernate.Criterion.Order;

namespace EZakaz.DaoImpl
{
    public class ItemDao: AbstractNHibernateDao<Item, int>, IItemDao
    {
    	#region IItemDao Members

    	public int ItemsInCategory(Category category)
    	{
    		return CreateCriteria()
    			.Add(Expression.Eq("Category", category))
    			.SetProjection(Projections.RowCount())
				.UniqueResult<int>();
    	}

    	public IList<Item> FindByCategoryPaged(Category category, int start, int size)
    	{
    		return CreateCriteria()
    			.Add(Expression.Eq("Category", category))
    			.SetFirstResult(start)
    			.SetMaxResults(size)
    			.List<Item>();
    	}

    	#endregion

        public override List<Item> FindAll()
        {
            return new List<Item>(CreateCriteria()
                .CreateAlias("Category", "c")
                .AddOrder(Order.Asc("c.Name"))
                .AddOrder(Order.Asc("Name"))
                .List<Item>()); 
        }
    }
}
