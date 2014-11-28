using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;

namespace EZakaz.Server.Core.Web
{
    public interface IUserContext
    {
        User CurentUser { get; }
    }
}
