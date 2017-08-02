using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Catalyst.Business.Model.ModSubCourseMaster;
using System.Data.SqlClient;

namespace Catalyst.DataAccess.DataManagers.ModSubCourseMaster
{
    public class SubCourseMasterDataManager
    {
        public DataTable GetSubCourseList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllSubCourse");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetSubCourseListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@SubCourseID",ID)
                };
                return DBOperate.GetDataTable("usp_GetSubCourseById", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetSubCourseListWithCourseID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@CourseID",ID)
                };
                return DBOperate.GetDataTable("usp_GetSubCourseByCourseId", parameter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetCourseListWithSubCourseID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@SubCourseID",ID)
                };
                return DBOperate.GetDataTable("usp_GetCourseBySubCourseId", parameter);
            }
            catch
            {
                throw;
            }
        }

        public void AddSubCourseDetail(SubCourseMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                       // new SqlParameter("@SubCourseID",obj.SubCourseID),
                        new SqlParameter("@Name",obj.Name),
                        new SqlParameter("@CourseID",obj.CourseID),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_AddSubCourse", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateSubCourseDetail(SubCourseMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@SubCourseID",obj.SubCourseID),
                        new SqlParameter("@Name",obj.Name),
                        new SqlParameter("@CourseID",obj.CourseID),
                        //new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)                        
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_UpdateSubCourse", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void DeleteSubCourseDetail(int id)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@SubCourseID",id)                                            
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_DeleteSubCourse", parameter);
            }
            catch
            {
                throw;
            }
        }
    }

}

