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
    public class CartItemRepository : BaseRepository, ICartItemRepository
    {
        public IEnumerable<CartItem> GetAll()
        {
            IEnumerable<CartItem> lstCartItem;
            lstCartItem = this.DB.ExecuteSprocAccessor<CartItem>("usp_GetAllCartItem");
            return lstCartItem;
        }

        public CartItem GetById(IdentifiableData id)
        {
            throw new NotImplementedException();
        }

        public void Add(long shoppingCartId, int productId)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddCartItem");
            this.DB.AddInParameter(saveCommand, "@ShoppingCartID", DbType.Int64, shoppingCartId);
            this.DB.AddInParameter(saveCommand, "@ProductID", DbType.Int32, productId);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(CartItem UserMaster)
        {
            throw new NotImplementedException();
        }

        public void Delete(long shoppingCartId, int productId)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeleteCartItem");
            this.DB.AddInParameter(saveCommand, "@ShoppingCartID", DbType.Int64, shoppingCartId);
            this.DB.AddInParameter(saveCommand, "@ProductID", DbType.Int32, productId);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void DeleteAll(long shoppingCartId)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeleteAllCartItem");
            this.DB.AddInParameter(saveCommand, "@ShoppingCartID", DbType.Int64, shoppingCartId);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
    }
}