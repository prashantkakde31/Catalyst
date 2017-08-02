using Catalyst.Business.Model.ModTopicMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.DataAccess.DataManagers.ModTopicMaster
{
    public class TopicMasterDataManager
    {
        public DataTable GetTopicList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllTopic");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetTopicListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@TopicID",ID)
                };
                return DBOperate.GetDataTable("usp_GetTopicById", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetTopicsWithSubjectID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@SubjectID",ID)
                };
                return DBOperate.GetDataTable("usp_GetTopicBySubjectId", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void AddTopicDetail(TopicMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {                      
                        new SqlParameter("@SubjectID",obj.SubjectID),
                        new SqlParameter("@Name",obj.Name),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@Description",obj.Description), 
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_AddTopic", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateTopicDetail(TopicMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@TopicID",obj.TopicID),
                        new SqlParameter("@SubjectID",obj.SubjectID),
                        new SqlParameter("@Name",obj.Name),
                        new SqlParameter("@Description",obj.Description),
                        //new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)                        
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_UpdateTopic", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void DeleteTopicDetail(int id)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@TopicID",id)                                            
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_DeleteTopic", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
