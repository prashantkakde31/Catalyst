using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class OrderItem
    {
        public long OrderItemID { get; set; } // bigint, not null

        public long OrderID { get; set; } // bigint, not null

        public int ProductID { get; set; } // int, not null

        public decimal OriginalPrice { get; set; } // money, not null

        public decimal DiscountPrice { get; set; } /// money, not null

        public decimal Price { get; set; } // money, not null
    }
}
