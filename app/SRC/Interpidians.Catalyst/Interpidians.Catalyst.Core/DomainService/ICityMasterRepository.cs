using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface ICityMasterRepository
    {
        IEnumerable<CityMaster> GetAll();
        CityMaster GetById(IdentifiableData id);
        void Add(CityMaster CityMaster);
        void Update(CityMaster CityMaster);
        void Delete(IdentifiableData id);
    }
}
