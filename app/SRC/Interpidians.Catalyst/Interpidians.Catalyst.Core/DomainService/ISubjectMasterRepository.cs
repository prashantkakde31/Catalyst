using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface ISubjectMasterRepository
    {
        IEnumerable<SubjectMaster> GetAll();
        SubjectMaster GetById(IdentifiableData id);
        void Add(SubjectMaster SubjectMaster);
        void Update(SubjectMaster SubjectMaster);
        void Delete(IdentifiableData id);
    }
}
