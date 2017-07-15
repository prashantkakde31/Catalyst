using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface ITransactionDetailRepository
    {
        IEnumerable<TransactionDetail> GetAll();
        TransactionDetail GetById(IdentifiableData id);
        void Add(TransactionDetail TransactionDetail);
        void Update(TransactionDetail TransactionDetail);
        void Delete(IdentifiableData id);
    }
}
