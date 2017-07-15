using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class ProductMaster : BaseEntity
    {
        public int ProductID { get; set; } // int, not null

        public int? DiscountID { get; set; } // int, null

        public int SubjectID { get; set; } // int, not null

        public int? TopicID { get; set; } // int, null

        public int? YearwisePaperID { get; set; } // int, null

        public string Name { get; set; } // nvarchar(50), null

        public string Description { get; set; } // nvarchar(max), null

        public decimal Price { get; set; } // money, not null

        public string BaseCurrency { get; set; } // nvarchar(10), null

        public DateTime ValidFrom { get; set; } // datetime, not null

        public DateTime ValidUpto { get; set; } // datetime, not null

        public bool IsVisible { get; set; } // bit, not null
    }
}
