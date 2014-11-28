using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using EZakaz.Domain;
using EZakaz.Server.Core.Services;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
    public class FeedbackPresenter : AbstractPresenter<IFeedbackView>
    {
        MailService mailService = new MailService();

        public void SendMessage()
        {
        	User user = CurrentUser;

			mailService.SendMail(
                ConfigurationManager.AppSettings["MyEmail"], 
                "��������� �� ������������ ����� EZakaz",
                string.Format(
                    "������������ {0} ({1}) �����: {2}{3}",
                    user == null ? "����������� ������������" : user.Login,
					user == null ? "" : user.Name,
                    Environment.NewLine,
                    View.MessageText)
                );
            View.ShowSuccesMessage();
        }
    }
}
