using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IExamDetailRepository
    {
        IEnumerable<ExamDetail> GetAll();
        ExamDetail GetById(IdentifiableData id);
        void Add(ExamDetail exmDtl);
        void Update(ExamDetail exmDtl);
        void Delete(IdentifiableData id);
    }
}
