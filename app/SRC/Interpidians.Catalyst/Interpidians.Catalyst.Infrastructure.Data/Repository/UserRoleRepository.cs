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
    public class UserRoleRepository : BaseRepository, IUserRoleRepository
    {
        public IEnumerable<UserRole> GetAll()
        {
            IEnumerable<UserRole> lstUserRole;
            lstUserRole = this.DB.ExecuteSprocAccessor<UserRole>("usp_GetAllUserRole");
            return lstUserRole;
        }

        public UserRole GetById(IdentifiableData id)
        {
            //UserRole userRole = new UserRole();
            //using (IDataReader IReader = this.DB.ExecuteReader("usp_GetUserRoleById", id))
            //{
            //    MapRecord(IReader, userRole);
            //}
            //return userRole;

            throw new NotImplementedException();
        }

        public void Add(UserRole UserRole)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddUserRole");
            this.DB.AddInParameter(saveCommand, "@RoleID", DbType.Int32, UserRole.RoleID);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(UserRole UserRole)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdateUserRole");
            this.DB.AddInParameter(saveCommand, "@UserID", DbType.Int32, UserRole.UserID);
            this.DB.AddInParameter(saveCommand, "@RoleID", DbType.Int32, UserRole.RoleID);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Delete(IdentifiableData id)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeleteUserRole");
            this.DB.AddInParameter(saveCommand, "@UserID", DbType.Int32, id);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
    }
}
