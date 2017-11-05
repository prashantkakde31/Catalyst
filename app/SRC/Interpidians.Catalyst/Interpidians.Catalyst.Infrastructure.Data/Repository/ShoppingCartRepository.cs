using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;


namespace Interpidians.Catalyst.Infrastructure.Data
{
    public class ShoppingCartRepository : BaseRepository, IShoppingCartRepository
    {
        public IEnumerable<ShoppingCart> GetAll()
        {
            IEnumerable<ShoppingCart> lstShoppingCart;
            lstShoppingCart = this.DB.ExecuteSprocAccessor<ShoppingCart>("usp_GetAllShoppingCart");
            return lstShoppingCart;
        }

        public ShoppingCart GetById(IdentifiableData id)
        {
            throw new NotImplementedException();
        }

        public void Add(ShoppingCart ShoppinCart)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddShoppingCart");
            this.DB.AddInParameter(saveCommand, "@UserID", DbType.Int32, ShoppinCart.UserID);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(ShoppingCart UserMaster)
        {
            throw new NotImplementedException();
        }

        public void Delete(IdentifiableData id)
        {
            throw new NotImplementedException();
        }
    }
}