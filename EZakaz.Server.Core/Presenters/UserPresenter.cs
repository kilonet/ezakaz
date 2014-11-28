using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
    public class UserPresenter: AbstractPresenter<IUserView>
    {
        private IUserDao userDao;
        
        public override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
			if (!View.IsPostBack)
			{
				User user = GetUserByIdParam();
				if (user == null)
				{
					Response.Redirect("~/Users.aspx");
					return;
				}
				
				View.CurrentUser = user;
				View.IsAdminView = CurrentUser.IsAdmin;
			}
        }

        public User GetUserByIdParam()
        {
            int id = IdParameter;
            if (id != -1)
            {
                return userDao.FindById(id);
            }
            return null;
        }


        public IUserDao UserDao
        {
            set { userDao = value; }
        }

        public void UpdateFromView()
        {
            User user = GetUserByIdParam();
            user.IsActive = View.Active;
            user.Role = View.Role;
            user.PriceType = View.PriceType;
            user.AccessId = View.ClientId;
            userDao.Save(user);
        }

    	public void AcceptUser()
    	{
    		User user = GetUserByIdParam();
    		user.IsActive = true;
    		user.IsNew = false;
    		userDao.Save(user);

    		View.IsAdminView = CurrentUser.IsAdmin;
    		View.CurrentUser = GetUserByIdParam();
    	}

    	public void CancelUser()
    	{
    		User user = GetUserByIdParam();
    		user.IsNew = false;
    		userDao.Save(user);

			View.IsAdminView = CurrentUser.IsAdmin;
			View.CurrentUser = GetUserByIdParam();
    	}
    }
}
