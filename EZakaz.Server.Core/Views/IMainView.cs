using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZakaz.Server.Core.Views
{
    public interface IMainView: IView
    {
        string NewsContents { set; }
    }
}
