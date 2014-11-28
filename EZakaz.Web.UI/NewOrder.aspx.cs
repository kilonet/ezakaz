using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EZakaz.Domain;
using EZakaz.Server.Core;
using EZakaz.Server.Core.Presenters;
using EZakaz.Server.Core.Views;

namespace EZakaz.Web.UI
{
	public partial class NewOrder : AbstractPage<NewOrderPresenter>, INewOrderView
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected override string PageTitle
        {
            get { return ""; }
        }

		#region INewOrderView Members

		public IList<Category> Categories
		{
			set
			{
				foreach (Category category in value)
				{
					TableRow row = new TableRow();
					TableCell cell = new TableCell();
				    cell.Text = string.Format("<a href='javascript:sitePopup({0})'>{1}</a>", category.Id, category.Name);
					row.Cells.Add(cell);
					Table1.Rows.Add(row);
				}
			}
		}

		#endregion
	}
}
