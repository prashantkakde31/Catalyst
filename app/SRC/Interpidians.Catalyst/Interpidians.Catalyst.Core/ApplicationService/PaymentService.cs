using Interpidians.Catalyst.Core.DomainService;
using Interpidians.Catalyst.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public class PaymentService : IPaymentService
    {
        private ITransactionDetailRepository TransactionDetailRepository { get; set; }
        private IOrderDetailRepository OrderDetailRepository { get; set; }
        public PaymentService(ITransactionDetailRepository transactionDetailRepository, IOrderDetailRepository orderDetailRepository)
        {
            this.TransactionDetailRepository = transactionDetailRepository;
            this.OrderDetailRepository = orderDetailRepository;
        }

        public List<TransactionDetail> GetAllTransaction()
        {
            return TransactionDetailRepository.GetAll().ToList();
        }

        public void LogPaymentRequest(TransactionDetail transactionDetail)
        {
            TransactionDetailRepository.Add(transactionDetail);
        }

        public void LogPaymentResponse(TransactionDetail transactionDetail)
        {
            TransactionDetailRepository.Update(transactionDetail);
        }

        public void CreateOrder(OrderDetail orderDetail)
        {
            OrderDetailRepository.Add(orderDetail);
        }

        public void UpdateOrder(OrderDetail orderDetail)
        {
            OrderDetailRepository.Update(orderDetail);
        }
    }
}
