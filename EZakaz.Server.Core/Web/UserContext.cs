using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using EZakaz.Dao;
using EZakaz.Domain;

namespace EZakaz.Server.Core.Web
{
    public class UserContext: IUserContext
    {
        private IUserDao userDao = Repository.Default.Resolve<IUserDao>();

        public User CurentUser
        {
            get
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                    return userDao.FindByLogin(HttpContext.Current.User.Identity.Name);
                return null;
            }
        }
    }
}
