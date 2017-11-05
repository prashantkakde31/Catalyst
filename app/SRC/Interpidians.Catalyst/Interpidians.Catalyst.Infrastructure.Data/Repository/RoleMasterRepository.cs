using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;


namespace Interpidians.Catalyst.Infrastructure.Data
{
    public class RoleMasterRepository : BaseRepository, IRoleMasterRepository
    {
        public IEnumerable<RoleMaster> GetAll()
        {
            IEnumerable<RoleMaster> lstRoleMaster;
            lstRoleMaster = this.DB.ExecuteSprocAccessor<RoleMaster>("usp_GetAllRoleMaster");
            return lstRoleMaster;
        }

        public RoleMaster GetById(IdentifiableData id)
        {
            RoleMaster roleMaster = new RoleMaster();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetRoleMasterById", id.Id))
            {
                MapRecord(IReader, roleMaster);
            }
            return roleMaster;
        }

        public void Add(RoleMaster RoleMaster)
        {
            throw new NotImplementedException();
        }

        public void Update(RoleMaster UserMaster)
        {
            throw new NotImplementedException();
        }

        public void Delete(IdentifiableData id)
        {
            throw new NotImplementedException();
        }
    }
}