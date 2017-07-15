using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class UserRole
    {
        public int UserID { get; set; } // int, not null

        public int RoleID { get; set; } // int, not null
    }
}
