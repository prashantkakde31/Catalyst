using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class OrderDetail : BaseEntity
    {
        public long OrderID { get; set; } // bigint, not null

        public string TransactionID { get; set; } // bigint, not null

        public int UserID { get; set; } // int, not null

        public string OrderInfo { get; set; } // nvarchar(max), null

        public string PaymentStatus { get; set; } // nvarchar(10), null

        public string CurrencyCode { get; set; } // nvarchar(50), null

        public decimal CurrencyRate { get; set; } // decimal(18,8), null

        public decimal OrderSubTotal { get; set; } // money, null

        public decimal OrderDiscount { get; set; } // money, null

        public decimal OrderTotal { get; set; } // money, null

        public decimal RefundedAmount { get; set; } // money, null

        public string UserIPAddress { get; set; } // nvarchar(50), null
    }
}
