using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core.Security;
using EZakaz.Server.Core.Services;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
    public class LoginPresenter: AbstractPresenter<ILoginView>
    {
    	private IUserDao userDao = Repository.Default.Resolve<IUserDao>();

        public void Login()
        {
            if (!View.IsValid)
                return;

            if (UserManagment.ValidateUser(View.UserLogin, View.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(View.UserLogin, true);
            	NewsService.SetShowNewsMode(true);
            	
            }
            else
            {
                View.ShowFailureMessage(); 
            }
        }

        public void CreateAdmin()
        {
            if (UserManagment.AdminCount() == 0)
            {
                UserManagment.RegisterUser("admin", "123", "Default name", "kilonet@nm.ru", "ул. Садовая, д. 12", "77-12-12",
                                           "Bill McCafferty", Role.Admin, true, PriceType.Price1, false, 0);

            }
        }
    }
}
