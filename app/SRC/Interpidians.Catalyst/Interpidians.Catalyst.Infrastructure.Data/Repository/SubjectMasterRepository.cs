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
   public class SubjectMasterRepository:BaseRepository,ISubjectMasterRepository
    {
        public IEnumerable<SubjectMaster> GetAll()
        {
            IEnumerable<SubjectMaster> lstSubjMst;
            lstSubjMst = this.DB.ExecuteSprocAccessor<SubjectMaster>("usp_GetAllSubject");
            return lstSubjMst;
        }

        public SubjectMaster GetById(IdentifiableData id)
        {
            SubjectMaster subjectMaster = new SubjectMaster();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetSubjectById", id))
            {
                MapRecord(IReader, subjectMaster);
            }
            return subjectMaster;
        }

        public void Add(SubjectMaster SubjectMaster)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddSubject");
            this.DB.AddInParameter(saveCommand, "@SubCourseID", DbType.Int32, SubjectMaster.SubCourseID);
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, SubjectMaster.Name);
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String, SubjectMaster.Description);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, SubjectMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, SubjectMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, SubjectMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, SubjectMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, SubjectMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(SubjectMaster SubjectMaster)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdateSubject");
            this.DB.AddInParameter(saveCommand, "@SubjectID", DbType.Int32, SubjectMaster.SubjectID);
            this.DB.AddInParameter(saveCommand, "@SubCourseID", DbType.Int32, SubjectMaster.SubCourseID);
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, SubjectMaster.Name);
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String, SubjectMaster.Description);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, SubjectMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, SubjectMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, SubjectMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, SubjectMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, SubjectMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Delete(IdentifiableData id)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeleteSubject");
            this.DB.AddInParameter(saveCommand, "@SubjectID", DbType.Int32, id);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
    }
}
