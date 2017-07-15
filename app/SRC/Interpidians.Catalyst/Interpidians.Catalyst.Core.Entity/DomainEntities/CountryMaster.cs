using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class CountryMaster
    {
        public int CountryID { get; set; } // int, not null

        public string Country { get; set; } // nvarchar(50), not null

        public string Sortname { get; set; } // nvarchar(5), not null

        public int? CountryCode { get; set; } // int, null
    }
}
