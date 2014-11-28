using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Server.Core.Views
{
    public interface IChangePasswordView: IView
    {
        string OldPassword { get; }

        string NewPassword { get; }

        void SetResult(string p);
    }
}
