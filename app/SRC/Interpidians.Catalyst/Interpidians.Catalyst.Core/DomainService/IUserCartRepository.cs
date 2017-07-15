using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IUserCartRepository
    {
        IEnumerable<UserCart> GetAll();
        UserCart GetById(IdentifiableData id);
        void Add(UserCart UserCart);
        void Update(UserCart UserCart);
        void Delete(IdentifiableData id);
    }
}
