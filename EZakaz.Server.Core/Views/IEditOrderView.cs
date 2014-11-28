using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;
using EZakaz.Domain.Dto;
using Iesi.Collections.Generic;

namespace EZakaz.Server.Core.Views
{
    public interface IEditOrderView: IView
    {
        OrderDto OrderDto { get;}
        IList<OrderItem> OrderItems { set; }
        bool IsAdminView { set; get; }
        bool IsRead { set; }
        bool IsBtnSaveVisible { set; }
        bool IsBtnSendVisible { set; }
        bool IsBtnDeleteVisible { set; }

        decimal OrderPrice { set; }
        DateTime? OrderSentDate { set; }
        DateTime OrderCreatedDate { set; }

        string Comment { get; set; }

        void ShowSuccesMessage();
    }
}
