using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core.Security;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace EZakaz.Web.UI
{

	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			
            log4net.Config.XmlConfigurator.Configure();
            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            if (UserManagment.AdminCount() == 0)
            {
                UserManagment.RegisterUser("admin", "123", "Default name", "kilonet@nm.ru", "ул. Садовая, д. 12", "77-12-12",
                                           "Bill McCafferty", Role.Admin, true, PriceType.Price1, false, 0);

            }
		}

        protected void Session_Start(object sender, EventArgs e) 
        {
 
        }

	}
}