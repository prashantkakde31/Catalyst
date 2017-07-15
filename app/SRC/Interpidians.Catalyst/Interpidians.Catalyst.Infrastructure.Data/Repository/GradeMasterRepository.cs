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
   public class GradeMasterRepository:BaseRepository,IGradeMasterRepository
    {
        public IEnumerable<GradeMaster> GetAll()
        {
            IEnumerable<GradeMaster> lstGrade;
            lstGrade = this.DB.ExecuteSprocAccessor<GradeMaster>("usp_GetAllGrade");
            return lstGrade;
        }

        public GradeMaster GetById(IdentifiableData id)
        {
            //usp_GetGradeById is the name of stored procedure but dont know how to use it
            GradeMaster gradeMaster = new GradeMaster();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetGradeById", id))
            {
                MapRecord(IReader, gradeMaster);
            }
            return gradeMaster;
        }

        public void Add(GradeMaster gradeMaster)
        {
            //usp_AddGrade is the name of stored procedure but dont know how to use it
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddGrade");
            this.DB.AddInParameter(saveCommand, "@Grade", DbType.String, gradeMaster.Grade);
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String, gradeMaster.Description);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, gradeMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, gradeMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, gradeMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, gradeMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, gradeMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(GradeMaster gradeMaster)
        {
            //usp_UpdateGrade is the name of stored procedure but dont know how to use it
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdateGrade");
            this.DB.AddInParameter(saveCommand, "@GradeID", DbType.Int32,gradeMaster.GradeID);
            this.DB.AddInParameter(saveCommand, "@Grade", DbType.String,gradeMaster.Grade );
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String,gradeMaster.Description );
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, gradeMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32,gradeMaster.CreatedBy );
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime,gradeMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32,gradeMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, gradeMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Delete(IdentifiableData id)
        {
            //usp_DeleteGrade is the name of stored procedure but dont know how to use it
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeleteGrade");
            this.DB.AddInParameter(saveCommand, "@GradeID", DbType.Int32, id);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
    }
}
