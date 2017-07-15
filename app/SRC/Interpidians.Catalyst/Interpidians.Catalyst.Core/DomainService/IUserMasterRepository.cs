using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IUserMasterRepository
    {
        IEnumerable<UserMaster> GetAll();
        UserMaster GetById(IdentifiableData id);
        void Add(UserMaster UserMaster);
        void Update(UserMaster UserMaster);
        void Delete(IdentifiableData id);
    }
}
