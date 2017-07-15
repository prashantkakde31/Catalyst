using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class TransactionDetail : BaseEntity
    {
        public long TransactionID { get; set; } // bigint, not null

        public int UserID { get; set; } // int, not null

        public int ProductID { get; set; } // int, not null

        public string Description { get; set; } // nvarchar(max), null

        public string Status { get; set; } // nvarchar(20), null
    }
}
