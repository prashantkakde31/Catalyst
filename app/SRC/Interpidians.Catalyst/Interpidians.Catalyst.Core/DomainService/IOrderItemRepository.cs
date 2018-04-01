using Interpidians.Catalyst.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.DomainService
{
       public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> GetAll();
        OrderItem GetById(IdentifiableData id);
        void Add(OrderItem OrderItem);
        void Update(OrderItem OrderItem);
        void Delete(IdentifiableData id);
    }
}
