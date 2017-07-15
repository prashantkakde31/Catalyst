using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Interpidians.Catalyst.Infrastructure.Data
{
   public class CourseMasterRepository:BaseRepository,ICourseMasterRepository
    {
       
        public IEnumerable<CourseMaster> GetAll()
        {
            IEnumerable<CourseMaster> lstCourse;
            lstCourse = this.DB.ExecuteSprocAccessor<CourseMaster>("usp_GetAllCourse");
            return lstCourse;
        }

        public CourseMaster GetById(IdentifiableData id)
        {
            CourseMaster courseMaster = new CourseMaster();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetCourseById", id))
            {
                MapRecord(IReader, courseMaster);
            }
            //usp_GetCourseById is name of stored procedure but dont know how to use it
            //courseMaster = this.DB.ExecuteSprocAccessor<CourseMaster>("usp_GetCourseById");
            return courseMaster;
            //should i write following course?
            //IEnumerable<CourseMaster> lstCourse;
            //lstCourse = this.DB.ExecuteSprocAccessor<CourseMaster>("usp_GetCourseById");
            //return lstCourse;
        }

        public void Add(CourseMaster CourseMaster)
        {
            //usp_AddCourse is name of stored procedure but dont know how to use it
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddCourse");
            //this.DB.AddInParameter(saveCommand, "@CourseID", DbType.Int32, CourseMaster.CourseID);
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, CourseMaster.Name);
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String, CourseMaster.Description);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, CourseMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, CourseMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, CourseMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, CourseMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, CourseMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(CourseMaster CourseMaster)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdateCourse");
            this.DB.AddInParameter(saveCommand, "@CourseID", DbType.Int32, CourseMaster.CourseID);
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, CourseMaster.Name);
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String, CourseMaster.Description);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, CourseMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, CourseMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, CourseMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, CourseMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, CourseMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
            //usp_UpdateCourse is name of stored procedure but dont know how to use it
        }

        public void Delete(IdentifiableData id)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeleteCourse");
            this.DB.AddInParameter(saveCommand, "@CourseID", DbType.Int32, id);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
            //not sure about this code
        }
    }
}
