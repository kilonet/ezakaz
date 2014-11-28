using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;

namespace EZakaz.Dao
{
    public interface ICategoryDao: IDao<Category, int>
    {
        Category FindByNumber(int number);
    }
}
