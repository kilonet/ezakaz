using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;

namespace EZakaz.Dao
{
    public interface IItemDao: IDao<Item, int>
    {
    	IList<Item> FindByCategoryPaged(Category category, int start, int size);
    	int ItemsInCategory(Category category);

        
    }
}
