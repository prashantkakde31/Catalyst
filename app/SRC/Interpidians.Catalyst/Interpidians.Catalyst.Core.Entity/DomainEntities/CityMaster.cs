using System;

namespace Interpidians.Catalyst.Core.Entity
{
    public partial class CityMaster
    {
        public int CityID { get; set; } // int, not null

        public int StateID { get; set; } // int, not null

        public string City { get; set; } // nvarchar(50), null
    }
}
