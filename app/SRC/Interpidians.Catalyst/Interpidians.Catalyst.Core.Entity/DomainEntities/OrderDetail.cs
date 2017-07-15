using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class OrderDetail : BaseEntity
    {
        public long OrderID { get; set; } // bigint, not null

        public long TransactionID { get; set; } // bigint, not null

        public string PaymentMode { get; set; } // nvarchar(20), null

        public string PaymentStatus { get; set; } // nvarchar(10), null

        public string Detail { get; set; } // nvarchar(max), null
    }
}
