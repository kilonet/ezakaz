using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core.Views;
using System.Web.UI.WebControls;

namespace EZakaz.Server.Core.Presenters
{
    public class UsersPresenter: AbstractPresenter<IUsersView>
    {
        private IUserDao userDao;
        
        public int GetUsersCount()
        {
            return userDao.GetTotalRecordCount();
        }

        public IEnumerable<User> GetUsersPaged(int start, int size, SortDirection sortDirection, string sortField)
        {
            if (string.IsNullOrEmpty(sortField))
                return userDao.FindAllPagedSorted(start, size, sortDirection, "Name");
            return userDao.FindAllPagedSorted(start, size, sortDirection, sortField);
        }


        public IUserDao UserDao
        {
            set { userDao = value; }
        }

        public void DeleteUser(int userId)
        {
            User user = userDao.FindById(userId);
            if (user.IsAdmin)
            {
                if (userDao.GetAdminCount() == 1)
                    return;
            }
            userDao.Delete(user);
        }
    }
}
