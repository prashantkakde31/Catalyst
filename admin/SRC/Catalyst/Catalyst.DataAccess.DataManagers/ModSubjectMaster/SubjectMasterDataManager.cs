using Catalyst.Business.Model.ModSubjectMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.DataAccess.DataManagers.ModSubjectMaster
{
    public class SubjectMasterDataManager
    {
        public DataTable GetSubjectList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllSubject");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetSubjectListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@SubjectID",ID)
                };
                return DBOperate.GetDataTable("usp_GetSubjectById", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetSubjectListWithSubCourseID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@SubCourseID",ID)
                };
                return DBOperate.GetDataTable("usp_GetSubjectBySubCourseId", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetSubjectListWithTopicID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@TopicID",ID)
                };
                return DBOperate.GetDataTable("usp_GetSubjectByTopicId", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetSubCourseListWithSubjectID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@SubjectID",ID)
                };
                return DBOperate.GetDataTable("usp_GetSubCourseBySubjectId", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void AddSubjectDetail(SubjectMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {                      
                        new SqlParameter("@SubCourseID",obj.SubCourseID),
                        new SqlParameter("@Name",obj.Name),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@Description",obj.Description), 
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_AddSubject", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateSubjectDetail(SubjectMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@SubjectID",obj.SubjectID),
                        new SqlParameter("@SubCourseID",obj.SubCourseID),
                        new SqlParameter("@Name",obj.Name),
                        new SqlParameter("@Description",obj.Description),
                        //new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)                        
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_UpdateSubject", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void DeleteSubjectDetail(int id)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@SubjectID",id)                                            
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_DeleteSubject", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
