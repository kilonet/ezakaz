using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;

namespace EZakaz.Server.Core.Views
{
    public interface ICreateUserView: IView
    {
        string Login { get; }

        string Name { get; }

        string Email { get; }

        string Adres { get; }

        string Phone { get; }

        string Contact { get; }

        Role Role { get; }

        PriceType PriceType { get; }

        int AccessId { get; }
        string Password { get; }
    }
}
