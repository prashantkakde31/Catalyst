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
   public class PaperMasterRepository:BaseRepository,IPaperMasterRepository
    {
        public IEnumerable<PaperMaster> GetAll()
        {
            IEnumerable<PaperMaster> lstPaper;
            lstPaper = this.DB.ExecuteSprocAccessor<PaperMaster>("usp_GetAllPaper");
            return lstPaper;
        }

        public PaperMaster GetById(IdentifiableData id)
        {
            //usp_GetPaperById is the name of stored procedure but dont know how to use it
            PaperMaster paperMaster = new PaperMaster();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetPaperById", id))
            {
                MapRecord(IReader, paperMaster);
            }
            return paperMaster;
        }

        public void Add(PaperMaster paperMaster)
        {
            //usp_AddPaper is the name of stored procedure but dont know how to use it
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddPaper");
            this.DB.AddInParameter(saveCommand, "@SubjectID", DbType.Int32, paperMaster.SubjectId);
            this.DB.AddInParameter(saveCommand, "@TopicID", DbType.Int32, paperMaster.TopicID);
            this.DB.AddInParameter(saveCommand, "@GradeID", DbType.Int32, paperMaster.GradeID);
            this.DB.AddInParameter(saveCommand, "@IsYearwise", DbType.Boolean, paperMaster.IsYearwise);
            this.DB.AddInParameter(saveCommand, "@Year", DbType.Int32, paperMaster.Year);
            this.DB.AddInParameter(saveCommand, "@Month", DbType.Int32, paperMaster.Month);
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, paperMaster.Name);
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String, paperMaster.Description);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, paperMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, paperMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, paperMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, paperMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, paperMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(PaperMaster paperMaster)
        {
            //usp_UpdatePaper is the name of stored procedure but dont know how to use it
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdatePaper");
            this.DB.AddInParameter(saveCommand, "@PaperID", DbType.Int32, paperMaster.PaperID);
            this.DB.AddInParameter(saveCommand, "@SubjectID", DbType.Int32, paperMaster.SubjectId);
            this.DB.AddInParameter(saveCommand, "@TopicID", DbType.Int32, paperMaster.TopicID);
            this.DB.AddInParameter(saveCommand, "@GradeID", DbType.Int32, paperMaster.GradeID);
            this.DB.AddInParameter(saveCommand, "@IsYearwise", DbType.Boolean, paperMaster.IsYearwise);
            this.DB.AddInParameter(saveCommand, "@Year", DbType.Int32, paperMaster.Year);
            this.DB.AddInParameter(saveCommand, "@Month", DbType.Int32, paperMaster.Month);
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, paperMaster.Name);
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String, paperMaster.Description);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, paperMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, paperMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, paperMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, paperMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, paperMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Delete(IdentifiableData id)
        {
            //usp_DeletePaper is the name of stored procedure but dont know how to use it
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeletePaper");
            this.DB.AddInParameter(saveCommand, "@PaperID", DbType.Int32, id);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
    }
}
