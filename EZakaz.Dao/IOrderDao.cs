using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using EZakaz.Domain;

namespace EZakaz.Dao
{
    public interface IOrderDao: IDao<Order, int>
    {
        IList<Order> FindByUserPaged(User user, int start, int size, SortDirection sortDirection, string sortField);
        int UserOrdersCount(User user);
        int UnreadOrdersCount();
        int GetAdminTotalRecordCount();
        IList<Order> FindAllAdminPaged(int start, int size, SortDirection sortDirection, string sortField);
        IList<Order> FindAllAdmin();
    }
}
