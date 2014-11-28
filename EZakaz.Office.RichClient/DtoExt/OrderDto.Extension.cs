using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Office.RichClient.EZakaz.WS
{
    public partial class OrderDto
    {
        public override string ToString()
        {
            return string.Format("Заказ от {0} для {1}", 
                DateSent.ToShortDateString() + " " + DateSent.ToShortTimeString(),
                ClientName);
        }
    }
}
