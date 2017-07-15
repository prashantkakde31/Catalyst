using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IUserProfileRepository
    {
        IEnumerable<UserProfile> GetAll();
        UserProfile GetById(IdentifiableData id);
        void Add(UserProfile UserProfile);
        void Update(UserProfile UserProfile);
        void Delete(IdentifiableData id);
    }
}
