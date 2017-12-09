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
    public class UserMasterRepository : BaseRepository, IUserMasterRepository
    {
        public IEnumerable<UserMaster> GetAll()
        {
            IEnumerable<UserMaster> lstUserMaster;
            lstUserMaster = this.DB.ExecuteSprocAccessor<UserMaster>("usp_GetAllUserMaster");
            return lstUserMaster;
        }

        public UserMaster GetById(IdentifiableData id)
        {
            UserMaster userMaster = new UserMaster();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetUserMasterById", id.Id))
            {
                MapRecord(IReader, userMaster);
            }
            return userMaster;
        }

        public void Add(UserMaster UserMaster)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddUserMaster");
            this.DB.AddInParameter(saveCommand, "@UserName", DbType.String, UserMaster.UserName);
            this.DB.AddInParameter(saveCommand, "@Password", DbType.String, UserMaster.Password);
            //this.DB.AddInParameter(saveCommand, "@AccountStatus", DbType.String, UserMaster.AccountStatus);
            this.DB.AddInParameter(saveCommand, "@EmailID", DbType.String, UserMaster.EmailID);
            //this.DB.AddInParameter(saveCommand, "@ValidFrom", DbType.DateTime, UserMaster.ValidFrom);
            //this.DB.AddInParameter(saveCommand, "@ValidUpto", DbType.DateTime, UserMaster.ValidUpto);
            //this.DB.AddInParameter(saveCommand, "@IsLoggedOn", DbType.Boolean, UserMaster.IsLoggedOn);
            this.DB.AddInParameter(saveCommand, "@MobileNumber", DbType.String, UserMaster.MobileNumber);
            this.DB.AddInParameter(saveCommand, "@ExamYear", DbType.Int32, UserMaster.ExamYear);
            this.DB.AddInParameter(saveCommand, "@ExamMonth", DbType.Int32, UserMaster.ExamMonth);
            this.DB.AddInParameter(saveCommand, "@IsExternalUser", DbType.Boolean, UserMaster.IsExternalUser);
            this.DB.AddInParameter(saveCommand, "@ExternalLoginProvider", DbType.String, UserMaster.ExternalLoginProvider);
            this.DB.AddInParameter(saveCommand, "@ProviderKey", DbType.String, UserMaster.ProviderKey);
            this.DB.AddInParameter(saveCommand, "@IsRegistrationComplete", DbType.Boolean, UserMaster.IsRegistrationComplete);
            this.DB.ExecuteScalar(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(UserMaster UserMaster)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdateUserMaster");
            this.DB.AddInParameter(saveCommand, "@UserID", DbType.Int32, UserMaster.UserID);
            this.DB.AddInParameter(saveCommand, "@UserName", DbType.String, UserMaster.UserName);
            this.DB.AddInParameter(saveCommand, "@Password", DbType.String, UserMaster.Password);
            this.DB.AddInParameter(saveCommand, "@EmailID", DbType.String, UserMaster.EmailID);
            this.DB.AddInParameter(saveCommand, "@MobileNo", DbType.String, UserMaster.MobileNumber);
            this.DB.AddInParameter(saveCommand, "@ValidFrom", DbType.DateTime, UserMaster.ValidFrom);
            this.DB.AddInParameter(saveCommand, "@ValidUpto", DbType.DateTime, UserMaster.ValidUpto);
            this.DB.AddInParameter(saveCommand, "@IsLoggedOn", DbType.Boolean, UserMaster.IsLoggedOn);
            this.DB.AddInParameter(saveCommand, "@LoggedOnSessionID", DbType.String, UserMaster.LoggedOnSessionID);
            this.DB.AddInParameter(saveCommand, "@IsExternalUser", DbType.Boolean, UserMaster.IsExternalUser);
            this.DB.AddInParameter(saveCommand, "@ExternalLoginProvider", DbType.String, UserMaster.ExternalLoginProvider);
            this.DB.AddInParameter(saveCommand, "@ProviderKey", DbType.String, UserMaster.ProviderKey);
            this.DB.AddInParameter(saveCommand, "@IsRegistrationComplete", DbType.Boolean, UserMaster.IsRegistrationComplete);
            this.DB.AddInParameter(saveCommand, "@AccountStatus", DbType.String, UserMaster.AccountStatus);
            //this.DB.AddInParameter(saveCommand, "@ExamYear", DbType.Int32, UserMaster.ExamYear);
            //this.DB.AddInParameter(saveCommand, "@ExamMonth", DbType.Int32, UserMaster.ExamMonth);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Delete(IdentifiableData id)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeleteUserMaster");
            this.DB.AddInParameter(saveCommand, "@UserID", DbType.Int32, id);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
    }
}