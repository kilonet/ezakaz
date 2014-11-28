using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZakaz.Server.Core.Services;
using EZakaz.Server.Core.Views;

namespace EZakaz.Server.Core.Presenters
{
    public class MainPresenter: AbstractPresenter<IMainView>
    {
        public override void OnPreRender(EventArgs e)
        {
            View.NewsContents = NewsService.GetNewsContent();
        }
    }
}
