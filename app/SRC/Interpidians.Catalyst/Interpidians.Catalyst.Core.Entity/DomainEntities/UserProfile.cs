using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class UserProfile : BaseEntity
    {
        public int ProfileID { get; set; } // int, not null

        public int UserID { get; set; } // int, not null

        public string FirstName { get; set; } // nvarchar(50), null

        public string LastName { get; set; } // nvarchar(50), null

        public DateTime? DOB { get; set; } // datetime, null

        public string AddrLine1 { get; set; } // nvarchar(100), null

        public string AddrLine2 { get; set; } // nvarchar(100), null

        public string City { get; set; } // varchar(50), null

        public string State { get; set; } // varchar(50), null

        public string Country { get; set; } // varchar(50), null

        public string Pincode { get; set; } // varchar(10), null

        public string MobileNo { get; set; } // varchar(15), null

        public string LandlineNo { get; set; } // varchar(15), null
    }
}
