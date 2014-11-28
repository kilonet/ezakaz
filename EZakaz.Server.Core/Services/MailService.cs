using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using EZakaz.Dao;
using EZakaz.Domain;

namespace EZakaz.Server.Core.Services
{
    public class MailService
    {
        private IUserDao userDao = Repository.Default.Resolve<IUserDao>();

        public void SendMail(string recepientAdres, string subject, string body)
        {

            Thread thread = new Thread(SendMailInternal);
            thread.Start(new SendArgs {Body = body, RecepientAddress = recepientAdres, Subject = subject});
        }
        
        private void SendMailInternal(object o)
        {
            SendArgs args = (SendArgs) o ;
            MailMessage message = new MailMessage();
            message.From = new MailAddress(ConfigurationManager.AppSettings["FromEmailAdres"], "Сайт заказов ИП Покревского");
            message.To.Add(new MailAddress(args.RecepientAddress));

            message.IsBodyHtml = false;
            message.Subject = args.Subject;
            message.Body = args.Body;

            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["MailLogin"],
                ConfigurationManager.AppSettings["MailPassword"]);

            try
            {
                smtp.Send(message);
            }
            catch{}
        }

        public void NotifyAllAdmins(Order order)
        {
            IList<User> admins = userDao.FindAllAdmins();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Пользователь {0} отправил новый заказ {1}{2}", order.User.Name, Environment.NewLine, HttpContext.Current.Request.Url));
            sb.AppendLine(string.Format("Сумма: {0:C}", order.GetPrice()));
            foreach (OrderItem item in order.Items)
            {
                sb.AppendLine(item.Name + " x " + item.N);
            }
            sb.AppendLine("Примечание: " + order.Comment);
            foreach (User user in admins)
            {
                SendMail(user.Email, "Система электронных заказов - новый заказ", sb.ToString());
            }
        }
    }

    class SendArgs
    {
        public string Body { get; set;}
        public string RecepientAddress { get; set; }
        public string Subject { get; set; }
    }

}
