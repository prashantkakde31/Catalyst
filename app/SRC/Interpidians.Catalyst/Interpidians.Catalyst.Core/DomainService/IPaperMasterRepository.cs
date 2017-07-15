using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IPaperMasterRepository
    {
        IEnumerable<PaperMaster> GetAll();
        PaperMaster GetById(IdentifiableData id);
        void Add(PaperMaster PaperMaster);
        void Update(PaperMaster PaperMaster);
        void Delete(IdentifiableData id);
    }
}
