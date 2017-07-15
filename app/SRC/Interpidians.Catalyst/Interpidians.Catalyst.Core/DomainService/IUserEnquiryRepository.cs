using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IUserEnquiryRepository
    {
        IEnumerable<UserEnquiry> GetAll();
        UserEnquiry GetById(IdentifiableData id);
        void Add(UserEnquiry UserEnquiry);
        void Update(UserEnquiry UserEnquiry);
        void Delete(IdentifiableData id);
    }
}
