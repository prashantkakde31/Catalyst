using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class CartItem
    {
        public long CartItemID { get; set; } // bigint, not null

        public long ShoppingCartID { get; set; } // bigint, not null

        public int ProductID { get; set; } // int, not null
    }
}
