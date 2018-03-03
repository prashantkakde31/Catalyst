using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public class ShoppingCartService : IShoppingCartService
    {
        private IShoppingCartRepository ShoppingCartRepository { get; set; }
        private ICartItemRepository CartItemRepository { get; set; }

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, ICartItemRepository cartItemRepository)
        {
            this.ShoppingCartRepository = shoppingCartRepository;
            this.CartItemRepository = cartItemRepository;
        }
        public List<ShoppingCart> GetAll()
        {
            return ShoppingCartRepository.GetAll().ToList();
        }

        public void AddItemToCart(long shoppingCartId, int productId)
        {
            CartItemRepository.Add(shoppingCartId,productId);
        }

        public List<CartItem> GetCartItems(long shoppingCartId)
        {
            return CartItemRepository.GetAll().Where(x => x.ShoppingCartID == shoppingCartId).ToList();
        }

        public void RemoveItemFromCart(long shoppingCartId, int productId)
        {
            CartItemRepository.Delete(shoppingCartId,productId);
        }

        public void RemoveAllItemsFromCart(long shoppingCartId)
        {
            CartItemRepository.DeleteAll(shoppingCartId);
        }
    }
}
