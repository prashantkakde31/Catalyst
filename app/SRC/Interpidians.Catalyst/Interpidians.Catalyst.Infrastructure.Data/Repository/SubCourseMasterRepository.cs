using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Interpidians.Catalyst.Infrastructure.Data
{
   public class SubCourseMasterRepository:BaseRepository,ISubCourseMasterRepository
    {
        public IEnumerable<SubCourseMaster> GetAll()
        {
            IEnumerable<SubCourseMaster> lstSubCourse;
            lstSubCourse = this.DB.ExecuteSprocAccessor<SubCourseMaster>("usp_GetAllSubCourse");
            return lstSubCourse;
        }

        public SubCourseMaster GetById(IdentifiableData id)
        {
            SubCourseMaster subCourseMaster = new SubCourseMaster();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetSubCourseById", id))
            {
                MapRecord(IReader, subCourseMaster);
            }
            return subCourseMaster;
        }

        public void Add(SubCourseMaster subCourseMaster)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddSubCourse");
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, subCourseMaster.Name);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, subCourseMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, subCourseMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime,subCourseMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, subCourseMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, subCourseMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(SubCourseMaster subCourseMaster)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdateSubCourse");
            this.DB.AddInParameter(saveCommand, "@SubCourseID", DbType.Int32, subCourseMaster.SubCourseID);
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, subCourseMaster.Name);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, subCourseMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, subCourseMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, subCourseMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, subCourseMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, subCourseMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Delete(IdentifiableData id)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeleteSubCourse");
            this.DB.AddInParameter(saveCommand, "@SubCourseID", DbType.Int32,id);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
    }
}
