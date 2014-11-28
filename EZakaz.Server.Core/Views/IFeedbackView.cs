using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Server.Core.Views
{
    public interface IFeedbackView: IView
    {
        string MessageText { get; }

        void ShowSuccesMessage();
    }
}
