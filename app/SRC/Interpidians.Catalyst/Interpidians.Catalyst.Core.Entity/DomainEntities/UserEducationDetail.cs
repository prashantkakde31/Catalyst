using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class UserEducationDetail : BaseEntity
    {
        public int EducationDetailID { get; set; } // int, not null

        public int ProfileID { get; set; } // int, not null

        public int? SchoolCollegeID { get; set; } // int, null

        public string Qualification { get; set; } // nvarchar(50), null

        public string Stream { get; set; } // nvarchar(50), null

        public string SchoolCollegeAddress { get; set; } // nvarchar(1000), null

        public string SchoolCollegeCity { get; set; } // nvarchar(50), null

        public string SchoolCollegeState { get; set; } // nvarchar(50), null

        public string SchoolCollegeCountry { get; set; } // nvarchar(50), null

        public string CouchingName { get; set; } // nvarchar(50), null

        public string CouchingAddress { get; set; } // nvarchar(1000), null

        public string CouchingCity { get; set; } // nvarchar(50), null

        public string CouchingState { get; set; } // nvarchar(50), null

        public string CouchingCountry { get; set; } // nvarchar(50), null
    }
}
