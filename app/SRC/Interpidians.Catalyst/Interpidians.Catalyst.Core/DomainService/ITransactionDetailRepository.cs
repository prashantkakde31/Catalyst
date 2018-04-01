using Interpidians.Catalyst.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.DomainService
{
    public interface ITransactionDetailRepository
    {
        IEnumerable<TransactionDetail> GetAll();
        TransactionDetail GetById(IdentifiableData id);
        void Add(TransactionDetail Transaction);
        void Update(TransactionDetail Transaction);
        void Delete(IdentifiableData id);
    }
}
