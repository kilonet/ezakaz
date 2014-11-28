using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;

namespace EZakaz.Server.Core.Views
{
    public interface IOrdersView: IView
    {
        bool IsAdminView { set; }
        IEnumerable<int> SelectedOrdersIds { get; }
    }
}
