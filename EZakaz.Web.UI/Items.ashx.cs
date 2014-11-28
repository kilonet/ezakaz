using System;
using System.Data;
using System.Text;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.UI.WebControls;
using EZakaz.Dao;
using EZakaz.Domain;
using System.Collections.Generic;
using EZakaz.Server.Core;

namespace EZakaz.Web.UI
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Handler1 : IHttpHandler
    {
        private IItemDao itemDao = Repository.Default.Resolve<IItemDao>();
        public void ProcessRequest(HttpContext context)
        {
            string sortField = context.Request.Params["sidx"];
            SortDirection sortDirection = context.Request.Params["sord"] == "desc" ? SortDirection.Descending : SortDirection.Ascending;
            int pageIndex = Convert.ToInt32(context.Request.Params["page"]) - 1;
            int pageSize = Convert.ToInt32(context.Request.Params["rows"]);
            int totalRecords = itemDao.GetTotalRecordCount();
            IEnumerable<Item> items =
                itemDao.FindAllPagedSorted(pageIndex * pageSize, pageSize, sortDirection, sortField);

            StringBuilder sb = new StringBuilder("{");
            
            sb.Append(string.Format("\"page\": {0},", pageIndex + 1));
            sb.Append(string.Format("\"total\": {0},", (int)Math.Ceiling((float)totalRecords / (float)pageSize)));
            sb.Append(string.Format("\"records\": {0},", totalRecords));
            sb.Append(string.Format("\"rows\":["));
            foreach (Item item in items)
            {//'Наименование','Остаток','Заказ','Производитель','Упаковка','Срок годности','Цена 1','Цена 2','Цена 3'],
                sb.Append("{" + string.Format("\"i\": \"{0}\", \"cell\":[\"{1}\", \"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\"]", 
                    item.Id, item.Name.Replace("\"", "\\\""), item.Rest, item.Manufacter.Replace("\"", "\\\""), item.Pack, item.Date, item.Price1, item.Price2, item.Price3)+ "},");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]}");
            context.Response.ContentType = "application/json";
            context.Response.Write(sb.ToString());
            //, text/javascript, */*
            
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
