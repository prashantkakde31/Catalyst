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
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public IEnumerable<UserProfile> GetAll()
        {
            IEnumerable<UserProfile> lstUserProfile;
            lstUserProfile = this.DB.ExecuteSprocAccessor<UserProfile>("usp_GetAllUserProfile");
            return lstUserProfile;
        }

        public UserProfile GetById(IdentifiableData id)
        {
            UserProfile userProfile = new UserProfile();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetUserProfileById", id.Id))
            {
                MapRecord(IReader, userProfile);
            }
            return userProfile;
        }

        public void Add(UserProfile UserProfile)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddUserProfile");
            this.DB.AddInParameter(saveCommand, "@UserID", DbType.Int32, UserProfile.UserID);
            this.DB.AddInParameter(saveCommand, "@FirstName", DbType.String, UserProfile.FirstName);
            this.DB.AddInParameter(saveCommand, "@LastName", DbType.String, UserProfile.LastName);
            this.DB.AddInParameter(saveCommand, "@DOB", DbType.DateTime, UserProfile.DOB);
            this.DB.AddInParameter(saveCommand, "@AddrLine1", DbType.String, UserProfile.AddrLine1);
            this.DB.AddInParameter(saveCommand, "@AddrLine2", DbType.String, UserProfile.AddrLine2);
            this.DB.AddInParameter(saveCommand, "@City", DbType.String, UserProfile.City);
            this.DB.AddInParameter(saveCommand, "@State", DbType.String, UserProfile.State);
            this.DB.AddInParameter(saveCommand, "@Country", DbType.String, UserProfile.Country);
            this.DB.AddInParameter(saveCommand, "@Pincode", DbType.String, UserProfile.Pincode);
            this.DB.AddInParameter(saveCommand, "@MobileNo", DbType.String, UserProfile.MobileNo);
            this.DB.AddInParameter(saveCommand, "@LandlineNo", DbType.String, UserProfile.LandlineNo);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(UserProfile UserProfile)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdateUserProfile");
            this.DB.AddInParameter(saveCommand, "@ProfileID", DbType.Int32, UserProfile.ProfileID);
            this.DB.AddInParameter(saveCommand, "@UserID", DbType.Int32, UserProfile.UserID);
            this.DB.AddInParameter(saveCommand, "@FirstName", DbType.String, UserProfile.FirstName);
            this.DB.AddInParameter(saveCommand, "@LastName", DbType.String, UserProfile.LastName);
            this.DB.AddInParameter(saveCommand, "@DOB", DbType.String, UserProfile.DOB);
            this.DB.AddInParameter(saveCommand, "@AddrLine1", DbType.String, UserProfile.AddrLine1);
            this.DB.AddInParameter(saveCommand, "@AddrLine2", DbType.String, UserProfile.AddrLine2);
            this.DB.AddInParameter(saveCommand, "@City", DbType.String, UserProfile.City);
            this.DB.AddInParameter(saveCommand, "@State", DbType.String, UserProfile.State);
            this.DB.AddInParameter(saveCommand, "@Country", DbType.String, UserProfile.Country);
            this.DB.AddInParameter(saveCommand, "@Pincode", DbType.String, UserProfile.Pincode);
            this.DB.AddInParameter(saveCommand, "@MobileNo", DbType.String, UserProfile.MobileNo);
            this.DB.AddInParameter(saveCommand, "@LandlineNo", DbType.String, UserProfile.LandlineNo);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Delete(IdentifiableData id)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeleteUserProfile");
            this.DB.AddInParameter(saveCommand, "@ProfileID", DbType.Int32, id);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
    }
}