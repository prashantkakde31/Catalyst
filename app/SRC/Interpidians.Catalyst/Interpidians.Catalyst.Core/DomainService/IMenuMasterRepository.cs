using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface IMenuMasterRepository
    {
        IEnumerable<MenuMaster> GetAll();
        MenuMaster GetById(IdentifiableData id);
        void Add(MenuMaster MenuMaster);
        void Update(MenuMaster MenuMaster);
        void Delete(IdentifiableData id);
    }
}
