using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetAll();
        OrderDetail GetById(IdentifiableData id);
        void Add(OrderDetail OrderDetail);
        void Update(OrderDetail OrderDetail);
        void Delete(IdentifiableData id);
    }
}
