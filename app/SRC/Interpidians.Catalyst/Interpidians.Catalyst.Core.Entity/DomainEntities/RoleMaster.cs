using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class RoleMaster : BaseEntity
    {
        public int RoleID { get; set; } // int, not null

        public string Role { get; set; } // nvarchar(20), not null
    }
}
