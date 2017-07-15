using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IProductPurchaseDetailRepository
    {
        IEnumerable<ProductPurchaseDetail> GetAll();
        ProductPurchaseDetail GetById(IdentifiableData id);
        void Add(ProductPurchaseDetail ProductPurchaseDetail);
        void Update(ProductPurchaseDetail ProductPurchaseDetail);
        void Delete(IdentifiableData id);
    }
}
