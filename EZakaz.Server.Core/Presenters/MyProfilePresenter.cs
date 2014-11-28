using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
    public class MyProfilePresenter : AbstractPresenter<IMyProfileView>
    {
        private IUserDao userDao;
        
        public override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            View.Login = CurrentUser.Login;
            if (!View.IsPostBack)
            {
                View.DisplayedUser = CurrentUser;
            }
        }

        public void UpdateFromView()
        {
            User user = CurrentUser;
            user.Address = View.Adres;
            user.ContactName = View.Contact;
            user.Email = View.Email;
            user.Name = View.Name;
            user.Phone = View.Phone;
            userDao.Save(user);
        }


        public IUserDao UserDao
        {
            set { userDao = value; }
        }
    }
}
