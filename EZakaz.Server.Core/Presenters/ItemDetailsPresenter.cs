using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
    public class ItemDetailsPresenter: AbstractPresenter<IItemDetailsView>
    {
        private IItemDao itemDao;
        private IItemInfoDao itemInfoDao;

        public IItemInfoDao ItemInfoDao
        {
            set { itemInfoDao = value; }
        }

        public IItemDao ItemDao
        {
            set { itemDao = value; }
        }

        public ItemInfo GetItemInfo()
        {
            return itemInfoDao.FindById(itemDao.FindById(IdParameter).ProductId);
            //return itemDao.FindById(IdParameter).ItemInfo;
        }
    }
}
