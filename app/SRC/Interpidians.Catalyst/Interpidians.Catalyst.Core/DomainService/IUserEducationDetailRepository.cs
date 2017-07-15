using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IUserEducationDetailRepository
    {
        IEnumerable<UserEducationDetail> GetAll();
        UserEducationDetail GetById(IdentifiableData id);
        void Add(UserEducationDetail UserEducationDetail);
        void Update(UserEducationDetail UserEducationDetail);
        void Delete(IdentifiableData id);
    }
}
