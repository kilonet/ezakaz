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
                string text = "��������� ������������!" + Environment.NewLine + Environment.NewLine;
                text += "�� ���� ���������������� �� ����� ����������� ������� �� �����������, �������������� �� ������: http://zakaz.1gb.ru/";
                text += Environment.NewLine;
                text += Environment.NewLine;
                text += "��� ������� � ����� ����������� ��������� ������: ";
                text += Environment.NewLine;
                text += string.Format("�����: {0}{1}������:{2}", View.Login, Environment.NewLine, password);
                mailService.SendMail(createdUser.Email, "�����������", text);

                return createdUser;
            }
            return null;
        }
    }
}
