using Catalyst.Business.Model.ModGradeMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.DataAccess.DataManagers.ModGradeMaster
{
    public class GradeMasterDataManager
    {
        public DataTable GetGradeList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllGrade");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetGradeListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@GradeID",ID)
                };
                return DBOperate.GetDataTable("usp_GetGradeById", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void AddGradeDetail(GradeMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {                      
                        new SqlParameter("@Grade",obj.Grade),                        
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@Description",obj.Description), 
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_AddGrade", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateGradeDetail(GradeMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@GradeID",obj.GradeID),
                        new SqlParameter("@Grade",obj.Grade),
                        new SqlParameter("@Description",obj.Description),
                        //new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)                        
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_UpdateGrade", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void DeleteGradeDetail(int id)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@GradeID",id)                                            
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_DeleteGrade", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
