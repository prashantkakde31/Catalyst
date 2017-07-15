using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface ISubCourseMasterRepository
    {
        IEnumerable<SubCourseMaster> GetAll();
        SubCourseMaster GetById(IdentifiableData id);
        void Add(SubCourseMaster SubCourseMaster);
        void Update(SubCourseMaster SubCourseMaster);
        void Delete(IdentifiableData id);
    }
}
