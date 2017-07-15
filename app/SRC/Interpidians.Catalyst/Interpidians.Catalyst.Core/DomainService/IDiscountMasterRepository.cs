using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IDiscountMasterRepository
    {
        IEnumerable<DiscountMaster> GetAll();
        DiscountMaster GetById(IdentifiableData id);
        void Add(DiscountMaster DiscountMaster);
        void Update(DiscountMaster DiscountMaster);
        void Delete(IdentifiableData id);
    }
}
