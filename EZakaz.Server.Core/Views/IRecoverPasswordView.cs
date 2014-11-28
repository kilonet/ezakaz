using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Server.Core.Views
{
    public interface IRecoverPasswordView: IView
    {
        string Email { get; }

        string Login { get; }

        void SetResult(string p);
    }
}
