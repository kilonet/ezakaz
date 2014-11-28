using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core.Security;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
    public class ChangePasswordPresenter : AbstractPresenter<IChangePasswordView>
    {
        private IUserDao userDao;


        public IUserDao UserDao
        {
            set { userDao = value; }
        }

        public void ChangePassword()
        {
            if (View.OldPassword == View.NewPassword)
            {
                View.SetResult("Ошибка: старый и новый пароли совпадают");
                return;
            }

            if (EZakaz.Common.Array.Equals(
                UserManagment.CalculatePasswordHash(View.OldPassword),
                CurrentUser.PasswordHash))
            {
                User user = CurrentUser;
                user.PasswordHash = UserManagment.CalculatePasswordHash(View.NewPassword);
                userDao.Save(user);
                View.SetResult("Пароль изменён");
                return;
            }

            View.SetResult("Ошибка: неправильно введен старый пароль");
        }
    }
}
