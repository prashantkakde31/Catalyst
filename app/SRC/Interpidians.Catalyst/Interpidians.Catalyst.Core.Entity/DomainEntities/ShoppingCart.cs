using System;
using System.Collections.Generic;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            this.CartItems = new List<CartItem>();
        }

        public long ShoppingCartID { get; set; } // bigint, not null

        public int UserID { get; set; } // int, not null

        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
