using Catalyst.Business.Model.ModProductMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.DataAccess.DataManagers.ModProductMaster
{
    public class ProductMasterDataManager
    {
        public DataTable GetProductList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllProduct");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetProductsListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@ProductID",ID)
                };
                return DBOperate.GetDataTable("usp_GetProductById", parameter);
            }
            catch
            {
                throw;
            }
        }             
        public void AddProductDetail(ProductMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {                      
                        new SqlParameter("@DiscountID",obj.DiscountID),
                        new SqlParameter("@SubjectID",obj.SubjectID),
                        new SqlParameter("@TopicID",obj.TopicID),
                        new SqlParameter("@YearwisePaperID",obj.YearwisePaperID),
                        new SqlParameter("@Name",obj.Name),
                        new SqlParameter("@Description",obj.Description),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@Price",obj.Price), 
                        new SqlParameter("@BaseCurrency",obj.BaseCurrency), 
                        new SqlParameter("@ValidFrom",obj.ValidFrom), 
                        new SqlParameter("@ValidUpto",obj.ValidUpto), 
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_AddProduct", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateProductDetail(ProductMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@ProductID",obj.ProductID),
                        new SqlParameter("@DiscountID",obj.DiscountID),
                        new SqlParameter("@SubjectID",obj.SubjectID),
                        new SqlParameter("@TopicID",obj.TopicID),
                        new SqlParameter("@YearwisePaperID",obj.YearwisePaperID),
                        new SqlParameter("@Name",obj.Name),
                        new SqlParameter("@Description",obj.Description),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@Price",obj.Price), 
                        new SqlParameter("@BaseCurrency",obj.BaseCurrency), 
                        new SqlParameter("@ValidFrom",obj.ValidFrom), 
                        new SqlParameter("@ValidUpto",obj.ValidUpto), 
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_UpdateProduct", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void DeleteProductDetail(int id)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@ProductID",id)                                            
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_DeleteProduct", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
