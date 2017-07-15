using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IMcqAnswerRepository
    {
        IEnumerable<McqAnswer> GetAll();
        McqAnswer GetById(IdentifiableData id);
        void Add(McqAnswer mcqAns);
        void Update(McqAnswer mcqAns);
        void Delete(IdentifiableData id);
    }
}
