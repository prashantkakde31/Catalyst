using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IRoleMasterRepository
    {
        IEnumerable<RoleMaster> GetAll();
        RoleMaster GetById(IdentifiableData id);
        void Add(RoleMaster RoleMaster);
        void Update(RoleMaster RoleMaster);
        void Delete(IdentifiableData id);
    }
}
