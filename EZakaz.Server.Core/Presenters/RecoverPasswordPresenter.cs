using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core.Security;
using EZakaz.Server.Core.Services;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
    public class RecoverPasswordPresenter : AbstractPresenter<IRecoverPasswordView>
    {
        private IUserDao userDao;


        public IUserDao UserDao
        {
            set { userDao = value; }
        }

        public void ResetPassword()
        {
            User user = userDao.FindByLogin(View.Login);
            if (user != null)
            {
                if (View.Email == user.Email)
                {
                    UserManagment.ResetPassword(user);
                    View.SetResult("Пароль сброшен и выслан вам на email");
                    return;
                }
            }
            View.SetResult("Ошибка: пользователя с такими данными не существует");
        }
    }
}
