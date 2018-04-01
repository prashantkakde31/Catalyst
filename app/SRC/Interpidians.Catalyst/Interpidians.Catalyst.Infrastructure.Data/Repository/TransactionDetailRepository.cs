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
    public class TransactionDetailRepository : BaseRepository,ITransactionDetailRepository
    {
        public IEnumerable<TransactionDetail> GetAll()
        {
            IEnumerable<TransactionDetail> transactionDetail;
            transactionDetail = this.DB.ExecuteSprocAccessor<TransactionDetail>("usp_GetAllTransactionDetail");
            return transactionDetail;
        }
        public TransactionDetail GetById(IdentifiableData id)
        {
            throw new NotImplementedException();
        }
        public void Add(TransactionDetail Transaction)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_AddTransactionDetail");
            this.DB.AddInParameter(saveCommand, "@TransactionID", DbType.String, Transaction.TransactionID);
            this.DB.AddInParameter(saveCommand, "@UserID", DbType.Int32, Transaction.UserID);
            this.DB.AddInParameter(saveCommand, "@TransactionRequest", DbType.String, Transaction.TransactionRequest);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
        public void Update(TransactionDetail Transaction)
        {
            DbCommand saveCommand = this.DB.GetStoredProcCommand("usp_UpdateTransactionDetail");
            this.DB.AddInParameter(saveCommand, "@TransactionID", DbType.String, Transaction.TransactionID);
            this.DB.AddInParameter(saveCommand, "@UserID", DbType.Int32, Transaction.UserID);
            this.DB.AddInParameter(saveCommand, "@TransactionRequest", DbType.String, Transaction.TransactionRequest);
            this.DB.AddInParameter(saveCommand, "@TransactionResponse", DbType.String, Transaction.TransactionResponse);
            this.DB.AddInParameter(saveCommand, "@TransactionMode", DbType.String, Transaction.TransactionMode);
            this.DB.AddInParameter(saveCommand, "@TransactionStatus", DbType.String, Transaction.TransactionStatus);
            this.DB.AddInParameter(saveCommand, "@PaymentId", DbType.String, Transaction.PaymentId);
            this.DB.AddInParameter(saveCommand, "@PaymentIdEncrypted", DbType.String, Transaction.PaymentIdEncrypted);
            this.DB.AddInParameter(saveCommand, "@NameOnCard", DbType.String, Transaction.NameOnCard);
            this.DB.AddInParameter(saveCommand, "@MaskedCardNumber", DbType.String, Transaction.MaskedCardNumber);
            this.DB.AddInParameter(saveCommand, "@Amount", DbType.Decimal, Transaction.Amount);
            this.DB.AddInParameter(saveCommand, "@PayUMoneyID", DbType.String, Transaction.PayUMoneyID);
            this.DB.AddInParameter(saveCommand, "@BankRefNumber", DbType.String, Transaction.BankRefNumber);
            this.DB.AddInParameter(saveCommand, "@BankCode", DbType.String, Transaction.BankCode);
            this.DB.ExecuteNonQuery(saveCommand);
            if (saveCommand != null) saveCommand.Dispose();
        }
        public void Delete(IdentifiableData id)
        {
            throw new NotImplementedException();
        }
    }
}
