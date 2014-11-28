using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Domain
{
    public class ItemInfo: DomainObject<int>
    {
        public virtual string Image { get; set; }
        public virtual string SmallImage { get; set; }
        public virtual string Description { get; set; }
        public virtual int ProductId { get; set; }
    }
}

