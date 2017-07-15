using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class DiscountMaster : BaseEntity
    {
        public int DiscountID { get; set; } // int, not null

        public string Name { get; set; } // nvarchar(50), not null

        public string Description { get; set; } // nvarchar(max), null

        public decimal? Percentage { get; set; } // numeric(5,2), null

        public DateTime ValidFrom { get; set; } // datetime, not null

        public DateTime ValidUpto { get; set; } // datetime, not null

        public bool IsVisible { get; set; } // bit, not null

    }
}
