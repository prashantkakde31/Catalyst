using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class UserCart
    {
        public Guid CartID { get; set; } // uniqueidentifier, not null

        public int UserID { get; set; } // int, not null
    }
}
