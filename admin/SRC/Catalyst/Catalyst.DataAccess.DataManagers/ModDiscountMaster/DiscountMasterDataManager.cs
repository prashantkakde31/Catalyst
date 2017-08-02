using Catalyst.Business.Model.ModDiscountMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.DataAccess.DataManagers.ModDiscountMaster
{
    public class DiscountMasterDataManager
    {
        public DataTable GetDiscountList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllDiscount");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetDiscountListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@DiscountID",ID)
                };
                return DBOperate.GetDataTable("usp_GetDiscountById", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void AddDiscountDetail(DiscountMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@Name",obj.Name),
                        new SqlParameter("@Description",obj.Description),
                        new SqlParameter("@Percentage",obj.Percentage),
                        new SqlParameter("@ValidFrom",obj.ValidFrom),
                        new SqlParameter("@ValidUpto",obj.ValidTo),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_AddDiscount", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateDiscountDetail(DiscountMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@DiscountID",obj.DiscountID),    
                        new SqlParameter("@Name",obj.Name),
                        new SqlParameter("@Description",obj.Description),
                        new SqlParameter("@Percentage",obj.Percentage),
                        new SqlParameter("@ValidFrom",obj.ValidFrom),
                        new SqlParameter("@ValidUpto",obj.ValidTo),
                       // new SqlParameter("@IsVisible",obj.IsVisible.Equals(true)?1:0),
                        new SqlParameter("@CreatedBy",obj.CreatedBy),
                        new SqlParameter("@UpdatedBy",obj.UpdatedBy)                       
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_UpdateDiscount", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void DeleteDiscountDetail(int id)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@DiscountID",id)                                            
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_DeleteDiscount", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
