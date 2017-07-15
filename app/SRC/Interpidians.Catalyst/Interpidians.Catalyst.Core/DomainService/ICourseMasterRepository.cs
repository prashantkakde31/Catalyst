using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface ICourseMasterRepository
    {
        IEnumerable<CourseMaster> GetAll();
        CourseMaster GetById(IdentifiableData id);
        void Add(CourseMaster CourseMaster);
        void Update(CourseMaster CourseMaster);
        void Delete(IdentifiableData id);
    }
}
