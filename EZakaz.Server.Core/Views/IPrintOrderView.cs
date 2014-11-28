using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZakaz.Domain;

namespace EZakaz.Server.Core.Views
{
    public interface IPrintOrderView: IView
    {
        Order Order { set; }
    }
}
