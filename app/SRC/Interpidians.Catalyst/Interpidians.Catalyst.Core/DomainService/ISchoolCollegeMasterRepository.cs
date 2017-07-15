using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface ISchoolCollegeMasterRepository
    {
        IEnumerable<SchoolCollegeMaster> GetAll();
        SchoolCollegeMaster GetById(IdentifiableData id);
        void Add(SchoolCollegeMaster SchoolCollegeMaster);
        void Update(SchoolCollegeMaster SchoolCollegeMaster);
        void Delete(IdentifiableData id);
    }
}
