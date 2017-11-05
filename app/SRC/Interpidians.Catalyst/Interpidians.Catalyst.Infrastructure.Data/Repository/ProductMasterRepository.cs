using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Interpidians.Catalyst.Infrastructure.Data
{
   public class ProductMasterRepository:BaseRepository,IProductMasterRepository
    {
        public IEnumerable<ProductMaster> GetAll()
        {
            IEnumerable<ProductMaster> lstProduct;
            lstProduct = this.DB.ExecuteSprocAccessor<ProductMaster>("usp_GetAllProduct");
            return lstProduct;
        }

        public ProductMaster GetById(IdentifiableData id)
        {
            ProductMaster productMaster = new ProductMaster();
            using (IDataReader IReader = this.DB.ExecuteReader("usp_GetProductById",id))
            { 
                MapRecord(IReader,productMaster); 
            }
            return productMaster;
        }

        public void Add(ProductMaster ProductMaster)
        {
            
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddProduct");
            this.DB.AddInParameter(saveCommand, "@DiscountID", DbType.Int32, ProductMaster.DiscountID);
            this.DB.AddInParameter(saveCommand, "@SubjectID", DbType.Int32, ProductMaster.SubjectID);
            this.DB.AddInParameter(saveCommand, "@TopicID", DbType.Int32, ProductMaster.TopicID);
            this.DB.AddInParameter(saveCommand, "@YearwisePaperID", DbType.Int32, ProductMaster.YearwisePaperID);
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, ProductMaster.Name);
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String, ProductMaster.Description);
            this.DB.AddInParameter(saveCommand, "@Price", DbType.Currency, ProductMaster.Price);
            this.DB.AddInParameter(saveCommand, "@BaseCurrency", DbType.String, ProductMaster.BaseCurrency);
            this.DB.AddInParameter(saveCommand, "@ValidFrom", DbType.DateTime, ProductMaster.ValidFrom);
            this.DB.AddInParameter(saveCommand, "@ValidUpto", DbType.DateTime, ProductMaster.ValidUpto);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, ProductMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, ProductMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, ProductMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, ProductMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, ProductMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
            
        }

        public void Update(ProductMaster ProductMaster)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdatePaper");
            this.DB.AddInParameter(saveCommand, "@ProductID", DbType.Int32, ProductMaster.ProductID);
            this.DB.AddInParameter(saveCommand, "@DiscountID", DbType.Int32, ProductMaster.DiscountID);
            this.DB.AddInParameter(saveCommand, "@SubjectID", DbType.Int32, ProductMaster.SubjectID);
            this.DB.AddInParameter(saveCommand, "@TopicID", DbType.Int32, ProductMaster.TopicID);
            this.DB.AddInParameter(saveCommand, "@YearwisePaperID", DbType.Int32, ProductMaster.YearwisePaperID);
            this.DB.AddInParameter(saveCommand, "@Name", DbType.String, ProductMaster.Name);
            this.DB.AddInParameter(saveCommand, "@Description", DbType.String, ProductMaster.Description);
            this.DB.AddInParameter(saveCommand, "@Price", DbType.Currency, ProductMaster.Price);
            this.DB.AddInParameter(saveCommand, "@BaseCurrency", DbType.String, ProductMaster.BaseCurrency);
            this.DB.AddInParameter(saveCommand, "@ValidFrom", DbType.DateTime, ProductMaster.ValidFrom);
            this.DB.AddInParameter(saveCommand, "@ValidUpto", DbType.DateTime, ProductMaster.ValidUpto);
            this.DB.AddInParameter(saveCommand, "@IsVisible", DbType.Boolean, ProductMaster.IsVisible);
            this.DB.AddInParameter(saveCommand, "@CreatedBy", DbType.Int32, ProductMaster.CreatedBy);
            this.DB.AddInParameter(saveCommand, "@CreatedOn", DbType.DateTime, ProductMaster.CreatedOn);
            this.DB.AddInParameter(saveCommand, "@UpdatedBy", DbType.Int32, ProductMaster.UpdatedBy);
            this.DB.AddInParameter(saveCommand, "@UpdatedOn", DbType.DateTime, ProductMaster.UpdatedOn);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Delete(IdentifiableData id)
        {
            throw new NotImplementedException();
        }
    }
}
