using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface ICountryMasterRepository
    {
        IEnumerable<CountryMaster> GetAll();
        CountryMaster GetById(IdentifiableData id);
        void Add(CountryMaster cntrMstr);
        void Update(CountryMaster cntrMstr);
        void Delete(IdentifiableData id);
    }
}
