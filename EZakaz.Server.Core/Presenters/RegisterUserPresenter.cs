using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;
using EZakaz.Server.Core.Security;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
	public class RegisterUserPresenter : AbstractPresenter<IRegisterUserView>
	{
		public void RegisterUser()
		{
            if (!View.IsValid)
                return;
            if (UserManagment.RegisterUser(View.Login, View.Password, View.Name, View.EMail, View.Address,
                                       View.Phone, View.ContactName, View.Role, false, PriceType.Price1, true, 0) != null)
            {
                View.SetRegisterResult(true, "Пользователь зарегистрирован");
            }
            else
            {
                View.SetRegisterResult(false, "Пользователь с таким логином уже существует. Введите другой логин.");
            }
		}
	}
}
