using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class TransactionDetail : BaseEntity
    {
        public long TransactionDetailID { get; set; } // bigint, not null
        public string TransactionID { get; set; } // bigint, not null
        public int UserID { get; set; } // int, not null
        public string TransactionInfo { get; set; } // nvarchar(max), null
        public string TransactionRequest { get; set; } // xml, null
        public string TransactionResponse { get; set; } // xml, null
        public string TransactionMode { get; set; } // nvarchar(50), null
        public string TransactionStatus { get; set; } // nvarchar(20), null
        public string PaymentId { get; set; } // nvarchar(50), null
        public string PaymentIdEncrypted { get; set; } // nvarchar(50), null
        public string NameOnCard { get; set; } // nvarchar(50), null
        public string MaskedCardNumber { get; set; } // nvarchar(50), null
        public decimal Amount { get; set; } // money, null
        public string PayUMoneyID { get; set; } // nvarchar(50), null
        public string BankRefNumber { get; set; } // nvarchar(50), null
        public string BankCode { get; set; } // nvarchar(50), null
    }
}
