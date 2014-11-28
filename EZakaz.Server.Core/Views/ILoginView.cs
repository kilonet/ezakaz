using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Server.Core.Views
{
    public interface ILoginView: IView
    {
        string Password { get; }
        string UserLogin { get; }
        void ShowFailureMessage();
    }
}
