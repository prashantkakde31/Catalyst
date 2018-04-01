using Interpidians.Catalyst.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Interpidians.Catalyst.Infrastructure.Data
{
    public class OrderDetailRepository : BaseRepository, IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetAll()
        {
            IEnumerable<OrderDetail> orderDetail;
            orderDetail = this.DB.ExecuteSprocAccessor<OrderDetail>("usp_GetAllOrderDetail");
            return orderDetail;
        }

        public OrderDetail GetById(IdentifiableData id)
        {
            throw new NotImplementedException();
        }

        public void Add(OrderDetail OrderDetail)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddOrderDetail");
            this.DB.AddInParameter(saveCommand, "@TransactionID", DbType.String, OrderDetail.TransactionID);
            this.DB.AddInParameter(saveCommand, "@UserID", DbType.Int32, OrderDetail.UserID);
            this.DB.AddInParameter(saveCommand, "@OrderInfo", DbType.String, OrderDetail.OrderInfo);
            this.DB.AddInParameter(saveCommand, "@PaymentStatus", DbType.String, OrderDetail.PaymentStatus);
            this.DB.AddInParameter(saveCommand, "@CurrencyCode", DbType.String, OrderDetail.CurrencyCode);
            this.DB.AddInParameter(saveCommand, "@CurrencyRate", DbType.Decimal, OrderDetail.CurrencyRate);
            this.DB.AddInParameter(saveCommand, "@OrderSubTotal", DbType.Decimal, OrderDetail.OrderSubTotal);
            this.DB.AddInParameter(saveCommand, "@OrderDiscount", DbType.Decimal, OrderDetail.OrderDiscount);
            this.DB.AddInParameter(saveCommand, "@OrderTotal", DbType.Decimal, OrderDetail.OrderTotal);
            this.DB.AddInParameter(saveCommand, "@RefundedAmount", DbType.Decimal, OrderDetail.RefundedAmount);
            this.DB.AddInParameter(saveCommand, "@UserIPAddress", DbType.String, OrderDetail.UserIPAddress);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Update(OrderDetail OrderDetail)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdateOrderDetail");
            this.DB.AddInParameter(saveCommand, "@TransactionID", DbType.String, OrderDetail.TransactionID);
            this.DB.AddInParameter(saveCommand, "@UserID", DbType.Int32, OrderDetail.UserID);
            this.DB.AddInParameter(saveCommand, "@OrderInfo", DbType.String, OrderDetail.OrderInfo);
            this.DB.AddInParameter(saveCommand, "@PaymentStatus", DbType.String, OrderDetail.PaymentStatus);
            this.DB.AddInParameter(saveCommand, "@CurrencyCode", DbType.String, OrderDetail.CurrencyCode);
            this.DB.AddInParameter(saveCommand, "@CurrencyRate", DbType.Decimal, OrderDetail.CurrencyRate);
            this.DB.AddInParameter(saveCommand, "@OrderSubTotal", DbType.Decimal, OrderDetail.OrderSubTotal);
            this.DB.AddInParameter(saveCommand, "@OrderDiscount", DbType.Decimal, OrderDetail.OrderDiscount);
            this.DB.AddInParameter(saveCommand, "@OrderTotal", DbType.Decimal, OrderDetail.OrderTotal);
            this.DB.AddInParameter(saveCommand, "@RefundedAmount", DbType.Decimal, OrderDetail.RefundedAmount);
            this.DB.AddInParameter(saveCommand, "@UserIPAddress", DbType.String, OrderDetail.UserIPAddress);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }

        public void Delete(IdentifiableData id)
        {
            throw new NotImplementedException();
        }
    }
}
