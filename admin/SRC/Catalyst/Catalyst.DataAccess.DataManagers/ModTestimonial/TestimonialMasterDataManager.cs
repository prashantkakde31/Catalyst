using Catalyst.Business.Model.ModTestimonial;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.DataAccess.DataManagers.ModTestimonial
{
    public class TestimonialMasterDataManager
    {
        public DataTable GetTestimonialList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllTestimonial");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetTestimonialListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@TestimonialID",ID)
                };
                return DBOperate.GetDataTable("usp_GetTestimonialById", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void AddTestimonialDetail(TestimonialMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {                      
                        new SqlParameter("@AuthorName",obj.AuthorName),
                        new SqlParameter("@Photo",obj.Photo),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@Contents",obj.Contents), 
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_AddTestimonial", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateTestimonialDetail(TestimonialMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@TestimonialID",obj.TestimonialID),
                        new SqlParameter("@AuthorName",obj.AuthorName),
                        new SqlParameter("@Photo",obj.Photo),
                        new SqlParameter("@Contents",obj.Contents),
                        //new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)                        
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_UpdateTestimonial", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void DeleteTestimonialDetail(int id)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@TestimonialID",id)                                            
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_DeleteTestimonial", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
