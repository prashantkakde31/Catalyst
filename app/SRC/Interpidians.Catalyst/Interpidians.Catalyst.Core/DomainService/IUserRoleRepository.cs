using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IUserRoleRepository
    {
        IEnumerable<UserRole> GetAll();
        UserRole GetById(IdentifiableData id);
        void Add(UserRole UserRole);
        void Update(UserRole UserRole);
        void Delete(IdentifiableData id);
    }
}
