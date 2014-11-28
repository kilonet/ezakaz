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
                "Сообщение от пользователя сайта EZakaz",
                string.Format(
                    "пользователь {0} ({1}) пишет: {2}{3}",
                    user == null ? "Неизвестный пользователь" : user.Login,
					user == null ? "" : user.Name,
                    Environment.NewLine,
                    View.MessageText)
                );
            View.ShowSuccesMessage();
        }
    }
}
