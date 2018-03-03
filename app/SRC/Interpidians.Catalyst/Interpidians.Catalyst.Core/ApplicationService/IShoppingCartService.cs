using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public interface IShoppingCartService
    {
        List<ShoppingCart> GetAll();
        void AddItemToCart(long shoppingCartId,int productId);
        void RemoveItemFromCart(long shoppingCartId, int productId);
        void RemoveAllItemsFromCart(long shoppingCartId);
        List<CartItem> GetCartItems(long shoppingCartId);
    }
}
