using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;
using EZakaz.Domain.Dto;

namespace EZakaz.Server.Core.Views
{
    public interface IItemsView: IView
    {
		bool IsAdminView { set; }
        Dictionary<int, int> QuantityByItemId { get; }
        string Comment { get; }
        //OrderDto OrderDto { get; }
        //string Comment { get; }
    }
}
