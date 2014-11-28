using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Dao;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
	public class NewOrderPresenter: AbstractPresenter<INewOrderView>
	{
		private IItemDao itemDao = Repository.Default.Resolve<IItemDao>();
	    private ICategoryDao categoryDao = Repository.Default.Resolve<ICategoryDao>();
		
		public override void OnPreRender(EventArgs e)
		{
			View.Categories = categoryDao.FindAll();
		}
	}
}
