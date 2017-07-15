using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class MenuMaster : BaseEntity
    {
        public int MenuID { get; set; } // int, not null

        public int ParentMenuID { get; set; } // int, not null

        public string Name { get; set; } // nvarchar(50), null

        public string Description { get; set; } // nvarchar(300), null

        public string Url { get; set; } // nvarchar(1000), null

        public string MetaContent { get; set; } // nvarchar(max), null

        public int? SortOrder { get; set; } // int, null

        //public int? CreatedBy { get; set; } // int, null

        //public DateTime? CreatedOn { get; set; } // datetime, null

        //public int? UpdatedBy { get; set; } // int, null

        //public DateTime? UpdatedOn { get; set; } // datetime, null
    }
}
