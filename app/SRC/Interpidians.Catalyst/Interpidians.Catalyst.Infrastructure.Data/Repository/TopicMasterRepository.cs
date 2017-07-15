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
   public class TopicMasterRepository:BaseRepository,ITopicMasterRepository
    {
        public IEnumerable<TopicMaster> GetAll()
        {
            IEnumerable<TopicMaster> lstTopicMaster;
            lstTopicMaster = this.DB.ExecuteSprocAccessor<TopicMaster>("usp_GetAllTopic");
            return lstTopicMaster;
        }

        public TopicMaster GetById(IdentifiableData id)
        {
            TopicMaster topicMaster = new TopicMaster();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetTopicById", id))
            {
                MapRecord(IReader, topicMaster);
            }
            return topicMaster;
        }

        public void Add(TopicMaster TopicMaster)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddTopic");
            this.DB.AddInParameter(saveCommand, "@SubjectID", DbType.Int32, TopicMaster.SubjectID);
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, TopicMaster.Name);
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String, TopicMaster.Description);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, TopicMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, TopicMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, TopicMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, TopicMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, TopicMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(TopicMaster TopicMaster)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdateTopic");
            this.DB.AddInParameter(saveCommand, "@TopicID", DbType.Int32, TopicMaster.TopicID);
            this.DB.AddInParameter(saveCommand, "@SubjectID", DbType.Int32, TopicMaster.SubjectID);
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, TopicMaster.Name);
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String, TopicMaster.Description);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, TopicMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, TopicMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, TopicMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, TopicMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, TopicMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Delete(IdentifiableData id)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeleteTopic");
            this.DB.AddInParameter(saveCommand, "@TopicID", DbType.Int32, id);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
    }
}
