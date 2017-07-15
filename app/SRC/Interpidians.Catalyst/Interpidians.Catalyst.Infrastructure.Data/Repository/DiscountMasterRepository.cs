using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.DomainService;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Interpidians.Catalyst.Core.Entity;
using System.Data;
using System.Data.Common;

namespace Interpidians.Catalyst.Infrastructure.Data
{
   public class DiscountMasterRepository:BaseRepository,IDiscountMasterRepository
    {
        public IEnumerable<DiscountMaster> GetAll()
        {
            IEnumerable<DiscountMaster> lstDiscount;
            lstDiscount = this.DB.ExecuteSprocAccessor<DiscountMaster>("usp_GetAllDiscount");
            return lstDiscount;
        }

        public DiscountMaster GetById(IdentifiableData id)
        {
            //usp_GetDiscountById is the name of stored procedure but dont know how to implement
            DiscountMaster discountMaster = new DiscountMaster();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetDiscountById", id))
            {
                MapRecord(IReader, discountMaster);
            }
            return discountMaster;
        }

        public void Add(DiscountMaster discountMaster)
        {
            //usp_AddDiscount is the name of stored procedure but dont know how to implement
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddDiscount");
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String,discountMaster.Name );
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String,discountMaster.Description);
            this.DB.AddInParameter(saveCommand, "@Percentage", DbType.VarNumeric,discountMaster.Percentage );
            this.DB.AddInParameter(saveCommand, "@ValidFrom", DbType.DateTime,discountMaster.ValidFrom );
            this.DB.AddInParameter(saveCommand, "@ValidUpto", DbType.DateTime,discountMaster.ValidUpto );
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, discountMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32,discountMaster.CreatedBy );
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime,discountMaster.CreatedOn );
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32,discountMaster.UpdatedBy );
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime,discountMaster.UpdatedOn );
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(DiscountMaster discountMaster)
        {
            //usp_UpdateCourse is the name of stored procedure but dont know how to implement
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdateCourse");
            this.DB.AddInParameter(saveCommand, "@DiscountID", DbType.Int32, discountMaster.DiscountID);
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, discountMaster.Name);
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String, discountMaster.Description);
            this.DB.AddInParameter(saveCommand, "@Percentage", DbType.VarNumeric, discountMaster.Percentage);
            this.DB.AddInParameter(saveCommand, "@ValidFrom", DbType.DateTime, discountMaster.ValidFrom);
            this.DB.AddInParameter(saveCommand, "@ValidUpto", DbType.DateTime, discountMaster.ValidUpto);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, discountMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, discountMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, discountMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, discountMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, discountMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Delete(IdentifiableData id)
        {
            //usp_DeleteDiscount is the name of stored procedure but dont know how to implement
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeleteDiscount");
            this.DB.AddInParameter(saveCommand, "@DiscountID", DbType.Int32,id );
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
    }
}
