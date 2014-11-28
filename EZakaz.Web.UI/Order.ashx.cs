using System;
using System.Data;
using System.Net;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using EZakaz.Dao;
using EZakaz.Server.Core;
using EZakaz.Server.Core.Services;
using EZakaz.Server.Core.Web;

namespace EZakaz.Web.UI
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Order : IHttpHandler
    {
        private IOrderDao orderDao = Repository.Default.Resolve<IOrderDao>();
        private IUserContext userContext = Repository.Default.Resolve<IUserContext>();
        private OrderService orderService = new OrderService();

        public void ProcessRequest(HttpContext context)
        {
            int orderId = Convert.ToInt32(context.Request["id"]);
            Domain.Order order = orderDao.FindById(orderId);
            Domain.User currentUser = userContext.CurentUser;
            if (!currentUser.IsAdmin && !currentUser.IsStaff)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Response.End();
                return;
            }

            WebUtils.SendFileContent(context, orderService.ToStream(order), "Zakaz.csv");

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
