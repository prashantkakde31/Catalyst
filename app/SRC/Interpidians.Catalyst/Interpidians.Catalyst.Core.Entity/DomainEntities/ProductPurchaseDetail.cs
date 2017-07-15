using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class ProductPurchaseDetail : BaseEntity
    {
        public int ProductPurchaseID { get; set; } // int, not null

        public int UserID { get; set; } // int, not null

        public int ProductID { get; set; } // int, not null

        public DateTime SubscriptionStartDate { get; set; } // datetime, not null

        public DateTime SubscriptionEndDate { get; set; } // datetime, not null

        public string Status { get; set; } // nvarchar(10), null
    }
}
