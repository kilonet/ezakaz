using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using EZakaz.Dao;
using EZakaz.Server.Core;

namespace EZakaz.Web.UI
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetItemInfo : IHttpHandler
    {
        private IItemInfoDao itemInfoDao = Repository.Default.Resolve<IItemInfoDao>();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int infoId = Convert.ToInt32(context.Request["id"]);
            Domain.ItemInfo itemInfo = itemInfoDao.FindById(infoId);
            string s = "";
            s += "<table><tr><td style=\"padding-right: 5px; vertical-align: top;\">";
            if (!string.IsNullOrEmpty(itemInfo.Image))
            {
                s += string.Format("<a href=\"/uploads/{0}\" class=\"lightbox\">", itemInfo.Image);
                s += string.Format("<img style=\"border: 0px;\" src=\"uploads/{0}\">", itemInfo.SmallImage);
                s += "<a />";
            
            }
            if (!string.IsNullOrEmpty(itemInfo.Description))
            {
                s += string.Format("</td><td>{0}</td></tr></table>", itemInfo.Description);    
            }
            else
            {
                s += "</td></tr></table>"; 
            }

            context.Response.Write(s);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
