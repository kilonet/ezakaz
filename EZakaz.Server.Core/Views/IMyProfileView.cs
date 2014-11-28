using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;

namespace EZakaz.Server.Core.Views
{
    public interface IMyProfileView: IView
    {
        User DisplayedUser { set; }
        string Name { get; }
        string Email { get; }
        string Adres { get; }
        string Phone { get; }
        string Contact { get; }
        string Login { set; }
    }
}
