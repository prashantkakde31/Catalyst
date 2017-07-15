using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class UserEnquiry : BaseEntity
    {
        public int UserEnquiryID { get; set; } // int, not null

        public int UserID { get; set; } // int, not null

        public string Detail { get; set; } // nvarchar(max), null
    }
}
