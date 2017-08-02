using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Catalyst.Business.Model.ModCourseMaster;
using System.Data.SqlClient;

namespace Catalyst.DataAccess.DataManagers.ModCourseMaster
{
    public class CourseMasterDataManager
    {
        public DataTable GetCourseList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllCourse");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetCourseListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@CourseID",ID)
                };
                return DBOperate.GetDataTable("usp_GetCourseById", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void AddCourseDetail(CourseMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@CourseID",obj.CourseID),
                        new SqlParameter("@Name",obj.Name),
                        new SqlParameter("@Description",obj.Description),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_AddCourse", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateCourseDetail(CourseMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@CourseID",obj.CourseID),
                        new SqlParameter("@Name",obj.Name),
                        new SqlParameter("@Description",obj.Description),
                        //new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)                        
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_UpdateCourse", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void DeleteCourseDetail(int id)
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

