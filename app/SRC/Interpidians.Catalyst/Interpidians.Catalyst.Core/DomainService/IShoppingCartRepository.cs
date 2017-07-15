using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IShoppingCartRepository
    {
        IEnumerable<ShoppingCart> GetAll();
        ShoppingCart GetById(IdentifiableData id);
        void Add(ShoppingCart ShoppingCart);
        void Update(ShoppingCart ShoppingCart);
        void Delete(IdentifiableData id);
    }
}
