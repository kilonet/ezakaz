using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Office.RichClient.EZakaz.WS
{
    public partial class OrderDto
    {
        public override string ToString()
        {
            return string.Format("����� �� {0} ��� {1}", 
                DateSent.ToShortDateString() + " " + DateSent.ToShortTimeString(),
                ClientName);
        }
    }
}
