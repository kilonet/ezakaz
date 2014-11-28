using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.RichClient.localhost
{
    public partial class OrderItemDto
    {
        public OrderItemDto(int idField, string nameField, decimal priceField, int? receiptIdField, int productIdField, int countField)
        {
            this.idField = idField;
            this.nameField = nameField;
            this.priceField = priceField;
            this.receiptIdField = receiptIdField;
            this.productIdField = productIdField;
            this.countField = countField;
        }


        public OrderItemDto()
        {
        }
    }
}
