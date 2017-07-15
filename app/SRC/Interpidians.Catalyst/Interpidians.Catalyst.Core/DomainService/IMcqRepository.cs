using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
    public interface IMcqRepository
    {
        IEnumerable<Mcq> GetAll();
        Mcq GetById(IdentifiableData id);
        void Add(Mcq mcq);
        void Update(Mcq mcq);
        void Delete(IdentifiableData id);
    }
}
