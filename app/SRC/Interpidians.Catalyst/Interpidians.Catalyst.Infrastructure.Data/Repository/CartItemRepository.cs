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

        public void Add(CartItem CartItem)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddCartItem");
            this.DB.AddInParameter(saveCommand, "@ShoppingCartID", DbType.Int64, CartItem.ShoppingCartID);
            this.DB.AddInParameter(saveCommand, "@ProductID", DbType.Int32, CartItem.ProductID);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(CartItem UserMaster)
        {
            throw new NotImplementedException();
        }

        public void Delete(IdentifiableData id)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_DeleteCartItem");
            this.DB.AddInParameter(saveCommand, "@CartItemID", DbType.Int64, id.LId);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
    }
}