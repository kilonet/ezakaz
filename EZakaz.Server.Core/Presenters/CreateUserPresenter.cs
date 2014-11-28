using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using EZakaz.Domain;
using EZakaz.Server.Core.Security;
using EZakaz.Server.Core.Services;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
    public class CreateUserPresenter : AbstractPresenter<ICreateUserView>
    {
        
        MailService mailService = new MailService();

        public User CreateUser()
        {
            if (!View.IsValid)
                return null;
            string password = View.Password;//UserManagment.GenPassword();
            User createdUser = UserManagment.RegisterUser(View.Login, password, View.Name, View.Email, View.Adres,
                                                          View.Phone, View.Contact, View.Role, true, View.PriceType,
                                                          false, View.AccessId);
            if (createdUser != null)
            {
                string text = "Уважаемый пользователь!" + Environment.NewLine + Environment.NewLine;
                text += "Вы были зарегистрированы на сайте электронных заказов ИП Покревского, расположенного по адресу: http://zakaz.1gb.ru/";
                text += Environment.NewLine;
                text += Environment.NewLine;
                text += "Для доступа к сайту используйте следующие данные: ";
                text += Environment.NewLine;
                text += string.Format("Логин: {0}{1}Пароль:{2}", View.Login, Environment.NewLine, password);
                mailService.SendMail(createdUser.Email, "Регистрация", text);

                return createdUser;
            }
            return null;
        }
    }
}
