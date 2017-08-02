using Catalyst.Business.Model.ModAnswerMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.DataAccess.DataManagers.ModAnswerMaster
{
    public class AnswerMasterDataManager
    {
        public DataTable GetAnswerListWithMcqID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@McqID",ID)
                };
                return DBOperate.GetDataTable("usp_GetMcqAnwerByMcqId", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void AddAnswerDetail(AnswerMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@McqID",obj.McqID),
                        new SqlParameter("@SN",obj.SN),
                        new SqlParameter("@AnswerType",obj.AnswerType),
                        new SqlParameter("@Answer",obj.Answer),
                        new SqlParameter("@AnswerImage",obj.AnswerImage),                         
                        new SqlParameter("@IsVisible",obj.IsVisible),
                        new SqlParameter("@Correct",obj.Correct)                        
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_AddMcqAnswer", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateAnswerDetail(AnswerMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@McqAnswerID",obj.McqAnswerID),
                        new SqlParameter("@McqID",obj.McqID),
                        new SqlParameter("@SN",obj.SN),
                        new SqlParameter("@AnswerType",obj.AnswerType),
                        new SqlParameter("@Answer",obj.Answer),
                         new SqlParameter("@AnswerImage",obj.AnswerImage),                         
                        new SqlParameter("@IsVisible",obj.IsVisible),
                        new SqlParameter("@Correct",obj.Correct)
                        
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_UpdateMcqAnswer", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void DeleteAnswerDetail(int id)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@CourseID",id)                                            
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_DeleteCourse", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
