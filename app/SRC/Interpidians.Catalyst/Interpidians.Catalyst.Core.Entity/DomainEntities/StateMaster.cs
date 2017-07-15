using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class StateMaster
    {
        public int StateID { get; set; } // int, not null

        public int CountryID { get; set; } // int, not null

        public string State { get; set; } // nvarchar(50), null
    }
}
