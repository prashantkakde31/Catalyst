using Catalyst.Business.Model.ModPaperMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.DataAccess.DataManagers.ModPaperMaster
{
    public class PaperMasterDataManager
    {
        public DataTable GetPaperList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllPaper");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetPaperListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@PaperID",ID)
                };
                return DBOperate.GetDataTable("usp_GetPaperById", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetPaperListWithTopicID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@TopicID",ID)
                };
                return DBOperate.GetDataTable("usp_GetPaperByTopicId", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetPaperListWithSubjectID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@SubjectID",ID)
                };
                return DBOperate.GetDataTable("usp_GetPaperBySubjectId", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void AddPaperDetail(PaperMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {                      
                        new SqlParameter("@SubjectID",obj.SubjectId),
                        //new SqlParameter("@TopicID",obj.TopicID),
                        new SqlParameter("@GradeID",obj.GradeID),
                        new SqlParameter("@IsYearwise",obj.IsYearwise),
                        new SqlParameter("@Year",obj.Year),
                        new SqlParameter("@Month",obj.Month),
                        new SqlParameter("@IsSample",obj.IsSample),
                        new SqlParameter("@Name",obj.Name),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@Description",obj.Description), 
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_AddPaper", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void UpdatePaperDetail(PaperMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {                      
                        new SqlParameter("@PaperID",obj.PaperID),
                        new SqlParameter("@SubjectID",obj.SubjectId),
                        //new SqlParameter("@TopicID",obj.TopicID),
                        new SqlParameter("@GradeID",obj.GradeID),
                        new SqlParameter("@IsYearwise",obj.IsYearwise),
                        new SqlParameter("@Year",obj.Year),
                        new SqlParameter("@Month",obj.Month),
                        new SqlParameter("@IsSample",obj.IsSample),
                        new SqlParameter("@Name",obj.Name),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@Description",obj.Description), 
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_UpdatePaper", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void DeletePaperDetail(int id)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@PaperID",id)                                            
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_DeletePaper", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void DisablePaperDetail(int id, string flag)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@PaperID",id)  ,
                        new SqlParameter("@DisableFlag",flag)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_DisablePaper", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
