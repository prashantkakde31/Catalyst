using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IProductMasterRepository
    {
        IEnumerable<ProductMaster> GetAll();
        ProductMaster GetById(IdentifiableData id);
        void Add(ProductMaster ProductMaster);
        void Update(ProductMaster ProductMaster);
        void Delete(IdentifiableData id);
    }
}
