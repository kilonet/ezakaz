using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using EZakaz.Dao;
using EZakaz.Domain;
using NHibernate.Criterion;

namespace EZakaz.DaoImpl
{
    public class CategoryDao: AbstractNHibernateDao<Category, int>, ICategoryDao
    {
        public Category FindByNumber(int number)
        {
            return CreateCriteria()
                .Add(Restrictions.Eq("Number", number))
                .UniqueResult<Category>();
        }

    	public override List<Category> FindAll()
    	{
			return FindAllSorted(SortDirection.Ascending, "Name") as List<Category>;
    	}
    }
}
