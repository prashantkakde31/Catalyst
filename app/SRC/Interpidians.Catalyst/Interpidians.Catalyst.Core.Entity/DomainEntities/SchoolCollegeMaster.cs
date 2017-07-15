using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class SchoolCollegeMaster : BaseEntity
    {
        public int SchoolCollegeID { get; set; } // int, not null

        public string Name { get; set; } // nvarchar(50), not null

        public string Address { get; set; } // nvarchar(300), null

        public string City { get; set; } // nvarchar(50), null

        public string State { get; set; } // nvarchar(50), null

        public string Country { get; set; } // nvarchar(50), null

        public string Type { get; set; } // nvarchar(15), null
    }
}
