using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;

namespace EZakaz.DaoImpl
{
    public class ItemInfoDao : AbstractNHibernateDao<ItemInfo, int>, IItemInfoDao
    {
    }
}
