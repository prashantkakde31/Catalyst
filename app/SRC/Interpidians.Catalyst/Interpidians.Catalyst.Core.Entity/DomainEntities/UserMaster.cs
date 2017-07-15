using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class UserMaster : BaseEntity
    {
        public int UserID { get; set; } // int, not null

        public string UserName { get; set; } // nvarchar(50), not null

        public string Password { get; set; } // nvarchar(50), not null

        public string EmailID { get; set; } // nvarchar(50), not null

        public string AccountStatus { get; set; } // nvarchar(20), not null

        public DateTime ValidFrom { get; set; } // datetime, not null

        public DateTime ValidUpto { get; set; } // datetime, not null

        public bool IsLoggedOn { get; set; } // bit, not null

        public string LoggedOnSessionID { get; set; } // nvarchar(50), null

        public int ExamYear { get; set; } // int, not null

        public int ExamMonth { get; set; } // int, not null
    }
}
