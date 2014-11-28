﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EZakaz.Web.UI
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label label = Master.FindControl("lblTitle") as Label;
            if (label != null) label.Text = "Ошибка";
        }
    }
}
