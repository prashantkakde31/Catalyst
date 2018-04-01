using Interpidians.Catalyst.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public interface IPaymentService
    {
        List<TransactionDetail> GetAllTransaction();
        void LogPaymentRequest(TransactionDetail transactionDetail);
        void LogPaymentResponse(TransactionDetail transactionDetail);
        void CreateOrder(OrderDetail orderDetail);
        void UpdateOrder(OrderDetail orderDetail);
    }
}
