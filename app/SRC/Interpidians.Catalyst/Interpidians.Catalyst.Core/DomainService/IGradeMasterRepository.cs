using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IGradeMasterRepository
    {
        IEnumerable<GradeMaster> GetAll();
        GradeMaster GetById(IdentifiableData id);
        void Add(GradeMaster exmDtl);
        void Update(GradeMaster exmDtl);
        void Delete(IdentifiableData id);
    }
}
