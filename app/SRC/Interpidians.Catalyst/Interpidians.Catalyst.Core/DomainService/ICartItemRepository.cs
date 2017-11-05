using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;


namespace Interpidians.Catalyst.Core.DomainService
{
    public interface ICartItemRepository
    {
        IEnumerable<CartItem> GetAll();
        CartItem GetById(IdentifiableData id);
        void Add(CartItem ShoppingCart);
        void Update(CartItem ShoppingCart);
        void Delete(IdentifiableData id);
    }
}
