using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
  public interface IStateMasterRepository
    {
        IEnumerable<StateMaster> GetAll();
        StateMaster GetById(IdentifiableData id);
        void Add(StateMaster StateMaster);
        void Update(StateMaster StateMaster);
        void Delete(IdentifiableData id);
    }
}
