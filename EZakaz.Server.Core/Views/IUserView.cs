using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;

namespace EZakaz.Server.Core.Views
{
    public interface IUserView: IView
    {
        User CurrentUser { set; }

        bool IsAdminView { set; }
        
        Role Role { get; }
        bool Active { get; }

        PriceType PriceType { get; }
        int ClientId { get; }
    }
}
